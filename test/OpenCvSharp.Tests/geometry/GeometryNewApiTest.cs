using Xunit;

namespace OpenCvSharp.Tests;

public class GeometryNewApiTest : TestBase
{
    [Fact]
    public void PnPMethodsReturnPoseCandidates()
    {
        var objectPoints = new[]
        {
            new Point3f(0, 0, 1), new Point3f(1, 0, 1),
            new Point3f(0, 1, 1), new Point3f(1, 1, 1)
        };
        var camera = new double[,] { { 100, 0, 50 }, { 0, 100, 50 }, { 0, 0, 1 } };
        var distortion = new double[5];
        Cv2.ProjectPoints(objectPoints, new double[3], new double[] { 0, 0, 10 },
            camera, distortion, out var imagePoints, out _);
        using var objects = Mat.FromArray(objectPoints);
        using var images = Mat.FromArray(imagePoints);
        using var cameraMat = Mat.FromArray(camera);
        using var distortionMat = Mat.FromArray(distortion);

        var p3pCount = Cv2.SolveP3P(objects, images, cameraMat, distortionMat,
            out var p3pRotations, out var p3pTranslations);
        try
        {
            Assert.True(p3pCount > 0);
            Assert.Equal(p3pCount, p3pRotations.Length);
            Assert.Equal(p3pCount, p3pTranslations.Length);
        }
        finally
        {
            DisposeAll(p3pRotations);
            DisposeAll(p3pTranslations);
        }

        var genericCount = Cv2.SolvePnPGeneric(objects, images, cameraMat, distortionMat,
            out var rotations, out var translations, flags: SolvePnPMethod.P3P);
        try
        {
            Assert.True(genericCount > 0);
            Assert.Equal(genericCount, rotations.Length);
            Assert.Equal(genericCount, translations.Length);
        }
        finally
        {
            DisposeAll(rotations);
            DisposeAll(translations);
        }
    }

    private static void DisposeAll(IEnumerable<Mat> mats)
    {
        foreach (var mat in mats)
            mat.Dispose();
    }
}
