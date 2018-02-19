using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphEditor
{
    public partial class Paint : Form
    {
        Graphics drawSurface;
        enum TTools {PEN, RECTANGLE, TREANGLE, CIRCLE, ELLIPSE, LINE, RUBBER};

        Pen penReader = new Pen(Color.Black);    
        Point startCoords = new Point(0, 0);
        Point endCoords = new Point(0, 0);
        Point[] point = new Point[3];
        int currSize = 0;

        Point prevEndCoords = new Point(0, 0);
        Pen prevPen = new Pen(Color.White);
        int prevSize = 0;
        Point[] prevPoint = new Point[3];

        TTools currTool = TTools.PEN;
        Boolean isMouseClick = false;

        public Paint()
        {
            InitializeComponent();
        }

        private void yellowColor_Click(object sender, EventArgs e)
        {
            penReader.Color = yellowColor.BackColor;
            defaultColor.BackColor = yellowColor.BackColor;
        }

        private void redColor_Click(object sender, EventArgs e)
        {
            penReader.Color = redColor.BackColor;
            defaultColor.BackColor = redColor.BackColor;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startCoords.X = e.X;
            startCoords.Y = e.Y;
            isMouseClick = true;
        }


        public static void MyDrawingRectangle(Point endCoords, Point startCoords, Pen penReader, Graphics drawSurface)
        {
            if (endCoords.X > startCoords.X && endCoords.Y > startCoords.Y)
                drawSurface.DrawRectangle(penReader, startCoords.X, startCoords.Y, endCoords.X - startCoords.X, endCoords.Y - startCoords.Y);
            else if (endCoords.X > startCoords.X && endCoords.Y < startCoords.Y)
                drawSurface.DrawRectangle(penReader, startCoords.X, endCoords.Y, endCoords.X - startCoords.X, startCoords.Y - endCoords.Y);
            else if (endCoords.X < startCoords.X && endCoords.Y > startCoords.Y)
                drawSurface.DrawRectangle(penReader, endCoords.X, startCoords.Y, startCoords.X - endCoords.X, endCoords.Y - startCoords.Y);
            else if (endCoords.X < startCoords.X && endCoords.Y < startCoords.Y)
                drawSurface.DrawRectangle(penReader, endCoords.X, endCoords.Y, startCoords.X - endCoords.X, startCoords.Y - endCoords.Y);
        }

        public static void MyDrawingEllipse(Point endCoords, Point startCoords, Pen penReader, Graphics drawSurface, int  sizeCircle)
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

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            drawSurface = this.CreateGraphics();

            prevEndCoords.X = endCoords.X;
            prevEndCoords.Y = endCoords.Y;

            endCoords.X = e.X;
            endCoords.Y = e.Y;

            if (isMouseClick)
                switch (currTool)
                {
                    case TTools.PEN:
                        drawSurface.DrawLine(penReader, startCoords, endCoords);
                        startCoords = endCoords;
                        break;
                    case TTools.RECTANGLE:
                        MyDrawingRectangle(prevEndCoords, startCoords, prevPen, drawSurface);
                        MyDrawingRectangle(endCoords, startCoords, penReader, drawSurface);
                        break;
                    case TTools.ELLIPSE:
                        drawSurface.DrawEllipse(prevPen, startCoords.X, startCoords.Y, prevEndCoords.X - startCoords.X, prevEndCoords.Y - startCoords.Y);
                        drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, endCoords.X - startCoords.X, endCoords.Y - startCoords.Y);
                        break;
                    case TTools.LINE:
                        drawSurface.DrawLine(prevPen, startCoords, prevEndCoords);
                        drawSurface.DrawLine(penReader, startCoords, endCoords);
                        break;
                    case TTools.TREANGLE:
                        Array.Copy(point, prevPoint, point.Length);
                        drawSurface.DrawPolygon(prevPen, prevPoint);

                        Double lengthSiteTriangle = Math.Sqrt(Math.Pow((endCoords.X - startCoords.X), 2) + Math.Pow((endCoords.Y - startCoords.Y), 2)) / 2;

                        point[0].X = startCoords.X;
                        point[0].Y = startCoords.Y;
                        point[1].X = endCoords.X;
                        point[1].Y = endCoords.Y;
                        point[2].X = endCoords.X - 2 * (endCoords.X - startCoords.X);
                        point[2].Y = endCoords.Y;

                        drawSurface.DrawPolygon(penReader, point);
                        break;
                    case TTools.CIRCLE:
                        prevSize = currSize;
                        MyDrawingEllipse(prevEndCoords, startCoords, prevPen, drawSurface, prevSize);
                        currSize = (Math.Abs(endCoords.X - startCoords.X) > Math.Abs(endCoords.Y - startCoords.Y)) ? Math.Abs(endCoords.Y - startCoords.Y) : Math.Abs(endCoords.X - startCoords.X);
                        MyDrawingEllipse(endCoords, startCoords, penReader, drawSurface, currSize);
                        break;
                    case TTools.RUBBER:
                        drawSurface.DrawLine(penReader, startCoords, endCoords);
                        startCoords = endCoords;
                        break;
                }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseClick = false;
            currTool = TTools.PEN;

            Array.Clear(prevPoint, 0, prevPoint.Length);
            Array.Clear(point, 0, prevPoint.Length);
            penReader.Width = 1;

            startCoords.X = 0; startCoords.Y = 0;
            endCoords.X = 0; endCoords.Y = 0;
            currSize = 0; prevSize = 0;
            prevEndCoords.X = 0; prevEndCoords.Y = 0;
            penReader.Color = defaultColor.BackColor;

            prevPen.Color = Color.White;
        }

        private void whiteColor_Click(object sender, EventArgs e)
        {
            penReader.Color = whiteColor.BackColor;
            defaultColor.BackColor = whiteColor.BackColor;
        }

        private void blackColor_Click(object sender, EventArgs e)
        {
            penReader.Color = blackColor.BackColor;
            defaultColor.BackColor = blackColor.BackColor;
        }

        private void purpleColor_Click(object sender, EventArgs e)
        {
            penReader.Color = purpleColor.BackColor;
            defaultColor.BackColor = purpleColor.BackColor;
        }

        private void blueColor_Click(object sender, EventArgs e)
        {
            penReader.Color = blueColor.BackColor;
            defaultColor.BackColor = blueColor.BackColor;
        }

        private void greenColor_Click_1(object sender, EventArgs e)
        {
            penReader.Color = greenColor.BackColor;
            defaultColor.BackColor = greenColor.BackColor;
        }

        private void skyBlueColor_Click(object sender, EventArgs e)
        {
            penReader.Color = skyBlueColor.BackColor;
            defaultColor.BackColor = skyBlueColor.BackColor;
        }

        private void yellowColor_Click_1(object sender, EventArgs e)
        {
            penReader.Color = yellowColor.BackColor;
            defaultColor.BackColor = yellowColor.BackColor;
        }

        private void toolPen_Click(object sender, EventArgs e)
        {
            currTool = TTools.PEN;
        }

        private void toolLine_Click(object sender, EventArgs e)
        {
            currTool = TTools.LINE;
        } 

        private void toolRectangle_Click(object sender, EventArgs e)
        {
            currTool = TTools.RECTANGLE;
        }

        private void toolElipse_Click(object sender, EventArgs e)
        {
            currTool = TTools.ELLIPSE;
        }

        private void toolTreangle_Click(object sender, EventArgs e)
        {
            currTool = TTools.TREANGLE;
        }

        private void toolCircle_Click(object sender, EventArgs e)
        {
            currTool = TTools.CIRCLE;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            drawSurface = this.CreateGraphics();
            drawSurface.Clear(Color.White);
        }

        private void toolRubber_Click(object sender, EventArgs e)
        {
            penReader.Width = 25;
            currTool = TTools.RUBBER;
            penReader.Color = Color.White;
        }
    }
}
