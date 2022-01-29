using SnakeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SnakeServer
{
    public class Server
    {
        public bool IsActive { get; set; }
        public int LocalPort { get; private set; }
        public IPAddress Address { get; private set; }

        public event Action<String> OnLogReceived;
        public event Action<String> OnGameLogReceived;

        private String endPoint => listener.Server.LocalEndPoint.ToString();

        private TcpListener listener;

        private Dictionary<Room, Dictionary<String, TcpClient>> waitingRooms;
        private Dictionary<Room, Dictionary<String, TcpClient>> playingRooms;
        private Dictionary<Room, GameOnline> games;
        private List<String> onlinePlayers;

        private Dictionary<String, DateTime> lastHandledPacketDate;

        private BinaryFormatter binary;

        public Server(String ip, int port)
        {
            LocalPort = port;
            Address = IPAddress.Parse(ip);
            listener = null;
            IsActive = false;
            binary = new BinaryFormatter();
        }

        public void Start()
        {
            if (listener != null)
                return;

            try
            {
                listener = new TcpListener(IPAddress.Any, LocalPort);
                listener.Start(10);

                waitingRooms = new Dictionary<Room, Dictionary<String, TcpClient>>();
                playingRooms = new Dictionary<Room, Dictionary<String, TcpClient>>();
                games = new Dictionary<Room, GameOnline>();
                onlinePlayers = new List<String>();
                lastHandledPacketDate = new Dictionary<string, DateTime>();

                IsActive = true;
                OnLogReceived($"Setup server on {LocalPort} port");
                OnLogReceived?.Invoke("Server started");

                while (IsActive)
                    AcceptClient();
            }
            catch (Exception ex)
            {
                listener = null;
                OnLogReceived?.Invoke(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
                OnLogReceived?.Invoke("Server stopped");
            }
        }

        private void AcceptClient()
        {
            TcpClient client = listener.AcceptTcpClient();
            OnLogReceived?.Invoke($"Incoming connection from {client.Client.RemoteEndPoint}");

            new Thread(UpdatePackets).Start(client);
        }

        private void UpdatePackets(object _client)
        {
            TcpClient client = _client as TcpClient;
            ClientPacket clientPacket;
            ServerPacket serverPacket;

            try
            {
                do
                {
                    clientPacket = binary.Deserialize(client.GetStream()) as ClientPacket;

                    if (clientPacket.Type != ClientPacketType.ChangeSnakeDirection && clientPacket.Type != ClientPacketType.StartGame)
                        OnLogReceived?.Invoke($"Incoming packet from {clientPacket.Sender} - {client.Client.RemoteEndPoint}: {clientPacket.Type} -> {clientPacket.Message}");
                    else
                        OnGameLogReceived?.Invoke($"Incoming packet from {clientPacket.Sender} - {client.Client.RemoteEndPoint}: {clientPacket.Type} -> {clientPacket.Message}");

                    if (clientPacket.Type == ClientPacketType.Disconnect)
                    {
                        lastHandledPacketDate.Remove(clientPacket.Sender);
                        onlinePlayers.Remove(clientPacket.Sender);
                        OnLogReceived?.Invoke($"Packet to {clientPacket.Sender} - {client.Client.RemoteEndPoint}: {clientPacket.Type} -> User disconnected");
                        break;
                    }

                    serverPacket = Process(clientPacket, ref client);
                    
                    if (serverPacket.Type != ServerPacketType.GameStarted && serverPacket.Type != ServerPacketType.SnakeDirectionChanged)
                    {
                        OnLogReceived?.Invoke($"Packet to {clientPacket.Sender} - {client.Client.RemoteEndPoint}: {serverPacket.Type} -> {serverPacket.Message}");
                        binary.Serialize(client.GetStream(), serverPacket);
                    }
                    else
                    {
                        OnGameLogReceived?.Invoke($"Packet to {clientPacket.Sender} - {client.Client.RemoteEndPoint}: {serverPacket.Type} -> {serverPacket.Message}");
                    }
                } while (IsActive);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                client.GetStream().Close();
                client.Close();
            }
        }

        private ServerPacket Process(ClientPacket packet, ref TcpClient client)
        {
            if (packet.Type == ClientPacketType.GetRooms)
            {
                int count = waitingRooms.Keys.Count;
                List<Room> roomsList = new List<Room>();
                foreach (var room in waitingRooms.Keys)
                    roomsList.Add(room);

                return new ServerPacket(ServerPacketType.Success, endPoint, $"{count} rooms loaded to client", roomsList);
            }
            else if (packet.Type == ClientPacketType.IsNicknameExisting)
            {
                foreach (var player in onlinePlayers)
                    if (player == packet.Sender)
                        return new ServerPacket(ServerPacketType.Fail, endPoint, $"This nickname is existing");

                onlinePlayers.Add(packet.Sender);
                lastHandledPacketDate.Add(packet.Sender, DateTime.MinValue);
                return new ServerPacket(ServerPacketType.Success, endPoint, $"This nickname is free");
            }
            else if (packet.Type == ClientPacketType.JoinRoom)
            {
                var roomId = Guid.Parse(packet.Message);
                var room = waitingRooms.Keys.FirstOrDefault(r => r.Id == roomId);

                if (room == null)
                    return new ServerPacket(ServerPacketType.Error, endPoint, $"Room is deleted");

                if (!room.AddPlayer(packet.Sender))
                    return new ServerPacket(ServerPacketType.Error, endPoint, $"Room is full");

                waitingRooms[room].Add(packet.Sender, client);

                SendUpdatedRoomToClients(room, ref client);

                return new ServerPacket(ServerPacketType.Success, endPoint, $"<{room.Name}> room loaded to client", room);
            }
            else if (packet.Type == ClientPacketType.LeaveRoom)
            {
                var roomId = Guid.Parse(packet.Message);
                var room = waitingRooms.Keys.FirstOrDefault(r => r.Id == roomId);

                waitingRooms[room].Remove(packet.Sender);
                room.DeletePlayer(packet.Sender);

                SendUpdatedRoomToClients(room, ref client);

                return new ServerPacket(ServerPacketType.Success, endPoint, $"Player left <{room.Name}> room", room);
            }
            else if (packet.Type == ClientPacketType.CreateRoom)
            {
                try
                {
                    var room = packet.Parameter as Room;
                    waitingRooms.Add(room, new Dictionary<String, TcpClient>());

                    return new ServerPacket(ServerPacketType.Success, endPoint, $"Room created");
                }
                catch { return new ServerPacket(ServerPacketType.Error, endPoint, $"Failed to create room"); }
            }
            else if (packet.Type == ClientPacketType.DeleteRoom)
            {
                try
                {
                    var roomId = Guid.Parse(packet.Message);
                    var room = waitingRooms.Keys.FirstOrDefault(r => r.Id == roomId);

                    DisconnectClientsFromRoom(room, ref client);
                    
                    waitingRooms.Remove(room);

                    return new ServerPacket(ServerPacketType.RoomDeleted, endPoint, $"Room deleted");
                }
                catch { return new ServerPacket(ServerPacketType.Error, endPoint, $"Failed to delete room"); }
            }
            else if (packet.Type == ClientPacketType.StartGame)
            {
                try
                {
                    var roomId = Guid.Parse(packet.Message);
                    var room = waitingRooms.Keys.FirstOrDefault(r => r.Id == roomId);

                    games.Add(room, new GameOnline(waitingRooms[room].Keys));

                    SendGameStartToClients(room);

                    playingRooms.Add(room, waitingRooms[room]);
                    waitingRooms.Remove(room);

                    var gameThread = new Thread(PlayGame);
                    gameThread.IsBackground = true;
                    gameThread.Start(room);

                    return new ServerPacket(ServerPacketType.GameStarted, endPoint, $"Game started, load your game client");
                }
                catch { return new ServerPacket(ServerPacketType.Error, endPoint, $"Failed to start game"); }
            }
            else if (packet.Type == ClientPacketType.ChangeSnakeDirection)
            {
                try
                {
                    var roomId = Guid.Parse(packet.Message);
                    var room = playingRooms.Keys.FirstOrDefault(r => r.Id == roomId);

                    games[room].QueueDirectionChange(packet.Sender, (Direction)packet.Parameter);

                    lastHandledPacketDate[packet.Sender] = DateTime.Now;

                    return new ServerPacket(ServerPacketType.SnakeDirectionChanged, endPoint, $"Direction changed");
                }
                catch { return new ServerPacket(ServerPacketType.Error, endPoint, $"Failed to change direction"); }
            }
            else if (packet.Type == ClientPacketType.KickPlayer)
            {
                var roomId = Guid.Parse(packet.Parameter.ToString());
                var room = waitingRooms.Keys.FirstOrDefault(r => r.Id == roomId);

                if (packet.Sender == room.CreatorName)
                {
                    DisconnectClientFromRoom(packet.Message, room);

                    room.DeletePlayer(packet.Message);
                    waitingRooms[room].Remove(packet.Message);

                    SendUpdatedRoomToClients(room, ref client);

                    return new ServerPacket(ServerPacketType.Success, endPoint, $"Player kicked from <{room.Name}> room", room);
                }
                else return new ServerPacket(ServerPacketType.Fail, endPoint, $"Access denied - not a room creator", room);
            }
            else return new ServerPacket(ServerPacketType.Error, endPoint, $"Failed to process packet");
        }

        private void SendUpdatedRoomToClients(Room room, ref TcpClient client)
        {
            foreach (var player in waitingRooms[room])
                if (player.Value != client)
                    binary.Serialize(player.Value.GetStream(), new ServerPacket(ServerPacketType.RoomUpdated, endPoint, $"<{room.Name}> room has been updated", room));
        }

        private void DisconnectClientsFromRoom(Room room, ref TcpClient client)
        {
            foreach (var player in waitingRooms[room])
                if (player.Value != client)
                    binary.Serialize(player.Value.GetStream(), new ServerPacket(ServerPacketType.RoomDeleted, endPoint, $"<{room.Name}> room has been deleted"));
        }

        private void DisconnectClientFromRoom(String name, Room room)
        {
             binary.Serialize(waitingRooms[room][name].GetStream(), new ServerPacket(ServerPacketType.ClientKicked, endPoint, $"<{room.Name}> room has been deleted"));
        }

        private void SendGameStartToClients(Room room)
        {
            foreach (var player in waitingRooms[room])
            {
                var packet = new ServerPacket(ServerPacketType.GameStarted, endPoint, $"Game in <{room.Name}> room has been started");
                binary.Serialize(player.Value.GetStream(), packet);
                OnGameLogReceived?.Invoke($"Packet to {packet.Sender} - {waitingRooms[room][player.Key].Client.RemoteEndPoint}: {packet.Type} -> {packet.Message}");
            }
        }

        private void SendGameEndToClients(Room room, String winner)
        {
            foreach (var player in playingRooms[room])
                try
                {
                    ServerPacket packet;
                    if (player.Key == winner)
                        packet = new ServerPacket(ServerPacketType.GameWon, endPoint, $"<{winner}> win in game in <{room.Name}>");
                    else
                        packet = new ServerPacket(ServerPacketType.GameDefeat, endPoint, $"<{player.Key}> lose in game in <{room.Name}>");
                    
                    binary.Serialize(player.Value.GetStream(), packet);
                    OnGameLogReceived?.Invoke($"Packet to {packet.Sender} - {playingRooms[room][player.Key].Client.RemoteEndPoint}: {packet.Type} -> {packet.Message}");
                }
                catch { }
        }

        private void PlayGame(object _room)
        {
            Room room = _room as Room;
            bool gameState = true;

            Thread.Sleep(300);
            List<String> leavedPlayers = new List<String>();

            String winner = String.Empty;
            games[room].OnGameEnded += (String message) => { gameState = false; winner = message; };

            DateTime lastTick = DateTime.Now.AddMilliseconds(350);
            while (gameState)
            {
                if (DateTime.Now >= lastTick.AddMilliseconds(200))
                {
                    games[room].ChangeSnakesDirection();
                    games[room].MoveSnakes();

                    foreach (var player in playingRooms[room])
                        try { binary.Serialize(player.Value.GetStream(), new ServerPacket(ServerPacketType.GameUpdated, endPoint, $"Update game state", games[room].GetInfo(player.Key, lastHandledPacketDate[player.Key]))); lastHandledPacketDate[player.Key] = DateTime.MinValue; }
                        catch { }

                    lastTick = DateTime.Now;
                }
            }

            if (!String.IsNullOrEmpty(winner))
                SendGameEndToClients(room, winner);
            
            playingRooms.Remove(room);
        }
    }
}
