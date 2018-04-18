using System;

namespace Inertia
{
    internal class Hero : Element
    {
        public ConsoleKeyInfo Direction { set; get; }
        public bool Moving { set; get; }

        public Hero(int x, int y)
        {
            X = x;
            Y = y;
            Gist = "None";
            Moving = false;
        }
            
        public override void Display()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("&");
        }
            
        public void Move(bool reverse = false)
        {
            switch (Direction.Key)
            {
                case ConsoleKey.UpArrow:
                    if (reverse)
                        Y++;
                    else
                        Y--;
                    break;
                case ConsoleKey.DownArrow:
                    if (reverse)
                        Y--;
                    else
                        Y++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (reverse)
                        X++;
                    else
                        X--;
                    break;
                case ConsoleKey.RightArrow:
                    if (reverse)
                        X--;
                    else
                        X++;
                    break;
            }  
        }
    }
}