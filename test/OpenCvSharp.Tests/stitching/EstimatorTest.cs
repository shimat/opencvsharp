using OpenCvSharp.Detail;
using Xunit;

namespace OpenCvSharp.Tests.Stitching;

public class EstimatorTest : TestBase
{
    private static (ImageFeatures[] features, MatchesInfo[] matches, Mat[] images) ComputeFeaturesAndMatches()
    {
        using var source = LoadImage("lenna.png", ImreadModes.Grayscale);
        var images = new[]
        {
            source[new Rect(0, 0, 200, 200)].Clone(),
            source[new Rect(100, 100, 200, 200)].Clone(),
        };
        using var orb = ORB.Create(500);
        var features = Cv2.Detail.ComputeImageFeatures(orb, images);
        using var matcher = new BestOf2NearestMatcher();
        var matches = matcher.Apply(features);
        return (features, matches, images);
    }

    [Fact]
    public void HomographyBasedEstimatorApply()
    {
        var (features, matches, images) = ComputeFeaturesAndMatches();
        try
        {
            using var estimator = new HomographyBasedEstimator();
            var cameras = new CameraParams[features.Length];
            for (var i = 0; i < cameras.Length; i++)
                cameras[i] = new CameraParams();
            try
            {
                estimator.Apply(features, matches, cameras);
                Assert.All(cameras, c => Assert.False(c.R.Empty()));
            }
            finally
            {
                foreach (var c in cameras)
                    c.Dispose();
            }
        }
        finally
        {
            foreach (var f in features) f.Dispose();
            foreach (var m in matches) m.Dispose();
            foreach (var img in images) img.Dispose();
        }
    }

    [Fact]
    public void CameraParamsK()
    {
        using var cam = new CameraParams { Focal = 100, Aspect = 1.0, Ppx = 50, Ppy = 60 };
        using var k = cam.K();
        Assert.Equal(100.0, k.At<double>(0, 0));
        Assert.Equal(50.0, k.At<double>(0, 2));
        Assert.Equal(60.0, k.At<double>(1, 2));
        Assert.Equal(1.0, k.At<double>(2, 2));
    }

    [Fact]
    public void BundleAdjusterReprojProperties()
    {
        using var adjuster = new BundleAdjusterReproj();
        Assert.False(adjuster.RefinementMask.Empty());
        adjuster.ConfThresh = 0.5;
        Assert.Equal(0.5, adjuster.ConfThresh);
        var criteria = new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 100, 1e-6);
        adjuster.TermCriteria = criteria;
        Assert.Equal(criteria.Type, adjuster.TermCriteria.Type);
    }

    [Fact]
    public void NoBundleAdjusterApply()
    {
        var (features, matches, images) = ComputeFeaturesAndMatches();
        try
        {
            using var adjuster = new NoBundleAdjuster();
            var cameras = new CameraParams[features.Length];
            for (var i = 0; i < cameras.Length; i++)
                cameras[i] = new CameraParams();
            try
            {
                var ok = adjuster.Apply(features, matches, cameras);
                Assert.True(ok);
            }
            finally
            {
                foreach (var c in cameras)
                    c.Dispose();
            }
        }
        finally
        {
            foreach (var f in features) f.Dispose();
            foreach (var m in matches) m.Dispose();
            foreach (var img in images) img.Dispose();
        }
    }

    [Fact]
    public void WaveCorrectRuns()
    {
        using var r1 = Mat.Eye(3, 3, MatType.CV_32F).ToMat();
        using var r2 = Mat.Eye(3, 3, MatType.CV_32F).ToMat();
        Cv2.Detail.WaveCorrect([r1, r2], WaveCorrectKind.Horizontal);
        Assert.False(r1.Empty());
    }

    [Fact]
    public void MatchesGraphAsStringRuns()
    {
        var (features, matches, images) = ComputeFeaturesAndMatches();
        try
        {
            var dot = Cv2.Detail.MatchesGraphAsString(images.Length, matches, 1.0f);
            Assert.NotNull(dot);
        }
        finally
        {
            foreach (var f in features) f.Dispose();
            foreach (var m in matches) m.Dispose();
            foreach (var img in images) img.Dispose();
        }
    }

    [Fact]
    public void LeaveBiggestComponentRuns()
    {
        var (features, matches, images) = ComputeFeaturesAndMatches();
        try
        {
            var indices = Cv2.Detail.LeaveBiggestComponent(features, matches, 1.0f);
            Assert.NotEmpty(indices);
        }
        finally
        {
            foreach (var f in features) f.Dispose();
            foreach (var m in matches) m.Dispose();
            foreach (var img in images) img.Dispose();
        }
    }
}
