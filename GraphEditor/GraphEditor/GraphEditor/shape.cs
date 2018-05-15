using System.Drawing;
using System.Runtime.Serialization;
using System.IO;
using System;

namespace GraphEditor
{
    [DataContract]
    abstract class Shape
     {
        [DataMember]
        public Point firstPoint;

        [DataMember]
        public Point lastPoint;

        [DataMember]
        public byte[] byteBmp;

        public bool bitmapCancel;

        public void setFirstPoint(Point point)
        {
            bitmapCancel = true;
            firstPoint = point;
        }
        public void setLastPoint(Point point)
        {
            lastPoint = point;
        }

        public void addBmp(Bitmap bitmap)
        {
            byteBmp = ImageToByte(bitmap);
        }

        public Bitmap ByteToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bitmap2 = new Bitmap(ms);
            return bitmap2;
        }

        public byte[] ImageToByte(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public abstract void Draw(Graphics drawSurface);

        public void changeLocation(int pictureDrawingWidth, int pictureDrawingHeight)
        {
            Bitmap bm = new Bitmap(pictureDrawingWidth, pictureDrawingHeight);
            Graphics g = Graphics.FromImage(bm);
            Draw(g);
            byteBmp = ImageToByte(bm);
        }

        protected static float GetWidthShape(Point first, Point second) {
            return Math.Abs(first.X - second.X);
        }

        protected static float GetHightShape(Point first, Point second)
        {
            return Math.Abs(first.Y - second.Y);
        }

        protected static float GetSizeShape(Point first, Point second)
        {
            return (GetWidthShape(first, second) < GetHightShape(first, second) ? GetWidthShape(first, second) : GetHightShape(first, second));
        }

        protected static float GetX(Point first, Point second)
        {
            return (first.X > second.X) ? second.X : first.X;
        }

        protected static float GetY(Point first, Point second)
        {
            return (first.Y > second.Y) ? second.Y : first.Y;
        }
    }
}
