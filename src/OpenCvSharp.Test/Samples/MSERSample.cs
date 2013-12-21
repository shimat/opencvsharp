using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Maximally Stable Extremal Regions
    /// </summary>
    class MSERSample
    {
        public MSERSample()
        {
            using (IplImage imgSrc = new IplImage(Const.ImageDistortion, LoadMode.Color))
            using (IplImage imgGray = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (IplImage imgDst = imgSrc.Clone())
            {
                Cv.CvtColor(imgSrc, imgGray, ColorConversion.BgrToGray);

                //CStyleMSER(imgGray, imgRender);  // C style
                CppStyleMSER(imgGray, imgDst);  // C++ style

                using (new CvWindow("MSER src", imgSrc))
                using (new CvWindow("MSER gray", imgGray))
                using (new CvWindow("MSER dst", imgDst))
                {
                    Cv.WaitKey();
                }
            }
        }
        
        /// <summary>
        /// Extracts MSER by C-style code (cvExtractMSER)
        /// </summary>
        /// <param name="imgGray"></param>
        /// <param name="imgRender"></param>
        private void CStyleMSER(IplImage imgGray, IplImage imgDst)
        {
            using (CvMemStorage storage = new CvMemStorage())
            {
                CvContour[] contours;
                CvMSERParams param = new CvMSERParams();
                Cv.ExtractMSER(imgGray, null, out contours, storage, param);

                foreach (CvContour c in contours)
                {
                    CvColor color = CvColor.Random();
                    for (int i = 0; i < c.Total; i++)
                    {
                        imgDst.Circle(c[i].Value, 1, color);
                    }
                }
            }
        }

        /// <summary>
        /// Extracts MSER by C++-style code (cv::MSER)
        /// </summary>
        /// <param name="imgGray"></param>
        /// <param name="imgRender"></param>
        private void CppStyleMSER(IplImage imgGray, IplImage imgDst)
        {
            MSER mser = new MSER();
            CvPoint[][] contours = mser.Extract(new Mat(imgGray, false), null);     // operator()
            foreach (CvPoint[] p in contours)
            {
                CvColor color = CvColor.Random();
                for (int i = 0; i < p.Length; i++)
                {
                    imgDst.Circle(p[i], 1, color);
                }
            }
        }
    }
}