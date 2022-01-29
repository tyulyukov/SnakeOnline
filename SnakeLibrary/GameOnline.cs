using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;

namespace SnakeLibrary
{
    public class GameOnline
    {
        public readonly int Width = 630;
        public readonly int Height = 630;
        public readonly int PartsSize = 30;

        public event Action OnFoodEaten;
        public event Action<String> OnGameEnded;

        private Dictionary<String, Snake> snakes;
        private Part food;

        private Dictionary<String, Queue<Direction>> directionChanges;

        private Random random = new Random();

        public GameOnline(ICollection<String> players)
        {
            snakes = new Dictionary<string, Snake>();
            directionChanges = new Dictionary<string, Queue<Direction>>();

            foreach (var player in players)
            {
                snakes.Add(player, new Snake(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), GetRandomSpawn(), PartsSize));
                directionChanges.Add(player, new Queue<Direction>());
            }

            food = new Part(Color.Red, Point.Empty, PartsSize);

            GenerateFood();
        }

        public void QueueDirectionChange(String name, Direction direction) => directionChanges[name].Enqueue(direction);

        public void RemoveSnake(String name)
        {
            if (snakes.Count == 0)
            {
                return;
            }
            else
            {
                snakes[name].Remove();
                snakes.Remove(name);

                if (snakes.Count == 1)
                    OnGameEnded?.Invoke(GetWinnerName());
            }
        }

        private String GetWinnerName()
        {
            if (snakes.Count == 1)
                return snakes.FirstOrDefault().Key;
            else
                return String.Empty;
        }

        public void MoveSnakes()
        {
            List<String> snakesToDelete = new List<String>();
            foreach (var snake in snakes)
            {
                if (snake.Value.CanEat(food))
                {
                    snake.Value.Eat(food);
                    GenerateFood();
                    OnFoodEaten?.Invoke();
                }
                else
                {
                    snake.Value.Move();
                }

                if (Losing(snake.Key))
                {
                    snakesToDelete.Add(snake.Key);
                }
            }

            foreach (var snake in snakesToDelete)
                RemoveSnake(snake);
        }

        public Point GetRandomSpawn()
        {
            int offset = PartsSize * 5;
            Point position;

            while (true)
            {
                bool contains;
                
                position = new Point(random.Next(offset, Width - offset), random.Next(offset, Height - offset));

                if (position.X % PartsSize == 0 && position.Y % PartsSize == 0)
                {
                    contains = false;

                    foreach (var snake in snakes.Values)
                        if (snake.Contains(position))
                            contains = true;

                    if (!contains)
                        return position;
                }
            }
        }

        public bool Losing(String name) => IsSnakeOutsideTheMap(name) || snakes[name].EatsItself() || CollissionAnotherSnake(name);

        private bool IsSnakeOutsideTheMap(String name) => snakes[name].Head.Location.X + PartsSize > Width || snakes[name].Head.Location.X < 0 || snakes[name].Head.Location.Y + PartsSize > Height || snakes[name].Head.Location.Y < 0;

        private bool CollissionAnotherSnake(String name) 
        {
            Snake currentSnake = snakes[name];

            foreach (var snake in snakes.Values)
                if (snake != currentSnake)
                    if (snake.Contains(currentSnake.Head.Location))
                        return true;

            return false;
        }

        public void Draw(Graphics g)
        {
            foreach (var snake in snakes.Values)
                snake.Draw(g);
            food.Draw(g);
        }

        public void ChangeSnakesDirection()
        {
            foreach (var snake in snakes)
            {
                if (directionChanges[snake.Key].Count != 0)
                {
                    Direction direction = directionChanges[snake.Key].Dequeue();

                    if (snakes[snake.Key].Direction == direction || snakes[snake.Key].Direction == InvertDirection(direction))
                        return;

                    snakes[snake.Key].Direction = direction;
                }
            }
        }

        public OnlineGameInfo GetInfo(String name, DateTime lastHandled) => new OnlineGameInfo(snakes.Values, food, snakes[name].Score, lastHandled, snakes[name].Head.Location);

        private Direction InvertDirection(Direction direction)
        {
            if (direction == Direction.Down) return Direction.Up;
            else if (direction == Direction.Up) return Direction.Down;
            else if (direction == Direction.Left) return Direction.Right;
            else return Direction.Left;
        }

        private void GenerateFood()
        {
            Point position;

            bool generated = false;

            while (!generated)
            {
                position = new Point(random.Next(0, Width), random.Next(0, Height));

                if (position.X % PartsSize == 0 && position.Y % PartsSize == 0)
                {
                    foreach (var snake in snakes.Values)
                    {
                        if (!snake.Contains(position))
                        {
                            food.SetLocation(position);
                            generated = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}
