using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace GraphEditor
{
    [DataContract]
    class ListShape
    {
        [DataMember]
        private List<byte[]> listShapeByte;

        public ListShape()
        {
            listShapeByte = new List<byte[]>();
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

        public void  WriteOnImage(Graphics tempGr)
        {
            foreach (byte[] temp in listShapeByte)
                tempGr.DrawImage(ByteToImage(temp), 0, 0);
        }
    }
}
