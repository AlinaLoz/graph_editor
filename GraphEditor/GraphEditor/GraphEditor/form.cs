using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ShapeSDK;
using AddFigure;

namespace GraphEditor
{
    public partial class Paint : Form
    {
        List<PictureBox> ToolsFromPlugins = new List<PictureBox>();
        int numberAddTools;
        List<Shape> shapesList = new List<Shape>();
        List<Type> addinTypes = new List<Type>();
        DisplayManager displayManager;
        Boolean isMouseClick;
        Frame frame;
        Keys prevKey, currKey;
        String nameWorkFile;
        bool isCtrlZ;

        public Paint()
        {
            InitializeComponent();
            displayManager = DisplayManager.getInstance(pictureDrawing);
            numberAddTools = -1;
            nameWorkFile = "";
            isMouseClick = false;
            prevKey = new Keys();
            currKey = new Keys();
            isCtrlZ = false;
            string currentDir = Path.GetDirectoryName(
               Assembly.GetEntryAssembly().Location);

            string[] addinAssemblies = Directory.GetFiles(currentDir, "*.dll");

            foreach (string file in addinAssemblies)
            {
                Assembly addinAssembly = Assembly.LoadFrom(file);
                foreach (Type t in addinAssembly.GetExportedTypes())
                {
                    if ((t).IsSubclassOf(typeof(Shape)) && t.IsClass && !t.IsAbstract && (typeof(ISelectable).IsAssignableFrom(t) || !typeof(ISelectable).IsAssignableFrom(t)) )
                    {
                        addinTypes.Add(t);
                        ToolsFromPlugins.Add(new PictureBox());
                        ToolsFromPlugins[ToolsFromPlugins.Count - 1].Name = "bpNewTools/" + addinTypes.IndexOf(t);
                        ToolsFromPlugins[ToolsFromPlugins.Count - 1].Parent = panelTools;
                        ToolsFromPlugins[ToolsFromPlugins.Count - 1].BackColor = Color.Transparent;
                        ToolsFromPlugins[ToolsFromPlugins.Count - 1].BorderStyle = BorderStyle.FixedSingle;
                        ToolsFromPlugins[ToolsFromPlugins.Count - 1].Location = (ToolsFromPlugins.Count == 1) ?
                            new Point(toolFrame.Location.X,
                            toolFrame.Location.Y + toolFrame.Height + 5) :
                            new Point(ToolsFromPlugins[ToolsFromPlugins.Count - 2].Location.X,
                            ToolsFromPlugins[ToolsFromPlugins.Count - 2].Location.Y +
                            ToolsFromPlugins[ToolsFromPlugins.Count - 2].Height + 5);
                        ToolsFromPlugins[ToolsFromPlugins.Count - 1].Size = new Size(25, 25);
                        ToolsFromPlugins[ToolsFromPlugins.Count - 1].MouseDown += new MouseEventHandler(ToolsFromPlugins_MouseDown);
                    }   
                }
            }
        }

        private void ToolsFromPlugins_MouseDown(object sender, MouseEventArgs e)
        {
            numberAddTools = Convert.ToInt32(Regex.Replace(((PictureBox)sender).Name, @"[^\d]+", ""));
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            shapesList.Clear();
            displayManager.DeleteAll();
        }

        private void pictureDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            Point startPoint = new Point(e.X, e.Y);
                if (frame != null)
                {
                    if (!frame.IsExistFrame && frame.CreateFrame(shapesList, startPoint, pictureDrawing))
                    {
                        Bitmap bitmap = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                        Graphics tempGr = Graphics.FromImage(bitmap);
                        tempGr.Clear(Color.White);
                        OpenFile.WriteOnImage(tempGr, shapesList);
                        displayManager.DeleteAll();
                        displayManager.InitComponent(bitmap);
                    }
                    else
                    {
                        if (frame.IsExistFrame)
                        {
                            frame.DeleteFrame(shapesList, pictureDrawing.Width, pictureDrawing.Height);
                            Bitmap bitmap = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                            Graphics tempGr = Graphics.FromImage(bitmap);
                            tempGr.Clear(Color.White);
                            OpenFile.WriteOnImage(tempGr, shapesList);
                            displayManager.DeleteAll();
                            displayManager.InitComponent(bitmap);
                            frame = null;
                        }
                        else
                        {
                            frame = null;
                        }

                    }
                }
                else {
                    if (numberAddTools != -1)
                    {
                        isMouseClick = true;
                        shapesList.Add((Shape)Activator.CreateInstance(addinTypes[numberAddTools]));
                        shapesList.Last().setFirstPoint(new Point(e.X, e.Y));
                    }
                }
        }

