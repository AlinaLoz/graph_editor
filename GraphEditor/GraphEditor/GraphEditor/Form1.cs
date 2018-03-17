﻿using System;
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

        Point startCoords = new Point(0, 0);
        Point endCoords = new Point(0, 0);
        float diametrCircle = 0;


        Graphics drawSurface;
        Bitmap btmFront;
        Graphics grFront;


        Pen penReader = new Pen(Color.Black);
        Pen rubberPen = new Pen(Color.White, 20);
        TTools currTool = TTools.PEN;
        Boolean isMouseClick;

        public Paint()
        {
            InitializeComponent();

            btmFront = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
            grFront = Graphics.FromImage(btmFront);
            pictureDrawing.BackgroundImage = btmFront;

            isMouseClick = false;
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


        private void ToolDraw()
        {
            switch (currTool)
            {
                case TTools.PEN:
                    drawSurface = grFront;
                    drawSurface.DrawLine(penReader, startCoords, endCoords);
                    startCoords = endCoords;
                    break;
                case TTools.RECTANGLE:
                    Rectangle rectangle = new Rectangle(drawSurface);
                    rectangle.Draw(startCoords, endCoords, penReader);
                    break;
                case TTools.ELLIPSE:
                    Ellipse ellipse = new Ellipse(drawSurface);
                    ellipse.Draw(startCoords, endCoords, penReader);
                    break;
                case TTools.LINE:
                    Line line = new Line(drawSurface);
                    line.Draw(startCoords, endCoords, penReader);
                    break;
                case TTools.TREANGLE:
                    Triangle triangle = new Triangle(drawSurface);
                    triangle.Draw(startCoords, endCoords, penReader);
                    break;
                case TTools.CIRCLE:
                    Circle circle = new Circle(drawSurface);
                    circle.getSize(diametrCircle);
                    circle.Draw(startCoords, endCoords, penReader);
                    diametrCircle = circle.returnSize();
                    break;
                case TTools.RUBBER:
                    drawSurface = grFront;
                    drawSurface.DrawLine(penReader, startCoords, endCoords);
                    startCoords = endCoords;
                    break;
            }
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
            btmFront.Dispose();
            pictureDrawing.BackgroundImage = null;
            pictureDrawing.Image = null;

        }

        private void toolRubber_Click(object sender, EventArgs e)
        {
            penReader.Width = 25;
            currTool = TTools.RUBBER;
            penReader.Color = Color.White;
        }

        private void pictureDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            startCoords.X = e.X;
            startCoords.Y = e.Y;
            isMouseClick = true;
        }

        private void pictureDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
            Graphics g = Graphics.FromImage(bm);
            drawSurface = g;

            if (isMouseClick)
            {
                ToolDraw();
                pictureDrawing.Image = bm;
            }
            endCoords.X = e.X;
            endCoords.Y = e.Y;
        }

        private void pictureDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseClick = false;
            //currTool = TTools.PEN;

            penReader.Width = 1;
            penReader.Color = defaultColor.BackColor;

            drawSurface = grFront;
            ToolDraw();
        }

        private void toolDelete_MouseUp(object sender, MouseEventArgs e)
        {
            if (pictureDrawing.Image == null) {
                btmFront = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                grFront = Graphics.FromImage(btmFront);
                pictureDrawing.BackgroundImage = btmFront;
                pictureDrawing.Image = btmFront;
            }
        }
    }
}
