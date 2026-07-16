using Xunit;

namespace OpenCvSharp.Tests.Photo;

public class ColorCorrectionModelTest : TestBase
{
    // 24 synthetic RGB patch colors in [0, 1], matching the patch count of the built-in Macbeth
    // ColorChecker. The values are arbitrary - this only exercises the P/Invoke plumbing, not the
    // numerical quality of the fitted correction matrix.
    private static Mat MakeSyntheticPatches()
    {
        var values = new Vec3d[24];
        var rnd = new Random(42);
        for (var i = 0; i < values.Length; i++)
        {
            values[i] = new Vec3d(rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble());
        }
        return Mat.FromArray(values);
    }

    [Fact]
    public void CreateFromBuiltInColorChecker_ComputeAndCorrect()
    {
        using var src = MakeSyntheticPatches();
        using var model = new ColorCorrectionModel(src, ColorCheckerType.Macbeth);

        model.SetColorSpace(ColorSpace.SRGB);
        model.SetCcmType(CcmType.Linear);
        model.SetDistance(DistanceType.CIE2000);
        model.SetLinearization(LinearizationType.Gamma);
        model.SetLinearizationGamma(2.2);
        model.SetSaturatedThreshold(0, 1);
        model.SetInitialMethod(InitialMethodType.LeastSquare);
        model.SetMaxCount(500);
        model.SetEpsilon(1e-4);
        model.SetRGB(true);

        using var ccm = model.Compute();
        Assert.False(ccm.Empty());

        using var matrix = model.GetColorCorrectionMatrix();
        Assert.False(matrix.Empty());

        _ = model.GetLoss();

        using var srcImage = LoadImage("lenna.png", ImreadModes.Color);
        using var corrected = new Mat();
        model.CorrectImage(srcImage, corrected);
        Assert.False(corrected.Empty());
        Assert.Equal(srcImage.Size(), corrected.Size());
    }

    [Fact]
    public void CreateFromExplicitReferenceColors()
    {
        using var src = MakeSyntheticPatches();
        using var colors = MakeSyntheticPatches();
        using var model = new ColorCorrectionModel(src, colors, ColorSpace.SRGB);

        using var ccm = model.Compute();
        Assert.False(ccm.Empty());
    }

    [Fact]
    public void GammaCorrection()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();

        Cv2.GammaCorrection(src, dst, 2.2);

        Assert.False(dst.Empty());
        Assert.Equal(src.Size(), dst.Size());
    }
}
