using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Tracking.Legacy;

/// <inheritdoc />
/// <summary>
/// KCF is a novel tracking framework that utilizes properties of circulant matrix to enhance the
/// processing speed. Mirrors <c>cv::legacy::TrackerKCF</c> (as opposed to the modern
/// <see cref="OpenCvSharp.Tracking.TrackerKCF"/>).
/// </summary>
// ReSharper disable once InconsistentNaming
public class TrackerKCF : LegacyTracker
{
    private TrackerKCF(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerKCF_delete(p)))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public static TrackerKCF Create()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_TrackerKCF_create1(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerKCF_get(smartPtr, out var rawPtr));
        return new TrackerKCF(smartPtr, rawPtr);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">KCF parameters TrackerKCF::Params</param>
    public static TrackerKCF Create(Params parameters)
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_TrackerKCF_create2(ref parameters, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerKCF_get(smartPtr, out var rawPtr));
        return new TrackerKCF(smartPtr, rawPtr);
    }

#pragma warning disable CA1034
#pragma warning disable CA1051
    /// <summary>
    /// TrackerKCF parameters. Layout matches the native <c>tracker_legacy_TrackerKCF_Params</c>
    /// bridge struct (<c>cv::legacy::TrackerKCF::Params</c> just re-exposes
    /// <c>cv::tracking::TrackerKCF::Params</c>); the <see langword="bool"/> options are backed by
    /// a plain <see langword="int"/> per the general Params-struct convention, not a native <c>bool</c>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Params
    {
        /// <summary>
        /// detection confidence threshold
        /// </summary>
        public float DetectThresh;

        /// <summary>
        /// gaussian kernel bandwidth
        /// </summary>
        public float Sigma;

        /// <summary>
        /// regularization
        /// </summary>
        public float Lambda;

        /// <summary>
        /// linear interpolation factor for adaptation
        /// </summary>
        public float InterpFactor;

        /// <summary>
        /// spatial bandwidth (proportional to target)
        /// </summary>
        public float OutputSigmaFactor;

        /// <summary>
        /// compression learning rate
        /// </summary>
        public float PcaLearningRate;

        private int resize;
        private int splitCoeff;
        private int wrapKernel;
        private int compressFeature;

        /// <summary>
        /// activate the resize feature to improve the processing speed
        /// </summary>
        public bool Resize
        {
            readonly get => resize != 0;
            set => resize = value ? 1 : 0;
        }

        /// <summary>
        /// split the training coefficients into two matrices
        /// </summary>
        public bool SplitCoeff
        {
            readonly get => splitCoeff != 0;
            set => splitCoeff = value ? 1 : 0;
        }

        /// <summary>
        /// wrap around the kernel values
        /// </summary>
        public bool WrapKernel
        {
            readonly get => wrapKernel != 0;
            set => wrapKernel = value ? 1 : 0;
        }

        /// <summary>
        /// activate the pca method to compress the features
        /// </summary>
        public bool CompressFeature
        {
            readonly get => compressFeature != 0;
            set => compressFeature = value ? 1 : 0;
        }

        /// <summary>
        /// threshold for the ROI size
        /// </summary>
        public int MaxPatchSize;

        /// <summary>
        /// feature size after compression
        /// </summary>
        public int CompressedSize;

        /// <summary>
        /// compressed descriptors: a combination of <see cref="TrackerKCFMode"/> flags
        /// </summary>
        public int DescPca;

        /// <summary>
        /// non-compressed descriptors: a combination of <see cref="TrackerKCFMode"/> flags
        /// </summary>
        public int DescNpca;
    }
#pragma warning restore CA1051
}
