using System;
using System.Drawing;

namespace GraphEditor
{
    class Rectangle : Shape, ISelectable
    {
        public Rectangle()
        {
        }

        public bool isHighLight(Point currPoint)
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
