using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Xunit;

[assembly: CollectionBehavior(/*MaxParallelThreads = 2, */DisableTestParallelization = true)]

namespace OpenCvSharp.Tests
{
    public abstract class TestBase 
    {
        protected static Mat Image(string fileName, ImreadModes modes = ImreadModes.Color)
        {
            return new Mat(Path.Combine("_data", "image", fileName), modes);
        }

        protected static void ImageEquals(Mat img1, Mat img2)
        {
            if (img1 == null && img2 == null)
                return;
            Assert.NotNull(img1);
            Assert.NotNull(img2);
            Assert.Equal(img1.Type(), img2.Type());

            using (var comparison = new Mat())
            {
                Cv2.Compare(img1, img2, comparison, CmpTypes.NE);
                if (img1.Channels() == 1)
                {
                    Assert.Equal(0, Cv2.CountNonZero(comparison));
                }
                else
                {
                    var channels = Cv2.Split(comparison);
                    try
                    {
                        foreach (var channel in channels)
                        {
                            Assert.Equal(0, Cv2.CountNonZero(channel));
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

        protected static void ShowImagesWhenDebugMode(params Mat[] mats)
        {
            if (Debugger.IsAttached)
            {
                Window.ShowImages(mats);
            }
        }
    }
}
