using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// Bridges a managed <see cref="IStreamReader"/> implementation to the native cv::IStreamReader callback ABI.
/// </summary>
/// <remarks>
/// The native-facing function pointers (see <see cref="ReadCallbackPointer"/>/<see cref="SeekCallbackPointer"/>)
/// are always the fixed, static <see cref="UnmanagedCallersOnlyAttribute"/> trampolines below; the real
/// <see cref="IStreamReader"/> is boxed into a <see cref="GCHandle"/>-rooted context, whose <see cref="IntPtr"/>
/// representation (<see cref="UserData"/>) is passed through as the native userData. An instance must be
/// disposed once the associated native VideoCapture can no longer call back into it, both to free the
/// GCHandle and because native never inspects userData beyond that call.
/// </remarks>
internal sealed class StreamReaderBridge : IDisposable
{
    private GCHandle handle;

    public IntPtr ReadCallbackPointer { get; } = GetReadTrampolinePointer();

    public IntPtr SeekCallbackPointer { get; } = GetSeekTrampolinePointer();

    public IntPtr UserData => GCHandle.ToIntPtr(handle);

    public StreamReaderBridge(IStreamReader source)
    {
        handle = GCHandle.Alloc(source);
    }

    public void Dispose()
    {
        if (handle.IsAllocated)
            handle.Free();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static long ReadTrampoline(IntPtr userData, IntPtr buffer, long size)
    {
        try
        {
            var source = (IStreamReader)GCHandle.FromIntPtr(userData).Target!;
            unsafe
            {
                var span = new Span<byte>((void*)buffer, checked((int)size));
                var read = source.Read(span);
                // Defensive: a misbehaving IStreamReader implementation must not be able to make native
                // code believe it received more bytes than actually fit in the buffer it handed us.
                if (read < 0 || read > span.Length)
                    return -1;
                return read;
            }
        }
        catch
        {
            // Exceptions must never unwind into native code from an UnmanagedCallersOnly method.
            return -1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static long SeekTrampoline(IntPtr userData, long offset, int origin)
    {
        try
        {
            var source = (IStreamReader)GCHandle.FromIntPtr(userData).Target!;
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
            // Exceptions must never unwind into native code from an UnmanagedCallersOnly method.
            return -1;
        }
    }

    private static unsafe IntPtr GetReadTrampolinePointer() =>
        (IntPtr)(delegate* unmanaged[Cdecl]<IntPtr, IntPtr, long, long>)&ReadTrampoline;

    private static unsafe IntPtr GetSeekTrampolinePointer() =>
        (IntPtr)(delegate* unmanaged[Cdecl]<IntPtr, long, int, long>)&SeekTrampoline;
}
