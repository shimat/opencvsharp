using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Tracking;

// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
/// <inheritdoc />
/// <summary>
/// the CSRT tracker
/// The implementation is based on @cite Lukezic_IJCV2018 Discriminative Correlation Filter with Channel and Spatial Reliability
/// </summary>
// ReSharper disable once InconsistentNaming
public class TrackerCSRT : Tracker
{
    /// <summary>
    /// 
    /// </summary>
    private TrackerCSRT(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.tracking_Ptr_TrackerCSRT_delete(p)))
    { }
    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static TrackerCSRT Create()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_TrackerCSRT_create1(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_Ptr_TrackerCSRT_get(smartPtr, out var rawPtr));
        return new TrackerCSRT(smartPtr, rawPtr);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">CSRT parameters</param>
    /// <returns></returns>
    public static TrackerCSRT Create(Params parameters)
    {
        // window_function is a char* in the native struct, so marshal it for the duration of the call
        // (native copies it into a std::string immediately). ANSI matches the previous LPStr behavior.
        var windowFunctionPtr = Marshal.StringToCoTaskMemAnsi(parameters.WindowFunction);
        try
        {
            var native = parameters.ToNativeStruct(windowFunctionPtr);
            NativeMethods.HandleException(
                NativeMethods.tracking_TrackerCSRT_create2(ref native, out var smartPtr));
            NativeMethods.HandleException(NativeMethods.tracking_Ptr_TrackerCSRT_get(smartPtr, out var rawPtr));
            return new TrackerCSRT(smartPtr, rawPtr);
        }
        finally
        {
            Marshal.FreeCoTaskMem(windowFunctionPtr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mask"></param>
    public virtual void SetInitialMask(InputArray mask)
    {
        if (mask is null)
            throw new ArgumentNullException(nameof(mask));
        mask.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.tracking_TrackerCSRT_setInitialMask(RawPtr, mask.CvPtr));

        GC.KeepAlive(mask);
    }

    #pragma warning disable CA1034
    /// <summary>
    /// CSRT Params. A managed-friendly parameter bag; <see cref="ToNativeStruct"/> converts it into
    /// the blittable <see cref="WTrackerCSRTParams"/> mirror passed to the native entry point.
    /// </summary>
    [SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
    public struct Params
    {
#pragma warning disable 1591
        public bool UseHog;
        public bool UseColorNames;
        public bool UseGray;
        public bool UseRgb;
        public bool UseChannelWeights;
        public bool UseSegmentation;

        /// <summary>
        /// Window function: "hann", "cheb", "kaiser"
        /// </summary>
        public string WindowFunction;

        public float KaiserAlpha;
        public float ChebAttenuation;

        public float TemplateSize;
        public float GslSigma;
        public float HogOrientations;
        public float HogClip;
        public float Padding;
        public float FilterLr;
        public float WeightsLr;
        public int NumHogChannelsUsed;
        public int AdmmIterations;
        public int HistogramBins;
        public float HistogramLr;
        public int BackgroundRatio;
        public int NumberOfScales;
        public float ScaleSigmaFactor;
        public float ScaleModelMaxArea;
        public float ScaleLr;
        public float ScaleStep;

        /// <summary>
        /// we lost the target, if the psr is lower than this.
        /// </summary>
        public float PsrThreshold;
#pragma warning restore 1591

        /// <summary>
        /// Builds the blittable native mirror. <paramref name="windowFunction"/> must point to a
        /// char* that stays alive for the duration of the native call.
        /// </summary>
        internal readonly WTrackerCSRTParams ToNativeStruct(IntPtr windowFunction) => new()
        {
            UseHog = UseHog ? 1 : 0,
            UseColorNames = UseColorNames ? 1 : 0,
            UseGray = UseGray ? 1 : 0,
            UseRgb = UseRgb ? 1 : 0,
            UseChannelWeights = UseChannelWeights ? 1 : 0,
            UseSegmentation = UseSegmentation ? 1 : 0,
            WindowFunction = windowFunction,
            KaiserAlpha = KaiserAlpha,
            ChebAttenuation = ChebAttenuation,
            TemplateSize = TemplateSize,
            GslSigma = GslSigma,
            HogOrientations = HogOrientations,
            HogClip = HogClip,
            Padding = Padding,
            FilterLr = FilterLr,
            WeightsLr = WeightsLr,
            NumHogChannelsUsed = NumHogChannelsUsed,
            AdmmIterations = AdmmIterations,
            HistogramBins = HistogramBins,
            HistogramLr = HistogramLr,
            BackgroundRatio = BackgroundRatio,
            NumberOfScales = NumberOfScales,
            ScaleSigmaFactor = ScaleSigmaFactor,
            ScaleModelMaxArea = ScaleModelMaxArea,
            ScaleLr = ScaleLr,
            ScaleStep = ScaleStep,
            PsrThreshold = PsrThreshold,
        };
    }
}

/// <summary>
/// Blittable mirror of native <c>tracker_TrackerCSRT_Params</c> (the use-flags are <c>int</c> and
/// <c>window_function</c> is a <c>char*</c>). Built from <see cref="TrackerCSRT.Params"/> for the P/Invoke.
/// </summary>
#pragma warning disable CA1815
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
public struct WTrackerCSRTParams
{
#pragma warning disable 1591
    public int UseHog;
    public int UseColorNames;
    public int UseGray;
    public int UseRgb;
    public int UseChannelWeights;
    public int UseSegmentation;
    public IntPtr WindowFunction;
    public float KaiserAlpha;
    public float ChebAttenuation;
    public float TemplateSize;
    public float GslSigma;
    public float HogOrientations;
    public float HogClip;
    public float Padding;
    public float FilterLr;
    public float WeightsLr;
    public int NumHogChannelsUsed;
    public int AdmmIterations;
    public int HistogramBins;
    public float HistogramLr;
    public int BackgroundRatio;
    public int NumberOfScales;
    public float ScaleSigmaFactor;
    public float ScaleModelMaxArea;
    public float ScaleLr;
    public float ScaleStep;
    public float PsrThreshold;
#pragma warning restore 1591
}
