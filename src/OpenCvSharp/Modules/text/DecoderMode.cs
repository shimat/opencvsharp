namespace OpenCvSharp.Text;

/// <summary>
/// HMM/BeamSearch decoding algorithm.
/// </summary>
public enum DecoderMode
{
    /// <summary>
    /// The Viterbi algorithm. Only decoding algorithm available at the moment.
    /// </summary>
    Viterbi = 0,
}
