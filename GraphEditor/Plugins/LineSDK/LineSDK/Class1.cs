using System.Drawing;
using AddFigure;
using ShapeSDK;

namespace LineSDK
{
    public class LineM : Shape
    {
       public override  void Draw(Graphics drawSurface)
       {
           Pen pen = new Pen(Color.Black, 5);
           drawSurface.DrawLine(pen, firstPoint, lastPoint);
       }
    }
}
