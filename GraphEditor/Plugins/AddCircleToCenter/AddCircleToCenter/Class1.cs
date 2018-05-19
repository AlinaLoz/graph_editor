using System.Drawing;
using System.IO;
using AddStyleToShape;

namespace AddSquareToCentre
{
    public class AddCircleToCentre : IAddStyleToShape
    {

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

        public void AddShapeToCentre(ref byte[] drawSurface, Point start, Point end, int displayWidth,
            int displayHeight)
        {
            int CenterX = (end.X - start.X) / 2 + start.X;
            int CenterY = (end.Y - start.Y) / 2 + start.Y;
            Pen pen = new Pen(Color.DarkRed, 5);
            Bitmap bitmap = new Bitmap(displayWidth, displayHeight);
            Graphics tempGr = Graphics.FromImage(bitmap);
            tempGr.DrawImage(ByteToImage(drawSurface), 0, 0);
            tempGr.DrawEllipse(pen, CenterX - 5, CenterY - 5, 5, 5);
            drawSurface = ImageToByte(bitmap);
        }
    }
}
