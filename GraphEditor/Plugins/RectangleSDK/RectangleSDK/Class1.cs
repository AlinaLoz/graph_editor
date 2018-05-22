using System.Drawing;
using AddFigure;
using ShapeSDK;
using System.Runtime.Serialization;

namespace RectangleSDK
{
    [DataContract]
    public class RectangleM : Shape, ISelectable
    {
        public RectangleM()
        {
        }

        public bool IsHighLight(Point currPoint)
        {
            bool firstCondition = (currPoint.X >= firstPoint.X) && (currPoint.X <= lastPoint.X);
            bool secondCondition = (currPoint.Y >= firstPoint.Y) && (currPoint.Y <= lastPoint.Y);
            return firstCondition && secondCondition;
        }
        public void CreateFrame(Graphics drawSurface)
        {
            Pen pen = new Pen(Color.Brown, 2);
            Point start = new Point(firstPoint.X, firstPoint.Y);
            Point end = new Point(lastPoint.X, lastPoint.Y);
            Draw(drawSurface);
        }

        public override void Draw(Graphics drawSurface)
        {
            Pen pen = new Pen(Color.Black, 1);
            drawSurface.DrawRectangle(pen, GetX(firstPoint, lastPoint), GetY(firstPoint, lastPoint), GetWidthShape(firstPoint, lastPoint), GetHightShape(firstPoint, lastPoint));
        }
    }
}
