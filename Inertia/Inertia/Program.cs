using System;

namespace Test
{
    internal class Program
    {
        class Matrix
        {
            private static Element[,] _map;

            public Matrix(int rows, int columns)
            {
                _map = new Element[rows, columns];
            }
            
            public Element this[int row, int column]
            {
                set { _map[row, column] = value; }
                get { return _map[row, column]; }
            }

            public static Element GetElem(int x, int y)
            {
                return _map[y, x];
            }
            
            public void Render()
            {
                Console.Clear();
                for(int i = 0; i < _map.GetLength(0); i++)
                {
                    for (int j = 0; j < _map.GetLength(1); j++)
                    {
                        this[i, j] = i == 0 || i == _map.GetLength(0) - 1 ||
                                    j == 0 || j == _map.GetLength(1) - 1 ?
                                    (Element) new Wall(j, i) : new Ground(j, i);
                        this[i, j].Display();
                    }
                }
            }
        }
        
        abstract class Element
        {
            public string Shape { get; protected set; }
            public int X { get; protected set; }
            public int Y { get; protected set; }
            public bool IsObstacle { get; protected set; }

            public void Display()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(Shape);
            }
        }
        
        class Hero : Element
        {
            public Hero(int x, int y)
            {
                X = x;
                Y = y;
                Shape = "ߐ";
                IsObstacle = false;
            }
            
            public void Move(ConsoleKeyInfo press)
            {
                switch (press.Key)
                {
                    case ConsoleKey.UpArrow:
                        while(!Matrix.GetElem(Y - 1, X).IsObstacle)
                            Y--;
                        break;
                    case ConsoleKey.DownArrow:
                        while(!Matrix.GetElem(Y + 1, X).IsObstacle)
                            Y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        while(!Matrix.GetElem(Y, X - 1).IsObstacle)
                            X--;
                        break;
                    case ConsoleKey.RightArrow:
                        while(!Matrix.GetElem(Y, X + 1).IsObstacle)
                            X++;
                        break;
                }
                Display();
            }
        }
        
        class Wall : Element
        {
            public Wall(int x, int y)
            {
                X = x;
                Y = y;
                Shape = "ߛ";
                IsObstacle = true;
            }
        }

        class Ground : Element
        {
            public Ground(int x, int y)
            {
                X = x;
                Y = y;
                Shape = " ";
                IsObstacle = false;
            }
        }

        class Trap : Element
        {
            public Trap(int x, int y)
            {
                X = x;
                Y = y;
                Shape = "ߡ";
                IsObstacle = true;
            }
        }
        
        class Treasure : Element
        {
            public Treasure(int x, int y)
            {
                X = x;
                Y = y;
                Shape = "ߋ";
                IsObstacle = false;
            }
        }
        
        public static void Main()
        {
            Console.CursorVisible = false;
            Matrix field = new Matrix(20, 20);
            Random rng = new Random();
            Hero hero = new Hero(rng.Next(1, 14), rng.Next(1, 14));
            field.Render();
            hero.Display();
            while (true)
            {
                ConsoleKeyInfo press = Console.ReadKey();
                if (press.Key == ConsoleKey.Q)
                    break;
                field.Render();
                hero.Move(press);
            }
        }
    }
}