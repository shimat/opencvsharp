using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Tracking;

/// <inheritdoc />
/// <summary>
/// KCF is a novel tracking framework that utilizes properties of circulant matrix to enhance the processing speed.
/// * This tracking method is an implementation of @cite KCF_ECCV which is extended to KFC with color-names features(@cite KCF_CN).
/// * The original paper of KCF is available at [http://www.robots.ox.ac.uk/~joao/publications/henriques_tpami2015.pdf]
/// * as well as the matlab implementation.For more information about KCF with color-names features, please refer to
/// * [http://www.cvl.isy.liu.se/research/objrec/visualtracking/colvistrack/index.html].
/// </summary>
// ReSharper disable once InconsistentNaming
public class TrackerKCF : Tracker
{
    /// <summary>
    /// 
    /// </summary>
    private TrackerKCF(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.tracking_Ptr_TrackerKCF_delete(p)))
    { }
    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static TrackerKCF Create()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_TrackerKCF_create1(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_Ptr_TrackerKCF_get(smartPtr, out var rawPtr));
        return new TrackerKCF(smartPtr, rawPtr);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">KCF parameters TrackerKCF::Params</param>
    /// <returns></returns>
    public static TrackerKCF Create(Params parameters)
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_TrackerKCF_create2(ref parameters, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_Ptr_TrackerKCF_get(smartPtr, out var rawPtr));
        return new TrackerKCF(smartPtr, rawPtr);
    }

    // Roots the managed callback process-wide (not on the instance): the native side
    // (cv::TrackerKCF::FeatureExtractorCallbackFN) is a plain C function pointer with no per-instance
    // user-data slot, so the callback stays reachable through this shared field for as long as any
    // tracker might still invoke it, even after the TrackerKCF instance that registered it is
    // collected. Replacing it is guarded by a lock since registrations race on the same native slot.
    // The native-facing function pointer is always the fixed trampoline below; only the field it
    // reads is swapped.
    private static readonly object featureExtractorLock = new();
    private static FeatureExtractorCallback? currentFeatureExtractor;

    /// <summary>
    /// Sets a custom feature extractor. Corresponds to <c>cv::TrackerKCF::setFeatureExtractor</c>.
    /// </summary>
    /// <remarks>
    /// <c>cv::TrackerKCF::FeatureExtractorCallbackFN</c> is a plain C function pointer with no
    /// per-instance user-data slot, so only one managed callback can be active process-wide at a
    /// time: calling this method on any <see cref="TrackerKCF"/> instance replaces the callback
    /// used by every other instance as well. To actually take effect, either <see cref="Params.DescPca"/>
    /// or <see cref="Params.DescNpca"/> (matching <paramref name="pcaFunc"/>) must include
    /// <see cref="TrackerKCFMode.Custom"/>.
    /// </remarks>
    /// <param name="extractor">
    /// Callback receiving the current frame, the region of interest, and the output feature matrix
    /// to fill in. Neither <see cref="Mat"/> passed to the callback is owned by the callee.
    /// </param>
    /// <param name="pcaFunc">Whether this extractor is used for the compressed (PCA) descriptors.</param>
    public void SetFeatureExtractor(FeatureExtractorCallback extractor, bool pcaFunc = false)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(extractor);

        lock (featureExtractorLock)
        {
            currentFeatureExtractor = extractor;
            NativeMethods.HandleException(
                NativeMethods.tracking_TrackerKCF_setFeatureExtractor(RawPtr, GetFeatureExtractorTrampolinePointer(), pcaFunc ? 1 : 0));
        }
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Custom feature extraction callback for <see cref="SetFeatureExtractor"/>.
    /// </summary>
    /// <param name="image">The current frame.</param>
    /// <param name="roi">The region of interest to extract features from.</param>
    /// <param name="features">The output feature matrix to fill in.</param>
    public delegate void FeatureExtractorCallback(Mat image, Rect roi, Mat features);

    // Bridges cv::TrackerKCF's real by-value signature (const Mat, const Rect, Mat&) to an
    // all-pointers one: a reverse P/Invoke thunk cannot replicate the MSVC by-value-object calling
    // convention that cv::Mat's non-trivial copy constructor requires, and even a plain-POD
    // by-value struct (interop::Rect) is risky to pass that way - so the native trampoline
    // (tracking_TrackerKCF_featureExtractorTrampoline in tracking.h) hands us pointers only, with
    // roi read back via Marshal.PtrToStructure.
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void FeatureExtractorTrampoline(IntPtr image, IntPtr roi, IntPtr features)
    {
        try
        {
            var extractor = currentFeatureExtractor;
            if (extractor is null)
                return;

            using var imageMat = new Mat(image, ownsHandle: false);
            using var featuresMat = new Mat(features, ownsHandle: false);
            var roiRect = Marshal.PtrToStructure<Rect>(roi);
            extractor(imageMat, roiRect, featuresMat);
        }
        catch
        {
            // Exceptions must never unwind into native code from an UnmanagedCallersOnly method.
        }
    }

    private static unsafe IntPtr GetFeatureExtractorTrampolinePointer() =>
        (IntPtr)(delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, void>)&FeatureExtractorTrampoline;

    #pragma warning disable CA1034
#pragma warning disable CA1051
    /// <summary>
    /// TrackerKCF parameters. Layout matches <c>cv::TrackerKCF::Params</c> so it can be passed
    /// directly to the native entry point; the <c>bool</c> options are backed by a single byte
    /// (native <c>bool</c> is one byte) to keep the struct blittable for source-generated marshalling.
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

        private byte resize;
        private byte splitCoeff;
        private byte wrapKernel;
        private byte compressFeature;

        /// <summary>
        /// activate the resize feature to improve the processing speed
        /// </summary>
        public bool Resize
        {
            readonly get => resize != 0;
            set => resize = value ? (byte)1 : (byte)0;
        }

        /// <summary>
        /// split the training coefficients into two matrices
        /// </summary>
        public bool SplitCoeff
        {
            readonly get => splitCoeff != 0;
            set => splitCoeff = value ? (byte)1 : (byte)0;
        }

        /// <summary>
        /// wrap around the kernel values
        /// </summary>
        public bool WrapKernel
        {
            readonly get => wrapKernel != 0;
            set => wrapKernel = value ? (byte)1 : (byte)0;
        }

        /// <summary>
        /// activate the pca method to compress the features
        /// </summary>
        public bool CompressFeature
        {
            readonly get => compressFeature != 0;
            set => compressFeature = value ? (byte)1 : (byte)0;
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
        /// compressed descriptors of TrackerKCF::MODE
        /// </summary>
        public int DescPca;

        /// <summary>
        /// non-compressed descriptors of TrackerKCF::MODE
        /// </summary>
        public int DescNpca;
    }
#pragma warning restore CA1051
}
