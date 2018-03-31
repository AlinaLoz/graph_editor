using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;

namespace GraphEditor
{
    class OpenFile : IWorkFile
    {
        private OpenFileDialog opendialog;

        public OpenFile()
        {
            opendialog = new OpenFileDialog();
        }

        public void workWithFile(PictureBox pictureDrawing, ref  Bitmap btmFront, ref Graphics grFront, ref string nameWorkFile)
        {
            DialogResult dialogResult = opendialog.ShowDialog();
            nameWorkFile = Path.GetFullPath(opendialog.FileName);
            if (!String.Equals(opendialog.FileName, "") && dialogResult != DialogResult.Cancel && dialogResult != DialogResult.Abort) ;
            {
                try
                {
                    Image image = Image.FromFile(opendialog.FileName);
                    btmFront.Dispose();
                    btmFront = new Bitmap(image, pictureDrawing.Width, pictureDrawing.Height);
                    grFront = Graphics.FromImage(btmFront);
                    pictureDrawing.BackgroundImage = btmFront;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
            }
        }

        public void initTool(string exp, string title, string filter, bool CheckPathExists) {
            opendialog.DefaultExt = exp;
            opendialog.Title = title;
            opendialog.CheckPathExists = CheckPathExists;
            opendialog.Filter = filter;
        }
    }
}