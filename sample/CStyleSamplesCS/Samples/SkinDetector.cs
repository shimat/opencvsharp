using System;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// CvAdaptiveSkinDetector sample
    /// </summary>
    class SkinDetector
    {
        /// <summary>
        /// 
        /// </summary>
        public SkinDetector()
        {
            using (IplImage imgSrc = new IplImage(FilePath.Image.Balloon, LoadMode.Color))            
            using (IplImage imgHueMask = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (IplImage imgDst = imgSrc.Clone())
            {
                CvAdaptiveSkinDetector detector = new CvAdaptiveSkinDetector(1, MorphingMethod.None);
                detector.Process(imgSrc, imgHueMask);
                DisplaySkinPoints(imgHueMask, imgDst, CvColor.Green);

                using (new CvWindow("src", imgSrc))
                using (new CvWindow("skin", imgDst))
                {
                    Cv.WaitKey(0);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imgHueMask"></param>
        /// <param name="imgRgbDst"></param>
        /// <param name="color"></param>
        private void DisplaySkinPoints(IplImage imgHueMask, IplImage imgRgbDst, CvColor color)
        {
            if (imgHueMask.Size != imgRgbDst.Size)
                throw new ArgumentException();

            for (int y = 0; y < imgHueMask.Height; y++)
            {
                for (int x = 0; x < imgHueMask.Width; x++)
                {
                    byte value = (byte)imgHueMask[y, x].Val0;
                    if (value != 0)
                    {
                        imgRgbDst[y, x] = color;
                    }
                }
            }
        }
    }
}