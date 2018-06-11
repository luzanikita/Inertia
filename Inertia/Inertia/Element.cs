using System;
namespace Inertia
{
    abstract class Element : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Gists Gist { get; set; }

        public abstract System.Drawing.Bitmap GetShape();

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}