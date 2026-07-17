using OpenCvSharp.Detail;
using Xunit;

#pragma warning disable CA5394 // Do not use insecure randomness

namespace OpenCvSharp.Tests.Stitching;

public class StitchingTest : TestBase
{
    private readonly ITestOutputHelper testOutputHelper;

    public StitchingTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Run()
    {
        Mat[] images = SelectStitchingImages(200, 200, 12);

        using (var stitcher = Stitcher.Create(Stitcher.Mode.Scans))
        using (var pano = new Mat())
        {
            testOutputHelper.WriteLine("Stitching start...");
            var status = stitcher.Stitch(images, pano);
            testOutputHelper.WriteLine("finish (status:{0})", status);
            Assert.Equal(Stitcher.Status.OK, status);

            ShowImagesWhenDebugMode(pano);
        }

        foreach (Mat image in images)
        {
            image.Dispose();
        }
    }

    private static Mat[] SelectStitchingImages(int width, int height, int count)
    {
        var mats = new List<Mat>();

        using var source = LoadImage(@"lenna.png");
        using var result = source.Clone();
        var rand = new Random(123); // constant seed for test
        for (int i = 0; i < count; i++)
        {
            int x1 = rand.Next(source.Cols - width);
            int y1 = rand.Next(source.Rows - height);
            int x2 = x1 + width;
            int y2 = y1 + height;

            Cv2.Line(result, new Point(x1, y1), new Point(x1, y2), new Scalar(0, 0, 255));
            Cv2.Line(result, new Point(x1, y2), new Point(x2, y2), new Scalar(0, 0, 255));
            Cv2.Line(result, new Point(x2, y2), new Point(x2, y1), new Scalar(0, 0, 255));
            Cv2.Line(result, new Point(x2, y1), new Point(x1, y1), new Scalar(0, 0, 255));

            Mat m = source[new Rect(x1, y1, width, height)];
            mats.Add(m.Clone());
        }

        ShowImagesWhenDebugMode(result);

        return mats.ToArray();
    }

    // ArrayProxy migration coverage (issue #1976): two-step estimate + compose.
    [Fact]
    public void ComposePanorama()
    {
        Mat[] images = SelectStitchingImages(200, 200, 12);
        try
        {
            using var stitcher = Stitcher.Create(Stitcher.Mode.Scans);
            using var pano = new Mat();
            var est = stitcher.EstimateTransform(images);
            Assert.Equal(Stitcher.Status.OK, est);
            var status = stitcher.ComposePanorama(pano);
            Assert.Equal(Stitcher.Status.OK, status);
            ShowImagesWhenDebugMode(pano);
        }
        finally
        {
            foreach (Mat image in images)
                image.Dispose();
        }
    }

    [Fact]
    public void PropertyRegistrationResol()
    {
        using var stitcher = Stitcher.Create();
        const double value = 3.14159;
        stitcher.RegistrationResol = value;
        Assert.Equal(value, stitcher.RegistrationResol, 6);
    }

    [Fact]
    public void PropertySeamEstimationResol()
    {
        using var stitcher = Stitcher.Create();
        const double value = 3.14159;
        stitcher.SeamEstimationResol = value;
        Assert.Equal(value, stitcher.SeamEstimationResol, 6);
    }

    [Fact]
    public void PropertyRCompositingResol()
    {
        using var stitcher = Stitcher.Create();
        const double value = 3.14159;
        stitcher.CompositingResol = value;
        Assert.Equal(value, stitcher.CompositingResol, 6);
    }

    [Fact]
    public void PropertyPanoConfidenceThresh()
    {
        using var stitcher = Stitcher.Create();
        const double value = 3.14159;
        stitcher.PanoConfidenceThresh = value;
        Assert.Equal(value, stitcher.PanoConfidenceThresh, 6);
    }

    [Fact]
    public void PropertyWaveCorrection()
    {
        using var stitcher = Stitcher.Create();
        const bool value = true;
        stitcher.WaveCorrection = value;
        Assert.Equal(value, stitcher.WaveCorrection);
    }

    [Fact]
    public void PropertyWaveCorrectKind()
    {
        using var stitcher = Stitcher.Create();
        const WaveCorrectKind value = WaveCorrectKind.Vertical;
        stitcher.WaveCorrectKind = value;
        Assert.Equal(value, stitcher.WaveCorrectKind);
    }

    [Fact]
    public void MatchingMaskProperty()
    {
        using var stitcher = Stitcher.Create();
        using var mask = new Mat(3, 3, MatType.CV_8U, Scalar.All(1));
        stitcher.MatchingMask = mask;
        using var roundTripped = stitcher.MatchingMask;
        Assert.Equal(mask.Size(), roundTripped.Size());
    }

    [Fact]
    public void CustomPipelineComponentsStitch()
    {
        Mat[] images = SelectStitchingImages(200, 200, 6);
        try
        {
            using var stitcher = Stitcher.Create(Stitcher.Mode.Scans);
            using var warper = new PlaneWarper();
            using var exposureCompensator = new GainCompensator();
            using var seamFinder = new VoronoiSeamFinder();
            using var blender = new FeatherBlender();
            using var bundleAdjuster = new BundleAdjusterRay();

            stitcher.SetWarper(warper);
            stitcher.SetExposureCompensator(exposureCompensator);
            stitcher.SetSeamFinder(seamFinder);
            stitcher.SetBlender(blender);
            stitcher.SetBundleAdjuster(bundleAdjuster);

            using var pano = new Mat();
            var status = stitcher.Stitch(images, pano);
            Assert.Equal(Stitcher.Status.OK, status);

            var cameras = stitcher.Cameras;
            Assert.NotEmpty(cameras);
            foreach (var cam in cameras)
                cam.Dispose();
        }
        finally
        {
            foreach (Mat image in images)
                image.Dispose();
        }
    }
}
