using System;
namespace Inertia
{
    class Trap : Element
    {
        public Trap(int x, int y)
        {
            X = x;
            Y = y;
            Gist = "Trap";
        }
            
        public override void Display()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("%");
        }
    }
}