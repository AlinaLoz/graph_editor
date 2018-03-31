using System.Windows.Forms;
using System;
using System.Drawing;
using System.IO;

namespace GraphEditor
{
    class SaveFile:IWorkFile
    {
        private SaveFileDialog savedialog;

        public SaveFile() {
            savedialog = new SaveFileDialog();
        }

        public void save(PictureBox pictureDrawing, ref Bitmap btmFront, ref Graphics grFront, string nameWorkFile) {
            try
            {
                Bitmap tempBmp = (Bitmap)(pictureDrawing.BackgroundImage as Bitmap).Clone();
                Graphics tempGr = Graphics.FromImage(tempBmp);
                tempGr.Clear(Color.White);
                tempGr.DrawImage(pictureDrawing.BackgroundImage as Bitmap, 0, 0);
                tempBmp.Save(nameWorkFile, System.Drawing.Imaging.ImageFormat.Bmp);
                MessageBox.Show("File save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void workWithFile(PictureBox pictureDrawing,ref Bitmap btmFront, ref Graphics grFront, ref string nameWorkFile) {
            DialogResult dialogResult = savedialog.ShowDialog();
            nameWorkFile = Path.GetFullPath(savedialog.FileName);
            MessageBox.Show(nameWorkFile, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!String.Equals(savedialog.FileName, "") && dialogResult != DialogResult.Cancel && dialogResult != DialogResult.Abort) ;
                save(pictureDrawing, ref btmFront, ref grFront, nameWorkFile);
        }

        public void initTool(string exp, string title, string filter, bool CheckPathExists)
        {
            savedialog.DefaultExt = exp;
            savedialog.Title = title;
            savedialog.CheckPathExists = CheckPathExists;
            savedialog.Filter = filter;
        }
    }
}
