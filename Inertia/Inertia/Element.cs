using System;
namespace Inertia
{
    abstract class Element
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Gists Gist { get; set; }

        public void Display()
        {
            Console.SetCursorPosition(25 + X, Y);
            Console.Write(GetCurrentSymbol());
        }

        public abstract String GetCurrentSymbol();
    }
}