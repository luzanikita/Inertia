using System;

namespace Inertia
{
    internal class Program
    {
        internal class Hero
        {
            private int _x;
            public int X
            {
                set { _x = value; }
                get { return _x; }
            }
            
            private int _y;
            public int Y
            {
                set { _y = value; }
                get { return _y; }
            }
            
            private readonly string _shape;
            public string Shape
            {
                get { return _shape; }
            }

            public Hero(int x, int y, string shape)
            {
                _x = x;
                _y = y;
                _shape = shape;
            }

            public void Move(ConsoleKeyInfo press)
            {
                switch (press.Key)
                {
                    case ConsoleKey.UpArrow:
                        Y--;
                        break;
                    case ConsoleKey.DownArrow:
                        Y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        X--;
                        break;
                    case ConsoleKey.RightArrow:
                        X++;
                        break;
                }
            }
        }
        public static void Render(string[,] matrix, Hero hero, string wall)
        {
            Console.Clear();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i == 0 || i == matrix.GetLength(0) - 1) || (j == 0 || j == matrix.GetLength(1) - 1))
                    {
                        Console.Write(wall);
                    }
                    else if (i == hero.Y && j == hero.X)
                    {
                        Console.Write(hero.Shape);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        
        public static void Main(string[] args)
        {
            string[,] matrix = new string[8, 8];
            string wall = "#";
            Hero hero = new Hero((new Random()).Next(1, 7), (new Random()).Next(1, 7), "I");
            
            Console.Clear();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i == 0 || i == matrix.GetLength(0) - 1) || (j == 0 || j == matrix.GetLength(1) - 1))
                    {
                        matrix[i, j] = wall;
                        Console.Write(wall);
                    }
                    else if (i == hero.Y && j == hero.X)
                    {
                        matrix[i, j] = hero.Shape;
                        Console.Write(hero.Shape);
                    }
                    else
                    {
                        matrix[i, j] = " ";
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            while (true)
            {
                ConsoleKeyInfo press = Console.ReadKey();
                if (press.Key == ConsoleKey.Q)
                    break;
                
                hero.Move(press);
                Console.Beep();
                Render(matrix, hero, wall);
            }

        }
    }
}