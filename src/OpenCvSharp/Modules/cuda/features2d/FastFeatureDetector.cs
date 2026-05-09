using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class FastFeatureDetector : Feature2DAsync
{
    public const int FeatureSize = 7;
    public const int LocationRow = 0;
    public const int ResponseRow = 1;
    public const int RowsCount = 2;

    private FastFeatureDetector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_FastFeatureDetector_delete(p)))
    {
    }

    /// <summary>
    /// Creates the CUDA FastFeatureDetector instance.
    /// </summary>
    /// <param name="threshold">Threshold on difference between intensity of the central pixel and pixels of a circle around this pixel.</param>
    /// <param name="nonmaxSuppression">If true, non-maximum suppression is applied to detected corners.</param>
    /// <param name="type">Type of the detector (one of the FastFeatureDetector.DetectorType constants).</param>
    /// <param name="maxNPoints">Maximum number of keypoints to detect.</param>
    public static FastFeatureDetector Create(
        int threshold = 10,
        bool nonmaxSuppression = true,
        FASTType type = FASTType.TYPE_9_16,
        int maxNPoints = 5000)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createFastFeatureDetector(
                threshold, nonmaxSuppression ? 1 : 0, (int)type, maxNPoints, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_FastFeatureDetector_get(smartPtr, out var rawPtr));

        return new FastFeatureDetector(smartPtr, rawPtr);
    }

    /// <summary>
    /// Gets or sets the maximum number of keypoints to detect.
    /// </summary>
    public int MaxNumPoints
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_FastFeatureDetector_getMaxNumPoints(RawPtr, out int val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_FastFeatureDetector_setMaxNumPoints(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Sets the threshold value.
    /// </summary>
    public int Threshold
    {
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_FastFeatureDetector_setThreshold(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
}
