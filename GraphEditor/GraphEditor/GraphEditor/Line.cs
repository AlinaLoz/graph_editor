using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphEditor
{
    class Line:Shape
    {
        public override void Draw(Graphics drawSurface)
        {
            Pen pen = new Pen(Color.Black, 5);
            drawSurface.DrawLine(pen, firstPoint, lastPoint);
        }
        
    }
}
