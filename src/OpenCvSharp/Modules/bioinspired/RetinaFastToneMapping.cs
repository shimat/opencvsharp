using OpenCvSharp.Internal;

namespace OpenCvSharp.Bioinspired;

/// <summary>Fast retina-inspired local luminance adaptation for tone mapping.</summary>
public class RetinaFastToneMapping : Algorithm
{
    private RetinaFastToneMapping(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(
            NativeMethods.bioinspired_Ptr_RetinaFastToneMapping_delete(p)))
    {
    }

    /// <summary>Creates a tone mapper for images of the specified size.</summary>
    public static RetinaFastToneMapping Create(Size inputSize)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(inputSize.Width);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(inputSize.Height);
        NativeMethods.HandleException(NativeMethods.bioinspired_RetinaFastToneMapping_create(
            inputSize.Width, inputSize.Height, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.bioinspired_Ptr_RetinaFastToneMapping_get(smartPtr, out var rawPtr));
        return new RetinaFastToneMapping(smartPtr, rawPtr);
    }

    /// <summary>Adjusts the local adaptation neighborhoods and mean luminance modulation.</summary>
    public void Setup(
        float photoreceptorsRadius = 3f, float ganglionCellsRadius = 1f,
        float meanLuminanceModulator = 1f)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.bioinspired_RetinaFastToneMapping_setup(
            Handle, photoreceptorsRadius, ganglionCellsRadius, meanLuminanceModulator));
        GC.KeepAlive(this);
    }

    /// <summary>Applies fast tone mapping to a grayscale or color image.</summary>
    public void Apply(InputArray input, OutputArray output)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.bioinspired_RetinaFastToneMapping_apply(
            Handle, input.Proxy, output.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(input.Source);
        GC.KeepAlive(output.Source);
    }
}
