using OpenCvSharp.Internal;

namespace OpenCvSharp.Text;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Callback with the character classifier used by <see cref="OCRBeamSearchDecoder"/>. Instances are
/// obtained by loading a trained classifier model from a file; implementing a custom classifier in
/// managed code is not supported.
/// </summary>
public sealed class OCRBeamSearchDecoderClassifierCallback : CvPtrObject
{
    private OCRBeamSearchDecoderClassifierCallback(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.text_Ptr_OCRBeamSearchDecoder_ClassifierCallback_delete(p)))
    { }

    /// <summary>
    /// Loads the default CNN character classifier used by the Beam Search decoder.
    /// </summary>
    /// <param name="filename">The XML or YAML file with the classifier model (e.g. OCRBeamSearch_CNN_model_data.xml.gz).</param>
    /// <returns></returns>
    public static OCRBeamSearchDecoderClassifierCallback LoadClassifierCNN(string filename)
    {
        ArgumentNullException.ThrowIfNull(filename);

        NativeMethods.HandleException(
            NativeMethods.text_loadOCRBeamSearchClassifierCNN(filename, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.text_Ptr_OCRBeamSearchDecoder_ClassifierCallback_get(smartPtr, out var rawPtr));
        return new OCRBeamSearchDecoderClassifierCallback(smartPtr, rawPtr);
    }
}
