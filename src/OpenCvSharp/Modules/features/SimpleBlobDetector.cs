using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// Class for extracting blobs from an image.
/// </summary>
public class SimpleBlobDetector : Feature2D
{

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
                maxConvexity = float.MaxValue,
                collectContours = 0
            };
        }

#pragma warning disable 1591
        /// <summary>
        /// Distance between neighboring thresholds when converting the source image to several
        /// binary images, from MinThreshold (inclusive) to MaxThreshold (exclusive).
        /// </summary>
        public float ThresholdStep
        {
            get => Data.thresholdStep;
            set => Data.thresholdStep = value;
        }

        /// <summary>
        /// Lower bound (inclusive) of the range of thresholds used to binarize the source image.
        /// </summary>
        public float MinThreshold
        {
            get => Data.minThreshold;
            set => Data.minThreshold = value;
        }

        /// <summary>
        /// Upper bound (exclusive) of the range of thresholds used to binarize the source image.
        /// </summary>
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

        /// <summary>
        /// Maximum distance between centers of two blobs for them to be merged into a single blob
        /// group when combining results from the several binarized images.
        /// </summary>
        public float MinDistBetweenBlobs
        {
            get => Data.minDistBetweenBlobs;
            set => Data.minDistBetweenBlobs = value;
        }

        /// <summary>
        /// If true, blobs are filtered by comparing the intensity of a binary image at the center of a
        /// blob to <see cref="BlobColor"/>; blobs with a different intensity are filtered out.
        /// </summary>
        public bool FilterByColor
        {
            get => Data.filterByColor != 0;
            set => Data.filterByColor = (value ? 1 : 0);
        }

        /// <summary>
        /// Expected intensity of a blob center in the binary image, used when <see cref="FilterByColor"/>
        /// is enabled. Use 0 to extract dark blobs and 255 to extract light blobs.
        /// </summary>
        public byte BlobColor
        {
            get => Data.blobColor;
            set => Data.blobColor = value;
        }

        /// <summary>
        /// If true, blobs are filtered by area; only blobs with an area between
        /// <see cref="MinArea"/> (inclusive) and <see cref="MaxArea"/> (exclusive) are extracted.
        /// </summary>
        public bool FilterByArea
        {
            get => Data.filterByArea != 0;
            set => Data.filterByArea = (value ? 1 : 0);
        }

        /// <summary>
        /// Lower bound (inclusive) of blob area used when <see cref="FilterByArea"/> is enabled.
        /// </summary>
        public float MinArea
        {
            get => Data.minArea;
            set => Data.minArea = value;
        }

        /// <summary>
        /// Upper bound (exclusive) of blob area used when <see cref="FilterByArea"/> is enabled.
        /// </summary>
        public float MaxArea
        {
            get => Data.maxArea;
            set => Data.maxArea = value;
        }

        /// <summary>
        /// If true, blobs are filtered by circularity (4*pi*area / perimeter^2); only blobs with a
        /// circularity between <see cref="MinCircularity"/> (inclusive) and <see cref="MaxCircularity"/>
        /// (exclusive) are extracted.
        /// </summary>
        public bool FilterByCircularity
        {
            get => Data.filterByCircularity != 0;
            set => Data.filterByCircularity = (value ? 1 : 0);
        }

        /// <summary>
        /// Lower bound (inclusive) of blob circularity used when <see cref="FilterByCircularity"/> is enabled.
        /// </summary>
        public float MinCircularity
        {
            get => Data.minCircularity;
            set => Data.minCircularity = value;
        }

        /// <summary>
        /// Upper bound (exclusive) of blob circularity used when <see cref="FilterByCircularity"/> is enabled.
        /// </summary>
        public float MaxCircularity
        {
            get => Data.maxCircularity;
            set => Data.maxCircularity = value;
        }

        /// <summary>
        /// If true, blobs are filtered by the ratio of the minimum to the maximum inertia; only blobs
        /// with a ratio between <see cref="MinInertiaRatio"/> (inclusive) and
        /// <see cref="MaxInertiaRatio"/> (exclusive) are extracted.
        /// </summary>
        public bool FilterByInertia
        {
            get => Data.filterByInertia != 0;
            set => Data.filterByInertia = (value ? 1 : 0);
        }

        /// <summary>
        /// Lower bound (inclusive) of the inertia ratio used when <see cref="FilterByInertia"/> is enabled.
        /// </summary>
        public float MinInertiaRatio
        {
            get => Data.minInertiaRatio;
            set => Data.minInertiaRatio = value;
        }

        /// <summary>
        /// Upper bound (exclusive) of the inertia ratio used when <see cref="FilterByInertia"/> is enabled.
        /// </summary>
        public float MaxInertiaRatio
        {
            get => Data.maxInertiaRatio;
            set => Data.maxInertiaRatio = value;
        }

        /// <summary>
        /// If true, blobs are filtered by convexity (area / area of the blob's convex hull); only blobs
        /// with a convexity between <see cref="MinConvexity"/> (inclusive) and <see cref="MaxConvexity"/>
        /// (exclusive) are extracted.
        /// </summary>
        public bool FilterByConvexity
        {
            get => Data.filterByConvexity != 0;
            set => Data.filterByConvexity = (value ? 1 : 0);
        }

        /// <summary>
        /// Lower bound (inclusive) of blob convexity used when <see cref="FilterByConvexity"/> is enabled.
        /// </summary>
        public float MinConvexity
        {
            get => Data.minConvexity;
            set => Data.minConvexity = value;
        }

        /// <summary>
        /// Upper bound (exclusive) of blob convexity used when <see cref="FilterByConvexity"/> is enabled.
        /// </summary>
        public float MaxConvexity
        {
            get => Data.maxConvexity;
            set => Data.maxConvexity = value;
        }

        /// <summary>
        /// Flag to enable contour collection. If set to true, the detector will store the contours
        /// of the detected blobs in memory, which can be retrieved after the Detect() call using
        /// GetBlobContours(). Default value is false.
        /// </summary>
        public bool CollectContours
        {
            get => Data.collectContours != 0;
            set => Data.collectContours = (value ? 1 : 0);
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

        public int collectContours;
#pragma warning restore CA1051
#pragma warning restore 1591
    }

    /// <summary>
    /// Constructor
    /// </summary>
    private SimpleBlobDetector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features_Ptr_SimpleBlobDetector_delete(p)))
    {
    }

    /// <summary>
    /// Construct a SimpleBlobDetector instance
    /// </summary>
    /// <param name="parameters"></param>
    public static SimpleBlobDetector Create(Params? parameters = null)
    {
        parameters ??= new Params();
        NativeMethods.HandleException(
            NativeMethods.features_SimpleBlobDetector_create(ref parameters.Data, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new SimpleBlobDetector(smartPtr, rawPtr);
    }

    /// <summary>
    /// Returns the contours of the blobs detected during the last call to Detect().
    /// The <see cref="Params.CollectContours"/> parameter must be set to true before calling
    /// Detect() for this method to return any data.
    /// </summary>
    /// <returns></returns>
    public virtual Point[][] GetBlobContours()
    {
        ThrowIfDisposed();
        using var contours = new VectorOfVectorPoint();
        NativeMethods.HandleException(
            NativeMethods.features_SimpleBlobDetector_getBlobContours(Handle, contours.CvPtr));
        GC.KeepAlive(this);
        return contours.ToArray();
    }
}
