using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Image segmentation by mean shift filtering
    /// </summary>
    /// <remarks>http://opencv.jp/sample/segmentation_and_connection.html#meanshiftsegm</remarks>
    class PyrMeanShiftFiltering
    {
        public PyrMeanShiftFiltering()
        {
            const int level = 2;

            using (var srcImg = new IplImage(FilePath.Image.Goryokaku, LoadMode.AnyDepth | LoadMode.AnyColor))
            {
                if (srcImg.NChannels != 3)
                {
                    throw new Exception();
                }
                if (srcImg.Depth != BitDepth.U8)
                {
                    throw new Exception();
                }

                CvRect roi = new CvRect
                {
                    X = 0,
                    Y = 0,
                    Width = srcImg.Width & -(1 << level),
                    Height = srcImg.Height & -(1 << level)
                };
                srcImg.ROI = roi;

                using (IplImage dstImg = srcImg.Clone())
                {
                    Cv.PyrMeanShiftFiltering(srcImg, dstImg, 30.0, 30.0, level, new CvTermCriteria(5, 1));

                    using (new CvWindow("Source", srcImg))
                    using (new CvWindow("MeanShift", dstImg))
                    {
                        CvWindow.WaitKey();
                    }
                }
            }

        }
    }
}
