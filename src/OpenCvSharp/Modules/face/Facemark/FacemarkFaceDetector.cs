using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Face;

/// <summary>
/// Detects face rectangles from an image for a facemark model.
/// </summary>
public delegate Rect[] FacemarkFaceDetector(Mat image);

internal sealed unsafe class FacemarkFaceDetectorBridge : IDisposable
{
    // callback is a function pointer to the static, [UnmanagedCallersOnly] trampoline below;
    // userData is a GCHandle to the FacemarkFaceDetectorBridge instance it should dispatch to,
    // round-tripped opaquely by the native side (see face_Facemark.h).
    internal delegate ExceptionStatus NativeSetter(
        OpenCvSafeHandle obj,
        IntPtr callback,
        IntPtr userData,
        out IntPtr callbackData,
        out int returnValue);

    private readonly FacemarkFaceDetector detector;
    private readonly ConcurrentDictionary<int, Rect[]> pendingResults = new();
    private GCHandle contextHandle;
    private OpenCvPtrSafeHandle? callbackDataHandle;

    public FacemarkFaceDetectorBridge(
        OpenCvSafeHandle obj,
        FacemarkFaceDetector detector,
        NativeSetter setter)
    {
        this.detector = detector;
        contextHandle = GCHandle.Alloc(this);
        IntPtr callbackData;
        int result;
        try
        {
            NativeMethods.HandleException(
                setter(obj, GetTrampolinePointer(), GCHandle.ToIntPtr(contextHandle), out callbackData, out result));
        }
        catch
        {
            contextHandle.Free();
            throw;
        }
        if (result == 0 || callbackData == IntPtr.Zero)
        {
            contextHandle.Free();
            throw new OpenCvSharpException("OpenCV rejected the custom facemark face detector.");
        }
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

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static int Trampoline(IntPtr userData, IntPtr image, Rect* faces, int capacity)
    {
        try
        {
            var bridge = (FacemarkFaceDetectorBridge)GCHandle.FromIntPtr(userData).Target!;
            return bridge.Invoke(image, faces, capacity);
        }
        catch
        {
            // Exceptions must never unwind into native code from an UnmanagedCallersOnly method.
            return -1;
        }
    }

    private static IntPtr GetTrampolinePointer() =>
        (IntPtr)(delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Rect*, int, int>)&Trampoline;

    public void Dispose()
    {
        callbackDataHandle?.Dispose();
        callbackDataHandle = null;
        if (contextHandle.IsAllocated)
            contextHandle.Free();
        pendingResults.Clear();
    }
}
