using System.Drawing;

namespace GraphEditor
{
    class Ellipse:Shape
    {
        private Graphics drawSurface;
        public Ellipse(Graphics drawSurface)
        {
            this.drawSurface = drawSurface;
        }

        public override void Draw(Point startCoords, Point endCoords, Pen penReader)
        {
            drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, endCoords.X - startCoords.X, endCoords.Y - startCoords.Y);
        }
    }
}
