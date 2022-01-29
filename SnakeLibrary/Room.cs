using System;
using System.Collections.Generic;

namespace SnakeLibrary
{
    [Serializable]
    public class Room
    {
        public Guid Id { get; private set; }
        public String Name { get; private set; }
        public String CreatorName { get; private set; }

        public IReadOnlyList<String> Players => players;
        private List<String> players;

        public int MaxPlayers { get; private set; }

        public Room(String name, String creator, int maxPlayers)
        {
            Id = Guid.NewGuid();
            players = new List<String>();
            Name = name;
            CreatorName = creator;
            MaxPlayers = maxPlayers;
        }

        public bool AddPlayer(String nickname)
        {
            if (players.Count >= MaxPlayers)
                return false;

            players.Add(nickname);
            return true;
        }

        public bool DeletePlayer(String nickname)
        {
            if (players.Count == 0)
                return false;

            return players.Remove(nickname);
        }
    }
}
