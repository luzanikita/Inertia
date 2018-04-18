using System;
namespace Inertia
{
    class Ground : Element
    {
        public Ground(int x, int y)
        {
            X = x;
            Y = y;
            Gist = "None";
        }
            
        public override void Display()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}