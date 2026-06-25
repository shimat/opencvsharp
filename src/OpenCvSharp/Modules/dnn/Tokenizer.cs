using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Dnn;

/// <summary>
/// Tokenizer for LLM / VLM text (OpenCV 5). Provides a simple API to encode text to token ids
/// and decode token ids back to text (BPE, e.g. gpt2 / gpt4 families).
/// </summary>
public class Tokenizer : CvObject
{
    private Tokenizer(IntPtr ptr)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, ownsHandle: true,
            static h => NativeMethods.HandleException(NativeMethods.dnn_Tokenizer_delete(h))));
    }

    /// <summary>
    /// Loads a tokenizer from a model directory. The directory must contain a config.json
    /// (with a supported <c>model_type</c>, e.g. "gpt2" or "gpt4") and a tokenizer.json.
    /// </summary>
    /// <param name="modelConfig">Path prefix to the model directory. File names are concatenated directly,
    /// so it must end with an appropriate path separator.</param>
    /// <returns>A ready-to-use Tokenizer.</returns>
    public static Tokenizer Load(string modelConfig)
    {
        if (modelConfig is null)
            throw new ArgumentNullException(nameof(modelConfig));

        NativeMethods.HandleException(
            NativeMethods.dnn_Tokenizer_load(modelConfig, out var ptr));
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to load {nameof(Tokenizer)}");
        return new Tokenizer(ptr);
    }

    /// <summary>
    /// Encodes UTF-8 text to token ids.
    /// </summary>
    /// <param name="text">UTF-8 input string.</param>
    /// <returns>The token ids.</returns>
    public int[] Encode(string text)
    {
        if (text is null)
            throw new ArgumentNullException(nameof(text));
        ThrowIfDisposed();

        using var vec = new VectorOfInt32();
        NativeMethods.HandleException(
            NativeMethods.dnn_Tokenizer_encode(CvPtr, text, vec.CvPtr));
        GC.KeepAlive(this);
        return vec.ToArray();
    }

    /// <summary>
    /// Decodes token ids back to text.
    /// </summary>
    /// <param name="tokens">The token ids.</param>
    /// <returns>The decoded UTF-8 string.</returns>
    public string Decode(int[] tokens)
    {
        if (tokens is null)
            throw new ArgumentNullException(nameof(tokens));
        ThrowIfDisposed();

        using var stdString = new StdString();
        NativeMethods.HandleException(
            NativeMethods.dnn_Tokenizer_decode(CvPtr, tokens, tokens.Length, stdString.CvPtr));
        GC.KeepAlive(this);
        return stdString.ToString();
    }
}
