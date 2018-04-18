using System;
namespace Inertia
{
    class Wall : Element
    {
        public Wall(int x, int y)
        {
            X = x;
            Y = y;
            Gist = "Wall";
        }

        public override void Display()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("#");
        }
    }
}