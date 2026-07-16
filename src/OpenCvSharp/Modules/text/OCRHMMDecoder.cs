using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Text;

// ReSharper disable InconsistentNaming
/// <summary>
/// Provides an interface for OCR using Hidden Markov Models.
/// </summary>
public sealed class OCRHMMDecoder : BaseOCR
{
    private OCRHMMDecoder(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.text_Ptr_OCRHMMDecoder_delete(p)))
    { }

    /// <summary>
    /// Creates an instance of the OCRHMMDecoder class. Initializes the HMM decoder.
    /// </summary>
    /// <param name="classifier">The character classifier with a built-in feature extractor.</param>
    /// <param name="vocabulary">The language vocabulary (chars when ASCII English text). Its length
    /// must be equal to the number of classes of the classifier.</param>
    /// <param name="transitionProbabilitiesTable">Table with transition probabilities between
    /// character pairs. cols == rows == vocabulary.Length.</param>
    /// <param name="emissionProbabilitiesTable">Table with observation emission probabilities.
    /// cols == rows == vocabulary.Length.</param>
    /// <param name="mode">HMM decoding algorithm.</param>
    /// <returns></returns>
    public static OCRHMMDecoder Create(
        OCRHMMDecoderClassifierCallback classifier, string vocabulary,
        InputArray transitionProbabilitiesTable, InputArray emissionProbabilitiesTable,
        DecoderMode mode = DecoderMode.Viterbi)
    {
        ArgumentNullException.ThrowIfNull(classifier);
        ArgumentNullException.ThrowIfNull(vocabulary);
        classifier.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.text_OCRHMMDecoder_create_callback(
                classifier.SmartPtr, vocabulary, transitionProbabilitiesTable.Proxy, emissionProbabilitiesTable.Proxy,
                (int)mode, out var smartPtr));
        GC.KeepAlive(classifier);
        GC.KeepAlive(transitionProbabilitiesTable.Source);
        GC.KeepAlive(emissionProbabilitiesTable.Source);

        NativeMethods.HandleException(NativeMethods.text_Ptr_OCRHMMDecoder_get(smartPtr, out var rawPtr));
        return new OCRHMMDecoder(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates an instance of the OCRHMMDecoder class. Loads and initializes the HMM decoder from
    /// the specified classifier model file.
    /// </summary>
    /// <param name="filename">The classifier model file.</param>
    /// <param name="vocabulary">The language vocabulary (chars when ASCII English text). Its length
    /// must be equal to the number of classes of the classifier.</param>
    /// <param name="transitionProbabilitiesTable">Table with transition probabilities between
    /// character pairs. cols == rows == vocabulary.Length.</param>
    /// <param name="emissionProbabilitiesTable">Table with observation emission probabilities.
    /// cols == rows == vocabulary.Length.</param>
    /// <param name="mode">HMM decoding algorithm.</param>
    /// <param name="classifier">The character classifier type.</param>
    /// <returns></returns>
    public static OCRHMMDecoder Create(
        string filename, string vocabulary,
        InputArray transitionProbabilitiesTable, InputArray emissionProbabilitiesTable,
        DecoderMode mode = DecoderMode.Viterbi, ClassifierType classifier = ClassifierType.Knn)
    {
        ArgumentNullException.ThrowIfNull(filename);
        ArgumentNullException.ThrowIfNull(vocabulary);

        NativeMethods.HandleException(
            NativeMethods.text_OCRHMMDecoder_create_file(
                filename, vocabulary, transitionProbabilitiesTable.Proxy, emissionProbabilitiesTable.Proxy,
                (int)mode, (int)classifier, out var smartPtr));
        GC.KeepAlive(transitionProbabilitiesTable.Source);
        GC.KeepAlive(emissionProbabilitiesTable.Source);

        NativeMethods.HandleException(NativeMethods.text_Ptr_OCRHMMDecoder_get(smartPtr, out var rawPtr));
        return new OCRHMMDecoder(smartPtr, rawPtr);
    }

    /// <inheritdoc />
    public override void Run(
        Mat image,
        out string outputText,
        out Rect[] componentRects,
        out string?[] componentTexts,
        out float[] componentConfidences,
        ComponentLevels componentLevel = ComponentLevels.Word)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(image);
        image.ThrowIfDisposed();

        using var outputTextString = new StdString();
        using var componentRectsVector = new StdVector<Rect>();
        using var componentTextsVector = new VectorOfString();
        using var componentConfidencesVector = new StdVector<float>();
        NativeMethods.HandleException(
            NativeMethods.text_OCRHMMDecoder_run1(
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

    /// <inheritdoc />
    public override void Run(
        Mat image,
        Mat mask,
        out string outputText,
        out Rect[] componentRects,
        out string?[] componentTexts,
        out float[] componentConfidences,
        ComponentLevels componentLevel = ComponentLevels.Word)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(image);
        ArgumentNullException.ThrowIfNull(mask);
        image.ThrowIfDisposed();
        mask.ThrowIfDisposed();

        using var outputTextString = new StdString();
        using var componentRectsVector = new StdVector<Rect>();
        using var componentTextsVector = new VectorOfString();
        using var componentConfidencesVector = new StdVector<float>();
        NativeMethods.HandleException(
            NativeMethods.text_OCRHMMDecoder_run2(
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
