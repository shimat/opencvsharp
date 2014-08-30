using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Distance transform
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/special_transforms.html#disttrans
    /// </remarks>
    class DistTransform
    {        
        public DistTransform()
        {
            // cvDistTransform

            using (var src = new IplImage(FilePath.Image.Lenna, LoadMode.GrayScale))
            {
                if (src.Depth != BitDepth.U8)
                {
                    throw new Exception("Invalid Depth");
                }

                using (var dst = new IplImage(src.Size, BitDepth.F32, 1))
                using (var dstNorm = new IplImage(src.Size, BitDepth.U8, 1))
                {
                    Cv.DistTransform(src, dst, DistanceType.L2, 3, null, null);
                    Cv.Normalize(dst, dstNorm, 0.0, 255.0, NormType.MinMax, null);

                    using (new CvWindow("Source", WindowMode.AutoSize, src)) 
                    using (new CvWindow("Distance Image", WindowMode.AutoSize, dstNorm))
                    {
                        CvWindow.WaitKey(0);
                    }
                }
            }

        }
    }
}
