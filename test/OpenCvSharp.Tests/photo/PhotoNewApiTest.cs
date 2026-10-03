using Xunit;

namespace OpenCvSharp.Tests;

public class PhotoNewApiTest : TestBase
{
    [Fact]
    public void AlignMtbAndMergeRobertsonWorkWithExposureSequence()
    {
        using var first = new Mat(new Size(32, 32), MatType.CV_8UC3, new Scalar(60, 80, 100));
        using var second = new Mat(new Size(32, 32), MatType.CV_8UC3, new Scalar(120, 160, 200));
        using var aligner = AlignMTB.Create(cut: false);
        var aligned = aligner.Process(new[] { first, second });
        try
        {
            Assert.Equal(2, aligned.Length);
            Assert.All(aligned, image => Assert.Equal(first.Size(), image.Size()));
        }
        finally
        {
            DisposeAll(aligned);
        }

        using var merger = MergeRobertson.Create();
        using var times = Mat.FromArray(new float[] { 0.5f, 1.0f });
        using var hdr = new Mat();
        merger.Process(new[] { first, second }, hdr, times);
        Assert.Equal(MatType.CV_32FC3, hdr.Type());
        Assert.Equal(first.Size(), hdr.Size());

        using var wrongTimes = Mat.FromArray(new double[] { 0.5, 1.0 });
        Assert.Throws<OpenCVException>(() => merger.Process(new[] { first, second }, hdr, wrongTimes));
    }

    private static void DisposeAll(IEnumerable<Mat> mats)
    {
        foreach (var mat in mats)
            mat.Dispose();
    }
}
