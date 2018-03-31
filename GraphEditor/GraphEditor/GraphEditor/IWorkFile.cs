using System.Windows.Forms;
using System.Drawing;

namespace GraphEditor
{
    interface IWorkFile
    {
        void workWithFile(PictureBox pictureDrawing, ref Bitmap btmFront, ref Graphics grFront, ref string nameWorkFile);
        void initTool(string exp, string title, string filter, bool CheckPathExists);
    }
}
