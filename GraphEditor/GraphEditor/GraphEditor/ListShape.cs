using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows.Forms;

namespace GraphEditor
{
    [DataContract]
    class ListShape
    {
        [DataMember]
        private List<byte[]> listShapeByte;
        public List<bool> bitmapCancel;

        public int CountBitmap { get { return listShapeByte.Count; } set { } }
        public ListShape()
        {
            listShapeByte = new List<byte[]>();
            bitmapCancel = new List<bool>();
        }

        private byte[] ImageToByte(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public void  AddShape(Bitmap bitmap)
        {
            listShapeByte.Add(ImageToByte(bitmap));
        }

        public void Remove()
        {
            while (listShapeByte.Count != 0)
                listShapeByte.RemoveAt(0);
        }

        private Bitmap ByteToImage(byte[] arr)
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
                if (bitmapCancel[i] == true)  
                    tempGr.DrawImage(ByteToImage(temp), 0, 0);
                i++;
            } 
        }
    }
}
