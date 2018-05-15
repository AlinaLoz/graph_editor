using System.Windows.Forms;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Drawing;
using System.Collections.Generic;

namespace GraphEditor
{
    class SaveFile: Product_File
    {
        private SaveFileDialog savedialog;
        DataContractJsonSerializer jsonFormatter;

        public SaveFile() {
            savedialog = new SaveFileDialog();
        }

        public void save(List<Shape> shapesList, string nameWorkFile) {
            try
            {
                Type[] knownTypes = new[] { typeof(Circle), typeof(Rectangle), typeof(Line),
                    typeof(Ellipse) };
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Shape>), knownTypes);
                using (FileStream fs = new FileStream(nameWorkFile, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, shapesList);
                    fs.Close();
                }
                MessageBox.Show("File save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void workWithFile(List<Shape> shapesList, ref DisplayManager displayManage, ref string nameWorkFile) {
            DialogResult dialogResult = savedialog.ShowDialog();
            nameWorkFile = Path.GetFullPath(savedialog.FileName);
            MessageBox.Show(nameWorkFile, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!String.Equals(savedialog.FileName, "") && dialogResult != DialogResult.Cancel && dialogResult != DialogResult.Abort) 
                save(shapesList,  nameWorkFile);
        }

        public override void initTool(string title, bool CheckPathExists)
        {
            savedialog.DefaultExt = "json";
            savedialog.Title = title;
            savedialog.CheckPathExists = CheckPathExists;
        }
    }
}
