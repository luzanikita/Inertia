using System;

namespace Inertia
{
    internal class Hero : Element
    {
        public Direction Direction { set; get; }
        public bool Moving { set; get; }

        public Hero(int x, int y)
        {
            X = x;
            Y = y;
            Gist = Gists.None;
            Moving = false;
        }


        public override System.Drawing.Bitmap GetShape()
        {
            return Properties.Resources.Hero;
        }

        public void Move(bool reverse = false)
        {
            switch (Direction)
            {
                case Direction.Up:
                    if (reverse)
                        Y++;
                    else
                        Y--;
                    break;
                case Direction.Down:
                    if (reverse)
                        Y--;
                    else
                        Y++;
                    break;
                case Direction.Left:
                    if (reverse)
                        X++;
                    else
                        X--;
                    break;
                case Direction.Right:
                    if (reverse)
                        X--;
                    else
                        X++;
                    break;
            }  
        }
    }
}