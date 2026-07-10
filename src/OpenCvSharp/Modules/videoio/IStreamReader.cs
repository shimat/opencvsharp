namespace OpenCvSharp;

/// <summary>
/// Read data stream interface. Implement this to let VideoCapture read from an arbitrary managed data
/// source (e.g. an in-memory buffer, network stream, or any other custom stream).
/// </summary>
/// <remarks>
/// Mirrors cv::IStreamReader.
/// </remarks>
public interface IStreamReader
{
    /// <summary>
    /// Reads bytes from the stream into the given buffer.
    /// </summary>
    /// <param name="buffer">Buffer to receive the read bytes. At most buffer.Length bytes are read.</param>
    /// <returns>Actual number of bytes read.</returns>
    long Read(Span<byte> buffer);

    /// <summary>
    /// Sets the stream position.
    /// </summary>
    /// <param name="offset">Seek offset.</param>
    /// <param name="origin">Seek origin.</param>
    /// <returns>The resulting stream position.</returns>
    long Seek(long offset, SeekOrigin origin);
}
