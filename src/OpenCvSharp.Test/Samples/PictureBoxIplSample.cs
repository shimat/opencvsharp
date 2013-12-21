using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.UserInterface;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// PictureBoxIpl sample
    /// </summary>
    class PictureBoxIplSample
    {
        public PictureBoxIplSample()
        {
            using (IplImage img = new IplImage(Const.ImageFruits, LoadMode.Color))
            {
                using (Form form = new Form() { ClientSize = new Size(img.Width, img.Height), Text = "PictureBoxIpl Sample" })  
                using (PictureBoxIpl pbi = new PictureBoxIpl())
                {
                    pbi.ImageIpl = img;
                    pbi.ClientSize = form.ClientSize;
                    form.Controls.Add(pbi);

                    Application.Run(form);
                }
            }

        }

    }
}
