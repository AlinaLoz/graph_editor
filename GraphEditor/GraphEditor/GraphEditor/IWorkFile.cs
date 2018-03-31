using System.Windows.Forms;
using System.Drawing;

namespace GraphEditor
{
    interface IWorkFile
    {
        void workWithFile(ListShape listShape, PictureBox pictureDrawing, ref Bitmap btmFront, ref Graphics grFront, ref string nameWorkFile);
        void initTool(string title, bool CheckPathExists);
    }
}
