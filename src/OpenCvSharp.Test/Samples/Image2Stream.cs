using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 
    /// </summary>
    class Image2Stream
    {
        public Image2Stream()
        {
            // Stream -> IplImage
            using (FileStream stream = new FileStream(Const.ImageLenna, FileMode.Open))
            using (IplImage img = IplImage.FromStream(stream, LoadMode.Color))
            {
                CvWindow.ShowImages(img);

                // IplImage -> Stream
                using (MemoryStream ms = new MemoryStream())
                {
                    img.ToStream(ms, ".tiff");
                    ms.ToString();
                }
            }

            // Stream -> CvMat
            using (FileStream stream = new FileStream(Const.ImageLenna, FileMode.Open))
            using (CvMat mat = CvMat.FromStream(stream, LoadMode.Color))
            {
                mat.ToString();

                // CvMat -> Stream
                using (MemoryStream ms = new MemoryStream())
                {
                    mat.ToStream(ms, ".bmp");
                    ms.ToString();
                }
            }
        }
    }
}