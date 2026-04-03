using Xunit;

namespace OpenCvSharp.Tests.Shape;

#pragma warning disable CA1707 // Identifiers should not contain underscores

public class HistogramCostExtractorTest : TestBase
{
    // ----------------------------------------------------------------
    // NormHistogramCostExtractor
    // ----------------------------------------------------------------

    [Fact]
    public void Norm_CreateAndDispose()
    {
        using var ext = NormHistogramCostExtractor.Create();
        Assert.NotNull(ext);
    }

    [Fact]
    public void Norm_CreateViaStaticMethod()
    {
        using var ext = CvShape.CreateNormHistogramCostExtractor();
        Assert.NotNull(ext);
    }

    [Fact]
    public void Norm_CreateWithCustomParameters()
    {
        using var ext = NormHistogramCostExtractor.Create(DistanceTypes.L1, nDummies: 10, defaultCost: 0.5f);
        Assert.Equal(DistanceTypes.L1, ext.NormFlag);
        Assert.Equal(10, ext.NDummies);
        Assert.Equal(0.5f, ext.DefaultCost, precision: 5);
    }

    [Fact]
    public void Norm_NormFlagRoundTrip()
    {
        using var ext = NormHistogramCostExtractor.Create();
        ext.NormFlag = DistanceTypes.L1;
        Assert.Equal(DistanceTypes.L1, ext.NormFlag);
        ext.NormFlag = DistanceTypes.L2;
        Assert.Equal(DistanceTypes.L2, ext.NormFlag);
    }

    [Fact]
    public void Norm_NDummiesRoundTrip()
    {
        using var ext = NormHistogramCostExtractor.Create();
        ext.NDummies = 10;
        Assert.Equal(10, ext.NDummies);
    }

    [Fact]
    public void Norm_DefaultCostRoundTrip()
    {
        using var ext = NormHistogramCostExtractor.Create();
        ext.DefaultCost = 0.5f;
        Assert.Equal(0.5f, ext.DefaultCost, precision: 5);
    }

    [Fact]
    public void Norm_BuildCostMatrix()
    {
        using var ext = NormHistogramCostExtractor.Create();
        using var hist1 = Mat.FromArray(new float[] { 0.5f, 0.3f, 0.2f });
        using var hist2 = Mat.FromArray(new float[] { 0.4f, 0.4f, 0.2f });
        using var costMat = new Mat();

        ext.BuildCostMatrix(hist1, hist2, costMat);

        Assert.False(costMat.Empty());
    }

    // ----------------------------------------------------------------
    // EMDHistogramCostExtractor
    // ----------------------------------------------------------------

    [Fact]
    public void EMD_CreateAndDispose()
    {
        using var ext = EMDHistogramCostExtractor.Create();
        Assert.NotNull(ext);
    }

    [Fact]
    public void EMD_CreateViaStaticMethod()
    {
        using var ext = CvShape.CreateEMDHistogramCostExtractor();
        Assert.NotNull(ext);
    }

    [Fact]
    public void EMD_NormFlagRoundTrip()
    {
        using var ext = EMDHistogramCostExtractor.Create();
        ext.NormFlag = DistanceTypes.L1;
        Assert.Equal(DistanceTypes.L1, ext.NormFlag);
    }

    [Fact]
    public void EMD_NDummiesRoundTrip()
    {
        using var ext = EMDHistogramCostExtractor.Create();
        ext.NDummies = 5;
        Assert.Equal(5, ext.NDummies);
    }

    // ----------------------------------------------------------------
    // ChiHistogramCostExtractor
    // ----------------------------------------------------------------

    [Fact]
    public void Chi_CreateAndDispose()
    {
        using var ext = ChiHistogramCostExtractor.Create();
        Assert.NotNull(ext);
    }

    [Fact]
    public void Chi_CreateViaStaticMethod()
    {
        using var ext = CvShape.CreateChiHistogramCostExtractor();
        Assert.NotNull(ext);
    }

