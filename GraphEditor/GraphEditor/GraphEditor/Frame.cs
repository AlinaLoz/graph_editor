using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphEditor
{
    class Frame
    {
        private static Frame instance;
        private PictureBox bpSelectable;
        private bool isDown;
        private Point locat;
        private int numberFigure;

        public static Frame getInstance()
        {
            if (instance == null)
                instance = new Frame();
            return instance;
        }

        public bool IsExistFrame { get { return (bpSelectable == null) ? false : true; } }

        public void DeleteFrame(List<Shape> shapesList, int pictureDrawingWidth, int pictureDrawingHeight)
        {
            Point endCoords = new Point(bpSelectable.Location.X + bpSelectable.Image.Width, 
                bpSelectable.Location.Y + bpSelectable.Image.Height);

            shapesList[numberFigure].firstPoint = bpSelectable.Location;
            shapesList[numberFigure].lastPoint = endCoords;

            shapesList[numberFigure].bitmapCancel = true;
            shapesList[numberFigure].changeLocation(pictureDrawingWidth, pictureDrawingHeight);

            bpSelectable.Dispose();
            bpSelectable = null;
            isDown = false;
        }

        public bool CreateFrame(List<Shape> listShape, Point currPoint, PictureBox pictureDrawing)
        {
            foreach (Shape shape in listShape)
            {
                if (shape is ISelectable && ((ISelectable)shape).isHighLight(currPoint))
                {
                    this.numberFigure = listShape.IndexOf(shape);
                    shape.bitmapCancel = false;

                    bpSelectable = new PictureBox();
                    bpSelectable.Name = "bpSelectable";
                    bpSelectable.Parent = pictureDrawing;
                    bpSelectable.BackColor = Color.Transparent;
                    bpSelectable.BorderStyle = BorderStyle.FixedSingle;
                    bpSelectable.Location = new Point(shape.firstPoint.X, shape.firstPoint.Y);
                    bpSelectable.Size = new Size(Math.Abs(shape.lastPoint.X - shape.firstPoint.X), Math.Abs(shape.lastPoint.Y - shape.firstPoint.Y));
                    bpSelectable.Image = new Bitmap(Math.Abs(shape.lastPoint.X - shape.firstPoint.X), Math.Abs(shape.lastPoint.Y - shape.firstPoint.Y));
                    Graphics qw = Graphics.FromImage(bpSelectable.Image);
                    shape.firstPoint.X -= bpSelectable.Location.X;
                    shape.firstPoint.Y -= bpSelectable.Location.Y;
                    shape.lastPoint.X -= bpSelectable.Location.X;
                    shape.lastPoint.Y -= bpSelectable.Location.Y;
                    shape.Draw(qw);
                    this.AddMethodToPictureDrawing();
                    return true;
                }
            }
            return false;
        }

        private void AddMethodToPictureDrawing() {
            bpSelectable.MouseMove += new MouseEventHandler(bpSelectable_MouseMove);
            bpSelectable.MouseDown += new MouseEventHandler(bpSelectable_MouseDown);
            bpSelectable.MouseUp += new MouseEventHandler(bpSelectable_MouseUp);
        }

        private void bpSelectable_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void bpSelectable_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            locat = new Point(e.X, e.Y);
        }

        private void bpSelectable_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.SizeAll;
            int x = bpSelectable.Location.X;
            int y = bpSelectable.Location.Y;
            if (isDown) 
            {
                bpSelectable.Location = new Point(x + (e.X - locat.X),  y + (e.Y - locat.Y));
            }
        }
    }
}
