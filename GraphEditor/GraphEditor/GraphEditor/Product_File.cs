using System.Windows.Forms;
using System.Drawing;

namespace GraphEditor
{
    abstract class Product_File
    {
        public abstract void workWithFile(ListShape listShape, PictureBox pictureDrawing, ref Bitmap btmFront, ref Graphics grFront, ref string nameWorkFile);
        public abstract void initTool(string title, bool CheckPathExists);
    }
}
