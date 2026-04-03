namespace OpenCvSharp;

/// <summary>
/// Factory methods for the shape module.
/// </summary>
public static partial class CvShape
{
    #region shape_transformer.hpp

    /// <summary>
    /// Creates a Thin Plate Spline shape transformer.
    /// </summary>
    /// <param name="regularizationParameter">
    /// The regularization parameter for relaxing the exact interpolation requirements
    /// of the TPS algorithm. Default: 0 (exact interpolation).
    /// </param>
    /// <returns>A new ThinPlateSplineShapeTransformer instance.</returns>
    public static ThinPlateSplineShapeTransformer CreateThinPlateSplineShapeTransformer(
        double regularizationParameter = 0)
        => ThinPlateSplineShapeTransformer.Create(regularizationParameter);

    /// <summary>
    /// Creates an Affine shape transformer.
    /// </summary>
    /// <param name="fullAffine">
    /// If true, uses a full affine transformation (6 degrees of freedom).
    /// If false, uses a partial affine transformation (4 degrees of freedom). Default: false.
    /// </param>
    /// <returns>A new AffineTransformer instance.</returns>
    public static AffineTransformer CreateAffineTransformer(bool fullAffine = false)
        => AffineTransformer.Create(fullAffine);

    #endregion

    #region hist_cost.hpp

    /// <summary>
    /// Creates a norm-based histogram cost extractor.
    /// </summary>
    /// <param name="flag">Distance norm type. Default: L2.</param>
    /// <param name="nDummies">Number of dummy histogram bins. Default: 25.</param>
    /// <param name="defaultCost">Default cost for dummy bins. Default: 0.2.</param>
    public static NormHistogramCostExtractor CreateNormHistogramCostExtractor(
        DistanceTypes flag = DistanceTypes.L2, int nDummies = 25, float defaultCost = 0.2f)
        => NormHistogramCostExtractor.Create(flag, nDummies, defaultCost);

    /// <summary>
    /// Creates an EMD-based histogram cost extractor.
    /// </summary>
    /// <param name="flag">Distance norm type. Default: L2.</param>
    /// <param name="nDummies">Number of dummy histogram bins. Default: 25.</param>
    /// <param name="defaultCost">Default cost for dummy bins. Default: 0.2.</param>
    public static EMDHistogramCostExtractor CreateEMDHistogramCostExtractor(
        DistanceTypes flag = DistanceTypes.L2, int nDummies = 25, float defaultCost = 0.2f)
        => EMDHistogramCostExtractor.Create(flag, nDummies, defaultCost);

    /// <summary>
    /// Creates a chi-squared histogram cost extractor.
    /// </summary>
    /// <param name="nDummies">Number of dummy histogram bins. Default: 25.</param>
    /// <param name="defaultCost">Default cost for dummy bins. Default: 0.2.</param>
    public static ChiHistogramCostExtractor CreateChiHistogramCostExtractor(
        int nDummies = 25, float defaultCost = 0.2f)
        => ChiHistogramCostExtractor.Create(nDummies, defaultCost);

    /// <summary>
    /// Creates an EMD-L1 histogram cost extractor.
    /// </summary>
    /// <param name="nDummies">Number of dummy histogram bins. Default: 25.</param>
    /// <param name="defaultCost">Default cost for dummy bins. Default: 0.2.</param>
    public static EMDL1HistogramCostExtractor CreateEMDL1HistogramCostExtractor(
        int nDummies = 25, float defaultCost = 0.2f)
        => EMDL1HistogramCostExtractor.Create(nDummies, defaultCost);

    #endregion

    #region emdL1.hpp

    /// <summary>
    /// Computes the Earth Mover's Distance L1 (EMDL1) between two weighted point configurations.
    /// </summary>
    /// <param name="signature1">First signature: a single-column float matrix where each row is a histogram bin value.</param>
    /// <param name="signature2">Second signature, same format and size as signature1.</param>
    /// <returns>The EMDL1 distance.</returns>
    public static float EMDL1(InputArray signature1, InputArray signature2)
    {
        if (signature1 is null)
            throw new ArgumentNullException(nameof(signature1));
        if (signature2 is null)
            throw new ArgumentNullException(nameof(signature2));
        signature1.ThrowIfDisposed();
        signature2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.shape_EMDL1(signature1.CvPtr, signature2.CvPtr, out var ret));

        GC.KeepAlive(signature1);
        GC.KeepAlive(signature2);
        return ret;
    }

    #endregion
}