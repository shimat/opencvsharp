using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Face;

/// <summary>
/// Detects face rectangles from an image for a facemark model.
/// </summary>
public delegate Rect[] FacemarkFaceDetector(Mat image);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate int FacemarkFaceDetectorNativeCallback(
    IntPtr image, Rect* faces, int capacity);

internal sealed unsafe class FacemarkFaceDetectorBridge : IDisposable
{
    internal delegate ExceptionStatus NativeSetter(
        OpenCvSafeHandle obj,
        FacemarkFaceDetectorNativeCallback callback,
        out IntPtr callbackData,
        out int returnValue);

    private readonly FacemarkFaceDetector detector;
    private readonly FacemarkFaceDetectorNativeCallback nativeCallback;
    private readonly ConcurrentDictionary<int, Rect[]> pendingResults = new();
    private OpenCvPtrSafeHandle? callbackDataHandle;

    public FacemarkFaceDetectorBridge(
        OpenCvSafeHandle obj,
        FacemarkFaceDetector detector,
        NativeSetter setter)
    {
        this.detector = detector;
        nativeCallback = Invoke;
        NativeMethods.HandleException(setter(obj, nativeCallback, out var callbackData, out var result));
        if (result == 0 || callbackData == IntPtr.Zero)
            throw new OpenCvSharpException("OpenCV rejected the custom facemark face detector.");
        callbackDataHandle = new OpenCvPtrSafeHandle(
            callbackData, ownsHandle: true,
            releaseAction: p => NativeMethods.HandleException(
                NativeMethods.face_FacemarkFaceDetectorCallbackData_delete(p)));
    }

    private unsafe int Invoke(IntPtr imagePointer, Rect* faces, int capacity)
    {
        try
        {
            var threadId = Environment.CurrentManagedThreadId;
            if (faces == null)
            {
                using var image = new Mat(imagePointer, ownsHandle: false);
                var result = detector(image) ?? [];
                pendingResults[threadId] = result;
                return result.Length;
            }

            if (!pendingResults.TryRemove(threadId, out var pending) || pending.Length != capacity)
                return -1;
            pending.AsSpan().CopyTo(new Span<Rect>(faces, capacity));
            return pending.Length;
        }
        catch
        {
            return -1;
        }
    }

    public void Dispose()
    {
        callbackDataHandle?.Dispose();
        callbackDataHandle = null;
        pendingResults.Clear();
    }
}
