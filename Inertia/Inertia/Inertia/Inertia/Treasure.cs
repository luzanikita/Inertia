﻿using System;
namespace Inertia
{
    class Treasure : Element
    {
        public Treasure(int x, int y)
        {
            X = x;
            Y = y;
            Gist = "Treasure";
        }
            
        public override void Display()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("$");
        }
    }
}