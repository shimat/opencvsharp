using OpenCvSharp.Internal;

namespace OpenCvSharp.Bioinspired;

/// <summary>Segments transient motion areas using a retina-inspired model.</summary>
public class TransientAreasSegmentation : Algorithm
{
    private TransientAreasSegmentation(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(
            NativeMethods.bioinspired_Ptr_TransientAreasSegmentation_delete(p)))
    {
    }

    /// <summary>Creates a segmentation model for images of the specified size.</summary>
    public static TransientAreasSegmentation Create(Size inputSize)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(inputSize.Width);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(inputSize.Height);
        NativeMethods.HandleException(NativeMethods.bioinspired_TransientAreasSegmentation_create(
            inputSize.Width, inputSize.Height, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.bioinspired_Ptr_TransientAreasSegmentation_get(
            smartPtr, out var rawPtr));
        return new TransientAreasSegmentation(smartPtr, rawPtr);
    }

    /// <summary>Processes a frame; select a channel for multichannel input.</summary>
    public void Run(InputArray input, int channelIndex = 0)
    {
        ThrowIfDisposed();
        ArgumentOutOfRangeException.ThrowIfNegative(channelIndex);
        NativeMethods.HandleException(NativeMethods.bioinspired_TransientAreasSegmentation_run(
            Handle, input.Proxy, channelIndex));
        GC.KeepAlive(this);
        GC.KeepAlive(input.Source);
    }

    /// <summary>Gets the latest motion segmentation picture.</summary>
    public void GetSegmentationPicture(OutputArray output)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.bioinspired_TransientAreasSegmentation_getPicture(
            Handle, output.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(output.Source);
    }

    /// <summary>Clears temporal state.</summary>
    public void ClearBuffers()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.bioinspired_TransientAreasSegmentation_clearBuffers(Handle));
        GC.KeepAlive(this);
    }
}
