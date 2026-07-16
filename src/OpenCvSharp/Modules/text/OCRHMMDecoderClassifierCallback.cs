using OpenCvSharp.Internal;

namespace OpenCvSharp.Text;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Callback with the character classifier used by <see cref="OCRHMMDecoder"/>. Instances are
/// obtained by loading a trained classifier model from a file; implementing a custom classifier
/// in managed code is not supported.
/// </summary>
public sealed class OCRHMMDecoderClassifierCallback : CvPtrObject
{
    private OCRHMMDecoderClassifierCallback(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.text_Ptr_OCRHMMDecoder_ClassifierCallback_delete(p)))
    { }

    /// <summary>
    /// Loads the default KNN character classifier (deprecated upstream in favor of LoadClassifier).
    /// </summary>
    /// <param name="filename">The XML or YAML file with the classifier model (e.g. OCRHMM_knn_model_data.xml).</param>
    /// <returns></returns>
    [Obsolete("Use LoadClassifier instead")]
    public static OCRHMMDecoderClassifierCallback LoadClassifierNM(string filename)
    {
        ArgumentNullException.ThrowIfNull(filename);

        NativeMethods.HandleException(
            NativeMethods.text_loadOCRHMMClassifierNM(filename, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.text_Ptr_OCRHMMDecoder_ClassifierCallback_get(smartPtr, out var rawPtr));
        return new OCRHMMDecoderClassifierCallback(smartPtr, rawPtr);
    }

    /// <summary>
    /// Loads the default CNN character classifier (deprecated upstream in favor of LoadClassifier).
    /// </summary>
    /// <param name="filename">The XML or YAML file with the classifier model (e.g. OCRBeamSearch_CNN_model_data.xml.gz).</param>
    /// <returns></returns>
    [Obsolete("Use LoadClassifier instead")]
    public static OCRHMMDecoderClassifierCallback LoadClassifierCNN(string filename)
    {
        ArgumentNullException.ThrowIfNull(filename);

        NativeMethods.HandleException(
            NativeMethods.text_loadOCRHMMClassifierCNN(filename, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.text_Ptr_OCRHMMDecoder_ClassifierCallback_get(smartPtr, out var rawPtr));
        return new OCRHMMDecoderClassifierCallback(smartPtr, rawPtr);
    }

    /// <summary>
    /// Loads the default character classifier used when creating an OCRHMMDecoder object.
    /// </summary>
    /// <param name="filename">The XML or YAML file with the classifier model.</param>
    /// <param name="classifier">The type of classifier stored in the file.</param>
    /// <returns></returns>
    public static OCRHMMDecoderClassifierCallback LoadClassifier(string filename, ClassifierType classifier)
    {
        ArgumentNullException.ThrowIfNull(filename);

        NativeMethods.HandleException(
            NativeMethods.text_loadOCRHMMClassifier(filename, (int)classifier, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.text_Ptr_OCRHMMDecoder_ClassifierCallback_get(smartPtr, out var rawPtr));
        return new OCRHMMDecoderClassifierCallback(smartPtr, rawPtr);
    }
}
