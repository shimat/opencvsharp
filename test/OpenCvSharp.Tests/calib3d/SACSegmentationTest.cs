using System;
using System.Collections.Generic;
using Xunit;

#pragma warning disable CA5394 // Do not use insecure randomness

namespace OpenCvSharp.Tests.Calib3D;

public class SACSegmentationTest : TestBase
{
    private static Mat MakePlaneWithOutliers(Random rng, int inlierCount, int outlierCount)
    {
        var pts = new List<Point3f>();
        for (var i = 0; i < inlierCount; i++)
            pts.Add(new Point3f((float)rng.NextDouble(), (float)rng.NextDouble(), 0));
        for (var i = 0; i < outlierCount; i++)
            pts.Add(new Point3f((float)rng.NextDouble() * 5, (float)rng.NextDouble() * 5, 2 + (float)rng.NextDouble() * 5));

        return Mat.FromPixelData(pts.Count, 1, MatType.CV_32FC3, pts.ToArray());
    }

    [Fact]
    public void SegmentFindsPlane()
    {
        var rng = new Random(41);
        using var inputPts = MakePlaneWithOutliers(rng, 200, 20);
        using var seg = SACSegmentation.Create(SacModelType.SAC_MODEL_PLANE, SacMethod.SAC_METHOD_RANSAC, 0.05, 1000);
        using var labels = new Mat();
        using var modelsCoefficients = new Mat();

        var numModels = seg.Segment(inputPts, labels, modelsCoefficients);

        Assert.True(numModels >= 1);
        Assert.Equal((long)inputPts.Rows, labels.Total());
        Assert.Equal(4, modelsCoefficients.Cols);

        // Plane coefficients [a, b, c, d] for z=0: the (unnormalized) normal (a, b, c)
        // should point mostly along z regardless of its overall scale.
        var a = modelsCoefficients.Get<double>(0, 0);
        var b = modelsCoefficients.Get<double>(0, 1);
        var c = modelsCoefficients.Get<double>(0, 2);
        var cosZ = Math.Abs(c) / Math.Sqrt(a * a + b * b + c * c);
        Assert.True(cosZ > 0.9, $"expected normal close to z-axis, got ({a},{b},{c}) cosZ={cosZ}");
    }

    [Fact]
    public void GetSetProperties()
    {
        using var seg = SACSegmentation.Create();

        seg.SacModelType = SacModelType.SAC_MODEL_SPHERE;
        Assert.Equal(SacModelType.SAC_MODEL_SPHERE, seg.SacModelType);

        seg.SacMethodType = SacMethod.SAC_METHOD_RANSAC;
        Assert.Equal(SacMethod.SAC_METHOD_RANSAC, seg.SacMethodType);

        seg.DistanceThreshold = 0.25;
        Assert.Equal(0.25, seg.DistanceThreshold, 6);

        seg.SetRadiusLimits(0.1, 2.0);
        seg.GetRadiusLimits(out var radiusMin, out var radiusMax);
        Assert.Equal(0.1, radiusMin, 6);
        Assert.Equal(2.0, radiusMax, 6);

        seg.MaxIterations = 500;
        Assert.Equal(500, seg.MaxIterations);

        seg.Confidence = 0.9;
        Assert.Equal(0.9, seg.Confidence, 6);

        seg.NumberOfModelsExpected = 2;
        Assert.Equal(2, seg.NumberOfModelsExpected);

        seg.IsParallel = true;
        Assert.True(seg.IsParallel);
        seg.IsParallel = false;
        Assert.False(seg.IsParallel);

        seg.RandomGeneratorState = 12345UL;
        Assert.Equal(12345UL, seg.RandomGeneratorState);
    }

    [Fact]
    public void CustomModelConstraintsRejectingAllModelsYieldsZeroModels()
    {
        var rng = new Random(43);
        using var inputPts = MakePlaneWithOutliers(rng, 200, 20);
        using var seg = SACSegmentation.Create(SacModelType.SAC_MODEL_PLANE, SacMethod.SAC_METHOD_RANSAC, 0.05, 1000);
        using var labels = new Mat();
        using var modelsCoefficients = new Mat();

        var invoked = false;
        seg.SetCustomModelConstraints(coefficients =>
        {
            invoked = true;
            Assert.Equal(4, coefficients.Length);
            return false;
        });

        var numModels = seg.Segment(inputPts, labels, modelsCoefficients);

        Assert.True(invoked);
        Assert.Equal(0, numModels);
        Assert.NotNull(seg.GetCustomModelConstraints());

        seg.SetCustomModelConstraints(null);
        Assert.Null(seg.GetCustomModelConstraints());
    }
}
