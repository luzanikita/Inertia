using System;
using System.Collections.Generic;
using System.IO;

namespace Inertia
{
    class Game
    {
        private Element[,] _map;
        private Hero Hero { set; get; }
        private int Health { set; get; }
        private int Score { set; get; }
        private int Treasures { set; get; }

        public Game(List<string> matrix)
        {
            Console.CursorVisible = false;
            LevelDowload(matrix);
            Health = 3;
            Score = 0;
        }

        private Element this[int row, int column]
        {
            set { _map[row, column] = value; }
            get { return _map[row, column]; }
        }

        public void Start()
        {
            Console.Clear();
            Render();
            while (true)
            {
                ConsoleKeyInfo press = Console.ReadKey();
                if (press.Key == ConsoleKey.Q)
                {
                    GameOver();
                    break;
                }

                if (press.Key != ConsoleKey.UpArrow && press.Key != ConsoleKey.DownArrow &&
                    press.Key != ConsoleKey.LeftArrow && press.Key != ConsoleKey.RightArrow) continue;
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

        private void GameOver(bool victory = false)
        {
            string text;
            int x;
            int y;
            Console.Clear();
            if (victory)
            {
                text = "victory";
                x = 10;
                y = 7;
            }
            else
            {
                text = "gameover";
                x = 20;
                y = 5;
            }

            TextReader reader1 = new StreamReader($"../../{text}.txt");
            string line;
            while ((line = reader1.ReadLine()) != null) {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(line);
                y++;
            }
            reader1.Close();
            Console.SetCursorPosition(30, y + 1);
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

        private void DisplayInfo()
        {
            Console.SetCursorPosition(25, _map.GetLength(0) + 1);
            Console.Write($"Score: {Score}   Health: {Health}");
        }

        private void Render()
        {
            Console.Clear();
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    this[i, j].Display();
                }
            }

            Hero.Display();
            DisplayInfo();
        }

        private void LevelDowload(List<string> matrix)
        {
            int x = 1;
            int y = 1;
            Treasures = 0;
            Element[,] map = new Element[matrix.Count, matrix[0].Length];
            for (int i = 0; i < matrix.Count; i++)
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
            _map = map;
        }
    }
}