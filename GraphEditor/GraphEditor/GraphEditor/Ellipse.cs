using System.Drawing;

namespace GraphEditor
{
    class Ellipse:Shape, ISelectable
    {
        private Graphics drawSurface;
        public Ellipse(Graphics drawSurface)
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
            drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, endCoords.X - startCoords.X, endCoords.Y - startCoords.Y);
        }
    }
}
