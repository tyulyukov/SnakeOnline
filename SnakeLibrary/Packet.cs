using System;

namespace SnakeLibrary
{
    [Serializable]
    abstract public class Packet
    {
        public String Sender { get; private set; }
        public String Message { get; private set; }
        public object Parameter { get; private set; }

        public Packet(String sender, String message)
        {
            Sender = sender;
            Message = message;
        }

        public Packet(String sender, String message, object parameter)
        {
            Sender = sender;
            Message = message;
            Parameter = parameter;
        }
    }

    [Serializable]
    public class ServerPacket : Packet
    {
        public ServerPacketType Type { get; private set; }

        public ServerPacket(ServerPacketType type, String sender, String message) : base(sender, message)
        {
            Type = type;
        }

        public ServerPacket(ServerPacketType type, String sender, String message, object parameter) : base(sender, message, parameter)
        {
            Type = type;
        }
    }

    [Serializable]
    public class ClientPacket : Packet
    {
        public ClientPacketType Type { get; private set; }

        public ClientPacket(ClientPacketType type, String sender, String message) : base(sender, message)
        {
            Type = type;
        }

        public ClientPacket(ClientPacketType type, String sender, String message, object parameter) : base(sender, message, parameter)
        {
            Type = type;
        }
    }

    public enum ClientPacketType
    {
        GetRooms,
        CreateRoom,
        JoinRoom,
        DeleteRoom,
        Disconnect,
        LeaveRoom,
        StartGame,
        ChangeSnakeDirection,
        IsNicknameExisting,
        KickPlayer,
    }

    public enum ServerPacketType
    {
        Error,
        Success,
        RoomUpdated,
        RoomDeleted,
        GameStarted,
        GameUpdated,
        SnakeDirectionChanged,
        GameEnded,
        Fail,
        GameDefeat,
        GameWon,
        ClientKicked
    }
}
