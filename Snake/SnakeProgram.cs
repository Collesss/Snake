using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Snake
{
    class SnakeProgram
    {
        static char[,] field;

        //private static readonly Point size = new Point(23, 12);
        private static readonly Point stepMove = new Point(1, 1);

        private static Point startSnake;
        private static Point endSnake;



        private static Queue<Move> moves = new Queue<Move>();


        // down - \u25BC; left - \u25C4; right - \u25BA; up - \u25B2
        private static readonly Dictionary<Direction, char> dirToCharHead = new Dictionary<Direction, char>() { 
            [Direction.Up]      = '\u25B2',
            [Direction.Down]    = '\u25BC',
            [Direction.Left]    = '\u25C4',
            [Direction.Right]   = '\u25BA'
        };

        private static readonly Dictionary<Direction, char> dirToChar = new Dictionary<Direction, char>() { 
            [Direction.LeftToUp]    = '\u255D',
            [Direction.LeftToDown]  = '\u2557',
            [Direction.RightToUp]   = '\u255A',
            [Direction.RightToDown] = '\u2554',
            [Direction.Left]        = '\u2550',
            [Direction.Right]       = '\u2550',
            [Direction.Up]          = '\u2551',
            [Direction.Down]        = '\u2551'
        };

        private static readonly Dictionary<ConsoleKey, Direction> keyToDir = new Dictionary<ConsoleKey, Direction>()
        {
            [ConsoleKey.W] = Direction.Up,
            [ConsoleKey.S] = Direction.Down,
            [ConsoleKey.A] = Direction.Left,
            [ConsoleKey.D] = Direction.Right
        };



        static SnakeProgram() 
        {
            //moves.Enqueue(new Move());

        }

        


        static void Main(string[] args)
        {
            #region Test
            var console = Console.OutputEncoding;
            var system = System.Text.Encoding.Default;


            Console.OutputEncoding = System.Text.Encoding.Default;
            #endregion

            Console.CursorVisible = false;

            startSnake = new Point(5, 5);
            endSnake = new Point(2, 5);
            //endSnake = startSnake;


            Move currentMove = new Move(Direction.Right, 3);
            moves.Enqueue(currentMove);


            Test1();

            Direction direction = Direction.Right;

            //int i = 0;

            while (true)
            {
                if (ReadLastKey(out ConsoleKey key) && keyToDir.TryGetValue(key, out Direction newDir) && (newDir & Direction.HorOrVer) != (direction & Direction.HorOrVer))
                {
                    //Console.WriteLine($"\nLast dir: {direction};\nNew dir: {newDir};\nRotate char: {(direction | newDir) & Direction.Rotate};");
                    //direction = newDir;
                }
                else
                {
                    currentMove.Inc();
                    Draw(startSnake, dirToChar[direction]);
                    startSnake = GetNewPoint(startSnake, stepMove, direction);
                    Draw(startSnake, dirToCharHead[direction]);

                    Move end = moves.Peek();
                    end.Dec();
                    Draw(endSnake, ' ');
                    endSnake = GetNewPoint(endSnake, stepMove, end.direction);
                }


                //Console.WriteLine($"Tick: {i++}\n");

                Task.Delay(1000).Wait();
            }




        }

        static void Draw(Point point, char drawChar)
        {
            Console.CursorLeft = point.X;
            Console.CursorTop = point.Y;
            Console.Write(drawChar);
        }

        static Point GetNewPoint(Point point, Point offset, Direction direction) => direction switch { 
            Direction.Up    => new Point(point.X, point.Y - offset.Y),
            Direction.Down  => new Point(point.X, point.Y + offset.Y),
            Direction.Left  => new Point(point.X - offset.X, point.Y),
            Direction.Right => new Point(point.X + offset.X, point.Y),
            _               => point
        };

        static bool ReadLastKey(out ConsoleKey key)
        {
            key = ConsoleKey.NoName;

            if (!Console.KeyAvailable)
                return false;

            while (Console.KeyAvailable)
                key = Console.ReadKey(true).Key;

            return true;
        }

        static void Test1()
        {
            Console.CursorLeft = 2;
            Console.CursorTop = 5;
            Console.Write(dirToChar[Direction.Right]);
            Console.Write(dirToChar[Direction.Right]);
            Console.Write(dirToChar[Direction.Right]);
            Console.Write(dirToCharHead[Direction.Right]);
        }

        /*
        static void InitField()
        {
            
            field = new char[size.Y, size.X];

            field[0, 0]                     = '\u250C';
            field[0, size.X - 1]            = '\u2510';
            field[size.Y - 1, 0]            = '\u2514';
            field[size.Y - 1, size.X - 1]   = '\u2518';
            
            //\u2500 - ; \u2502

            

            for (int i = 1; i < size.X - 1; i++)
                field[0, i] = field[size.Y - 1, i] = '\u2500';

            for (int i = 1; i < size.Y - 1; i++)
                field[i, 0] = field[i, size.X - 1] = '\u2502';


            for (int i = 1; i < size.Y - 1; i++)
                for (int j = 1; j < size.X - 1; j++)
                    field[i, j] = j % 2 == 0 ? '\u25A0' : ' ';
            
            //Test();
        }
        */
        #region Testing
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
        #endregion
        /*
        static void Draw()
        {
            Console.Clear();
            
            for (int i = 0; i < size.Y; i++)
            {
                for (int j = 0; j < size.X; j++)
                    Console.Write(field[i, j]);
                    
                if(i != size.Y - 1)
                    Console.WriteLine();
            }
        }
        */
    }
}
