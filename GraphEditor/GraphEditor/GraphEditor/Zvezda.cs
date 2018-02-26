using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphEditor
{
    class Zvezda: Shape
    {
        private Graphics drawSurface;
        private Point[] point = new Point[5];
        private Point[] prevPoint = new Point[5];

        public Zvezda(Graphics drawSurface)
        {
            this.drawSurface = drawSurface;
            Array.Clear(prevPoint, 0, prevPoint.Length);
            Array.Clear(point, 0, point.Length);
        }

        public void Clear(Point[] pointInput, Pen prevPen)
        {
            Array.Copy(pointInput, prevPoint, prevPoint.Length);
            drawSurface.DrawPolygon(prevPen, prevPoint);
        }

        public Point[] returnCoords()
        {
            return point;
        }

        public override void Draw(Point prevEndCoords, Point startCoords, Point endCoords, Pen prevPen, Pen penReader)
        {
            point[0].X = startCoords.X;
            point[0].Y = startCoords.Y;
            point[1].X = startCoords.X + 10;
            point[1].Y = startCoords.Y + 10;
            point[2].X = startCoords.X +10;
            point[2].Y = startCoords.Y -10;
            point[3].X = startCoords.X -10 ;
            point[3].Y = startCoords.Y + 10;
            point[4].X = startCoords.X - 10;
            point[4].Y = startCoords.Y - 10;


            drawSurface.DrawPolygon(penReader, point);
        }
    }
}
