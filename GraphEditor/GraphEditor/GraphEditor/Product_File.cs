using System.Collections.Generic;
using ShapeSDK;

namespace GraphEditor
{
    abstract class Product_File
    {
        public abstract void workWithFile(List<Shape> shapesList, ref DisplayManager displayManager, ref string nameWorkFile,
            List<System.Type> addInType);
        public abstract void initTool(string title, bool CheckPathExists);
    }
}
