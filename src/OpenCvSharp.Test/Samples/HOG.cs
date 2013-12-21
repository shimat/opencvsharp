using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using CPP = OpenCvSharp.CPlusPlus;
using GPU = OpenCvSharp.Gpu;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// samples/c/peopledetect.c
    /// </summary>
    class HOG
    {
        public HOG()
        {
            CPP.Mat img = CPP.CvCpp.ImRead(Const.ImageAsahiyama, LoadMode.Color);

            ///*
            if (GPU.CvGpu.IsEnabled)
            {
                GPU.GpuMat imgGpu = new GPU.GpuMat(img);

                GPU.HOGDescriptor hog = new GPU.HOGDescriptor();
                hog.SetSVMDetector(OpenCvSharp.CPlusPlus.HOGDescriptor.GetDefaultPeopleDetector());

                //bool b = hog.CheckDetectorSize();
                //b.ToString();
            }
            else
            //*/
            {
                CPP.HOGDescriptor hog = new CPP.HOGDescriptor();
                hog.SetSVMDetector(CPP.HOGDescriptor.GetDefaultPeopleDetector());

                bool b = hog.CheckDetectorSize();
                b.ToString();

                Stopwatch watch = Stopwatch.StartNew();

                // run the detector with default parameters. to get a higher hit-rate
                // (and more false alarms, respectively), decrease the hitThreshold and
                // groupThreshold (set groupThreshold to 0 to turn off the grouping completely).
                CvRect[] found = hog.DetectMultiScale(img, 0, new CvSize(8, 8), new CvSize(24, 16), 1.05, 2);

                watch.Stop();
                Console.WriteLine("Detection time = {0}ms", watch.ElapsedMilliseconds);
                Console.WriteLine("{0} region(s) found", found.Length);

                foreach (CvRect rect in found)
                {
                    // the HOG detector returns slightly larger rectangles than the real objects.
                    // so we slightly shrink the rectangles to get a nicer output.
                    CvRect r = new CvRect
                    {
                        X = rect.X + (int)Math.Round(rect.Width * 0.1),
                        Y = rect.Y + (int)Math.Round(rect.Height * 0.1),
                        Width = (int)Math.Round(rect.Width * 0.8),
                        Height = (int)Math.Round(rect.Height * 0.8)
                    };
                    img.Rectangle(r.TopLeft, r.BottomRight, CvColor.Red, 3, LineType.Link8, 0);
                }

                using (CvWindow window = new CvWindow("people detector", WindowMode.None, img.ToIplImage()))
                {
                    window.SetProperty(WindowProperty.Fullscreen, 1);
                    Cv.WaitKey(0);
                }
            }
        }
    }
}