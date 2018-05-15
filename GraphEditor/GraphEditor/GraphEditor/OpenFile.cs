using System.Windows.Forms;
using System.Drawing;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

namespace GraphEditor
{
    class OpenFile : Product_File
    {
        private OpenFileDialog opendialog;

        public OpenFile()
        {
            opendialog = new OpenFileDialog();
        }

        public static void WriteOnImage(Graphics tempGr, List<Shape> shapesList)
        {
            byte[] temp;
            foreach (Shape shape in shapesList)
            {
                if (shape.bitmapCancel)
                {
                    temp = shape.byteBmp;
                    tempGr.DrawImage(shape.ByteToImage(temp), 0, 0);
                } 
            }
        }

        public override void workWithFile(List<Shape> shapesList, ref DisplayManager displayManager, ref string nameWorkFile)
        {
            try
            {
                DialogResult dialogResult = opendialog.ShowDialog();
                nameWorkFile = Path.GetFullPath(opendialog.FileName);
                if (!String.Equals(opendialog.FileName, "") && dialogResult != DialogResult.Cancel && dialogResult != DialogResult.Abort)
                {
                    Type[] knownTypes = new[] { typeof(Circle), typeof(Rectangle), typeof(Line),
                    typeof(Ellipse) };
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(shapesList.GetType(), knownTypes);
                    using (FileStream fs = new FileStream(nameWorkFile, FileMode.OpenOrCreate))
                    {
                        shapesList.Clear();
                        shapesList = jsonFormatter.ReadObject(fs) as List<Shape>;
                        fs.Close();
                    }
                    Bitmap bitmap = new Bitmap(displayManager.pictureDrawing.Width, displayManager.pictureDrawing.Height);
                    Graphics tempGr = Graphics.FromImage(bitmap);
                    tempGr.Clear(Color.White);

                    WriteOnImage(tempGr, shapesList);

                    displayManager.DeleteAll();
                    displayManager.InitComponent(bitmap);
                }
            }
            catch
            {
                MessageBox.Show("Неправильный файл", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MessageBox.Show(ex.ToString(), "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void initTool(string title, bool CheckPathExists) {
            opendialog.DefaultExt = "json";
            opendialog.Title = title;
            opendialog.CheckPathExists = CheckPathExists;
        }
    }
}