using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace GraphEditor
{
    [DataContract]
    class Circle:Shape, ISelectable
    {
        public Circle()
        {
        }

        public bool isHighLight(Point currPoint)
        {
            int radius = (int)GetSizeShape(lastPoint, firstPoint) / 2;
            int dx = Math.Abs(currPoint.X - (firstPoint.X + radius));
            int dy = Math.Abs(currPoint.Y - (firstPoint.Y + radius));
            return (Math.Pow(dx, 2) + Math.Pow(dy, 2) < Math.Pow(radius, 2)) ? true : false;
        }

    public override void Draw(Graphics drawSurface)
        {
            Pen pen = new Pen(Color.Black, 1);

            if (this.lastPoint.X > firstPoint.X && lastPoint.Y > firstPoint.Y)
                drawSurface.DrawEllipse(pen, firstPoint.X, firstPoint.Y, GetSizeShape(lastPoint, firstPoint), GetSizeShape(lastPoint, firstPoint));
            else
                if (lastPoint.X > firstPoint.X && lastPoint.Y < firstPoint.Y)
                drawSurface.DrawEllipse(pen, firstPoint.X, firstPoint.Y, GetSizeShape(lastPoint, firstPoint), -GetSizeShape(lastPoint, firstPoint));
            else
                    if (lastPoint.X < firstPoint.X && lastPoint.Y > firstPoint.Y)
                drawSurface.DrawEllipse(pen, firstPoint.X, firstPoint.Y, -GetSizeShape(lastPoint, firstPoint), GetSizeShape(lastPoint, firstPoint));
            else
                        if (lastPoint.X < firstPoint.X && lastPoint.Y < firstPoint.Y)
                drawSurface.DrawEllipse(pen, firstPoint.X, firstPoint.Y, -GetSizeShape(lastPoint, firstPoint), -GetSizeShape(lastPoint, firstPoint));
        }

    }
}
