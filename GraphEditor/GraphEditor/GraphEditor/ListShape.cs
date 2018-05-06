using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Forms;


namespace GraphEditor
{
     class InfoAboutStructute
     {
        public Point start, end;
        public TTools tools;

        public InfoAboutStructute(Point start, Point end, TTools tools)
        {
            this.tools = tools;
            this.start = start;
            this.end = end;
        }

        public void ChangeValue(Point newStart, Point newEnd)
        {
            this.start = newStart;
            this.end = newEnd;
        }
     }

    [DataContract]
    class ListShape
    {
        [DataMember]
        public List<byte[]> listShapeByte;

        public List<bool> bitmapCancel;

        public List<InfoAboutStructute> listInfoAboutStructure;

        public int CountBitmap { get { return listShapeByte.Count; } set { } }

        public ListShape()
        {
            listShapeByte = new List<byte[]>();
            bitmapCancel = new List<bool>();
            listInfoAboutStructure = new List<InfoAboutStructute>();
        }

        public void UpDateBitmap(int resultFrame, int pictureDrawingWidth, int pictureDrawingHeight )
        {
            Bitmap bm = new Bitmap(pictureDrawingWidth, pictureDrawingHeight);
            Graphics g = Graphics.FromImage(bm);
            Pen penReader = new Pen(Color.Black);
            switch (listInfoAboutStructure[resultFrame].tools)
            {
                case TTools.RECTANGLE:
                    Rectangle rectangle = new Rectangle(g);
                    rectangle.Draw(listInfoAboutStructure[resultFrame].start, listInfoAboutStructure[resultFrame].end, penReader);
                    break;
                case TTools.ELLIPSE:
                    Ellipse ellipse = new Ellipse(g);
                    ellipse.Draw(listInfoAboutStructure[resultFrame].start, listInfoAboutStructure[resultFrame].end, penReader);
                    break;
                case TTools.TREANGLE:
                    Triangle triangle = new Triangle(g);
                    triangle.Draw(listInfoAboutStructure[resultFrame].start, listInfoAboutStructure[resultFrame].end, penReader);
                    break;
            }
            listShapeByte[resultFrame] = ImageToByte(bm);
        }

        public byte[] ImageToByte(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public void  AddShape(Bitmap bitmap)
        {
           MessageBox.Show("here", "dwq", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            listShapeByte.Add(ImageToByte(bitmap));
        }

        public void AddInfoAboutShape(Point start, Point end, TTools tools)
        {
            listInfoAboutStructure.Add(new InfoAboutStructute(start, end, tools));
        }

        public void Remove()
        {
            while (listShapeByte.Count != 0)
            {
                listInfoAboutStructure.RemoveAt(0);
                listShapeByte.RemoveAt(0);
                bitmapCancel.RemoveAt(0);
            }
        }

        public Bitmap ByteToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bitmap2 = new Bitmap(ms);
            return bitmap2;
        }

        public void CtrlZ()
        {
            if (bitmapCancel.LastIndexOf(true) > -1)
                bitmapCancel[bitmapCancel.LastIndexOf(true)] = false;
        }

        public void CtrlY(bool isCtrlZ)
        {
            if (isCtrlZ)
            {
                if (bitmapCancel.IndexOf(false) > -1)
                    bitmapCancel[bitmapCancel.IndexOf(false)] = true;
            }
            else
               if (bitmapCancel.LastIndexOf(false) > -1)
                    bitmapCancel[bitmapCancel.LastIndexOf(false)] = true;
        }

        public void  WriteOnImage(Graphics tempGr)
        {
            int i = 0;
            foreach (byte[] temp in listShapeByte)
            {
                // MessageBox.Show(bitmapCancel.IndexOf(i).ToString(), "sdas");
                if (listShapeByte.Count != 0 && bitmapCancel == null ||  bitmapCancel[i])  
                    tempGr.DrawImage(ByteToImage(temp), 0, 0);
                i++;
            } 
        }
    }
}
