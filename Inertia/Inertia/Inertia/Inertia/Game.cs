using System;
namespace Inertia
{
    internal class Game
    {
        public Element[,] Map;
        public Hero Hero { set; get; }
        public int Health { set; get; }
        public int Score { set; get; }
        public int Treasures { set; get; }

        public Game(string[] matrix)
        {
            Console.CursorVisible = false;
            LevelDowload(matrix);
            Health = 3;
            Score = 0;
        }

        public Element this[int row, int column]
        {
            set { Map[row, column] = value; }
            get { return Map[row, column]; }
        }

        public void Start()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("   ###  ###       ##  ###########  #########   ############  ###   ########");
            Console.WriteLine("   ###  ######    ##  ###          ##     ###      ###       ###  ####   ###");
            Console.WriteLine("   ###  ########  ##  #########    ##########      ###       ###  ####   ###");
            Console.WriteLine("   ###  ###   ######  ###          ###   ###       ###       ###  ##########");
            Console.WriteLine("   ###  ###     ####  ###########  ###    ###      ###       ###  ####   ###");
            Console.SetCursorPosition(28, 15);
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Render();
            while (true)
            {
                ConsoleKeyInfo press = Console.ReadKey();
                if (press.Key == ConsoleKey.Q)
                {
                    GameOver();
                    break;
                }

                if (press.Key == ConsoleKey.UpArrow ||
                    press.Key == ConsoleKey.DownArrow ||
                    press.Key == ConsoleKey.LeftArrow ||
                    press.Key == ConsoleKey.RightArrow)
                {
                    this[Hero.Y, Hero.X].Display();
                    MoveHero(press);
                    if (Treasures == 0)
                    {
                        Score *= Health;
                        GameOver(true);
                        break;
                    }

                    if (Health <= 0)
                    {
                        GameOver();
                        break;
                    }

                    Hero.Display();
                    DisplayInfo();
                }
            }
        }

        private void GameOver(bool victory = false)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("                #######     ########   ##### ######  ##########");
            Console.WriteLine("               ###         ####   ###  ### ###  ###  ###");
            Console.WriteLine("               ### ######  ####   ###  ### ###  ###  ##########");
            Console.WriteLine("               ###   ####  ##########  ### ###  ###  ###");
            Console.WriteLine("                ########   ####   ###  ### ###  ###  ##########");
            Console.SetCursorPosition(0, 10);                                                    
            Console.WriteLine("                 ########   ####   ###  ##########  #########"); 
            Console.WriteLine("                ###   ####  ####   ###  ###         ###    ###");      
            Console.WriteLine("                ###   ####  ####   ###  ##########  ##########");    
            Console.WriteLine("                ###   ####   #### ###   ###         ###   ###");
            Console.WriteLine("                 ########       ###     ##########  ###    ###");
            Console.SetCursorPosition(33, 16);
            Console.WriteLine($"Your Score: {Score}");
            Console.ReadKey();
        }

        private void MoveHero(ConsoleKeyInfo press)
        {
            Hero.Direction = press;
            Hero.Moving = true;
            Hero.Move();
            while (Hero.Moving)
            {
                switch (this[Hero.Y, Hero.X].Gist)
                {
                    case "Wall":
                        Hero.Move(true);
                        Hero.Moving = false;
                        break;
                    case "Trap":
                        Hero.Move(true);
                        Hero.Moving = false;
                        Health--;
                        break;
                    case "Treasure":
                        Score++;
                        Treasures--;
                        this[Hero.Y, Hero.X] = new Ground(Hero.X, Hero.Y);
                        this[Hero.Y, Hero.X].Display();
                        Hero.Move();
                        break;
                    case "StopPoint":
                        Hero.Moving = false;
                        break;
                    default:
                        Hero.Move();
                        break;
                }
            }
        }

        public void DisplayInfo()
        {
            Console.SetCursorPosition(0, Map.GetLength(0) + 1);
            Console.Write($"Score: {Score}");
            Console.SetCursorPosition(0, Map.GetLength(0) + 2);
            Console.Write($"Health: {Health}");
        }

        public void Render()
        {
            Console.Clear();
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    this[i, j].Display();
                }
            }

            Hero.Display();
            DisplayInfo();
        }

        public void LevelDowload(string[] matrix)
        {
            int x = 1;
            int y = 1;
            Treasures = 0;
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
                        case '%':
                            map[i, j] = new Trap(j, i);
                            break;
                        case '$':
                            map[i, j] = new Treasure(j, i);
                            Treasures++;
                            break;
                        case '.':
                            map[i, j] = new StopPoint(j, i);
                            break;
                        case '&':
                            map[i, j] = new Ground(j, i);
                            x = j;
                            y = i;
                            break;
                        default:
                            map[i, j] = new Ground(j, i);
                            break;
                    }
                }
            }

            Hero = new Hero(x, y);
            Map = map;
        }
    }
}