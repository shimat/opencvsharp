using Xunit;

namespace OpenCvSharp.Tests.Face;

public class FaceUtilitiesTest : TestBase
{
    [Fact]
    public void LoadFacePointsAndDrawFacemarks()
    {
        var file = Path.GetTempFileName();
        try
        {
            File.WriteAllText(file, "version: 1\nn_points: 2\n{\n10 12\n20 24\n}\n");

            var loaded = Cv2.Face.LoadFacePoints(file, out var points);

            Assert.True(loaded);
            Assert.Equal([new Point2f(10, 12), new Point2f(20, 24)], points);
            using var image = new Mat(40, 40, MatType.CV_8UC3, Scalar.Black);
            using var pointsMat = Mat.FromPixelData(points.Length, 1, MatType.CV_32FC2, points);
            Cv2.Face.DrawFacemarks(image, pointsMat, Scalar.Red);
            Assert.NotEqual(0, Cv2.CountNonZero(image.Reshape(1)));
        }
        finally
        {
            File.Delete(file);
        }
    }

    [Fact]
    public void LoadDatasetList()
    {
        var imagesFile = Path.GetTempFileName();
        var annotationsFile = Path.GetTempFileName();
        try
        {
            File.WriteAllLines(imagesFile, ["image-a.png", "image-b.png"]);
            File.WriteAllLines(annotationsFile, ["face-a.pts", "face-b.pts"]);

            var loaded = Cv2.Face.LoadDatasetList(
                imagesFile, annotationsFile, out var images, out var annotations);

            Assert.True(loaded);
            Assert.Equal(["image-a.png", "image-b.png"], images);
            Assert.Equal(["face-a.pts", "face-b.pts"], annotations);
        }
        finally
        {
            File.Delete(imagesFile);
            File.Delete(annotationsFile);
        }
    }
}
