using System;
namespace Inertia
{
    class StopPoint : Element
    {
        public StopPoint(int x, int y)
        {
            X = x;
            Y = y;
            Gist = Gists.StopPoint;
        }

        public override System.Drawing.Bitmap GetShape()
        {
            return Properties.Resources.StopPoint;
        }
    }
}