using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
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
        ArgumentNullException.ThrowIfNull(dictionary);
        dictionary.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_create(dictionary.CvPtr, ref detectorParams, ref refineParams, out var ptr));
        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, true,
            static h => NativeMethods.HandleException(NativeMethods.aruco_ArucoDetector_delete(h))));
        GC.KeepAlive(dictionary);
    }

    /// <summary>
    /// Creates ArucoDetector for multiple dictionaries.
    /// </summary>
    /// <param name="dictionaries">indicates the types of markers that will be searched. Empty dictionaries will throw an error.</param>
    /// <param name="detectorParams">marker detection parameters</param>
    /// <param name="refineParams">marker refine detection parameters</param>
    public ArucoDetector(IEnumerable<Dictionary> dictionaries, DetectorParameters detectorParams, RefineParameters refineParams)
    {
        ArgumentNullException.ThrowIfNull(dictionaries);
        var dictArray = dictionaries.ToArray();
        foreach (var d in dictArray)
        {
            ArgumentNullException.ThrowIfNull(d);
            d.ThrowIfDisposed();
        }
        var ptrs = dictArray.Select(d => d.CvPtr).ToArray();

        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_create_MultiDict(ptrs, ptrs.Length, ref detectorParams, ref refineParams, out var ptr));
        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, true,
            static h => NativeMethods.HandleException(NativeMethods.aruco_ArucoDetector_delete(h))));
        GC.KeepAlive(dictArray);
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
        ThrowIfDisposed();

        using var cornersVec = new VectorOfVectorPoint2f();
        using var idsVec = new StdVector<int>();
        using var rejectedVec = new VectorOfVectorPoint2f();

        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_detectMarkers(
                Handle, image.Proxy, cornersVec.CvPtr, idsVec.CvPtr, rejectedVec.CvPtr));

        corners = cornersVec.ToArray();
        ids = idsVec.ToArray();
        rejectedImgPoints = rejectedVec.ToArray();

        GC.KeepAlive(image.Source);
    }

    /// <summary>
    /// Marker detection with confidence computation.
    /// </summary>
    /// <param name="image">input image</param>
    /// <param name="corners">vector of detected marker corners. For each marker, its four corners are provided.</param>
    /// <param name="ids">vector of identifiers of the detected markers.</param>
    /// <param name="markersConfidence">contains the normalized confidence [0;1] of the markers' detection.</param>
    /// <param name="rejectedImgPoints">contains the imgPoints of those squares whose inner code has not a correct codification.</param>
    public void DetectMarkersWithConfidence(
        InputArray image,
        out Point2f[][] corners,
        out int[] ids,
        out float[] markersConfidence,
        out Point2f[][] rejectedImgPoints)
    {
        ThrowIfDisposed();

        using var cornersVec = new VectorOfVectorPoint2f();
        using var idsVec = new StdVector<int>();
        using var confidenceVec = new StdVector<float>();
        using var rejectedVec = new VectorOfVectorPoint2f();

        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_detectMarkersWithConfidence(
                Handle, image.Proxy, cornersVec.CvPtr, idsVec.CvPtr, confidenceVec.CvPtr, rejectedVec.CvPtr));

        corners = cornersVec.ToArray();
        ids = idsVec.ToArray();
        markersConfidence = confidenceVec.ToArray();
        rejectedImgPoints = rejectedVec.ToArray();

        GC.KeepAlive(image.Source);
    }

    /// <summary>
    /// Basic marker detection using all configured dictionaries.
    /// </summary>
    /// <param name="image">input image</param>
    /// <param name="corners">vector of detected marker corners. For each marker, its four corners are provided.</param>
    /// <param name="ids">vector of identifiers of the detected markers.</param>
    /// <param name="rejectedImgPoints">contains the imgPoints of those squares whose inner code has not a correct codification.</param>
    /// <param name="dictIndices">vector of dictionary indices for each detected marker. Use GetDictionaries() to get the list of corresponding dictionaries.</param>
    public void DetectMarkersMultiDict(
        InputArray image,
        out Point2f[][] corners,
        out int[] ids,
        out Point2f[][] rejectedImgPoints,
        out int[] dictIndices)
    {
        ThrowIfDisposed();

        using var cornersVec = new VectorOfVectorPoint2f();
        using var idsVec = new StdVector<int>();
        using var rejectedVec = new VectorOfVectorPoint2f();
        using var dictIndicesVec = new StdVector<int>();

        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_detectMarkersMultiDict(
                Handle, image.Proxy, cornersVec.CvPtr, idsVec.CvPtr, rejectedVec.CvPtr, dictIndicesVec.CvPtr));

        corners = cornersVec.ToArray();
        ids = idsVec.ToArray();
        rejectedImgPoints = rejectedVec.ToArray();
        dictIndices = dictIndicesVec.ToArray();

        GC.KeepAlive(image.Source);
    }

    /// <summary>
    /// Refine not detected markers based on the already detected and the board layout.
    /// This function tries to find markers that were not detected in the basic DetectMarkers function.
    /// </summary>
    /// <param name="image">input image</param>
    /// <param name="board">layout of markers in the board.</param>
    /// <param name="detectedCorners">vector of already detected marker corners.</param>
    /// <param name="detectedIds">vector of already detected marker identifiers.</param>
    /// <param name="rejectedCorners">vector of rejected candidates during the marker detection process.</param>
    /// <param name="newDetectedCorners">updated vector of detected marker corners, including any recovered markers.</param>
    /// <param name="newDetectedIds">updated vector of detected marker identifiers, including any recovered markers.</param>
    /// <param name="newRejectedCorners">updated vector of rejected candidates, with recovered markers removed.</param>
    /// <param name="recoveredIdxs">the indexes of the recovered candidates in the original rejectedCorners array.</param>
    /// <param name="cameraMatrix">optional input 3x3 floating-point camera matrix</param>
    /// <param name="distCoeffs">optional vector of distortion coefficients</param>
    public void RefineDetectedMarkers(
        InputArray image,
        Board board,
        Point2f[][] detectedCorners,
        int[] detectedIds,
        Point2f[][] rejectedCorners,
        out Point2f[][] newDetectedCorners,
        out int[] newDetectedIds,
        out Point2f[][] newRejectedCorners,
        out int[] recoveredIdxs,
        InputArray cameraMatrix = default,
        InputArray distCoeffs = default)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(board);
        ArgumentNullException.ThrowIfNull(detectedCorners);
        ArgumentNullException.ThrowIfNull(detectedIds);
        ArgumentNullException.ThrowIfNull(rejectedCorners);
        board.ThrowIfDisposed();

        using var detectedCornersAddress = new ArrayAddress2<Point2f>(detectedCorners);
        using var rejectedCornersAddress = new ArrayAddress2<Point2f>(rejectedCorners);
        using var outDetectedCornersVec = new VectorOfVectorPoint2f();
        using var outDetectedIdsVec = new StdVector<int>();
        using var outRejectedCornersVec = new VectorOfVectorPoint2f();
        using var recoveredIdxsVec = new StdVector<int>();

        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_refineDetectedMarkers(
                Handle, image.Proxy, board.CvPtr,
                detectedCornersAddress.GetPointer(), detectedCornersAddress.GetDim1Length(), detectedCornersAddress.GetDim2Lengths(),
                detectedIds, detectedIds.Length,
                rejectedCornersAddress.GetPointer(), rejectedCornersAddress.GetDim1Length(), rejectedCornersAddress.GetDim2Lengths(),
                cameraMatrix.Proxy, distCoeffs.Proxy,
                outDetectedCornersVec.CvPtr, outDetectedIdsVec.CvPtr, outRejectedCornersVec.CvPtr, recoveredIdxsVec.CvPtr));

        newDetectedCorners = outDetectedCornersVec.ToArray();
        newDetectedIds = outDetectedIdsVec.ToArray();
        newRejectedCorners = outRejectedCornersVec.ToArray();
        recoveredIdxs = recoveredIdxsVec.ToArray();

        GC.KeepAlive(image.Source);
        GC.KeepAlive(board);
        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(distCoeffs.Source);
    }

    /// <summary>
    /// Returns first dictionary from internal list used for marker detection.
    /// </summary>
    public Dictionary GetDictionary()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_getDictionary(Handle, out var ret));
        return new Dictionary(ret);
    }

    /// <summary>
    /// Sets and replaces the first dictionary in internal list to be used for marker detection.
    /// </summary>
    public void SetDictionary(Dictionary dictionary)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(dictionary);
        dictionary.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_setDictionary(Handle, dictionary.CvPtr));

        GC.KeepAlive(dictionary);
    }

    /// <summary>
    /// Returns all dictionaries currently used for marker detection.
    /// </summary>
    public Dictionary[] GetDictionaries()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_getDictionariesSize(Handle, out var size));

        var ptrs = new IntPtr[size];
        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_getDictionaries(Handle, ptrs, size));

        return ptrs.Select(ptr => new Dictionary(ptr)).ToArray();
    }

    /// <summary>
    /// Sets the entire collection of dictionaries to be used for marker detection, replacing any existing dictionaries.
    /// Setting an empty collection of dictionaries will throw an error.
    /// </summary>
    public void SetDictionaries(IEnumerable<Dictionary> dictionaries)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(dictionaries);
        var dictArray = dictionaries.ToArray();
        foreach (var d in dictArray)
        {
            ArgumentNullException.ThrowIfNull(d);
            d.ThrowIfDisposed();
        }
        var ptrs = dictArray.Select(d => d.CvPtr).ToArray();

        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_setDictionaries(Handle, ptrs, ptrs.Length));

        GC.KeepAlive(dictArray);
    }

    /// <summary>
    /// Gets the detector parameters currently used for marker detection.
    /// </summary>
    public DetectorParameters GetDetectorParameters()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_getDetectorParameters(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Sets the detector parameters to be used for marker detection.
    /// </summary>
    public void SetDetectorParameters(DetectorParameters detectorParameters)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_setDetectorParameters(Handle, ref detectorParameters));
    }

    /// <summary>
    /// Gets the marker refine detection parameters currently used.
    /// </summary>
    public RefineParameters GetRefineParameters()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_getRefineParameters(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Sets the marker refine detection parameters to be used.
    /// </summary>
    public void SetRefineParameters(RefineParameters refineParameters)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_ArucoDetector_setRefineParameters(Handle, ref refineParameters));
    }

    /// <summary>
    /// Stores algorithm parameters in a file storage.
    /// </summary>
    public void Write(FileStorage fs)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fs);

        NativeMethods.HandleException(
            NativeMethods.core_Algorithm_write(Handle, fs.CvPtr));

        GC.KeepAlive(fs);
    }

    /// <summary>
    /// Reads algorithm parameters from a file storage.
    /// </summary>
    public void Read(FileNode fn)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fn);

        NativeMethods.HandleException(
            NativeMethods.core_Algorithm_read(Handle, fn.CvPtr));

        GC.KeepAlive(fn);
    }
}
