using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp.UserInterface;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Pure C# implementation of CvWindow
    /// </summary>
    class CvWindowExTest
    {
        private IplImage image;
        private CvWindowEx window;

        public CvWindowExTest()
        {
            image = new IplImage(Const.ImageLenna);

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
