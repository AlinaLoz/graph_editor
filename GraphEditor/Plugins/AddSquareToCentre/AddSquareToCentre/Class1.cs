using System.Drawing;
using System.IO;
using AddStyleToShape;

namespace AddSquareToCentre
{
    public class AddSquareToCentre : IAddStyleToShape
    {

        public Bitmap ByteToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bitmap2 = new Bitmap(ms);
            return bitmap2;
        }

        public void AddShapeToCentre(byte[] drawSurface, Point start, Point end, int displayWidth,
            int displayHeight)
        {
            int CenterX = (end.X - start.X) / 2 + start.X;
            int CenterY = (end.Y - start.Y) / 2 + start.Y;
            Pen pen = new Pen(Color.DarkRed, 5);
            Bitmap bitmap = new Bitmap(displayWidth, displayHeight);
            Graphics tempGr = Graphics.FromImage(bitmap);
            tempGr.Clear(Color.White);
            tempGr.DrawImage(ByteToImage(drawSurface), 0, 0);
            tempGr.DrawRectangle(pen, CenterX - 5, CenterY - 5, CenterX + 5, CenterY + 5);
        }
    }
}
