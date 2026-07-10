using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// Native callback invoked by cv::IStreamReader::read() through the <see cref="StreamReaderBridge"/>.
/// </summary>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate long StreamReaderReadCallback(IntPtr userData, IntPtr buffer, long size);

/// <summary>
/// Native callback invoked by cv::IStreamReader::seek() through the <see cref="StreamReaderBridge"/>.
/// </summary>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate long StreamReaderSeekCallback(IntPtr userData, long offset, int origin);

/// <summary>
/// Bridges a managed <see cref="IStreamReader"/> implementation to the native cv::IStreamReader callback ABI.
/// </summary>
/// <remarks>
/// An instance must be kept alive (rooted) by the caller for as long as the associated native VideoCapture
/// may still call back into it, since the delegates it exposes are passed to native code as raw function
/// pointers and are not tracked by the GC.
/// </remarks>
internal sealed class StreamReaderBridge
{
    private readonly IStreamReader source;

    public StreamReaderReadCallback ReadCallback { get; }

    public StreamReaderSeekCallback SeekCallback { get; }

    public StreamReaderBridge(IStreamReader source)
    {
        this.source = source;
        ReadCallback = Read;
        SeekCallback = Seek;
    }

    private long Read(IntPtr userData, IntPtr buffer, long size)
    {
        try
        {
            unsafe
            {
                var span = new Span<byte>((void*)buffer, checked((int)size));
                return source.Read(span);
            }
        }
        catch
        {
            return -1;
        }
    }

    private long Seek(IntPtr userData, long offset, int origin)
    {
        try
        {
            var seekOrigin = origin switch
            {
                0 => SeekOrigin.Begin,
                1 => SeekOrigin.Current,
                2 => SeekOrigin.End,
                _ => throw new ArgumentOutOfRangeException(nameof(origin), origin, "Unknown seek origin"),
            };
            return source.Seek(offset, seekOrigin);
        }
        catch
        {
            return -1;
        }
    }
}
