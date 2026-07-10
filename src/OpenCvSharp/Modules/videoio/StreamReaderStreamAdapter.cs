namespace OpenCvSharp;

/// <summary>
/// Adapts a <see cref="System.IO.Stream"/> to <see cref="IStreamReader"/> so it can be passed to VideoCapture.
/// </summary>
internal sealed class StreamReaderStreamAdapter(Stream stream) : IStreamReader
{
    public long Read(Span<byte> buffer) => stream.Read(buffer);

    public long Seek(long offset, SeekOrigin origin) => stream.Seek(offset, origin);
}
