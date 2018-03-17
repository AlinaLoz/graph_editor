using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphEditor
{
    class Rectangle: Shape
    {
        private Graphics drawSurface;

        public Rectangle(Graphics drawSurface) {
            this.drawSurface = drawSurface;
        }
        public override void Draw(Point startCoords, Point endCoords, Pen penReader)
        {
            drawSurface.DrawRectangle(penReader, GetX(startCoords, endCoords), GetY(startCoords, endCoords), GetWidthShape(startCoords, endCoords), GetHightShape(startCoords, endCoords));
        }

    }
}
