using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// QR code encoder
/// </summary>
public class QRCodeEncoder : Algorithm
{
    /// <summary>
    /// Creates instance by cv::Ptr&lt;cv::QRCodeEncoder&gt;* and cv::QRCodeEncoder*
    /// </summary>
    private QRCodeEncoder(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.objdetect_Ptr_QRCodeEncoder_delete(p)))
    { }

    /// <summary>
    /// Creates an instance of this class with default parameters.
    /// </summary>
    public static QRCodeEncoder Create() => Create(new QRCodeEncoderParams());

    /// <summary>
    /// Creates an instance of this class with given parameters.
    /// </summary>
    /// <param name="parameters">QR code encoder parameters.</param>
    public static QRCodeEncoder Create(QRCodeEncoderParams parameters)
    {
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeEncoder_create(parameters, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.objdetect_Ptr_QRCodeEncoder_get(smartPtr, out var rawPtr));
        return new QRCodeEncoder(smartPtr, rawPtr);
    }

    /// <summary>
    /// Generates QR code from string as input.
    /// </summary>
    /// <param name="encodedInfo">Input string to encode.</param>
    /// <param name="qrcode">Generated QR code.</param>
    public void Encode(string encodedInfo, OutputArray qrcode)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(encodedInfo);

        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeEncoder_encode(Handle, encodedInfo, qrcode.Proxy));

        GC.KeepAlive(qrcode.Source);
    }

    /// <summary>
    /// Generates QR code from string as input, using the Structured Append mode. The encoded message is splitting over a number of QR codes.
    /// </summary>
    /// <param name="encodedInfo">Input string to encode.</param>
    /// <param name="qrcodes">Vector of generated QR codes.</param>
    public void EncodeStructuredAppend(string encodedInfo, out Mat[] qrcodes)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(encodedInfo);

        using var qrcodesVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.objdetect_QRCodeEncoder_encodeStructuredAppend(Handle, encodedInfo, qrcodesVec.CvPtr));

        qrcodes = qrcodesVec.ToArray();
    }
}
