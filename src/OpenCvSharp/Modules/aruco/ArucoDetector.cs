using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Aruco;

/// <summary>
/// The main functionality of ArucoDetector class is detection of markers in an image with detectMarkers() method.
/// </summary>
public class ArucoDetector : CvObject
{
    /// <summary>
    /// Creates ArucoDetector with default parameters.
    /// </summary>
    public ArucoDetector(Dictionary dictionary)
        : this(dictionary, new DetectorParameters(), new RefineParameters())
    {
    }

    /// <summary>
    /// Creates ArucoDetector.
    /// </summary>
    public ArucoDetector(Dictionary dictionary, DetectorParameters detectorParams, RefineParameters refineParams)
    {
        if (dictionary is null)
            throw new ArgumentNullException(nameof(dictionary));
        dictionary.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_create(dictionary.CvPtr, ref detectorParams, ref refineParams, out var ptr));
        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, true,
            static h => NativeMethods.HandleException(NativeMethods.aruco_ArucoDetector_delete(h))));
        GC.KeepAlive(dictionary);
    }

    /// <summary>
    /// Basic marker detection.
    /// </summary>
    public void DetectMarkers(
        InputArray image,
        out Point2f[][] corners,
        out int[] ids,
        out Point2f[][] rejectedImgPoints)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        ThrowIfDisposed();

        using var cornersVec = new VectorOfVectorPoint2f();
        using var idsVec = new VectorOfInt32();
        using var rejectedVec = new VectorOfVectorPoint2f();

        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_detectMarkers(
                CvPtr, image.CvPtr, cornersVec.CvPtr, idsVec.CvPtr, rejectedVec.CvPtr));

        corners = cornersVec.ToArray();
        ids = idsVec.ToArray();
        rejectedImgPoints = rejectedVec.ToArray();

        GC.KeepAlive(this);
        GC.KeepAlive(image);
    }
}
