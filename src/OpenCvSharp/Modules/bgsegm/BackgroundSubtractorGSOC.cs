using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Implementation of the different yet better algorithm which is called GSOC, as it was implemented
/// during GSOC and was not originated from any paper.
/// This algorithm demonstrates better performance on CDNET 2014 dataset compared to other algorithms in OpenCV.
/// </summary>
public class BackgroundSubtractorGSOC : BackgroundSubtractor
{
    /// <summary>
    /// Creates an instance of BackgroundSubtractorGSOC algorithm.
    /// </summary>
    /// <param name="mc">Whether to use camera motion compensation.</param>
    /// <param name="nSamples">Number of samples to maintain at each point of the frame.</param>
    /// <param name="replaceRate">Probability of replacing the old sample - how fast the model will update itself.</param>
    /// <param name="propagationRate">Probability of propagating to neighbors.</param>
    /// <param name="hitsThreshold">How many positives the sample must get before it will be considered as a possible replacement.</param>
    /// <param name="alpha">Scale coefficient for threshold.</param>
    /// <param name="beta">Bias coefficient for threshold.</param>
    /// <param name="blinkingSupressionDecay">Blinking supression decay factor.</param>
    /// <param name="blinkingSupressionMultiplier">Blinking supression multiplier.</param>
    /// <param name="noiseRemovalThresholdFacBG">Strength of the noise removal for background points.</param>
    /// <param name="noiseRemovalThresholdFacFG">Strength of the noise removal for foreground points.</param>
    /// <returns></returns>
    public static BackgroundSubtractorGSOC Create(
        LSBPCameraMotionCompensation mc = LSBPCameraMotionCompensation.None,
        int nSamples = 20,
        float replaceRate = 0.003f,
        float propagationRate = 0.01f,
        int hitsThreshold = 32,
        float alpha = 0.01f,
        float beta = 0.0022f,
        float blinkingSupressionDecay = 0.1f,
        float blinkingSupressionMultiplier = 0.1f,
        float noiseRemovalThresholdFacBG = 0.0004f,
        float noiseRemovalThresholdFacFG = 0.0008f)
    {
        NativeMethods.HandleException(
            NativeMethods.bgsegm_createBackgroundSubtractorGSOC(
                (int)mc, nSamples, replaceRate, propagationRate, hitsThreshold,
                alpha, beta, blinkingSupressionDecay, blinkingSupressionMultiplier,
                noiseRemovalThresholdFacBG, noiseRemovalThresholdFacFG, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.bgsegm_Ptr_BackgroundSubtractorGSOC_get(smartPtr, out var rawPtr));
        return new BackgroundSubtractorGSOC(smartPtr, rawPtr);
    }

    private BackgroundSubtractorGSOC(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.bgsegm_Ptr_BackgroundSubtractorGSOC_delete(p)))
    { }
}
