using OpenCvSharp.Face;
using Xunit;

namespace OpenCvSharp.Tests.Face;

// ReSharper disable once InconsistentNaming
public class MACETest
{
    [Fact]
    public void TrainAndRecognizeTrainingImage()
    {
        using var first = CreateImage(10);
        using var second = CreateImage(20);
        using var model = MACE.Create(64);
        model.Salt("test-passphrase");

        model.Train([first, second]);

        Assert.True(model.Same(first));
    }

    private static Mat CreateImage(int offset)
    {
        var image = new Mat(64, 64, MatType.CV_8UC1, Scalar.Black);
        Cv2.Circle(image, new Point(32 + offset / 10, 32), 16, Scalar.White, -1);
        Cv2.Line(image, new Point(12, 12 + offset), new Point(52, 52), Scalar.Gray, 2);
        return image;
    }
}
