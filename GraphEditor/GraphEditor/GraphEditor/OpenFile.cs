using System.Windows.Forms;
using System.Drawing;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using ShapeSDK;
using System.Text;
using Newtonsoft.Json;

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

        public override void workWithFile(List<Shape> shapesList, ref DisplayManager displayManager,
            ref string nameWorkFile, List<System.Type> addInType)
        {
            try
            {
                DialogResult dialogResult = opendialog.ShowDialog();
                nameWorkFile = Path.GetFullPath(opendialog.FileName);
                if (!String.Equals(opendialog.FileName, "") && dialogResult != DialogResult.Cancel && dialogResult != DialogResult.Abort)
                {
                    FileStream fs = new FileStream(nameWorkFile, FileMode.OpenOrCreate);
                    shapesList.Clear();
                    byte[] messageBytes = new byte[fs.Length];

                    fs.Read(messageBytes, 0, messageBytes.Length);
                    string jsonString = Encoding.ASCII.GetString(messageBytes);
                    dynamic tmpList = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
                    List<dynamic> outputList = new List<dynamic>();

                    foreach (dynamic element in tmpList)
                    {
                        {
                           foreach (Type type in addInType)
                            {
                                if (element["__type"].ToString().IndexOf(type.Name.ToString()) != -1)
                                {
                                    outputList.Add(element);
                                    break;
                                }
                            }
                        }
                    }

                    FileStream tmpStream = new FileStream("tmpFile.json", FileMode.Create);
                    jsonString = JsonConvert.SerializeObject(outputList);

                    tmpStream.Write(Encoding.ASCII.GetBytes(jsonString), 0, Encoding.ASCII.GetBytes(jsonString).Length);
                    tmpStream.Close();
                    string json = File.ReadAllText("tmpFile.json");
                    var serializer = new DataContractJsonSerializer(typeof(List<Shape>), addInType);
                    shapesList = (List<Shape>)serializer.ReadObject(
                            new MemoryStream(Encoding.Unicode.GetBytes(json)));

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
            }
        }

        public override void initTool(string title, bool CheckPathExists) {
            opendialog.DefaultExt = "json";
            opendialog.Title = title;
            opendialog.CheckPathExists = CheckPathExists;
        }
    }
}