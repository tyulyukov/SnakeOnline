using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SnakeLibrary
{
    [Serializable]
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    };

    [Serializable]
    public class Snake
    {
        public readonly int PartsSize;
        
        public int Score => parts.Count - 2;
        public Part Head => parts.Last();

        public Color Color { get; private set; }
        public Direction Direction { get; set; }

        private Queue<Part> parts;
        private Part Neck;

        public Snake(Color color, Point spawnLocation, int partsSize)
        {
            PartsSize = partsSize;
            Color = color;

            Reset(spawnLocation);
        }

        public void Move()
        {
            parts.Dequeue();

            Neck = Head;

            if (Direction == Direction.Down)
                parts.Enqueue(new Part(Color, new Point(Head.Location.X, Head.Location.Y + PartsSize), PartsSize));
            else if (Direction == Direction.Up)
                parts.Enqueue(new Part(Color, new Point(Head.Location.X, Head.Location.Y - PartsSize), PartsSize));
            else if (Direction == Direction.Left)
                parts.Enqueue(new Part(Color, new Point(Head.Location.X - PartsSize, Head.Location.Y), PartsSize));
            else if (Direction == Direction.Right)
                parts.Enqueue(new Part(Color, new Point(Head.Location.X + PartsSize, Head.Location.Y), PartsSize));

            Head.SetLightColor();
            Neck.SetDefaultColor();
        }

        public void Draw(Graphics g)
        {
            foreach (var part in parts)
                part.Draw(g);
        }

        public void Remove()
        {
            foreach (var part in parts)
                part.Remove();
        }

        public void Eat(Part food) 
        {
            Head.SetDefaultColor();
            parts.Enqueue(new Part(Color, new Point(food.Location.X, food.Location.Y), PartsSize));
            Head.SetLightColor();
        }

        public bool CanEat(Part food)
        {
            if (Direction == Direction.Down && Head.Location.X == food.Location.X && Head.Location.Y + PartsSize == food.Location.Y)
                return true;
            else if (Direction == Direction.Up && Head.Location.X == food.Location.X && Head.Location.Y - PartsSize == food.Location.Y)
                return true;
            else if (Direction == Direction.Left && Head.Location.X - PartsSize == food.Location.X && Head.Location.Y == food.Location.Y)
                return true;
            else if (Direction == Direction.Right && Head.Location.X + PartsSize == food.Location.X && Head.Location.Y == food.Location.Y)
                return true;

            return false;
        }

        public bool EatsItself()
        {
            int index = 0;
            return parts.Any(part => index++ != parts.Count - 1 && Head.Location.Y == part.Location.Y && Head.Location.X == part.Location.X);
        }

        public void Reset(Point spawnLocation)
        {
            parts = new Queue<Part>();

            var head = new Part(Color, spawnLocation, PartsSize);
            head.SetLightColor();
            parts.Enqueue(head);
            Neck = new Part(Color, new Point(spawnLocation.X, spawnLocation.Y - PartsSize), PartsSize);
            parts.Enqueue(Neck);

            Direction = Direction.Down;
        }

        public bool Contains(Point position) => parts.Any(part => part.Location == position);
    }

    [Serializable]
    public class Part 
    { 
        public Rectangle Graphic { get; private set; }
        public Color Color { get; private set; }
        public Point Location { get; private set; }
        public int Size { get; private set; }

        private Color color;

        public Part(Color _color, Point location, int size)
        {
            Color = color = _color;
            Location = location;
            Size = size;
            Graphic = new Rectangle(Location, new Size(size, size));
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color), Graphic);
            System.Windows.Forms.ControlPaint.DrawBorder(g, Graphic, Color.Black, System.Windows.Forms.ButtonBorderStyle.Solid);
        }

        public void Remove()
        {
            Graphic = Rectangle.Empty;
            Location = Point.Empty;
            Size = 0;
            Color = Color.Empty;
        }

        public void SetLocation(Point location)
        {
            Location = location;
            Graphic = new Rectangle(location.X, location.Y, Size, Size);
        }

        public void SetLightColor() => Color = System.Windows.Forms.ControlPaint.LightLight(color);

        public void SetDefaultColor() => Color = color;
    }
}
