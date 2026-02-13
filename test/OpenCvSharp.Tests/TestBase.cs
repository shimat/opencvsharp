using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using Xunit;

[assembly: CollectionBehavior(/*MaxParallelThreads = 2, */DisableTestParallelization = true)]

#pragma warning disable CA1810 // Initialize reference type static fields inline
#pragma warning disable CA5359 

namespace OpenCvSharp.Tests;

public abstract class TestBase
{
    static TestBase()
    {
#pragma warning disable CA5364
#pragma warning disable CA5386
        ServicePointManager.ServerCertificateValidationCallback = (_, _, _, _) => true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
#pragma warning restore CA5364
#pragma warning restore CA5386
    }

    protected static Mat LoadImage(string fileName, ImreadModes modes = ImreadModes.Color) 
        => new(Path.Combine("_data", "image", fileName), modes);

    protected static void ImageEquals(Mat img1, Mat img2)
    {
        if (img1 is null && img2 is null)
            return;
        Assert.NotNull(img1);
        Assert.NotNull(img2);
#pragma warning disable CS8602
#pragma warning disable CA1062
        Assert.Equal(img1.Type(), img2.Type());
#pragma warning restore CS8602 
#pragma warning restore CA1062 

        using var comparison = new Mat();
        Cv2.Compare(img1, img2, comparison, CmpType.NE);

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

    protected static void ShowImagesWhenDebugMode(params Mat[] mats)
    {
        if (Debugger.IsAttached)
        {
            Window.ShowImages(mats);
        }
    }

    protected static void ShowImagesWhenDebugMode(IEnumerable<Mat> mats, IEnumerable<string> names)
    {
        if (Debugger.IsAttached)
        {
            Window.ShowImages(mats, names);
        }
    }
}
