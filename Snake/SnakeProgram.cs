using System;
using System.Collections.Generic;

namespace Snake
{
    class SnakeProgram
    {
        static char[,] field;

        private static readonly PointReadOnly size;


        private static Point startSnake;
        private static Point endSnake;


        private static Queue<Move> moves;


        static SnakeProgram() 
        {
            size = new PointReadOnly(20, 10);

            //moves.Enqueue(new Move());

        }


        enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }

        private class Move 
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

            public Move(int X, int Y, Direction direction, int Length) : this(new PointReadOnly(X, Y), direction, Length){ }

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


        struct PointReadOnly { 
            public readonly int X;
            public readonly int Y;

            public PointReadOnly(int X, int Y)
            {
                this.X = X;
                this.Y = Y;
            }
        }


        static void Main(string[] args)
        {
            var console = Console.OutputEncoding;
            var system = System.Text.Encoding.Default;

            Console.OutputEncoding = System.Text.Encoding.Default;
            


            InitField();
            Draw();

        }

        static void InitField()
        {
            /*
            field = new char[size, size];

            field[0, 0]                 = '\u250C';
            field[0, size - 1]          = '\u2510';
            field[size - 1, 0]          = '\u2514';
            field[size - 1, size - 1]   = '\u2518';
            
            //\u2500 - ; \u2502

            for (int i = 1; i < size - 1; i++)
            {
                field[0, i] = field[size - 1, i] = '\u2500';
                field[i, 0] = field[i, size - 1] = '\u2502';
            }


            for (int i = 1; i < size - 1; i++)
                for (int j = 1; j < size - 1; j++)
                    field[i, j] = 'o';
            */
            Test();
        }

        static void Test()
        {
            // down - \u25BC; left - \u25C4; right - \u25BA; up - \u25B2
            //u25CB - end;
            field = new char[,] {
                { '\u250C', '\u2500', '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2510' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , '\u250C'  , '\u2500'  , '\u2510'  , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , '\u2502'  , 'o'       , '\u25BC'  , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , '\u25A0'  , '\u2500'  , '\u2518'  , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2514', '\u2500', '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2518' }
            };
        }

        static void Draw()
        {
            Console.Clear();
            /*
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(field[i, j]);
                    if(j != size - 1)
                        Console.Write(i == 0 || i == size - 1 ? '\u2500' : ' ');
                }
                    
                if(i != size - 1)
                    Console.WriteLine();
            }
            */
        }
    }
}
