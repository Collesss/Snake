using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    enum Direction
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
        RightToDown = 0b0010_0100
    }

    class Move
    {
        public readonly PointReadOnly point;
        public readonly Direction direction;
        public int Length { get; private set; }

        public Move(PointReadOnly point, Direction direction, int Length)
        {
            this.point = point;
            this.direction = direction;
            this.Length = Length;
        }

        public Move(int X, int Y, Direction direction, int Length) : this(new PointReadOnly(X, Y), direction, Length) { }

        public void Dec() =>
            Length += Length > 0 ? -1 : 0;

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
    }


    struct PointReadOnly
    {
        public readonly int X;
        public readonly int Y;

        public PointReadOnly(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

}
