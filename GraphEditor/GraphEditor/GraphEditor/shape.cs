using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace GraphEditor
{
    abstract class Shape
    {
        public abstract void Draw(Point prevEndCoords, Point startCoords, Point endCoords, Pen prevPen, Pen penReader);

        protected static float GetWidthShape(Point first, Point second) {
            return Math.Abs(first.X - second.X);
        }

        protected static float GetHightShape(Point first, Point second)
        {
            return Math.Abs(first.Y - second.Y);
        }

        protected static float GetSizeShape(Point first, Point second)
        {
            return (GetWidthShape(first, second) < GetHightShape(first, second) ? GetWidthShape(first, second) : GetHightShape(first, second));
        }

        protected static float GetX(Point first, Point second)
        {
            return (first.X > second.X) ? second.X : first.X;
        }

        protected static float GetY(Point first, Point second)
        {
            return (first.Y > second.Y) ? second.Y : first.Y;
        }
    }
}
