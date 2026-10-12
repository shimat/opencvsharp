using OpenCvSharp.Internal;

namespace OpenCvSharp.Bioinspired;

/// <summary>Retina-inspired processing with detail and motion channels.</summary>
public class Retina : Algorithm
{
    private Retina(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(
            NativeMethods.bioinspired_Ptr_Retina_delete(p)))
    {
    }

    /// <summary>Creates a retina model for images of the specified size.</summary>
    public static Retina Create(Size inputSize)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(inputSize.Width);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(inputSize.Height);
        NativeMethods.HandleException(NativeMethods.bioinspired_Retina_create(
            inputSize.Width, inputSize.Height, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.bioinspired_Ptr_Retina_get(smartPtr, out var rawPtr));
        return new Retina(smartPtr, rawPtr);
    }

    /// <summary>Processes an input frame and updates the detail and motion channels.</summary>
    public void Run(InputArray input)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.bioinspired_Retina_run(Handle, input.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(input.Source);
    }

    /// <summary>Gets the normalized detail channel from the last frame.</summary>
    public void GetParvo(OutputArray output)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.bioinspired_Retina_getParvo(Handle, output.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(output.Source);
    }

    /// <summary>Gets the normalized motion channel from the last frame.</summary>
    public void GetMagno(OutputArray output)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.bioinspired_Retina_getMagno(Handle, output.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(output.Source);
    }

    /// <summary>Clears temporal state before processing an unrelated sequence.</summary>
    public void ClearBuffers()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.bioinspired_Retina_clearBuffers(Handle));
        GC.KeepAlive(this);
    }
}
