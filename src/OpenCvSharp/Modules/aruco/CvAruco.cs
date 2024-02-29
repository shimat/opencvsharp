using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Aruco;

/// <summary>
/// aruco module
/// </summary>
public static class CvAruco
{
    /// <summary>
    /// Basic marker detection
    /// </summary>
    /// <param name="image">input image</param>
    /// <param name="dictionary">indicates the type of markers that will be searched</param>
    /// <param name="corners">vector of detected marker corners. 
    /// For each marker, its four corners are provided. For N detected markers,
    ///  the dimensions of this array is Nx4.The order of the corners is clockwise.</param>
    /// <param name="ids">vector of identifiers of the detected markers. The identifier is of type int. 
    /// For N detected markers, the size of ids is also N. The identifiers have the same order than the markers in the imgPoints array.</param>
    /// <param name="parameters">marker detection parameters</param>
    /// <param name="rejectedImgPoints">contains the imgPoints of those squares whose inner code has not a 
    /// correct codification.Useful for debugging purposes.</param>
    public static void DetectMarkers(
        InputArray image,
        Dictionary dictionary, 
        out Point2f[][] corners,
        out int[] ids, 
        DetectorParameters parameters, 
        out Point2f[][] rejectedImgPoints)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (dictionary is null)
            throw new ArgumentNullException(nameof(dictionary));
        dictionary.ThrowIfDisposed();

        using var cornersVec = new VectorOfVectorPoint2f();
        using var idsVec = new VectorOfInt32();
        using var rejectedImgPointsVec = new VectorOfVectorPoint2f();

        NativeMethods.HandleException(
            NativeMethods.aruco_detectMarkers(
                image.CvPtr, dictionary.CvPtr, cornersVec.CvPtr, idsVec.CvPtr, ref parameters,
                rejectedImgPointsVec.CvPtr));

        corners = cornersVec.ToArray();
        ids = idsVec.ToArray();
        rejectedImgPoints = rejectedImgPointsVec.ToArray();

