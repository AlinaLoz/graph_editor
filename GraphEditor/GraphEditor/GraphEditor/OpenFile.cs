using System.Windows.Forms;
using System.Drawing;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace GraphEditor
{
    class OpenFile : IWorkFile
    {
        private OpenFileDialog opendialog;

        public OpenFile()
        {
            opendialog = new OpenFileDialog();
        }

        public void workWithFile(ListShape listShape, PictureBox pictureDrawing, ref Bitmap btmFront, ref Graphics grFront, ref string nameWorkFile)
        {
            try
            {
                DialogResult dialogResult = opendialog.ShowDialog();
                nameWorkFile = Path.GetFullPath(opendialog.FileName);
                if (!String.Equals(opendialog.FileName, "") && dialogResult != DialogResult.Cancel && dialogResult != DialogResult.Abort)
                {
                    ListShape tmpListShape;
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(listShape.GetType());
                    using (FileStream fs = new FileStream(nameWorkFile, FileMode.OpenOrCreate))
                    {
                        listShape.Remove();

                        tmpListShape = new ListShape();
                        tmpListShape = jsonFormatter.ReadObject(fs) as ListShape;
                        fs.Close();
                    }
                    Bitmap bitmap = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                    Graphics tempGr = Graphics.FromImage(bitmap);
                    tempGr.Clear(Color.White);

                    tmpListShape.WriteOnImage(tempGr);

                    btmFront.Dispose();
                    btmFront = new Bitmap(bitmap, pictureDrawing.Width, pictureDrawing.Height);
                    grFront = Graphics.FromImage(btmFront);

                    pictureDrawing.BackgroundImage = btmFront;
                    pictureDrawing.Image = btmFront;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void initTool(string title, bool CheckPathExists) {
            opendialog.DefaultExt = "json";
            opendialog.Title = title;
            opendialog.CheckPathExists = CheckPathExists;
        }
    }
}