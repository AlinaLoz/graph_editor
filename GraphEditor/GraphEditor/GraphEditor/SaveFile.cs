using System.Windows.Forms;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Drawing;

namespace GraphEditor
{
    class SaveFile:IWorkFile
    {
        private SaveFileDialog savedialog;
        DataContractJsonSerializer jsonFormatter;

        public SaveFile() {
            savedialog = new SaveFileDialog();
        }

        public void save(ListShape listShape, string nameWorkFile) {
            try
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(ListShape));
                using (FileStream fs = new FileStream(nameWorkFile, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, listShape);
                    fs.Close();
                }
                MessageBox.Show("File save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void workWithFile(ListShape listShape, PictureBox pictureDrawing, ref Bitmap btmFront, ref Graphics grFront, ref string nameWorkFile) {
            DialogResult dialogResult = savedialog.ShowDialog();
            nameWorkFile = Path.GetFullPath(savedialog.FileName);
            MessageBox.Show(nameWorkFile, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!String.Equals(savedialog.FileName, "") && dialogResult != DialogResult.Cancel && dialogResult != DialogResult.Abort) 
                save(listShape,  nameWorkFile);
        }

        public void initTool(string title, bool CheckPathExists)
        {
            savedialog.DefaultExt = "json";
            savedialog.Title = title;
            savedialog.CheckPathExists = CheckPathExists;
        }
    }
}
