using OpenCvSharp.Reg;
using Xunit;

namespace OpenCvSharp.Tests.Reg;

public class CvRegTest : TestBase
{
    [Fact]
    public void EstimatesTranslationFromTexturedImages()
    {
        using var reference = CreateTexturedImage();
        using var moving = new Mat();
        using var knownTransform = Mat.FromPixelData(2, 3, MatType.CV_64FC1,
            new double[] { 1, 0, 2, 0, 1, -3 });
        Cv2.WarpAffine(reference, moving, knownTransform, reference.Size());

        using var estimated = CvReg.EstimateTransform(reference, moving);

        Assert.Equal(MatType.CV_64FC1, estimated.Type());
        Assert.Equal(3, estimated.Rows);
        Assert.Equal(3, estimated.Cols);
        Assert.InRange(estimated.At<double>(0, 2), 1.5, 2.5);
        Assert.InRange(estimated.At<double>(1, 2), -3.5, -2.5);
    }

    [Theory]
    [InlineData(RegistrationMotionModel.Euclidean)]
    [InlineData(RegistrationMotionModel.Similarity)]
    [InlineData(RegistrationMotionModel.Affine)]
    [InlineData(RegistrationMotionModel.Projective)]
    public void IdenticalImagesProduceIdentityTransform(RegistrationMotionModel model)
    {
        using var image = CreateTexturedImage();
        using var transform = CvReg.EstimateTransform(image, image, model,
            pyramidLevels: 1, iterationsPerLevel: 1);

        for (var row = 0; row < 3; row++)
        {
            for (var col = 0; col < 3; col++)
                Assert.InRange(transform.At<double>(row, col),
                    (row == col ? 1.0 : 0.0) - 0.1,
                    (row == col ? 1.0 : 0.0) + 0.1);
        }
    }

    [Fact]
    public void RejectsMismatchedImageTypes()
    {
        using var reference = CreateTexturedImage();
        using var moving = new Mat(reference.Size(), MatType.CV_8UC1);

        Assert.Throws<ArgumentException>(() => CvReg.EstimateTransform(reference, moving));
    }

    private static Mat CreateTexturedImage()
    {
        const int size = 128;
        var random = new Random(42);
        var pixels = new float[size * size];
        for (var i = 0; i < pixels.Length; i++)
            pixels[i] = random.NextSingle();
        var image = Mat.FromPixelData(size, size, MatType.CV_32FC1, pixels);
        Cv2.GaussianBlur(image, image, new Size(0, 0), 2);
        return image;
    }
}
