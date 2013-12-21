using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// LatentSVM
    /// </summary>
    class LatentSVM
    {
        public LatentSVM()
        {            
            using (CvLatentSvmDetector detector = new CvLatentSvmDetector(Const.XmlLatentSVMCat))
            using (IplImage imageSrc = new IplImage(Const.ImageCat, LoadMode.Color))
            using (IplImage imageDst = imageSrc.Clone())
            using (CvMemStorage storage = new CvMemStorage())
            {
                Console.WriteLine("Running LatentSVM...");
                Stopwatch watch = Stopwatch.StartNew();

                CvSeq<CvObjectDetection> result = detector.DetectObjects(imageSrc, storage, 0.5f, 2);

                watch.Stop();
                Console.WriteLine("Elapsed time: {0}ms", watch.ElapsedMilliseconds);

                foreach (CvObjectDetection detection in result)
                {
                    CvRect boundingBox = detection.Rect;
                    imageDst.Rectangle(
                        new CvPoint(boundingBox.X, boundingBox.Y), 
                        new CvPoint(boundingBox.X + boundingBox.Width, boundingBox.Y + boundingBox.Height),
                        CvColor.Red, 3);
                }

                using (new CvWindow("LatentSVM result", imageDst))
                {
                    Cv.WaitKey();
                }
            }
        }
    }
}