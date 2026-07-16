using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Text;

// ReSharper disable InconsistentNaming
/// <summary>
/// Provides the functionality of segmented word spotting. Given a predefined vocabulary, a DictNet
/// is employed to select the most probable word given an input image.
/// </summary>
public sealed class OCRHolisticWordRecognizer : BaseOCR
{
    private OCRHolisticWordRecognizer(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.text_Ptr_OCRHolisticWordRecognizer_delete(p)))
    { }

    /// <summary>
    /// Creates an instance of the OCRHolisticWordRecognizer class.
    /// </summary>
    /// <param name="archFilename">The DictNet model architecture (topology) file.</param>
    /// <param name="weightsFilename">The DictNet model weights file.</param>
    /// <param name="wordsFilename">The lexicon file listing the words in the dictionary.</param>
    /// <returns></returns>
    public static OCRHolisticWordRecognizer Create(string archFilename, string weightsFilename, string wordsFilename)
    {
        ArgumentNullException.ThrowIfNull(archFilename);
        ArgumentNullException.ThrowIfNull(weightsFilename);
        ArgumentNullException.ThrowIfNull(wordsFilename);

        NativeMethods.HandleException(
            NativeMethods.text_OCRHolisticWordRecognizer_create(archFilename, weightsFilename, wordsFilename, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.text_Ptr_OCRHolisticWordRecognizer_get(smartPtr, out var rawPtr));
        return new OCRHolisticWordRecognizer(smartPtr, rawPtr);
    }

    /// <summary>
    /// Recognizes text using a segmentation-based word-spotting classifier CNN.
    /// The output text is always one that exists in the dictionary.
    /// </summary>
    /// <param name="image">Input image CV_8UC1 or CV_8UC3.</param>
    /// <param name="outputText">Output text of the word spotting, always one that exists in the dictionary.</param>
    /// <param name="componentRects">Not applicable for word spotting.</param>
    /// <param name="componentTexts">Not applicable for word spotting.</param>
    /// <param name="componentConfidences">Not applicable for word spotting.</param>
    /// <param name="componentLevel">Must be ComponentLevels.Word.</param>
    public override void Run(
        Mat image,
        out string outputText,
        out Rect[] componentRects,
        out string?[] componentTexts,
        out float[] componentConfidences,
        ComponentLevels componentLevel = ComponentLevels.Word)
    {
        ArgumentNullException.ThrowIfNull(image);
        image.ThrowIfDisposed();

        using var outputTextString = new StdString();
        using var componentRectsVector = new StdVector<Rect>();
        using var componentTextsVector = new VectorOfString();
        using var componentConfidencesVector = new StdVector<float>();
        NativeMethods.HandleException(
            NativeMethods.text_OCRHolisticWordRecognizer_run1(
                Handle,
                image.CvPtr,
                outputTextString.CvPtr,
                componentRectsVector.CvPtr,
                componentTextsVector.CvPtr,
                componentConfidencesVector.CvPtr,
                (int)componentLevel));
        outputText = outputTextString.ToString();
        componentRects = componentRectsVector.ToArray();
        componentTexts = componentTextsVector.ToArray();
        componentConfidences = componentConfidencesVector.ToArray();

        GC.KeepAlive(image);
    }

    /// <summary>
    /// Recognizes text using a segmentation-based word-spotting classifier CNN. The mask parameter
    /// is ignored and only available for API compatibility.
    /// </summary>
    /// <param name="image">Input image CV_8UC1 or CV_8UC3.</param>
    /// <param name="mask">Ignored; only available for compatibility reasons.</param>
    /// <param name="outputText">Output text of the word spotting, always one that exists in the dictionary.</param>
    /// <param name="componentRects">Not applicable for word spotting.</param>
    /// <param name="componentTexts">Not applicable for word spotting.</param>
    /// <param name="componentConfidences">Not applicable for word spotting.</param>
    /// <param name="componentLevel">Must be ComponentLevels.Word.</param>
    public override void Run(
        Mat image,
        Mat mask,
        out string outputText,
        out Rect[] componentRects,
        out string?[] componentTexts,
        out float[] componentConfidences,
        ComponentLevels componentLevel = ComponentLevels.Word)
    {
        ArgumentNullException.ThrowIfNull(image);
        ArgumentNullException.ThrowIfNull(mask);
        image.ThrowIfDisposed();
        mask.ThrowIfDisposed();

        using var outputTextString = new StdString();
        using var componentRectsVector = new StdVector<Rect>();
        using var componentTextsVector = new VectorOfString();
        using var componentConfidencesVector = new StdVector<float>();
        NativeMethods.HandleException(
            NativeMethods.text_OCRHolisticWordRecognizer_run2(
                Handle,
                image.CvPtr,
                mask.CvPtr,
                outputTextString.CvPtr,
                componentRectsVector.CvPtr,
                componentTextsVector.CvPtr,
                componentConfidencesVector.CvPtr,
                (int)componentLevel));
        outputText = outputTextString.ToString();
        componentRects = componentRectsVector.ToArray();
        componentTexts = componentTextsVector.ToArray();
        componentConfidences = componentConfidencesVector.ToArray();

        GC.KeepAlive(image);
        GC.KeepAlive(mask);
    }
}
