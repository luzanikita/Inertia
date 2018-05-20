using System;
namespace Inertia
{
    class Ground : Element
    {
        public Ground(int x, int y)
        {
            X = x;
            Y = y;
            Gist = Gists.None;
        }

        public override String GetCurrentSymbol()
        {
            return " ";
        }
    }
}