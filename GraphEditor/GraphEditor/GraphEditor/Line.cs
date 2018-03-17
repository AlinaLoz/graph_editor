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

        public override void Draw(Point startCoords, Point endCoords, Pen penReader)
        {
            drawSurface.DrawLine(penReader, startCoords, endCoords);
        }
    }
}
