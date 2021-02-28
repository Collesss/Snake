using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    enum Direction : byte
    {
        Up          = 0b0000_0011,
        Right       = 0b0011_0000,
        Down        = 0b0000_0101,
        Left        = 0b0101_0000,
        Horizontal  = 0b0001_0000,
        Vertical    = 0b0000_0001,
        LeftToUp    = 0b0100_0010,
        LeftToDown  = 0b0100_0100,
        RightToUp   = 0b0010_0010,
        RightToDown = 0b0010_0100,
        Rotate      = 0b0110_0110,
        HorOrVer    = 0b0001_0001
    }

    class Move
    {
        public readonly Direction direction;
        public int Length { get; private set; }

        public Move(Direction direction, int Length)
        {
            this.direction = direction;
            this.Length = Length;
        }

        //public Move(int X, int Y, Direction direction, int Length) : this(new PointReadOnly(X, Y), direction, Length) { }

        public void Dec() =>
            Length--;

        public void Inc() =>
            Length++;

    }

    struct Point
    {
        public int X;
        public int Y;

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override bool Equals(object obj) =>
            X == ((Point)obj).X && Y == ((Point)obj).Y;

        public override int GetHashCode() =>
            base.GetHashCode();

        public static Point operator *(Point point1, Point point2) =>
            new Point(point1.X * point2.X, point2.Y * point2.Y);

        public static Point operator +(Point point1, Point point2) =>
            new Point(point1.X + point2.X, point1.Y + point2.Y);

        public static Point operator -(Point point1, Point point2) =>
            new Point(point1.X - point2.X, point1.Y - point2.Y);

        public static bool operator ==(Point point1, Point point2) =>
            point1.X == point2.X && point1.Y == point2.Y;

        public static bool operator !=(Point point1, Point point2) =>
             point1.X != point2.X || point1.Y != point2.Y;
    }

}
