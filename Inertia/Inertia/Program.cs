using System;

namespace Inertia
{
    internal class Program
    {
        internal class Game
        {
            public Element[,] Map;
            public Hero Hero { set; get; }

            public Game(Element[,] map, Hero hero)
            {
                Console.CursorVisible = false;
                Map = map;
                Hero = hero;
            }
            
            public Element this[int row, int column]
            {
                set { Map[row, column] = value; }
                get { return Map[row, column]; }
            }

            public void MoveHero(ConsoleKeyInfo press)
            {
                switch (press.Key)
                {
                    case ConsoleKey.UpArrow:
                        while (!this[Hero.Y - 1, Hero.X].IsObstacle)
                            Hero.Move("Up");
                        break;
                    case ConsoleKey.DownArrow:
                        while (!this[Hero.Y + 1, Hero.X].IsObstacle)
                            Hero.Move("Down");
                        break;
                    case ConsoleKey.LeftArrow:
                        while (!this[Hero.Y, Hero.X - 1].IsObstacle)
                            Hero.Move("Left");
                        break;
                    case ConsoleKey.RightArrow:
                        while (!this[Hero.Y, Hero.X + 1].IsObstacle)
                            Hero.Move("Right");
                        break;
                }  
            }
            
            public void Render()
            {
                Console.Clear();
                for(int i = 0; i < Map.GetLength(0); i++)
                {
                    for (int j = 0; j < Map.GetLength(1); j++)
                    {
                        this[i, j].Display();
                    }
                }
                Hero.Display();
            }
        }

        internal abstract class Element
        {
            public int X { get; protected set; }
            public int Y { get; protected set; }
            public bool IsObstacle { get; protected set; }

            public abstract void Display();
        }

        internal class Hero : Element
        {
            public Hero(int x, int y)
            {
                X = x;
                Y = y;
                IsObstacle = false;
            }
            
            public override void Display()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("&");
            }
            
            public void Move(string direction)
            {
                switch (direction)
                {
                    case "Up":
                            Y--;
                        break;
                    case "Down":
                            Y++;
                        break;
                    case "Left":
                            X--;
                        break;
                    case "Right":
                            X++;
                        break;
                }  
            }
        }
        
        class Wall : Element
        {
            public Wall(int x, int y)
            {
                X = x;
                Y = y;
                IsObstacle = true;
            }

            public override void Display()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("#");
            }
        }

        class Ground : Element
        {
            public Ground(int x, int y)
            {
                X = x;
                Y = y;
                IsObstacle = false;
            }
            
            public override void Display()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(" ");
            }
        }

        class Trap : Element
        {
            public Trap(int x, int y)
            {
                X = x;
                Y = y;
                IsObstacle = true;
            }
            
            public override void Display()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("%");
            }
        }
        
        class Treasure : Element
        {
            public Treasure(int x, int y)
            {
                X = x;
                Y = y;
                IsObstacle = false;
            }
            
            public override void Display()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("$");
            }
        }
        
        public static Game LevelDowload(string[] matrix)
        {
            int x = 1;
            int y = 1;
            Element[,] map = new Element[matrix.Length, matrix[0].Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    switch (matrix[i][j])
                    {
                        case '#':
                            map[i, j] = new Wall(j, i);
                            break;
                        case ' ':
                            map[i, j] = new Ground(j, i);
                            break;
                        case '&':
                            map[i, j] = new Ground(j, i);
                            x = j;
                            y = i;
                            break;
                        case '%':
                            map[i, j] = new Trap(j, i);
                            break;
                        case '$':
                            map[i, j] = new Treasure(j, i);
                            break;
                    }
                }
            }

            Hero hero = new Hero(x, y);
            return new Game(map, hero);
        }
        
        
        public static void Main()
        {
            string[] matrix =
            {
                    "###################", 
                    "#          #      #", 
                    "#          #      #", 
                    "#          #      #", 
                    "#$    &    #$     #", 
                    "#   ####   ##     #", 
                    "#          $#     #",  
                    "#  #              #", 
                    "#  #$        $    #", 
                    "#  ################",
                    "#   $             #", 
                    "################# #", 
                    "#       $         #", 
                    "# #################", 
                    "#            $    #", 
                    "###################" 
            };

            Game level01 = LevelDowload(matrix);
            level01.Render();
            while (true)
            {
                ConsoleKeyInfo press = Console.ReadKey();
                if (press.Key == ConsoleKey.Q)
                    break;
                level01.MoveHero(press);
                level01.Render();
            }
        }
    }
}