using OpenCvSharp.LineDescriptor;
using Xunit;

namespace OpenCvSharp.Tests.LineDescriptor;

public class BinaryDescriptorTest
{
    [Fact]
    public void DetectComputeMatchAndDraw()
    {
        using var image = Mat.Zeros(200, 200, MatType.CV_8UC1).ToMat();
        Cv2.Line(image, new Point(20, 20), new Point(180, 20), Scalar.White, 2);
        Cv2.Line(image, new Point(20, 60), new Point(180, 160), Scalar.White, 2);
        using var descriptor = BinaryDescriptor.Create();

        var keyLines = descriptor.Detect(image);
        using var descriptors = new Mat();
        descriptor.Compute(image, ref keyLines, descriptors);

        Assert.NotEmpty(keyLines);
        Assert.Equal(keyLines.Length, descriptors.Rows);
        Assert.Equal(descriptor.DescriptorSize / 8, descriptors.Cols);

        using var matcher = BinaryDescriptorMatcher.Create();
        var matches = matcher.Match(descriptors, descriptors);
        Assert.Equal(keyLines.Length, matches.Length);
        var nearest = matcher.KnnMatch(descriptors, descriptors, 1);
        Assert.Equal(keyLines.Length, nearest.Length);

        matcher.Add([descriptors]);
        matcher.Train();
        Assert.Equal(keyLines.Length, matcher.MatchQuery(descriptors).Length);
        Assert.Equal(keyLines.Length, matcher.KnnMatchQuery(descriptors, 1).Length);
        matcher.Clear();

        using var drawn = new Mat();
        Cv2.LineDescriptor.DrawKeylines(image, keyLines, drawn);
        Assert.False(drawn.Empty());

        using var matchesDrawn = new Mat();
        Cv2.LineDescriptor.DrawLineMatches(
            image, keyLines, image, keyLines, matches, matchesDrawn,
            matchesMask: Enumerable.Repeat((byte)1, matches.Length).ToArray());
        Assert.False(matchesDrawn.Empty());
    }

    [Fact]
    public void DetectAndComputeMultipleImages()
    {
        using var image1 = Mat.Zeros(200, 200, MatType.CV_8UC1).ToMat();
        using var image2 = Mat.Zeros(200, 200, MatType.CV_8UC1).ToMat();
        Cv2.Line(image1, new Point(20, 20), new Point(180, 20), Scalar.White, 2);
        Cv2.Line(image2, new Point(20, 80), new Point(180, 160), Scalar.White, 2);
        using var descriptor = BinaryDescriptor.Create();

        var keyLines = descriptor.Detect([image1, image2]);
        descriptor.Compute([image1, image2], ref keyLines, out var descriptors);
        try
        {
            Assert.Equal(2, keyLines.Length);
            Assert.Equal(2, descriptors.Length);
            Assert.Equal(keyLines[0].Length, descriptors[0].Rows);
            Assert.Equal(keyLines[1].Length, descriptors[1].Rows);
        }
        finally
        {
            foreach (var value in descriptors)
                value.Dispose();
        }
    }
}
