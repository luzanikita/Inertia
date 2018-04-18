﻿using System;
namespace Inertia
{
    class StopPoint : Element
    {
        public StopPoint(int x, int y)
        {
            X = x;
            Y = y;
            Gist = "StopPoint";
        }
            
        public override void Display()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(".");
        }
    }
}