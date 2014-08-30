using System;
using OpenCvSharp;
using OpenCvSharp.UserInterface;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Pure C# implementation of CvWindow
    /// </summary>
    class CvWindowExTest
    {
        private readonly IplImage image;
        private readonly CvWindowEx window;

        public CvWindowExTest()
        {
            image = new IplImage(FilePath.Image.Lenna);

            using (window = new CvWindowEx(image))
            {
                window.Text = "CvWindowEx Test";
                window.CreateTrackbar("foo", 127, 255, OnTrack);
                OnTrack(127);
                CvWindowEx.WaitKey();
            }
        }

        private void OnTrack(int pos)
        {
            using (IplImage tmp = image.Clone())
            {
                Cv.Threshold(image, tmp, pos, 255, ThresholdType.Binary);
                window.ShowImage(tmp);
            }
        }
    }
}
