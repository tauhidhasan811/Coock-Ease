using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public class PhotoHelper
    {


        public static PictureBox CreateRoundPictureBox()
        {
              PictureBox pictureBox = new PictureBox();
              pictureBox.Size = new Size(120, 120);
              pictureBox.Location = new Point(5,5);
              pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
              pictureBox.Image = Image.FromFile(@"C:\Users\ASUS\Pictures\download (2).png");

              MakePictureBoxRound(pictureBox);

              return pictureBox;
        }

        private static void MakePictureBoxRound(PictureBox pictureBox)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }
    }
}
