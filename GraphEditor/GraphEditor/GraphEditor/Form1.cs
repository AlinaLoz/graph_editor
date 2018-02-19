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
        Pen penReader = new Pen(Color.Black);
        Point startCoords = new Point(0, 0);
        Point endCoords = new Point(0, 0);

        Point prevEndCoords = new Point(0, 0);
        Pen prevPen = new Pen(Color.White);

        int stateMouse = 0, chooseTool = 0;
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
            switch (chooseTool) {
                case 0:
                    stateMouse = 1;
                    break;
                case 1:
                    stateMouse = 2;
                    break;
                case 2:
                    stateMouse = 3;
                    break;
                case 3:
                    stateMouse = 4;
                    break;
                case 4:
                    stateMouse = 5;
                    break;
                case 5:
                    stateMouse = 6;
                    break;
            }
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

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            drawSurface = this.CreateGraphics();

            prevEndCoords.X = endCoords.X;
            prevEndCoords.Y = endCoords.Y;

            endCoords.X = e.X;
            endCoords.Y = e.Y;
            if (stateMouse == 1)
            {
                drawSurface.DrawLine(penReader, startCoords, endCoords);
                startCoords = endCoords;
            }
            if (stateMouse == 2)
            {
                MyDrawingRectangle(prevEndCoords, startCoords, prevPen, drawSurface);
                MyDrawingRectangle(endCoords, startCoords, penReader, drawSurface);
            }
            if (stateMouse == 3)
            {
                drawSurface.DrawEllipse(prevPen, startCoords.X, startCoords.Y, prevEndCoords.X - startCoords.X, prevEndCoords.Y - startCoords.Y);
                drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, endCoords.X - startCoords.X, endCoords.Y - startCoords.Y);
            }
            if (stateMouse == 4)
            {
                drawSurface.DrawLine(prevPen, startCoords, prevEndCoords);
                drawSurface.DrawLine(penReader, startCoords, endCoords);
            }
            if (stateMouse == 5)
            {
                Point[] point = new Point[3];
                Double lengthSiteTriangle = Math.Sqrt(Math.Pow((endCoords.X - startCoords.X), 2) + Math.Pow((endCoords.Y - startCoords.Y), 2)) / 2;
                point[0].X = startCoords.X;
                point[0].Y = startCoords.Y;
                point[1].X = endCoords.X;
                point[1].Y = endCoords.Y;
                point[2].X = endCoords.X - 2 * (endCoords.X - startCoords.X);
                point[2].Y = endCoords.Y;
                drawSurface.Clear(Color.White);
                drawSurface.DrawPolygon(penReader, point);
            }
            if (stateMouse == 6)
            {
                drawSurface.Clear(Color.White);
                int sizeCircle = (Math.Abs(endCoords.X - startCoords.X) > Math.Abs(endCoords.Y - startCoords.Y)) ? Math.Abs(endCoords.Y - startCoords.Y) : Math.Abs(endCoords.X - startCoords.X);
                if (endCoords.X > startCoords.X && endCoords.Y > startCoords.Y)
                    drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, sizeCircle, sizeCircle);
                else if (endCoords.X > startCoords.X && endCoords.Y < startCoords.Y)
                    drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, sizeCircle, -sizeCircle);
                else if (endCoords.X < startCoords.X && endCoords.Y > startCoords.Y)
                    drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, -sizeCircle, sizeCircle);
                else if (endCoords.X < startCoords.X && endCoords.Y < startCoords.Y)
                    drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, -sizeCircle, -sizeCircle);
            }
            if (stateMouse == 7)
            {
                drawSurface.Clear(Color.White);
                int sizeSquare = (Math.Abs(endCoords.X - startCoords.X) < Math.Abs(endCoords.Y - startCoords.Y)) ? Math.Abs(endCoords.Y - startCoords.Y) : Math.Abs(endCoords.X - startCoords.X);
                if (endCoords.X > startCoords.X && endCoords.Y > startCoords.Y)
                    drawSurface.DrawRectangle(penReader, startCoords.X, startCoords.Y, sizeSquare, sizeSquare);
                else if (endCoords.X > startCoords.X && endCoords.Y < startCoords.Y)
                    drawSurface.DrawRectangle(penReader, startCoords.X, endCoords.Y, sizeSquare, sizeSquare);
                else if (endCoords.X < startCoords.X && endCoords.Y > startCoords.Y)
                    drawSurface.DrawRectangle(penReader, endCoords.X, startCoords.Y, sizeSquare, sizeSquare);
                else if (endCoords.X < startCoords.X && endCoords.Y < startCoords.Y)
                    drawSurface.DrawRectangle(penReader, endCoords.X, endCoords.Y, sizeSquare, sizeSquare);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            stateMouse = 0;
            chooseTool = 0;
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
            chooseTool = 0;
        }

        private void toolLine_Click(object sender, EventArgs e)
        {
            chooseTool = 3;
        } 

        private void toolRectangle_Click(object sender, EventArgs e)
        {
            chooseTool = 1;
        }

        private void toolElipse_Click(object sender, EventArgs e)
        {
            chooseTool = 2;
        }

        private void toolTreangle_Click(object sender, EventArgs e)
        {
            chooseTool = 4;
        }

        private void toolCircle_Click(object sender, EventArgs e)
        {
            chooseTool = 5;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            drawSurface = this.CreateGraphics();
            drawSurface.Clear(Color.White);
        }
    }
}
