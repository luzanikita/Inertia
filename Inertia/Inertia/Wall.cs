using System;
namespace Inertia
{
    class Wall : Element
    {
        public Wall(int x, int y)
        {
            X = x;
            Y = y;
            Gist = Gists.Wall;
        }

        public override String GetCurrentSymbol()
        {
            return "#";
        }
    }
}