using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Class for extracting blobs from an image.
/// </summary>
public class SimpleBlobDetector : Feature2D
{
    private Ptr? ptrObj;

#pragma warning disable CA1034
    /// <summary>
    /// SimpleBlobDetector parameters
    /// </summary>
    public class Params
    {
        internal WParams Data;

        /// <summary>
        /// 
        /// </summary>
        public Params()
        {
            Data = new WParams
            {
                thresholdStep = 10,
                minThreshold = 50,
                maxThreshold = 220,
                minRepeatability = 2,
                minDistBetweenBlobs = 10,
                filterByColor = 1,
                blobColor = 0,
                filterByArea = 1,
                minArea = 25,
                maxArea = 5000,
                filterByCircularity = 0,
                minCircularity = 0.8f,
                maxCircularity = float.MaxValue,
                filterByInertia = 1,
                minInertiaRatio = 0.1f,
                maxInertiaRatio = float.MaxValue,
                filterByConvexity = 1,
                minConvexity = 0.95f,
                maxConvexity = float.MaxValue
            };
        }

#pragma warning disable 1591
        public float ThresholdStep
        {
            get => Data.thresholdStep;
            set => Data.thresholdStep = value;
        }

        public float MinThreshold
        {
            get => Data.minThreshold;
            set => Data.minThreshold = value;
        }

        public float MaxThreshold
        {
            get => Data.maxThreshold;
            set => Data.maxThreshold = value;
        }

        public uint MinRepeatability
        {
            get => Data.minRepeatability;
            set => Data.minRepeatability = value;
        }

        public float MinDistBetweenBlobs
        {
            get => Data.minDistBetweenBlobs;
            set => Data.minDistBetweenBlobs = value;
        }

        public bool FilterByColor
        {
            get => Data.filterByColor != 0;
            set => Data.filterByColor = (value ? 1 : 0);
        }

        public byte BlobColor
        {
            get => Data.blobColor;
            set => Data.blobColor = value;
        }

        public bool FilterByArea
        {
            get => Data.filterByArea != 0;
            set => Data.filterByArea = (value ? 1 : 0);
        }

        public float MinArea
        {
            get => Data.minArea;
            set => Data.minArea = value;
        }

        public float MaxArea
        {
            get => Data.maxArea;
            set => Data.maxArea = value;
        }

        public bool FilterByCircularity
        {
            get => Data.filterByCircularity != 0;
            set => Data.filterByCircularity = (value ? 1 : 0);
        }

        public float MinCircularity
        {
            get => Data.minCircularity;
            set => Data.minCircularity = value;
        }

        public float MaxCircularity
        {
            get => Data.maxCircularity;
            set => Data.maxCircularity = value;
        }

        public bool FilterByInertia
        {
            get => Data.filterByInertia != 0;
            set => Data.filterByInertia = (value ? 1 : 0);
        }

        public float MinInertiaRatio
        {
            get => Data.minInertiaRatio;
            set => Data.minInertiaRatio = value;
        }

        public float MaxInertiaRatio
        {
            get => Data.maxInertiaRatio;
            set => Data.maxInertiaRatio = value;
        }

        public bool FilterByConvexity
        {
            get => Data.filterByConvexity != 0;
            set => Data.filterByConvexity = (value ? 1 : 0);
        }

        public float MinConvexity
        {
            get => Data.minConvexity;
            set => Data.minConvexity = value;
        }

        public float MaxConvexity
        {
            get => Data.maxConvexity;
            set => Data.maxConvexity = value;
        }
    }

#pragma warning disable CA1051
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
    public struct WParams
    {
        public float thresholdStep;
        public float minThreshold;
        public float maxThreshold;
        public uint minRepeatability; // size_t
        public float minDistBetweenBlobs;

        public int filterByColor;
        public byte blobColor;

        public int filterByArea;
        public float minArea, maxArea;

        public int filterByCircularity;
        public float minCircularity, maxCircularity;

        public int filterByInertia;
        public float minInertiaRatio, maxInertiaRatio;

        public int filterByConvexity;
        public float minConvexity, maxConvexity;
#pragma warning restore CA1051
#pragma warning restore 1591
    }

    /// <summary>
    /// Constructor
    /// </summary>
    protected SimpleBlobDetector(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Construct a SimpleBlobDetector instance
    /// </summary>
    /// <param name="parameters"></param>
    public static SimpleBlobDetector Create(Params? parameters = null)
    {
        if (parameters is null)
            parameters = new Params();
        NativeMethods.HandleException(
            NativeMethods.features2d_SimpleBlobDetector_create(ref parameters.Data, out var ptr));
        return new SimpleBlobDetector(ptr);
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_Ptr_SimpleBlobDetector_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_Ptr_SimpleBlobDetector_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
