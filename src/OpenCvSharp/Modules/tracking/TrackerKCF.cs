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
