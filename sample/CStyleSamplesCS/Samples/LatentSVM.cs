using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// LatentSVM
    /// </summary>
    class LatentSVM
    {
        public LatentSVM()
        {
            using (var detector = new CvLatentSvmDetector(FilePath.Text.LatentSvmCat))
            using (var imageSrc = new IplImage(FilePath.Image.Cat, LoadMode.Color))
            using (var imageDst = imageSrc.Clone())
            using (var storage = new CvMemStorage())
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