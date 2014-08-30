using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Filter operation
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/filter_and_color_conversion.html#filter2d
    /// </remarks>
    class Filter2D
    {
        public Filter2D()
        {
            using (IplImage srcImg = new IplImage(FilePath.Image.Fruits, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (IplImage dstImg = new IplImage(srcImg.Size, srcImg.Depth, srcImg.NChannels))
            {
                float[] data = {    2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                                    1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
                };
                CvMat kernel = new CvMat(1, 21, MatrixType.F32C1, data);

                Cv.Normalize(kernel, kernel, 1.0, 0, NormType.L1);
                Cv.Filter2D(srcImg, dstImg, kernel, new CvPoint(0, 0));

                using (new CvWindow("Filter2D", dstImg))
                {
                    Cv.WaitKey(0);
                }
            }

        }
    }
}
