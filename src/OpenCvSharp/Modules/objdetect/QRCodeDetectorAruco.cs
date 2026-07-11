using OpenCvSharp.Aruco;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// QR code detector that uses the Aruco-based marker detector for locating the finder patterns.
/// </summary>
public class QRCodeDetectorAruco : CvObject
{
    /// <summary>
    /// Creates a QRCodeDetectorAruco with default parameters.
    /// </summary>
    public QRCodeDetectorAruco()
    {
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetectorAruco_new(out var p));
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: true,
            releaseAction: ptr => NativeMethods.HandleException(NativeMethods.objdetect_QRCodeDetectorAruco_delete(ptr))));
    }

    /// <summary>
    /// Creates a QRCodeDetectorAruco with given parameters.
    /// </summary>
    /// <param name="parameters">Parameters for the QRCodeDetectorAruco</param>
    public QRCodeDetectorAruco(QRCodeDetectorArucoParams parameters)
    {
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetectorAruco_new_Params(parameters, out var p));
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: true,
            releaseAction: ptr => NativeMethods.HandleException(NativeMethods.objdetect_QRCodeDetectorAruco_delete(ptr))));
    }

    /// <summary>
    /// Detector parameters of QRCodeDetectorAruco.
    /// </summary>
    public QRCodeDetectorArucoParams DetectorParameters
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetectorAruco_getDetectorParameters(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetectorAruco_setDetectorParameters(Handle, value));
        }
    }

    /// <summary>
    /// Aruco detector parameters used to search for the finder patterns.
    /// </summary>
    public DetectorParameters ArucoParameters
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetectorAruco_getArucoParameters(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetectorAruco_setArucoParameters(Handle, value));
        }
    }

    /// <summary>
    /// Detects QR code in image and returns the quadrangle containing the code.
    /// </summary>
    /// <param name="img">grayscale or color (BGR) image containing (or not) QR code.</param>
    /// <param name="points">Output vector of vertices of the minimum-area quadrangle containing the code.</param>
    /// <returns></returns>
    public bool Detect(InputArray img, out Point2f[] points)
    {
        ThrowIfDisposed();

        using var pointsVec = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetectorAruco_detect(Handle, img.Proxy, pointsVec.CvPtr, out var ret));
        points = pointsVec.ToArray();

        GC.KeepAlive(img.Source);

        return ret != 0;
    }

    /// <summary>
    /// Decodes QR code in image once it's found by the detect() method.
    /// Returns UTF8-encoded output string or empty string if the code cannot be decoded.
    /// </summary>
    /// <param name="img">grayscale or color (BGR) image containing QR code.</param>
    /// <param name="points">Quadrangle vertices found by detect() method (or some other algorithm).</param>
    /// <param name="straightQrCode">The optional output image containing rectified and binarized QR code</param>
    /// <returns></returns>
    public string Decode(InputArray img, IEnumerable<Point2f> points, OutputArray straightQrCode = default)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(points);

        using var pointsVec = new StdVector<Point2f>(points);
        using var resultString = new StdString();
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetectorAruco_decode(
                Handle, img.Proxy, pointsVec.CvPtr, straightQrCode.Proxy, resultString.CvPtr));

        GC.KeepAlive(img.Source);
        GC.KeepAlive(straightQrCode.Source);

        return resultString.ToString();
    }

    /// <summary>
    /// Both detects and decodes QR code
    /// </summary>
    /// <param name="img">grayscale or color (BGR) image containing QR code.</param>
    /// <param name="points">optional output array of vertices of the found QR code quadrangle. Will be empty if not found.</param>
    /// <param name="straightQrCode">The optional output image containing rectified and binarized QR code</param>
    /// <returns></returns>
    public string DetectAndDecode(InputArray img, out Point2f[] points, OutputArray straightQrCode = default)
    {
        ThrowIfDisposed();

        using var pointsVec = new StdVector<Point2f>();
        using var resultString = new StdString();
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetectorAruco_detectAndDecode(
                Handle, img.Proxy, pointsVec.CvPtr, straightQrCode.Proxy, resultString.CvPtr));
        points = pointsVec.ToArray();

        GC.KeepAlive(img.Source);
        GC.KeepAlive(straightQrCode.Source);

        return resultString.ToString();
    }

    /// <summary>
    /// Detects QR codes in image and returns the quadrangles containing the codes.
    /// </summary>
    /// <param name="img">grayscale or color (BGR) image containing (or not) QR code.</param>
    /// <param name="points">Output vector of vertices of the minimum-area quadrangle containing the codes.</param>
    /// <returns></returns>
    public bool DetectMulti(InputArray img, out Point2f[] points)
    {
        ThrowIfDisposed();

        using var pointsVec = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetectorAruco_detectMulti(Handle, img.Proxy, pointsVec.CvPtr, out var ret));
        points = pointsVec.ToArray();

        GC.KeepAlive(img.Source);

        return ret != 0;
    }

    /// <summary>
    /// Decodes QR codes in image once it's found by the detect() method.
    /// Returns UTF8-encoded output vector of strings or empty vector of strings if the codes cannot be decoded.
    /// </summary>
    /// <param name="img">grayscale or color (BGR) image containing QR code.</param>
    /// <param name="points">Quadrangle vertices found by detect() method (or some other algorithm).</param>
    /// <param name="decodedInfo">UTF8-encoded output vector of string or empty vector of string if the codes cannot be decoded. </param>
    /// <returns></returns>
    public bool DecodeMulti(InputArray img, IEnumerable<Point2f> points, out string?[] decodedInfo)
    {
        return DecodeMulti(img, points, out decodedInfo, out _, false);
    }

    /// <summary>
    /// Decodes QR codes in image once it's found by the detect() method.
    /// Returns UTF8-encoded output vector of strings or empty vector of strings if the codes cannot be decoded.
    /// </summary>
    /// <param name="img">grayscale or color (BGR) image containing QR code.</param>
    /// <param name="points">Quadrangle vertices found by detect() method (or some other algorithm).</param>
    /// <param name="decodedInfo">UTF8-encoded output vector of string or empty vector of string if the codes cannot be decoded. </param>
    /// <param name="straightQrCode">The optional output image containing rectified and binarized QR code</param>
    /// <returns></returns>
    public bool DecodeMulti(InputArray img, IEnumerable<Point2f> points, out string?[] decodedInfo, out Mat[] straightQrCode)
    {
        return DecodeMulti(img, points, out decodedInfo, out straightQrCode, true);
    }

    private bool DecodeMulti(InputArray img, IEnumerable<Point2f> points, out string?[] decodedInfo, out Mat[] straightQrCode, bool isOutputStraightQrCode)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(points);

        using var decodedInfoVec = new VectorOfString();
        using var pointsVec = new StdVector<Point2f>(points);

        int ret;
        if (isOutputStraightQrCode)
        {
            using var straightQrCodeVec = new VectorOfMat();
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetectorAruco_decodeMulti(
                    Handle, img.Proxy, pointsVec.CvPtr, decodedInfoVec.CvPtr, straightQrCodeVec.CvPtr, out ret));
            straightQrCode = straightQrCodeVec.ToArray();
        }
        else
        {
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetectorAruco_decodeMulti_NoStraightQrCode(
                    Handle, img.Proxy, pointsVec.CvPtr, decodedInfoVec.CvPtr, out ret));
            straightQrCode = [];
        }

        decodedInfo = decodedInfoVec.ToArray();

        GC.KeepAlive(img.Source);
        GC.KeepAlive(points);

        return ret != 0;
    }

    /// <summary>
    /// Both detects and decodes QR codes
    /// </summary>
    /// <param name="img">grayscale or color (BGR) image containing QR codes.</param>
    /// <param name="decodedInfo">UTF8-encoded output vector of string or empty vector of string if the codes cannot be decoded.</param>
    /// <param name="points">optional output array of vertices of the found QR code quadrangles. Will be empty if not found.</param>
    /// <param name="straightQrCode">The optional output vector of images containing rectified and binarized QR codes</param>
    /// <returns></returns>
    public bool DetectAndDecodeMulti(
        InputArray img, out string?[] decodedInfo, out Point2f[] points, out Mat[] straightQrCode)
    {
        ThrowIfDisposed();

        using var decodedInfoVec = new VectorOfString();
        using var pointsVec = new StdVector<Point2f>();
        using var straightQrCodeVec = new VectorOfMat();

        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetectorAruco_detectAndDecodeMulti(
                Handle, img.Proxy, decodedInfoVec.CvPtr, pointsVec.CvPtr, straightQrCodeVec.CvPtr, out var ret));

        decodedInfo = decodedInfoVec.ToArray();
        points = pointsVec.ToArray();
        straightQrCode = straightQrCodeVec.ToArray();

        GC.KeepAlive(img.Source);

        return ret != 0;
    }
}
