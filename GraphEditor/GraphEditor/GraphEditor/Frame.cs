using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphEditor
{
    class Frame
    {
        private PictureBox bpSelectable;
        private bool isDown;
        private Point locat;
        int resultFrame;

        public bool IsExistFrame { get{ return (bpSelectable == null) ? false : true; } }

        public void DeleteFrame(ListShape listShape, int pictureDrawingWidth, int pictureDrawingHeight)
        {
            Point endCoords = new Point(bpSelectable.Location.X + bpSelectable.Image.Width, 
                bpSelectable.Location.Y + bpSelectable.Image.Height);
            listShape.listInfoAboutStructure[resultFrame].ChangeValue(bpSelectable.Location, endCoords);

            listShape.bitmapCancel[resultFrame] = true;
            listShape.UpDateBitmap(resultFrame, pictureDrawingWidth, pictureDrawingHeight);
            bpSelectable.Dispose();
            bpSelectable = null;
            isDown = false;
        }

        public void CreateFrame(ListShape listShape, Point currPoint, PictureBox pictureDrawing)
        {
            if ((resultFrame = SortFigure(listShape, currPoint)) == -1)
            {
                return;
            }
            if (bpSelectable != null) {
                return;
            }
            bpSelectable = new PictureBox();
            isDown = false;

            bpSelectable.Location = new Point(listShape.listInfoAboutStructure[resultFrame].start.X - 5,
                listShape.listInfoAboutStructure[resultFrame].start.Y - 5);
            bpSelectable.Name = "bpSelectable";

            bpSelectable.Size = new Size(listShape.listInfoAboutStructure[resultFrame].end.X - listShape.listInfoAboutStructure[resultFrame].start.X + 10,
              listShape.listInfoAboutStructure[resultFrame].end.Y - listShape.listInfoAboutStructure[resultFrame].start.Y + 10);
            bpSelectable.Image = new Bitmap(listShape.listInfoAboutStructure[resultFrame].end.X - listShape.listInfoAboutStructure[resultFrame].start.X + 10,
              listShape.listInfoAboutStructure[resultFrame].end.Y - listShape.listInfoAboutStructure[resultFrame].start.Y + 10);

            bpSelectable.Parent = pictureDrawing;
            bpSelectable.BackColor = Color.Transparent;
            bpSelectable.BorderStyle = BorderStyle.FixedSingle;
        
            Graphics qw = Graphics.FromImage(bpSelectable.Image);
            switch (listShape.listInfoAboutStructure[resultFrame].tools)
            {
                case TTools.RECTANGLE:
                    Rectangle rectangle = new Rectangle(qw);
                    rectangle.CreateFrame(listShape.listInfoAboutStructure[resultFrame].start.X - bpSelectable.Location.X,
                        listShape.listInfoAboutStructure[resultFrame].start.Y - bpSelectable.Location.Y,
                        listShape.listInfoAboutStructure[resultFrame].end.X - bpSelectable.Location.X,
                         listShape.listInfoAboutStructure[resultFrame].end.Y - bpSelectable.Location.Y);
                    break;
                case TTools.ELLIPSE:
                    Ellipse ellipse = new Ellipse(qw);
                    ellipse.CreateFrame(listShape.listInfoAboutStructure[resultFrame].start.X - bpSelectable.Location.X,
                        listShape.listInfoAboutStructure[resultFrame].start.Y - bpSelectable.Location.Y,
                        listShape.listInfoAboutStructure[resultFrame].end.X - bpSelectable.Location.X,
                         listShape.listInfoAboutStructure[resultFrame].end.Y - bpSelectable.Location.Y);
                    break;
                case TTools.TREANGLE:
                    Triangle triangle = new Triangle(qw);
                    triangle.CreateFrame(listShape.listInfoAboutStructure[resultFrame].start.X - bpSelectable.Location.X,
                        listShape.listInfoAboutStructure[resultFrame].start.Y - bpSelectable.Location.Y,
                        listShape.listInfoAboutStructure[resultFrame].end.X - bpSelectable.Location.X,
                         listShape.listInfoAboutStructure[resultFrame].end.Y - bpSelectable.Location.Y);
                    break;
            }
            listShape.bitmapCancel[resultFrame] = false;
            this.AddMethodToPictureDrawing();
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

        private int SortFigure(ListShape listShape, Point currPoint)
        {
            int i = 0;
            foreach (byte[] temp in listShape.listShapeByte)
            {
                if (listShape.listInfoAboutStructure[i].tools == TTools.PEN || listShape.listInfoAboutStructure[i].tools == TTools.CIRCLE) {
                    return -1;      
                }
                var currWidth = listShape.listInfoAboutStructure[i].end.X - listShape.listInfoAboutStructure[i].start.X;
                var currHeigth = listShape.listInfoAboutStructure[i].end.Y - listShape.listInfoAboutStructure[i].start.Y;
                var startX = listShape.listInfoAboutStructure[i].start.X;
                var startY = listShape.listInfoAboutStructure[i].start.Y;
                Bitmap bitmap = listShape.ByteToImage(temp);

                for (int y = -5; y < currHeigth + 5; y++)
                {
                    for (int x = -5; x < currWidth + 5; x++)
                    {
                        if ( listShape.listInfoAboutStructure[i].start.X + x == currPoint.X && listShape.listInfoAboutStructure[i].start.Y + y == currPoint.Y &&
                             bitmap.GetPixel(currPoint.X, currPoint.Y).Name != "0" &&
                             bitmap.GetPixel(currPoint.X, currPoint.Y) != Color.Transparent
                             && bitmap.GetPixel(currPoint.X, currPoint.Y) != Color.White && 
                             bitmap.GetPixel(currPoint.X, currPoint.Y) != Color.Brown)
                         {
                            MessageBox.Show("dsdf", "sa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            switch (listShape.listInfoAboutStructure[i].tools)
                            {
                                 case TTools.ELLIPSE:
                                     return i;
                                 case TTools.RECTANGLE:
                                     return i;
                                 case TTools.TREANGLE:
                                     return i;
                            }
                        }
                    }  
                }
                i++;
            }
            return -1;
        }
    }
}
