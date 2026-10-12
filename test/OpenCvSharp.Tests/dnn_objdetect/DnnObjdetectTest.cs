using Xunit;

namespace OpenCvSharp.Tests.DnnObjdetect;

public class DnnObjdetectTest : TestBase
{
    [Fact]
    public void InferBboxesFiltersSqueezeDetOutput()
    {
        using var deltas = new Mat(new MatShape(23, 23, 36), MatType.CV_32FC1, Scalar.All(0));
        using var classes = new Mat(4761, 20, MatType.CV_32FC1, Scalar.All(0));
        using var confidences = new Mat(new MatShape(23, 23, 9), MatType.CV_32FC1, Scalar.All(0));

        Assert.Empty(Cv2.DnnObjdetect.InferBboxes(deltas, classes, confidences));

        confidences.Set(0, 0, 0, 1f);
        classes.Set(0, 14, 1f);
        var detection = Assert.Single(Cv2.DnnObjdetect.InferBboxes(deltas, classes, confidences));

        Assert.Equal(14, detection.ClassIndex);
        Assert.Equal("person", detection.Label);
        Assert.Equal(1, detection.Probability);
        Assert.True(detection.XMax > detection.XMin);
        Assert.True(detection.YMax > detection.YMin);
    }

    [Fact]
    public void InferBboxesRejectsIncorrectShape()
    {
        using var deltas = new Mat(new MatShape(23, 23, 35), MatType.CV_32FC1, Scalar.All(0));
        using var classes = new Mat(4761, 20, MatType.CV_32FC1, Scalar.All(0));
        using var confidences = new Mat(new MatShape(23, 23, 9), MatType.CV_32FC1, Scalar.All(0));

        Assert.Throws<ArgumentException>(() => Cv2.DnnObjdetect.InferBboxes(deltas, classes, confidences));
    }
}
