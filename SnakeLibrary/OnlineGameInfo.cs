using System;
using System.Collections.Generic;
using System.Drawing;

namespace SnakeLibrary
{
    [Serializable]
    public class OnlineGameInfo
    {
        public readonly int Score;
        public readonly DateTime HandleDate;
        public readonly Point YourSnakeHeadLocation;

        private ICollection<Snake> snakes;
        private Part food;

        public OnlineGameInfo(ICollection<Snake> _snakes, Part _food, int score, DateTime _handleDate, Point headLocation)
        {
            snakes = _snakes;
            food = _food;
            Score = score;
            HandleDate = _handleDate;
            YourSnakeHeadLocation = headLocation;
        }

        public void Draw(Graphics g)
        {
            foreach (var snake in snakes)
                snake.Draw(g);
            food.Draw(g);
        }
    }
}
