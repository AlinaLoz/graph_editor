using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphEditor
{
    class Circle:Shape
    {
        private Graphics drawSurface;
        private float prevSize;
        private float currSize;

         
        public Circle(Graphics drawSurface)
        {
            this.drawSurface = drawSurface;
            currSize = 0;
            prevSize = 0;
        }

        public void getSize(float inputSize)
        {
            prevSize = inputSize;
        }

        public float returnSize() {
            return currSize;
        }

        public override void Draw(Point startCoords, Point endCoords, Pen penReader)
        {
            currSize = GetSizeShape(startCoords, endCoords);
             MyDrawingEllipse(endCoords, startCoords, penReader, drawSurface, currSize);
        }

        public static void MyDrawingEllipse(Point endCoords, Point startCoords, Pen penReader, Graphics drawSurface, float sizeCircle)
        {
            if (endCoords.X > startCoords.X && endCoords.Y > startCoords.Y)
                drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, sizeCircle, sizeCircle);
            else if (endCoords.X > startCoords.X && endCoords.Y < startCoords.Y)
                drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, sizeCircle, -sizeCircle);
            else if (endCoords.X < startCoords.X && endCoords.Y > startCoords.Y)
                drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, -sizeCircle, sizeCircle);
            else if (endCoords.X < startCoords.X && endCoords.Y < startCoords.Y)
                drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, -sizeCircle, -sizeCircle);
        }

    }
}
