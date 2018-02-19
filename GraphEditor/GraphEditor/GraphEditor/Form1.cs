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
    public partial class Form1 : Form
    {
        Graphics drawSurface; 
        Pen penReader = new Pen(Color.Black);
        Point startCoords = new Point(0, 0);
        Point endCoords = new Point(0, 0);
        int stateMouse = 0;
        public Form1()
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


        private void greenColor_Click(object sender, EventArgs e)
        {
           penReader.Color = greenColor.BackColor;
           defaultColor.BackColor = greenColor.BackColor;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startCoords.X = e.X;
            startCoords.Y = e.Y;
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked && !checkBox5.Checked)
            {
                stateMouse = 1;
            }
            else if (checkBox1.Checked)
            {
                stateMouse = 2;
            }
            else if (checkBox2.Checked)
            {
                stateMouse = 3;
            }
            else if (checkBox3.Checked)
            {
                stateMouse = 4;
            }
            else if (checkBox4.Checked)
            {
                stateMouse = 5;
            }
            else if (checkBox5.Checked) {
                stateMouse = 6;
            }
              
            Console.WriteLine("START:\n" + startCoords.X + " " + startCoords.Y + "\n" + e.X + " " + e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            drawSurface = this.CreateGraphics();
            endCoords.X = e.X;
            endCoords.Y = e.Y;
            if (stateMouse == 1)
            {
                drawSurface.DrawLine(penReader, startCoords, endCoords);
                startCoords = endCoords;
            }
            if (stateMouse == 2)
            {
                drawSurface.Clear(Color.White);
                if (endCoords.X > startCoords.X && endCoords.Y > startCoords.Y)
                    drawSurface.DrawRectangle(penReader, startCoords.X, startCoords.Y, endCoords.X - startCoords.X, endCoords.Y - startCoords.Y);
                else if (endCoords.X > startCoords.X && endCoords.Y < startCoords.Y)
                    drawSurface.DrawRectangle(penReader, startCoords.X, endCoords.Y, endCoords.X - startCoords.X, startCoords.Y - endCoords.Y);
                else if (endCoords.X < startCoords.X && endCoords.Y > startCoords.Y)
                    drawSurface.DrawRectangle(penReader, endCoords.X, startCoords.Y, startCoords.X - endCoords.X, endCoords.Y - startCoords.Y);
                else if (endCoords.X < startCoords.X && endCoords.Y < startCoords.Y)
                    drawSurface.DrawRectangle(penReader, endCoords.X, endCoords.Y, startCoords.X - endCoords.X, startCoords.Y - endCoords.Y);
            }
            if (stateMouse == 3)
            {
                drawSurface.Clear(Color.White);
                drawSurface.DrawEllipse(penReader, startCoords.X, startCoords.Y, endCoords.X - startCoords.X, endCoords.Y - startCoords.Y);
            }
            if (stateMouse == 4)
            {
                drawSurface.Clear(Color.White);
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
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            stateMouse = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
