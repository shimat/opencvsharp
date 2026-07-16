using OpenCvSharp.Text;
using Xunit;

namespace OpenCvSharp.Tests.Text;

// ReSharper disable InconsistentNaming
public class ERFilterTest : TestBase
{
    [Fact]
    public void ComputeNMChannels()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);

        var channels = Cv2.Text.ComputeNMChannels(src);

        Assert.NotEmpty(channels);
        foreach (var ch in channels)
        {
            using (ch)
            {
                Assert.False(ch.Empty());
            }
        }
    }

    [Fact]
    public void ComputeNMChannels_IHSGrad()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);

        var channels = Cv2.Text.ComputeNMChannels(src, ERFilterNMMode.IHSGrad);

        Assert.NotEmpty(channels);
        foreach (var ch in channels)
        {
            ch.Dispose();
        }
    }

    [Fact]
    public void CreateNM1_MissingFile_Throws()
    {
        // No trained classifier model is bundled with the test assets; this proves the file-based
        // factory overload reaches native and surfaces the missing-file error rather than crashing.
        Assert.ThrowsAny<Exception>(() => ERFilter.CreateNM1("_data/text/no_such_classifier_nm1.xml"));
    }

    [Fact]
    public void CreateNM2_MissingFile_Throws()
    {
        Assert.ThrowsAny<Exception>(() => ERFilter.CreateNM2("_data/text/no_such_classifier_nm2.xml"));
    }

    [Fact]
    public void LoadClassifierNM1_MissingFile_Throws()
    {
        Assert.ThrowsAny<Exception>(() => ERFilterCallback.LoadClassifierNM1("_data/text/no_such_classifier_nm1.xml"));
    }
}
