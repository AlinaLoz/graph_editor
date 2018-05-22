using System;
using System.Drawing;
using AddFigure;
using ShapeSDK;
using System.Runtime.Serialization;

namespace EllipseSDK
{
    public class Ellipse : Shape
    {
         public  override void Draw(Graphics drawSurface)
         {
             Pen pen = new Pen(Color.Black, 1);
             drawSurface.DrawEllipse(pen, firstPoint.X, firstPoint.Y, lastPoint.X - firstPoint.X, lastPoint.Y - firstPoint.Y);
         }
    }
}
