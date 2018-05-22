using System;
using System.Drawing;
using AddFigure;
using System.Runtime.Serialization;
using ShapeSDK;

namespace TreangleSDK
{
    [DataContract]
    public class Triangle: Shape
    {
        [DataMember]
        private Point[] point = new Point[3];

        public Triangle()
        {
            Array.Clear(point, 0, point.Length);
        }
        

        public override void Draw(Graphics drawSurface)
        {
            Double lengthSiteTriangle = Math.Sqrt(Math.Pow((lastPoint.X - firstPoint.X), 2) + Math.Pow((lastPoint.Y - firstPoint.Y), 2)) / 2;
            Pen pen = new Pen(Color.Black, 1);
            point[0].X = firstPoint.X;
            point[0].Y = firstPoint.Y;
            point[1].X = lastPoint.X;
            point[1].Y = lastPoint.Y;
            point[2].X = lastPoint.X - 2 * (lastPoint.X - firstPoint.X);
            point[2].Y = lastPoint.Y;
            drawSurface.DrawPolygon(pen, point);
        }
    }
}
