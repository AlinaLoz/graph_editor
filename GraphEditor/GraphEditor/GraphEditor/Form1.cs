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
        enum TTools { PEN, RECTANGLE, TREANGLE, CIRCLE, ELLIPSE, LINE, RUBBER };
        Graphics drawSurface;
        Point startCoords = new Point(0, 0);
        Point endCoords = new Point(0, 0);
        Point prevEndCoords = new Point(0, 0);
        float diametrCircle = 0;
        Point[] point = new Point[3] {
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
        };

        Pen penReader = new Pen(Color.Black);
        Pen prevPen = new Pen(Color.White);
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
                        Rectangle rectangle = new Rectangle(drawSurface);
                        rectangle.Draw(prevEndCoords,  startCoords,  endCoords,  prevPen,  penReader);
                        break;
                    case TTools.ELLIPSE:
                        Ellipse ellipse = new Ellipse(drawSurface);
                        ellipse.Draw(prevEndCoords, startCoords, endCoords, prevPen, penReader);
                        break;
                    case TTools.LINE:
                        Line line = new Line(drawSurface);
                        line.Draw(prevEndCoords, startCoords, endCoords, prevPen, penReader);
                        break;
                    case TTools.TREANGLE:
                        Triangle triangle = new Triangle(drawSurface);
                        triangle.Clear(point, prevPen);
                        triangle.Draw(prevEndCoords, startCoords, endCoords, prevPen, penReader);
                        point = triangle.returnCoords();
                        break;
                    case TTools.CIRCLE:
                        Circle circle = new Circle(drawSurface);
                        circle.getSize(diametrCircle);
                        circle.Draw(prevEndCoords, startCoords, endCoords, prevPen, penReader);
                        diametrCircle = circle.returnSize();
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
            penReader.Width = 1;
            endCoords.X = 0; endCoords.Y = 0;
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
