using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Background Subtraction using Local SVD Binary Pattern. More details about the algorithm can be
/// found at "Local SVD Binary Pattern (LSBP) for Background Subtraction in Complex Scenes" (Guo et al., 2016).
/// </summary>
public class BackgroundSubtractorLSBP : BackgroundSubtractor
{
    /// <summary>
    /// Creates an instance of BackgroundSubtractorLSBP algorithm.
    /// </summary>
    /// <param name="mc">Whether to use camera motion compensation.</param>
    /// <param name="nSamples">Number of samples to maintain at each point of the frame.</param>
    /// <param name="lsbpRadius">LSBP descriptor radius.</param>
    /// <param name="tLower">Lower bound for T-values.</param>
    /// <param name="tUpper">Upper bound for T-values.</param>
    /// <param name="tInc">Increase step for T-values.</param>
    /// <param name="tDec">Decrease step for T-values.</param>
    /// <param name="rScale">Scale coefficient for threshold values.</param>
    /// <param name="rIncdec">Increase/Decrease step for threshold values.</param>
    /// <param name="noiseRemovalThresholdFacBG">Strength of the noise removal for background points.</param>
    /// <param name="noiseRemovalThresholdFacFG">Strength of the noise removal for foreground points.</param>
    /// <param name="lsbpThreshold">Threshold for LSBP binary string.</param>
    /// <param name="minCount">Minimal number of matches for sample to be considered as foreground.</param>
    /// <returns></returns>
    public static BackgroundSubtractorLSBP Create(
        LSBPCameraMotionCompensation mc = LSBPCameraMotionCompensation.None,
        int nSamples = 20,
        int lsbpRadius = 16,
        float tLower = 2.0f,
        float tUpper = 32.0f,
        float tInc = 1.0f,
        float tDec = 0.05f,
        float rScale = 10.0f,
        float rIncdec = 0.005f,
        float noiseRemovalThresholdFacBG = 0.0004f,
        float noiseRemovalThresholdFacFG = 0.0008f,
        int lsbpThreshold = 8,
        int minCount = 2)
    {
        NativeMethods.HandleException(
            NativeMethods.bgsegm_createBackgroundSubtractorLSBP(
                (int)mc, nSamples, lsbpRadius, tLower, tUpper, tInc, tDec,
                rScale, rIncdec, noiseRemovalThresholdFacBG, noiseRemovalThresholdFacFG,
                lsbpThreshold, minCount, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.bgsegm_Ptr_BackgroundSubtractorLSBP_get(smartPtr, out var rawPtr));
        return new BackgroundSubtractorLSBP(smartPtr, rawPtr);
    }

    private BackgroundSubtractorLSBP(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.bgsegm_Ptr_BackgroundSubtractorLSBP_delete(p)))
    { }
}
