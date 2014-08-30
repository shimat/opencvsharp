using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Creates image border
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/filter_and_color_conversion.html#makeborder
    /// </remarks>
    class CopyMakeBorder
    {        
        public CopyMakeBorder()
        {
            const int offset = 30;

            using (IplImage src = Cv.LoadImage(FilePath.Image.Lenna, LoadMode.AnyDepth | LoadMode.AnyColor))
            {
                int dstWidth = src.Width + offset * 2;
                int dstHeight = src.Height + offset * 2;
                using (IplImage dstReplicate = Cv.CreateImage(new CvSize(dstWidth, dstHeight), src.Depth, src.NChannels))
                using (IplImage dstConstant = Cv.CreateImage(new CvSize(dstWidth, dstHeight), src.Depth, src.NChannels))
                {
                    Cv.CopyMakeBorder(src, dstReplicate, new CvPoint(offset, offset), BorderType.Replicate);
                    Cv.CopyMakeBorder(src, dstConstant, new CvPoint(offset, offset), BorderType.Constant, CvColor.Red);

                    Cv.NamedWindow("Border Replicate", WindowMode.AutoSize);
                    Cv.NamedWindow("Border Constant", WindowMode.AutoSize);
                    Cv.ShowImage("Border Replicate", dstReplicate);
                    Cv.ShowImage("Border Constant", dstConstant);
                    Cv.WaitKey(0);
                    Cv.DestroyAllWindows();
                }
            }
        }
    }
}
