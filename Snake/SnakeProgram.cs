using System;

namespace Snake
{
    class SnakeProgram
    {
        static char[,] field;
        const int size = 10;

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

            Test();
        }

        static void Test()
        {
            //u25A0 - end; start *
            field = new char[,] {
                { '\u250C', '\u2500', '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2510' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , '\u250C'  , '\u2500'  , '\u2510'  , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , '\u2502'  , 'o'       , '\u25A0'  , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , '*'       , '\u2500'  , '\u2518'  , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2502', 'o'     , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , 'o'       , '\u2502' },
                { '\u2514', '\u2500', '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2500'  , '\u2518' }
            };
        }

        static void Draw()
        {
            Console.Clear();

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
        }
    }
}
