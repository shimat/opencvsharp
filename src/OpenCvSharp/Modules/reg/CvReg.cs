using OpenCvSharp.Internal;

namespace OpenCvSharp.Reg;

/// <summary>Direct pixel-intensity image registration.</summary>
public static class CvReg
{
    /// <summary>Estimates a 3-by-3 transform that maps reference-image coordinates to moving-image coordinates.</summary>
    /// <param name="referenceImage">Reference image in 32-bit floating-point grayscale or BGR format.</param>
    /// <param name="movingImage">Image to register, with the same size and type as the reference.</param>
    /// <param name="model">Allowed motion model.</param>
    /// <param name="pyramidLevels">Number of Gaussian-pyramid levels.</param>
    /// <param name="iterationsPerLevel">Refinement iterations at each level.</param>
    /// <returns>A 3-by-3 double-precision transform matrix.</returns>
    public static Mat EstimateTransform(
        Mat referenceImage, Mat movingImage,
        RegistrationMotionModel model = RegistrationMotionModel.Shift,
        int pyramidLevels = 3, int iterationsPerLevel = 3)
    {
        ArgumentNullException.ThrowIfNull(referenceImage);
        ArgumentNullException.ThrowIfNull(movingImage);
        referenceImage.ThrowIfDisposed();
        movingImage.ThrowIfDisposed();

        if (referenceImage.Empty() || referenceImage.Size() != movingImage.Size() ||
            referenceImage.Type() != movingImage.Type() ||
            (referenceImage.Type() != MatType.CV_32FC1 && referenceImage.Type() != MatType.CV_32FC3))
            throw new ArgumentException("Images must be nonempty and have matching sizes and 32-bit float types.");
        if (!Enum.IsDefined(model))
            throw new ArgumentOutOfRangeException(nameof(model));
        if (pyramidLevels < 1)
            throw new ArgumentOutOfRangeException(nameof(pyramidLevels));
        if (iterationsPerLevel < 1)
            throw new ArgumentOutOfRangeException(nameof(iterationsPerLevel));

        var transform = new Mat();
        try
        {
            NativeMethods.HandleException(NativeMethods.reg_estimateTransform(
                referenceImage.CvPtr, movingImage.CvPtr, (int)model,
                pyramidLevels, iterationsPerLevel, transform.CvPtr));
            GC.KeepAlive(referenceImage);
            GC.KeepAlive(movingImage);
            return transform;
        }
        catch
        {
            transform.Dispose();
            throw;
        }
    }
}