        GC.KeepAlive(image);
        GC.KeepAlive(dictionary);
        GC.KeepAlive(parameters);
    }

    /// <summary>
    /// Pose estimation for single markers
    /// </summary>
    /// <param name="corners">corners vector of already detected markers corners. 
    /// For each marker, its four corners are provided, (e.g std::vector&lt;std::vector&lt;cv::Point2f&gt;&gt; ). 
    /// For N detected markers, the dimensions of this array should be Nx4. The order of the corners should be clockwise.</param>
    /// <param name="markerLength">the length of the markers' side. The returning translation vectors will 
    /// be in the same unit.Normally, unit is meters.</param>
    /// <param name="cameraMatrix">input 3x3 floating-point camera matrix 
    /// \f$A = \vecthreethree{f_x}{0}{c_x}{0}{f_y}{c_y}{0}{0}{1}\f$</param>
    /// <param name="distortionCoefficients">vector of distortion coefficients 
    /// \f$(k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6],[s_1, s_2, s_3, s_4]])\f$ of 4, 5, 8 or 12 elements</param>
    /// <param name="rvec">array of output rotation vectors (@sa Rodrigues) (e.g. std::vector&lt;cv::Vec3d&gt;). 
    /// Each element in rvecs corresponds to the specific marker in imgPoints.</param>
    /// <param name="tvec">array of output translation vectors (e.g. std::vector&lt;cv::Vec3d&gt;).
    /// Each element in tvecs corresponds to the specific marker in imgPoints.</param>
    /// <param name="objPoints">array of object points of all the marker corners</param>
    public static void EstimatePoseSingleMarkers(
        Point2f[][] corners,
        float markerLength, 
        InputArray cameraMatrix,
        InputArray distortionCoefficients,
        OutputArray rvec, 
        OutputArray tvec,
        OutputArray? objPoints = null)
    {
        if (corners is null)
            throw new ArgumentNullException(nameof(corners));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (distortionCoefficients is null)
            throw new ArgumentNullException(nameof(distortionCoefficients));
        if (rvec is null)
            throw new ArgumentNullException(nameof(rvec));
        if (tvec is null)
            throw new ArgumentNullException(nameof(tvec));

        cameraMatrix.ThrowIfDisposed();
        distortionCoefficients.ThrowIfDisposed();
        rvec.ThrowIfNotReady();
        tvec.ThrowIfNotReady();
        objPoints?.ThrowIfNotReady();

        using var cornersAddress = new ArrayAddress2<Point2f>(corners);

        NativeMethods.HandleException(
            NativeMethods.aruco_estimatePoseSingleMarkers(
                cornersAddress.GetPointer(), cornersAddress.GetDim1Length(), cornersAddress.GetDim2Lengths(),
                markerLength, cameraMatrix.CvPtr, distortionCoefficients.CvPtr, rvec.CvPtr, tvec.CvPtr,
                objPoints?.CvPtr ?? IntPtr.Zero));

        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(distortionCoefficients);
        rvec.Fix();
        tvec.Fix();
        objPoints?.Fix();
    }

    /// <summary>
    /// Draw detected markers in image
    /// </summary>
    /// <param name="image">input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
    /// <param name="corners">positions of marker corners on input image. 
    /// For N detected markers, the dimensions of this array should be Nx4.The order of the corners should be clockwise.</param>
    /// <param name="ids">vector of identifiers for markers in markersCorners. Optional, if not provided, ids are not painted.</param>
    public static void DrawDetectedMarkers(InputArray image, Point2f[][] corners, IEnumerable<int> ids)
    {
        DrawDetectedMarkers(image, corners, ids, new Scalar(0, 255, 0));
    }

    /// <summary>
    /// Draw detected markers in image
    /// </summary>
    /// <param name="image">input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
    /// <param name="corners">positions of marker corners on input image. 
    /// For N detected markers, the dimensions of this array should be Nx4.The order of the corners should be clockwise.</param>
    /// <param name="ids">vector of identifiers for markers in markersCorners. Optional, if not provided, ids are not painted.</param>
    /// <param name="borderColor">color of marker borders. Rest of colors (text color and first corner color)
    ///  are calculated based on this one to improve visualization.</param>
    public static void DrawDetectedMarkers(InputArray image, Point2f[][] corners, IEnumerable<int>? ids, Scalar borderColor)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (corners is null)
            throw new ArgumentNullException(nameof(corners));

        using var cornersAddress = new ArrayAddress2<Point2f>(corners);
        if (ids is null)
        {
            NativeMethods.HandleException(
                NativeMethods.aruco_drawDetectedMarkers(
                    image.CvPtr, cornersAddress.GetPointer(), cornersAddress.GetDim1Length(), cornersAddress.GetDim2Lengths(),
                    IntPtr.Zero, 0, borderColor));
        }
        else
        {
            var idxArray = ids.ToArray();
            NativeMethods.HandleException(
                NativeMethods.aruco_drawDetectedMarkers(
                    image.CvPtr, cornersAddress.GetPointer(), cornersAddress.GetDim1Length(), cornersAddress.GetDim2Lengths(),
                    idxArray, idxArray.Length, borderColor));
        }
        GC.KeepAlive(image);
    }
    
    /// <summary>
    /// Returns one of the predefined dictionaries defined in PREDEFINED_DICTIONARY_NAME
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Dictionary GetPredefinedDictionary(PredefinedDictionaryName name)
    {
        NativeMethods.HandleException(
            NativeMethods.aruco_getPredefinedDictionary((int) name, out IntPtr p));
        return new Dictionary(p);
    }

    /// <summary>
    /// Reads a new dictionary from FileNode.
    /// </summary>
    /// <remarks>
    /// Dictionary format is YAML see sample below
    /// <code>
    /// nmarkers: 35
    /// markersize: 6
    /// maxCorrectionBits: 5
    /// marker_0: "101011111011111001001001101100000000"
    /// ...
    /// marker_34: "011111010000111011111110110101100101"
    /// </code>
    /// </remarks>
    /// <param name="dictionaryFile">The path of the dictionary file</param>
    /// <returns>Instance of a Dictionary</returns>
    public static Dictionary ReadDictionary(string dictionaryFile)
    {
        NativeMethods.HandleException(
            NativeMethods.aruco_readDictionary(dictionaryFile, out IntPtr p));
        return new Dictionary(p);
    }

    /// <summary>
    /// Detect ChArUco Diamond markers.
    /// </summary>
    /// <param name="image">input image necessary for corner subpixel.</param>
    /// <param name="markerCorners">list of detected marker corners from detectMarkers function.</param>
    /// <param name="markerIds">list of marker ids in markerCorners.</param>
    /// <param name="squareMarkerLengthRate">rate between square and marker length: squareMarkerLengthRate = squareLength/markerLength. The real units are not necessary.</param>
    /// <param name="diamondCorners">output list of detected diamond corners (4 corners per diamond). The order is the same than in marker corners: top left, top right, bottom right and bottom left. Similar format than the corners returned by detectMarkers (e.g std::vector&lt;std::vector&lt;cv::Point2f&gt;&gt;).</param>
    /// <param name="diamondIds">ids of the diamonds in diamondCorners. The id of each diamond is in fact of type Vec4i, so each diamond has 4 ids, which are the ids of the aruco markers composing the diamond.</param>
    /// <param name="cameraMatrix">Optional camera calibration matrix.</param>
    /// <param name="distCoeffs">Optional camera distortion coefficients.</param>
    public static void DetectCharucoDiamond(InputArray image, Point2f[][] markerCorners, IEnumerable<int> markerIds,
        float squareMarkerLengthRate, out Point2f[][] diamondCorners, out Vec4i[] diamondIds,
        InputArray? cameraMatrix = null, InputArray? distCoeffs = null)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (markerCorners is null)
            throw new ArgumentNullException(nameof(markerCorners));
        if (markerIds is null)
            throw new ArgumentNullException(nameof(markerIds));

        if (cameraMatrix is null && distCoeffs is not null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        if (cameraMatrix is not null && distCoeffs is null)
            throw new ArgumentNullException(nameof(distCoeffs));

        image.ThrowIfDisposed();

        cameraMatrix?.ThrowIfDisposed();
        distCoeffs?.ThrowIfDisposed();

        using var markerCornersAddress = new ArrayAddress2<Point2f>(markerCorners);
        using var markerIdsVec = new VectorOfInt32(markerIds);

        using var diamondCornersVec = new VectorOfVectorPoint2f();
        using var diamondIdsVec = new VectorOfVec4i();

        NativeMethods.HandleException(
            NativeMethods.aruco_detectCharucoDiamond(
                image.CvPtr, markerCornersAddress.GetPointer(), markerCornersAddress.GetDim1Length(), markerCornersAddress.GetDim2Lengths(),
                markerIdsVec.CvPtr, squareMarkerLengthRate,
                diamondCornersVec.CvPtr, diamondIdsVec.CvPtr,
                cameraMatrix?.CvPtr ?? IntPtr.Zero, distCoeffs?.CvPtr ?? IntPtr.Zero));

        diamondCorners = diamondCornersVec.ToArray();
        diamondIds = diamondIdsVec.ToArray();

        GC.KeepAlive(image);
        if (cameraMatrix is not null)
            GC.KeepAlive(cameraMatrix);
        if (distCoeffs is not null)
            GC.KeepAlive(distCoeffs);
    }

    /// <summary>
    /// Draw a set of detected ChArUco Diamond markers.
    /// </summary>
    /// <param name="image">input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
    /// <param name="diamondCorners">positions of diamond corners in the same format returned by detectCharucoDiamond(). (e.g std::vector&lt;std::vector&lt;cv::Point2f&gt;&gt;). For N detected markers, the dimensions of this array should be Nx4. The order of the corners should be clockwise.</param>
    /// <param name="diamondIds">vector of identifiers for diamonds in diamondCorners, in the same format returned by detectCharucoDiamond() (e.g. std::vector&lt;Vec4i&gt;). Optional, if not provided, ids are not painted.</param>
    public static void DrawDetectedDiamonds(InputArray image, Point2f[][] diamondCorners, IEnumerable<Vec4i>? diamondIds = null)
    {
        DrawDetectedDiamonds(image, diamondCorners, diamondIds, new Scalar(0, 0, 255));
    }

    /// <summary>
    /// Draw a set of detected ChArUco Diamond markers.
    /// </summary>
    /// <param name="image">input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
    /// <param name="diamondCorners">positions of diamond corners in the same format returned by detectCharucoDiamond(). (e.g std::vector&lt;std::vector&lt;cv::Point2f&gt;&gt;). For N detected markers, the dimensions of this array should be Nx4. The order of the corners should be clockwise.</param>
    /// <param name="diamondIds">vector of identifiers for diamonds in diamondCorners, in the same format returned by detectCharucoDiamond() (e.g. std::vector&lt;Vec4i&gt;). Optional, if not provided, ids are not painted.</param>
    /// <param name="borderColor">color of marker borders. Rest of colors (text color and first corner color) are calculated based on this one.</param>
    public static void DrawDetectedDiamonds(InputArray image,
        Point2f[][] diamondCorners, IEnumerable<Vec4i>? diamondIds, Scalar borderColor)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (diamondCorners is null)
            throw new ArgumentNullException(nameof(diamondCorners));

        using var cornersAddress = new ArrayAddress2<Point2f>(diamondCorners);

        if (diamondIds is null)
        {
            NativeMethods.HandleException(
                NativeMethods.aruco_drawDetectedDiamonds(image.CvPtr,
                    cornersAddress.GetPointer(), cornersAddress.GetDim1Length(), cornersAddress.GetDim2Lengths(),
                    IntPtr.Zero, borderColor));
        }
        else
        {
            using var ids = new VectorOfVec4i(diamondIds);

            NativeMethods.HandleException(
                NativeMethods.aruco_drawDetectedDiamonds(image.CvPtr,
                    cornersAddress.GetPointer(), cornersAddress.GetDim1Length(), cornersAddress.GetDim2Lengths(),
                    ids.CvPtr, borderColor));
        }

        GC.KeepAlive(image);
    }
}
