using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override void Draw(Point prevEndCoords, Point startCoords, Point endCoords, Pen prevPen, Pen penReader)
        {
            drawSurface.DrawEllipse(prevPen, startCoords.X, startCoords.Y, prevEndCoords.X - startCoords.X, prevEndCoords.Y - startCoords.Y);
            drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, endCoords.X - startCoords.X, endCoords.Y - startCoords.Y);
        }
    }
}
