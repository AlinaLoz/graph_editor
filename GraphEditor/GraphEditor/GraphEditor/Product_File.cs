using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace GraphEditor
{
    abstract class Product_File
    {
        public abstract void workWithFile(List<Shape> shapesList, ref DisplayManager displayManager, ref string nameWorkFile);
        public abstract void initTool(string title, bool CheckPathExists);
    }
}
