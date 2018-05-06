using System.Drawing;

namespace GraphEditor
{
    class Rectangle : Shape, ISelectable
    {
        Graphics drawSurface;

        public Rectangle()
        {
        }

        public Rectangle(Graphics drawSurface)
        {
            this.drawSurface = drawSurface;
        }

        public void CreateFrame(int startX, int startY, int endX, int endY)
        {
            Pen pen = new Pen(Color.Brown, 2);
            Point start = new Point(startX, startY);
            Point end = new Point(endX, endY);
            Draw(start, end, pen);
        }

        public override void Draw(Point startCoords, Point endCoords, Pen penReader)
        {
            drawSurface.DrawRectangle(penReader, GetX(startCoords, endCoords), GetY(startCoords, endCoords), GetWidthShape(startCoords, endCoords), GetHightShape(startCoords, endCoords));
        }

    }
}