        private void pictureDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseClick)
            {
                Bitmap bm = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                Graphics g = Graphics.FromImage(bm);
                shapesList.Last().setLastPoint(new Point(e.X, e.Y));
                shapesList.Last().Draw(g);
                pictureDrawing.Image = bm;
            }
        }

        private void pictureDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseClick && frame == null && shapesList.Count > 0)
            {
                isMouseClick = false;
                shapesList.Last().setLastPoint(new Point(e.X, e.Y));
                if (shapesList.Last().firstPoint.X == shapesList.Last().lastPoint.X
                        && shapesList.Last().firstPoint.Y == shapesList.Last().lastPoint.Y)
                {
                    shapesList.RemoveAt(shapesList.Count - 1);
                }
                else
                {
                    Bitmap bm = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                    Graphics g = Graphics.FromImage(bm);
                    shapesList.Last().Draw(g);
                    displayManager.Imposition(bm);
                    shapesList.Last().addBmp(bm);
                }
                
            }
        }

        private void toolDelete_MouseUp(object sender, MouseEventArgs e)
        {
            if (pictureDrawing.Image == null) {
                displayManager.InitComponent();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile saveFile = new SaveFile();
            if (string.Equals(nameWorkFile, ""))
            {
                if (MessageBox.Show("Save As File?", "Save as", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveFile.initTool("Сохранить картинку как...", true);
                    saveFile.workWithFile(shapesList, ref displayManager, ref nameWorkFile, addinTypes);
                }
            }
            else
            {
                saveFile.save(shapesList, nameWorkFile, addinTypes);
            }
        }

        private void saveAsКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creator_File creator = new CreateProductSaveFile() ;
            Product_File saveFile = creator.FactoryMethod();
            saveFile.initTool("Сохранить картинку как...", true);
            saveFile.workWithFile(shapesList, ref displayManager, ref nameWorkFile, addinTypes);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creator_File creator = new CreateProductOpenFile();
            Product_File openFile = creator.FactoryMethod();
            openFile.initTool("Открыть картинку", true);
            openFile.workWithFile(shapesList, ref displayManager, ref nameWorkFile, addinTypes);
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void creatToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            toolDelete_Click(sender, e);
            toolDelete_MouseUp(sender, e);
            nameWorkFile = "";
        }

        private void toolFrame_Click(object sender, EventArgs e)
        {
            frame = Frame.getInstance();
        }

        public void CtrlZ()
        {
            for (int i = shapesList.Count - 1; i >= 0; i--)
            {
                if (shapesList[i].bitmapCancel)
                {
                    shapesList[i].bitmapCancel = false;
                    break;
                }
            }
        }

        public void CtrlY()
        {
            if (isCtrlZ)
            {
                foreach (Shape shape in shapesList)
                {
                    if (!shape.bitmapCancel)
                    {
                        shape.bitmapCancel = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = shapesList.Count - 1; i >= 0; i--)
                {
                    if (!shapesList[i].bitmapCancel)
                    {
                        shapesList[i].bitmapCancel = true;
                        break;
                    }
                }
            }
        }

        private void Paint_KeyDown(object sender, KeyEventArgs e)
        {
            prevKey = currKey;
            currKey = e.KeyCode;
            Boolean isKey = false;
            if (prevKey == Keys.ControlKey && e.KeyCode == Keys.Z)
            {
                CtrlZ();
                isKey = true;
                isCtrlZ = true;
            }
            if (prevKey == Keys.ControlKey && e.KeyCode == Keys.Y)
            {
                CtrlY();
                isKey = true;
                isCtrlZ = false;
            }
            if (isKey)
            {
                 Bitmap bitmap = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                 Graphics tempGr = Graphics.FromImage(bitmap);
                 tempGr.Clear(Color.White);
                 OpenFile.WriteOnImage(tempGr, shapesList);
                 displayManager.InitComponent(bitmap);
            }
        }
    }
}
