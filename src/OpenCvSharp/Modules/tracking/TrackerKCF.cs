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
    protected TrackerKCF(IntPtr p)
        : base(new Ptr(p)) 
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static TrackerKCF Create()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_TrackerKCF_create1(out var p));
        return new TrackerKCF(p);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">KCF parameters TrackerKCF::Params</param>
    /// <returns></returns>
    public static TrackerKCF Create(Params parameters)
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_TrackerKCF_create2(parameters, out var p));
        return new TrackerKCF(p);
    }
        
    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.tracking_Ptr_TrackerKCF_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.tracking_Ptr_TrackerKCF_delete(ptr));
            base.DisposeUnmanaged();
        }
    }

#pragma warning disable CA1034
#pragma warning disable CA1051
    /// <summary> 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class Params
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

        /// <summary>
        /// activate the resize feature to improve the processing speed
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        public bool Resize;

        /// <summary>
        /// split the training coefficients into two matrices
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        public bool SplitCoeff;

        /// <summary>
        /// wrap around the kernel values
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        public bool WrapKernel;

        /// <summary>
        /// activate the pca method to compress the features
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        public bool CompressFeature;

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
