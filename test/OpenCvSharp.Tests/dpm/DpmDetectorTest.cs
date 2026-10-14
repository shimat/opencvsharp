using OpenCvSharp.Dpm;
using Xunit;

namespace OpenCvSharp.Tests.Dpm;

public class DpmDetectorTest : TestBase
{
    [Fact]
    public void LoadsSampleModelAndDetectsWithoutChangingInput()
    {
        var modelPath = SampleModelPath;
        using var detector = DpmDetector.Create([modelPath], ["person"]);

        Assert.False(detector.IsEmpty);
        Assert.Equal(1, detector.ClassCount);
        Assert.Equal(["person"], detector.ClassNames);

        using var image = new Mat(192, 192, MatType.CV_8UC1, Scalar.All(128));
        var detections = detector.Detect(image);

        Assert.Equal(MatType.CV_8UC1, image.Type());
        Assert.All(detections, detection => Assert.Equal(0, detection.ClassId));
    }

    [Fact]
    public void RejectsMissingModelAndClassNameCountMismatch()
    {
        Assert.Throws<FileNotFoundException>(() => DpmDetector.Create(["missing-dpm-model.xml"]));
        Assert.Throws<ArgumentException>(() => DpmDetector.Create([SampleModelPath], ["a", "b"]));

        var unsupportedPath = Path.Combine(Path.GetTempPath(), $"dpm-{Guid.NewGuid():N}.XML");
        try
        {
            File.WriteAllText(unsupportedPath, string.Empty);
            Assert.Throws<ArgumentException>(() => DpmDetector.Create([unsupportedPath]));
        }
        finally
        {
            File.Delete(unsupportedPath);
        }
    }

    private static string SampleModelPath => Path.Combine(AppContext.BaseDirectory, "_data", "dpm", "inriaperson.xml");
}
