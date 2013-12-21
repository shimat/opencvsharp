using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Converts gray scale image to pseudo-color images
    /// </summary>
    class PseudoColor
    {
        public PseudoColor()
        {            
            using (IplImage imgGray = new IplImage(500, 100, BitDepth.U8, 1))
            using (IplImage imgPseudo = new IplImage(imgGray.Size, BitDepth.U8, 3))
            {
                // creates a beltlike grayscale image
                FillGrayScaleValues(imgGray);

                // converts imgGray to Pseudo-color image
                ConvertToPseudoColor(imgGray, imgPseudo);

                using (new CvWindow("gray", imgGray))
                using (new CvWindow("pseudo", imgPseudo))
                {
                    Cv.WaitKey();
                }
            }
        }

        /// <summary>
        /// Creates a beltlike grayscale image
        /// </summary>
        /// <param name="img"></param>
        private void FillGrayScaleValues(IplImage img)
        {
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    byte value = (byte)(255.0 / img.Width * x);
                    img[y, x] = value;
                }
            }
        }

        /// <summary>
        /// Converts imgGray to Pseudo-color image
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        private void ConvertToPseudoColor(IplImage src, IplImage dst)
        {
            // creates lookup table
            CvColor[] lutData = CreateLutData();

            using (IplImage src3ch = new IplImage(src.Size, BitDepth.U8, 3))
            using (CvMat lut = new CvMat(256, 1, MatrixType.U8C3, lutData))
            {
                // converts 1-channel image to 3-channel image
                Cv.Merge(src, src, src, null, src3ch);
                // applies lut to grayscale image
                Cv.LUT(src3ch, dst, lut);
            }
        }

        /// <summary>
        /// Creates lookup table
        /// </summary>
        /// <returns></returns>
        private CvColor[] CreateLutData()
        {
            CvColor[] lutData = new CvColor[256];
            for (int i = 0; i < lutData.Length; i++)
            {
                double r, g, b;
                if (i >= 0 && i <= 63)
                {
                    r = 0;
                    g = 255.0 / 63 * i;
                    b = 255;
                }
                else if (i > 63 && i <= 127)
                {
                    r = 0;
                    g = 255;
                    b = 255 - (255.0 / (127 - 63) * (i - 63));
                }
                else if (i > 127 && i <= 191)
                {
                    r = 255.0 / (191 - 127) * (i - 127);
                    g = 255;
                    b = 0;
                }
                else // if (i > 191 && i < 256)
                {
                    r = 255;
                    g = 255 - (255.0 / (255 - 191) * (i - 191));
                    b = 0;
                }
                lutData[i] = new CvColor((byte)r, (byte)g, (byte)b);
            }
            return lutData;
        }
    }
}