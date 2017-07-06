using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OpenCvSharp.Tests
{
    public abstract class TestBase 
    {
        protected TestBase()
        {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
        }

        protected Mat Image(string fileName, ImreadModes modes = ImreadModes.Color)
        {
            return new Mat(Path.Combine("_data", "image", fileName), modes);
        }

        protected void ImageEquals(Mat img1, Mat img2)
        {
            if (img1 == null && img2 == null)
                return;
            Assert.NotNull(img1);
            Assert.NotNull(img2);
            Assert.AreEqual(img1.Type(), img2.Type());

            using (var comparison = new Mat())
            {
                Cv2.Compare(img1, img2, comparison, CmpTypes.NE);
                if (img1.Channels() == 1)
                {
                    Assert.Zero(Cv2.CountNonZero(comparison));
                }
                else
                {
                    var channels = Cv2.Split(comparison);
                    try
                    {
                        foreach (var channel in channels)
                        {
                            Assert.Zero(Cv2.CountNonZero(channel));
                        }
                    }
                    finally
                    {
                        foreach (var channel in channels)
                        {
                            channel.Dispose();
                        }
                    }
                }
            }
        }

        protected void ShowImagesWhenDebugMode(params Mat[] mats)
        {
            if (Debugger.IsAttached)
            {
                Window.ShowImages(mats);
            }
        }
    }
}
