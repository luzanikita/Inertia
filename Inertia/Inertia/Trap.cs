using System;
namespace Inertia
{
    class Trap : Element
    {
        public Trap(int x, int y)
        {
            X = x;
            Y = y;
            Gist = Gists.Trap;
        }

        public override String GetCurrentSymbol()
        {
            return "%";
        }
    }
}