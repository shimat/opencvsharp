using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Image resizing
    /// </summary>
    class Resize
    {
        public Resize()
        {
            using (var src = new IplImage(FilePath.Image.Square5, LoadMode.AnyColor | LoadMode.AnyDepth))
            {
                CvSize size = new CvSize(src.Width * 2, src.Height * 2);
                using (IplImage dstNN = new IplImage(size, src.Depth, src.NChannels))
                using (IplImage dstCubic = new IplImage(size, src.Depth, src.NChannels))
                using (IplImage dstLinear = new IplImage(size, src.Depth, src.NChannels))
                using (IplImage dstLanczos = new IplImage(size, src.Depth, src.NChannels))                
                {
                    Cv.Resize(src, dstNN, Interpolation.NearestNeighbor);
                    Cv.Resize(src, dstCubic, Interpolation.Cubic);                    
                    Cv.Resize(src, dstLinear, Interpolation.Linear);
                    Cv.Resize(src, dstLanczos, Interpolation.Lanczos4);

                    using (new CvWindow("src", src))
                    using (new CvWindow("dst NearestNeighbor", dstNN))
                    using (new CvWindow("dst Cubic", dstCubic))
                    using (new CvWindow("dst Linear", dstLinear))
                    using (new CvWindow("dst Lanczos4", dstLanczos))                    
                    {
                        Cv.WaitKey();
                    }
                }
            }
        }
    }
}
