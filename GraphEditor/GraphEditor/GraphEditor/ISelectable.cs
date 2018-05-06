using System.Drawing;

namespace GraphEditor
{
    interface ISelectable
    {
        void CreateFrame(int startX, int startY, int endX, int endY);
    }
}
