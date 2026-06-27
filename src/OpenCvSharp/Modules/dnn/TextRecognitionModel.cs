using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <summary>
/// This class represents high-level API for text recognition networks.
/// TextRecognitionModel allows to set params for preprocessing input image.
/// TextRecognitionModel creates net from file with trained weights and config,
/// sets preprocessing input, runs forward pass and return recognition result.
/// For TextRecognitionModel, CRNN-CTC is supported.
/// </summary>
public class TextRecognitionModel : Model
{
    /// <summary>
    /// Create text recognition model from network represented in one of the supported formats.
    /// An order of @p model and @p config arguments does not matter.
    /// </summary>
    /// <param name="model">Binary file contains trained weights.</param>
    /// <param name="config">Text file contains network configuration.</param>
    public TextRecognitionModel(string model, string? config = null)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        NativeMethods.HandleException(
            NativeMethods.dnn_TextRecognitionModel_new_String(model, config, out var p));
        SetHandle(p, NativeMethods.dnn_TextRecognitionModel_delete);
    }

    /// <summary>
    /// Create model from deep learning network.
    /// </summary>
    /// <param name="network">Net object.</param>
    public TextRecognitionModel(Net network)
    {
        if (network is null)
            throw new ArgumentNullException(nameof(network));

        NativeMethods.HandleException(
            NativeMethods.dnn_TextRecognitionModel_new_Net(network.CvPtr, out var p));
        GC.KeepAlive(network);
        SetHandle(p, NativeMethods.dnn_TextRecognitionModel_delete);
    }

    /// <summary>
    /// Set the decoding method of translating the network output into string.
    /// </summary>
    /// <param name="decodeType">The decoding method of translating the network output into string, currently supported type:
    /// - "CTC-greedy" greedy decoding for the output of CTC-based methods
    /// - "CTC-prefix-beam-search" Prefix beam search decoding for the output of CTC-based methods</param>
    public void SetDecodeType(string decodeType)
    {
        if (decodeType is null)
            throw new ArgumentNullException(nameof(decodeType));
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextRecognitionModel_setDecodeType(Handle, decodeType));
    }

    /// <summary>
    /// Get the decoding method.
    /// </summary>
    /// <returns>the decoding method</returns>
    public string GetDecodeType()
    {
        ThrowIfDisposed();
        using var result = new StdString();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextRecognitionModel_getDecodeType(Handle, result.CvPtr));
        return result.ToString();
    }

    /// <summary>
    /// Set the decoding method options for "CTC-prefix-beam-search" decode usage.
    /// </summary>
    /// <param name="beamSize">Beam size for search</param>
    /// <param name="vocPruneSize">Parameter to optimize big vocabulary search,
    /// only take top @p vocPruneSize tokens in each search step, @p vocPruneSize &lt;= 0 stands for disable this prune.</param>
    public void SetDecodeOptsCTCPrefixBeamSearch(int beamSize, int vocPruneSize = 0)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextRecognitionModel_setDecodeOptsCTCPrefixBeamSearch(Handle, beamSize, vocPruneSize));
    }

    /// <summary>
    /// Set the vocabulary for recognition.
    /// </summary>
    /// <param name="vocabulary">the associated vocabulary of the network.</param>
    public void SetVocabulary(IEnumerable<string> vocabulary)
    {
        if (vocabulary is null)
            throw new ArgumentNullException(nameof(vocabulary));
        ThrowIfDisposed();

        var vocabularyArray = vocabulary as string[] ?? vocabulary.ToArray();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextRecognitionModel_setVocabulary(Handle, vocabularyArray, vocabularyArray.Length));
    }

    /// <summary>
    /// Get the vocabulary for recognition.
    /// </summary>
    /// <returns>vocabulary the associated vocabulary of the network.</returns>
    public string?[] GetVocabulary()
    {
        ThrowIfDisposed();
        using var resultVec = new VectorOfString();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextRecognitionModel_getVocabulary(Handle, resultVec.CvPtr));
        return resultVec.ToArray();
    }

    /// <summary>
    /// Given the @p input frame, create input blob, run net and return recognition result.
    /// </summary>
    /// <param name="frame">The input image.</param>
    /// <returns>The text recognition result.</returns>
    public string Recognize(InputArray frame)
    {
        ThrowIfDisposed();
        if (frame is null)
            throw new ArgumentNullException(nameof(frame));
        frame.ThrowIfDisposed();

        using var result = new StdString();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextRecognitionModel_recognize(Handle, frame.CvPtr, result.CvPtr));
        GC.KeepAlive(frame);
        return result.ToString();
    }
}