    [Fact]
    public void Chi_NDummiesRoundTrip()
    {
        using var ext = ChiHistogramCostExtractor.Create();
        ext.NDummies = 15;
        Assert.Equal(15, ext.NDummies);
    }

    [Fact]
    public void Chi_DefaultCostRoundTrip()
    {
        using var ext = ChiHistogramCostExtractor.Create();
        ext.DefaultCost = 0.3f;
        Assert.Equal(0.3f, ext.DefaultCost, precision: 5);
    }

    // ----------------------------------------------------------------
    // EMDL1HistogramCostExtractor
    // ----------------------------------------------------------------

    [Fact]
    public void EMDL1Ext_CreateAndDispose()
    {
        using var ext = EMDL1HistogramCostExtractor.Create();
        Assert.NotNull(ext);
    }

    [Fact]
    public void EMDL1Ext_CreateViaStaticMethod()
    {
        using var ext = CvShape.CreateEMDL1HistogramCostExtractor();
        Assert.NotNull(ext);
    }

    [Fact]
    public void EMDL1Ext_NDummiesRoundTrip()
    {
        using var ext = EMDL1HistogramCostExtractor.Create();
        ext.NDummies = 8;
        Assert.Equal(8, ext.NDummies);
    }

    // ----------------------------------------------------------------
    // CvShape.EMDL1 free function
    // ----------------------------------------------------------------

    [Fact]
    public void EMDL1_IdenticalSignatures()
    {
        var data = new float[] { 0.1f, 0.3f, 0.4f, 0.2f };
        using var sig = Mat.FromArray(data);

        float dist = CvShape.EMDL1(sig, sig);
        Assert.True(dist >= 0, $"Expected non-negative distance, got {dist}");
    }

    [Fact]
    public void EMDL1_DifferentSignatures()
    {
        var d1 = new float[] { 1.0f, 0.0f, 0.0f, 0.0f };
        var d2 = new float[] { 0.0f, 0.0f, 0.0f, 1.0f };
        using var sig1 = Mat.FromArray(d1);
        using var sig2 = Mat.FromArray(d2);

        float dist = CvShape.EMDL1(sig1, sig2);
        Assert.True(dist > 0, $"Expected positive distance, got {dist}");
    }

    // ----------------------------------------------------------------
    // SetCostExtractor / SetTransformAlgorithm on ShapeContextDistanceExtractor
    // ----------------------------------------------------------------

    [Fact]
    public void SCDE_SetCostExtractor_Chi()
    {
        using var extractor = ShapeContextDistanceExtractor.Create(
            nAngularBins: 5, nRadialBins: 3, iterations: 1);
        using var costExt = ChiHistogramCostExtractor.Create();

        // Should not throw
        extractor.SetCostExtractor(costExt);
    }

    [Fact]
    public void SCDE_SetCostExtractor_Norm()
    {
        using var extractor = ShapeContextDistanceExtractor.Create(
            nAngularBins: 5, nRadialBins: 3, iterations: 1);
        using var costExt = NormHistogramCostExtractor.Create(DistanceTypes.L1);

        extractor.SetCostExtractor(costExt);
    }

    [Fact]
    public void SCDE_SetTransformAlgorithm_TPS()
    {
        using var extractor = ShapeContextDistanceExtractor.Create(
            nAngularBins: 5, nRadialBins: 3, iterations: 1);
        using var tps = ThinPlateSplineShapeTransformer.Create(regularizationParameter: 0.1);

        // Should not throw
        extractor.SetTransformAlgorithm(tps);
    }

    [Fact]
    public void SCDE_SetTransformAlgorithm_Affine()
    {
        using var extractor = ShapeContextDistanceExtractor.Create(
            nAngularBins: 5, nRadialBins: 3, iterations: 1);
        using var affine = AffineTransformer.Create(fullAffine: true);

        extractor.SetTransformAlgorithm(affine);
    }
}