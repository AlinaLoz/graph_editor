using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphEditor
{
    class Line:Shape
    {
        private Graphics drawSurface;

        public Line(Graphics drawSurface)
        {
            this.drawSurface = drawSurface;
        }

        public override void Draw(Point prevEndCoords, Point startCoords, Point endCoords, Pen prevPen, Pen penReader)
        {
            drawSurface.DrawLine(prevPen, startCoords, prevEndCoords);
            drawSurface.DrawLine(penReader, startCoords, endCoords);
        }
    }
}
