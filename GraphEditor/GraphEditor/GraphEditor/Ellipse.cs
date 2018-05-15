using System;
using System.Drawing;

namespace GraphEditor
{
    class Ellipse:Shape
    {

        public override void Draw(Graphics drawSurface)
        {
            Pen pen = new Pen(Color.Black, 1);
            drawSurface.DrawEllipse(pen, firstPoint.X, firstPoint.Y, lastPoint.X - firstPoint.X, lastPoint.Y - firstPoint.Y);
        }
    }
}
