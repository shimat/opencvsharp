using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// 
/// </summary>
public class QRCodeDetector : CvObject
{
    /// <summary>
    /// 
    /// </summary>
    public QRCodeDetector()
    {
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetector_new(out var p));               
        InitSafeHandle(p);
    }
        
    /// <summary>
    /// Releases unmanaged resources
    /// </summary>

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.objdetect_QRCodeDetector_delete(h))));
    }

    /// <summary>
    /// sets the epsilon used during the horizontal scan of QR code stop marker detection.
    /// </summary>
    /// <param name="epsX">Epsilon neighborhood, which allows you to determine the horizontal pattern 
    /// of the scheme 1:1:3:1:1 according to QR code standard.</param>
    public void SetEpsX(double epsX)
    {
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetector_setEpsX(Handle, epsX));
    }

    /// <summary>
    /// sets the epsilon used during the vertical scan of QR code stop marker detection.
    /// </summary>
    /// <param name="epsY">Epsilon neighborhood, which allows you to determine the vertical pattern
    /// of the scheme 1:1:3:1:1 according to QR code standard.</param>
    public void SetEpsY(double epsY)
    {
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetector_setEpsY(Handle, epsY));
    }

    /// <summary>
    /// Detects QR code in image and returns the quadrangle containing the code.
    /// </summary>
    /// <param name="img">grayscale or color (BGR) image containing (or not) QR code.</param>
    /// <returns>Vector of vertices of the minimum-area quadrangle containing the code. Empty if not found.</returns>
    public Point2f[] Detect(InputArray img)
    {
        using var pointsVec = new StdVector<Point2f>();

        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetector_detect(Handle, img.Proxy, pointsVec.CvPtr, out _));

        GC.KeepAlive(img.Source);

        return pointsVec.ToArray();
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
        ArgumentNullException.ThrowIfNull(points);

        using var pointsVec = new StdVector<Point2f>(points);
        using var resultString = new StdString();
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetector_decode(
                Handle, img.Proxy, pointsVec.CvPtr, straightQrCode.Proxy, resultString.CvPtr));

        GC.KeepAlive(img.Source);
        GC.KeepAlive(points);
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
        using var pointsVec = new StdVector<Point2f>();
        using var resultString = new StdString();
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetector_detectAndDecode(
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
    /// <returns>Vector of vertices of the minimum-area quadrangles containing the codes. Empty if none found.</returns>
    public Point2f[] DetectMulti(InputArray img)
    {
        using var pointsVec = new StdVector<Point2f>();

        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeDetector_detectMulti(Handle, img.Proxy, pointsVec.CvPtr, out _));

        GC.KeepAlive(img.Source);

        return pointsVec.ToArray();
    }

    /// <summary>
    /// Decodes QR codes in image once it's found by the detect() method.
    /// Returns UTF8-encoded output string or empty string if the code cannot be decoded.
    /// </summary>
    /// <param name="img">grayscale or color (BGR) image containing QR code.</param>
    /// <param name="points">Quadrangle vertices found by detect() method (or some other algorithm).</param>
    /// <returns>UTF8-encoded output vector of string or empty vector of string if the codes cannot be decoded.</returns>
    public string?[] DecodeMulti(InputArray img, IEnumerable<Point2f> points)
    {
        return DecodeMulti(img, points, out _, false);
    }

    /// <summary>
    /// Decodes QR codes in image once it's found by the detect() method.
    /// Returns UTF8-encoded output string or empty string if the code cannot be decoded.
    /// </summary>
    /// <param name="img">grayscale or color (BGR) image containing QR code.</param>
    /// <param name="points">Quadrangle vertices found by detect() method (or some other algorithm).</param>
    /// <param name="straightQrCode">The optional output image containing rectified and binarized QR code</param>
    /// <returns>UTF8-encoded output vector of string or empty vector of string if the codes cannot be decoded.</returns>
    public string?[] DecodeMulti(InputArray img, IEnumerable<Point2f> points, out Mat[] straightQrCode)
    {
        return DecodeMulti(img, points, out straightQrCode, true);
    }


    /// <summary>
    /// Decodes QR codes in image once it's found by the detect() method.
    /// Returns UTF8-encoded output string or empty string if the code cannot be decoded.
    /// </summary>
    /// <param name="img">grayscale or color (BGR) image containing QR code.</param>
    /// <param name="points">Quadrangle vertices found by detect() method (or some other algorithm).</param>
    /// <param name="straightQrCode">The optional output image containing rectified and binarized QR code</param>
    /// <param name="isOutputStraightQrCode"><see langword="true"/> to output <paramref name="straightQrCode"/></param>
    /// <returns>UTF8-encoded output vector of string or empty vector of string if the codes cannot be decoded.</returns>
    protected string?[] DecodeMulti(InputArray img, IEnumerable<Point2f> points, out Mat[] straightQrCode, bool isOutputStraightQrCode)
    {
        ArgumentNullException.ThrowIfNull(points);

        using var decodedInfoVec = new VectorOfString();
        using var pointsVec = new StdVector<Point2f>(points);

        if (isOutputStraightQrCode)
        {
            using var straightQrCodeVec = new VectorOfMat();
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetector_decodeMulti(
                    Handle, img.Proxy, pointsVec.CvPtr, decodedInfoVec.CvPtr, straightQrCodeVec.CvPtr, out _));
            straightQrCode = straightQrCodeVec.ToArray();
        }
        else
        {
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetector_decodeMulti_NoStraightQrCode(
                    Handle, img.Proxy, pointsVec.CvPtr, decodedInfoVec.CvPtr, out _));
            straightQrCode = [];
        }

        // decode utf-8 bytes.
        var decodedInfo = decodedInfoVec.ToArray();

        GC.KeepAlive(img.Source);
        GC.KeepAlive(points);

        return decodedInfo;
    }
}
