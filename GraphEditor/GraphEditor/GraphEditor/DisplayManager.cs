
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphEditor
{
    class DisplayManager
    {
        public static DisplayManager instance;

        Bitmap btmFront;
        Graphics grFront;
        public PictureBox pictureDrawing;

        private DisplayManager(PictureBox pictureDrawing)
        {
            this.pictureDrawing = pictureDrawing;
            this.InitComponent();
        }

        public void InitComponent(params Bitmap[] list)
        {
            btmFront = (list.Length  == 0) ? new Bitmap(pictureDrawing.Width, pictureDrawing.Height) :
                new Bitmap(list[0], pictureDrawing.Width, pictureDrawing.Height);
            grFront = Graphics.FromImage(btmFront);
            pictureDrawing.BackgroundImage = btmFront;
            pictureDrawing.Image = btmFront;
        }

        public static DisplayManager getInstance(PictureBox pictureDrawing)
        {
            if (instance == null)
                instance = new DisplayManager(pictureDrawing);
            return instance;
        }

        public void DeleteAll()
        {
            btmFront.Dispose();
            this.pictureDrawing.BackgroundImage = null;
            this.pictureDrawing.Image = null;
        }

        public void Imposition(Bitmap bm)
        {
            grFront.DrawImage(bm, 0, 0);
        }

    }
}
