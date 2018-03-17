﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphEditor
{
    class Triangle:Shape
    {
        private Graphics drawSurface;

        private Point[] point = new Point[3];

        public Triangle(Graphics drawSurface)
        {
            this.drawSurface = drawSurface;
            Array.Clear(point, 0, point.Length);
        }

        public override void Draw(Point startCoords, Point endCoords, Pen penReader)
        {
            Double lengthSiteTriangle = Math.Sqrt(Math.Pow((endCoords.X - startCoords.X), 2) + Math.Pow((endCoords.Y - startCoords.Y), 2)) / 2;

            point[0].X = startCoords.X;
            point[0].Y = startCoords.Y;
            point[1].X = endCoords.X;
            point[1].Y = endCoords.Y;
            point[2].X = endCoords.X - 2 * (endCoords.X - startCoords.X);
            point[2].Y = endCoords.Y;

            drawSurface.DrawPolygon(penReader, point);
        }
    }
}
