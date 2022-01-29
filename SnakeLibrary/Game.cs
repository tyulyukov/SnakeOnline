using System;
using System.Drawing;

namespace SnakeLibrary
{
    public class Game
    {
        public readonly int Width;
        public readonly int Height;
        public readonly int PartsSize = 30;

        public event Action OnFoodEaten;
        public event Action OnGameLost;

        public int Score => snake.Score;

        private Snake snake;
        private Part food;

        private Random random = new Random();

        public Game(int width, int height)
        {
            Width = width;
            Height = height;

            var snakeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            snake = new Snake(snakeColor, GetRandomSpawn(), PartsSize);

            random = new Random();
            food = new Part(Color.Red, Point.Empty, PartsSize);

            Restart();
        }

        public void MoveSnake()
        {
            if (snake.CanEat(food))
            {
                snake.Eat(food);
                GenerateFood();
                OnFoodEaten?.Invoke();
            }
            else
            {
                snake.Move();
            }

            if (Losing())
            {
                OnGameLost?.Invoke();
                return;
            }
        }

        public Point GetRandomSpawn()
        {
            int offset = PartsSize * 5;
            Point position;

            while (true)
            {
                position = new Point(random.Next(offset, Width - offset), random.Next(offset, Height - offset));

                if (position.X % PartsSize == 0 && position.Y % PartsSize == 0)
                    return position;
            }
        }

        public bool Losing() => IsSnakeOutsideTheMap() || snake.EatsItself();

        private bool IsSnakeOutsideTheMap() => snake.Head.Location.X + PartsSize > Width || snake.Head.Location.X < 0 || snake.Head.Location.Y + PartsSize > Height || snake.Head.Location.Y < 0;

        public void Restart()
        {
            snake.Reset(GetRandomSpawn());
            GenerateFood();
        }

        public void Draw(Graphics g)
        {
            snake.Draw(g);
            food.Draw(g);
        }

        public void ChangeSnakeDirection(Direction direction)
        {
            if (snake.Direction == direction || snake.Direction == InvertDirection(direction))
                return;

            snake.Direction = direction;
        }

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

            while (true)
            {
                position = new Point(random.Next(0, Width), random.Next(0, Height));

                if (position.X % PartsSize == 0 && position.Y % PartsSize == 0)
                {
                    if (!snake.Contains(position))
                    {
                        food.SetLocation(position);
                        break;
                    }
                }
            }
        }
    }
}
