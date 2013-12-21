using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Saving image using the format-specific save parameters
    /// </summary>
    class SaveImage
    {
        public SaveImage()
        {
            using (IplImage img = new IplImage(Const.Image16bit, LoadMode.Color))
            {
                // JPEG quality test
                img.SaveImage("q000.jpg", new JpegEncodingParam(0));
                img.SaveImage("q025.jpg", new JpegEncodingParam(25));
                img.SaveImage("q050.jpg", new JpegEncodingParam(50));
                img.SaveImage("q075.jpg", new JpegEncodingParam(75));
                img.SaveImage("q100.jpg", new JpegEncodingParam(100));

                using (IplImage q000 = new IplImage("q000.jpg", LoadMode.Color))
                using (IplImage q025 = new IplImage("q025.jpg", LoadMode.Color))
                using (IplImage q050 = new IplImage("q050.jpg", LoadMode.Color))
                using (IplImage q075 = new IplImage("q075.jpg", LoadMode.Color))
                using (IplImage q100 = new IplImage("q100.jpg", LoadMode.Color))
                using (CvWindow w000 = new CvWindow("quality 0", q000))
                using (CvWindow w025 = new CvWindow("quality 25", q025))
                using (CvWindow w050 = new CvWindow("quality 50", q050))
                using (CvWindow w075 = new CvWindow("quality 75", q075))
                using (CvWindow w100 = new CvWindow("quality 100", q100))
                {
                    Cv.WaitKey();
                }
            }
        }
    }
}