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
        public override void Draw(Point prevEndCoords, Point startCoords, Point endCoords, Pen prevPen, Pen penReader)
        {
            drawSurface.DrawRectangle(prevPen, GetX(startCoords, prevEndCoords), GetY(startCoords, prevEndCoords), GetWidthShape(startCoords, prevEndCoords), GetHightShape(startCoords, prevEndCoords));
            drawSurface.DrawRectangle(penReader, GetX(startCoords, endCoords), GetY(startCoords, endCoords), GetWidthShape(startCoords, endCoords), GetHightShape(startCoords, endCoords));
        }

    }
}
