using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphEditor
{
    enum TTools { PEN, RECTANGLE, TREANGLE, CIRCLE, ELLIPSE, LINE, RUBBER, FRAME };

    public partial class Paint : Form
    {
        Keys prevKey, currKey;

        Point startCoords = new Point(0, 0);
        Point endCoords = new Point(0, 0);
        float diametrCircle = 0;

        Graphics drawSurface;
        Bitmap btmFront;
        Graphics grFront;

        Pen penReader = new Pen(Color.Black);
        Pen rubberPen = new Pen(Color.White, 20);
        Frame frame = new Frame();
        TTools currTool = TTools.PEN;
        Boolean isMouseClick;
        String nameWorkFile;

        ListShape listShape;
        bool isCtrZ;

        public Paint()
        {
            InitializeComponent();
            btmFront = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
            grFront = Graphics.FromImage(btmFront);
            pictureDrawing.BackgroundImage = btmFront;
            nameWorkFile = "";

            listShape = ListShape.getInstance();

            isMouseClick = false;
            prevKey = new Keys();
            currKey = new Keys();
            isCtrZ = false;
        }

        private void yellowColor_Click(object sender, EventArgs e)
        {
            penReader.Color = yellowColor.BackColor;
            defaultColor.BackColor = yellowColor.BackColor;
        }

        private void redColor_Click(object sender, EventArgs e)
        {
            penReader.Color = redColor.BackColor;
            defaultColor.BackColor = redColor.BackColor;
        }


        private void ToolDraw()
        {
            switch (currTool)
            {
                case TTools.PEN:
                    Bitmap bm = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                    Graphics g = Graphics.FromImage(bm);
                    drawSurface = g;
                    drawSurface.DrawLine(penReader, startCoords, endCoords);
                    grFront.DrawImage(bm, 0, 0);
                    listShape.AddShape(bm);                    
                    startCoords = endCoords;
                    break;
                case TTools.RECTANGLE:
                    Rectangle rectangle = new Rectangle(drawSurface);
                    rectangle.Draw(startCoords, endCoords, penReader);
                    break;
                case TTools.ELLIPSE:
                    Ellipse ellipse = new Ellipse(drawSurface);
                    ellipse.Draw(startCoords, endCoords, penReader);
                    break;
                case TTools.LINE:
                    Line line = new Line(drawSurface);
                    line.Draw(startCoords, endCoords, penReader);
                    break;
                case TTools.TREANGLE:
                    Triangle triangle = new Triangle(drawSurface);
                    triangle.Draw(startCoords, endCoords, penReader);
                    break;
                case TTools.CIRCLE:
                    Circle circle = new Circle(drawSurface);
                    circle.getSize(diametrCircle);
                    circle.Draw(startCoords, endCoords, penReader);
                    diametrCircle = circle.returnSize();
                    break;
                case TTools.RUBBER:
                    drawSurface = grFront;
                    drawSurface.DrawLine(penReader, startCoords, endCoords);
                    startCoords = endCoords;
                    break;
            }
        }


        private void whiteColor_Click(object sender, EventArgs e)
        {
            penReader.Color = whiteColor.BackColor;
            defaultColor.BackColor = whiteColor.BackColor;
        }

        private void blackColor_Click(object sender, EventArgs e)
        {
            penReader.Color = blackColor.BackColor;
            defaultColor.BackColor = blackColor.BackColor;
        }

        private void purpleColor_Click(object sender, EventArgs e)
        {
            penReader.Color = purpleColor.BackColor;
            defaultColor.BackColor = purpleColor.BackColor;
        }

        private void blueColor_Click(object sender, EventArgs e)
        {
            penReader.Color = blueColor.BackColor;
            defaultColor.BackColor = blueColor.BackColor;
        }

        private void greenColor_Click_1(object sender, EventArgs e)
        {
            penReader.Color = greenColor.BackColor;
            defaultColor.BackColor = greenColor.BackColor;
        }

        private void skyBlueColor_Click(object sender, EventArgs e)
        {
            penReader.Color = skyBlueColor.BackColor;
            defaultColor.BackColor = skyBlueColor.BackColor;
        }

        private void yellowColor_Click_1(object sender, EventArgs e)
        {
            penReader.Color = yellowColor.BackColor;
            defaultColor.BackColor = yellowColor.BackColor;
        }

        private void toolPen_Click(object sender, EventArgs e)
        {
            currTool = TTools.PEN;

        }

        private void toolLine_Click(object sender, EventArgs e)
        {
            currTool = TTools.LINE;
        }

        private void toolRectangle_Click(object sender, EventArgs e)
        {
            currTool = TTools.RECTANGLE;
        }

        private void toolElipse_Click(object sender, EventArgs e)
        {
            currTool = TTools.ELLIPSE;
        }

        private void toolTreangle_Click(object sender, EventArgs e)
        {
            currTool = TTools.TREANGLE;
        }

        private void toolCircle_Click(object sender, EventArgs e)
        {
            currTool = TTools.CIRCLE;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            btmFront.Dispose();
            pictureDrawing.BackgroundImage = null;
            pictureDrawing.Image = null;
        }

        private void toolRubber_Click(object sender, EventArgs e)
        {
            penReader.Width = 25;
            currTool = TTools.RUBBER;
            penReader.Color = Color.White;
        }

        private void pictureDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            startCoords.X = e.X;
            startCoords.Y = e.Y;
            isMouseClick = true;
        }

        private void pictureDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
            Graphics g = Graphics.FromImage(bm);
            drawSurface = g;

            if (isMouseClick)
            {
                ToolDraw();
                pictureDrawing.Image = bm;
            }

            endCoords.X = e.X;
            endCoords.Y = e.Y;
        }

        private void pictureDrawing_MouseUp(object sender, MouseEventArgs e)
        {

            isMouseClick = false;
            penReader.Width = 1;
            penReader.Color = defaultColor.BackColor;
            Bitmap bm = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
            Graphics g = Graphics.FromImage(bm);
            drawSurface = g;
            ToolDraw();
            grFront.DrawImage(bm, 0, 0);

            if (currTool != TTools.FRAME)
            {
                listShape.AddShape(bm);
                listShape.bitmapCancel.Add(true);
                listShape.AddInfoAboutShape(startCoords, endCoords, currTool);
            }
            
            if (currTool == TTools.FRAME)
            {
                Bitmap bitmap = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                Graphics tempGr = Graphics.FromImage(bitmap);
                tempGr.Clear(Color.White);

                frame.CreateFrame(listShape, startCoords, pictureDrawing);

                listShape.WriteOnImage(tempGr);
                btmFront.Dispose();
                btmFront = new Bitmap(bitmap, pictureDrawing.Width, pictureDrawing.Height);
                grFront = Graphics.FromImage(btmFront);
                pictureDrawing.BackgroundImage = btmFront;
                pictureDrawing.Image = btmFront;
            }
        }

        private void toolDelete_MouseUp(object sender, MouseEventArgs e)
        {
            if (pictureDrawing.Image == null) {
                btmFront = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                grFront = Graphics.FromImage(btmFront);
                pictureDrawing.BackgroundImage = btmFront;
                pictureDrawing.Image = btmFront;
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
                    saveFile.workWithFile(listShape, pictureDrawing, ref btmFront, ref grFront, ref nameWorkFile);
                }
            }
            else
            {
                saveFile.save(listShape, nameWorkFile);
            }
        }

        private void saveAsКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creator_File creator = new CreateProductSaveFile() ;
            Product_File saveFile = creator.FactoryMethod();
            saveFile.initTool("Сохранить картинку как...", true);
            saveFile.workWithFile(listShape, pictureDrawing, ref btmFront, ref grFront, ref nameWorkFile);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creator_File creator = new CreateProductOpenFile();
            Product_File openFile = creator.FactoryMethod();
            openFile.initTool("Открыть картинку", true);
            openFile.workWithFile(listShape, pictureDrawing, ref btmFront, ref grFront, ref nameWorkFile);
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
            currTool = TTools.FRAME;
        }

        private void pictureDrawing_Click(object sender, EventArgs e)
        {
            if (frame.IsExistFrame) {
                frame.DeleteFrame(listShape, pictureDrawing.Width, pictureDrawing.Height);

                Bitmap bitmap = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                Graphics tempGr = Graphics.FromImage(bitmap);
                tempGr.Clear(Color.White);

                listShape.WriteOnImage(tempGr);
                btmFront.Dispose();
                btmFront = new Bitmap(bitmap, pictureDrawing.Width, pictureDrawing.Height);
                grFront = Graphics.FromImage(btmFront);
                pictureDrawing.BackgroundImage = btmFront;
                pictureDrawing.Image = btmFront;
            }
        }

        private void Paint_KeyDown(object sender, KeyEventArgs e)
        {
            prevKey = currKey;
            currKey = e.KeyCode;
            Boolean isKey = false;
            if (prevKey == Keys.ControlKey && e.KeyCode == Keys.Z)
            {
                listShape.CtrlZ();
                isKey = true;
                isCtrZ = true;
            }
            if (prevKey == Keys.ControlKey && e.KeyCode == Keys.Y)
            {
                listShape.CtrlY(isCtrZ);
                isKey = true;
                isCtrZ = false;
            }
            if (isKey)
            {
                 Bitmap bitmap = new Bitmap(pictureDrawing.Width, pictureDrawing.Height);
                 Graphics tempGr = Graphics.FromImage(bitmap);
                 tempGr.Clear(Color.White);

                 listShape.WriteOnImage(tempGr);

                 btmFront.Dispose();
                 btmFront = new Bitmap(bitmap, pictureDrawing.Width, pictureDrawing.Height);
                 grFront = Graphics.FromImage(btmFront);

                 pictureDrawing.BackgroundImage = btmFront;
                 pictureDrawing.Image = btmFront;
            }
        }
    }
}
