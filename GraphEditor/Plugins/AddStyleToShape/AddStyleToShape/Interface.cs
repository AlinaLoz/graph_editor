using System.Drawing;

namespace AddStyleToShape
{
    public interface IAddStyleToShape
    {
        void AddShapeToCentre(ref byte[] drawSurface, Point start, Point end, int displayWidth,
            int displayHeight);
    }
}
