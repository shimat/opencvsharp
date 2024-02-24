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
    protected TrackerCSRT(IntPtr p)
        : base(new Ptr(p))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static TrackerCSRT Create()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_TrackerCSRT_create1(out var p));
        return new TrackerCSRT(p);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">CSRT parameters</param>
    /// <returns></returns>
    public static TrackerCSRT Create(Params parameters)
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_TrackerCSRT_create2(ref parameters, out var p));
        return new TrackerCSRT(p);
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
            NativeMethods.tracking_TrackerCSRT_setInitialMask(ptr, mask.CvPtr));

        GC.KeepAlive(mask);
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.tracking_Ptr_TrackerCSRT_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.tracking_Ptr_TrackerCSRT_delete(ptr));
            base.DisposeUnmanaged();
        }
    }

#pragma warning disable CA1034
    /// <summary>
    /// CSRT Params
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
    public struct Params
    {
#pragma warning disable 1591
        public int UseHog;
        public int UseColorNames;
        public int UseGray;
        public int UseRgb;
        public int UseChannelWeights;
        public int UseSegmentation;

        /// <summary>
        /// Window function: "hann", "cheb", "kaiser"
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
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
            
    }
}
