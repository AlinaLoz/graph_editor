using System.Windows.Forms;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using ShapeSDK;


namespace GraphEditor
{
    class SaveFile: Product_File
    {
        private SaveFileDialog savedialog;
        DataContractJsonSerializer jsonFormatter;

        public SaveFile() {
            savedialog = new SaveFileDialog();
        }

        public void save(List<Shape> shapesList, string nameWorkFile, List<Type> addInType) {
            try
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Shape>), addInType);
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

        public override void workWithFile(List<Shape> shapesList, ref DisplayManager displayManage, ref string nameWorkFile, List<Type> addInType) {
            DialogResult dialogResult = savedialog.ShowDialog();
            nameWorkFile = Path.GetFullPath(savedialog.FileName);
            MessageBox.Show(nameWorkFile, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!String.Equals(savedialog.FileName, "") && dialogResult != DialogResult.Cancel && dialogResult != DialogResult.Abort) 
                save(shapesList,  nameWorkFile, addInType);
        }

        public override void initTool(string title, bool CheckPathExists)
        {
            savedialog.DefaultExt = "json";
            savedialog.Title = title;
            savedialog.CheckPathExists = CheckPathExists;
        }
    }
}
