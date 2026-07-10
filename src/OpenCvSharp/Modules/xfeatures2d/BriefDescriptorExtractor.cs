using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

using DescriptorExtractor = Feature2D;

/// <summary>
/// BRIEF Descriptor
/// </summary>
public class BriefDescriptorExtractor : DescriptorExtractor
{
#pragma warning disable 1591
    // ReSharper disable InconsistentNaming
    public const int PATCH_SIZE = 48;
    public const int KERNEL_SIZE = 9;
    // ReSharper restore InconsistentNaming
#pragma warning restore 1591

    /// <summary>
    /// 
    /// </summary>
    private BriefDescriptorExtractor(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_BriefDescriptorExtractor_delete(p)))
    { }

    /// <summary>
    /// bytes is a length of descriptor in bytes. It can be equal 16, 32 or 64 bytes.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="useOrientation">Sample patterns using keypoints orientation, disabled by default.</param>
    public static BriefDescriptorExtractor Create(int bytes = 32, bool useOrientation = false)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_BriefDescriptorExtractor_create(bytes, useOrientation ? 1 : 0, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_BriefDescriptorExtractor_get(ptr, out var rawPtr));
        return new BriefDescriptorExtractor(ptr, rawPtr);
    }

    /// <summary>
    /// Length of the descriptor in bytes. Valid values are: 16, 32 (default) or 64.
    /// </summary>
    public new int DescriptorSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_BriefDescriptorExtractor_getDescriptorSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_BriefDescriptorExtractor_setDescriptorSize(Handle, value));
        }
    }

    /// <summary>
    /// Sample patterns using keypoints orientation. Disabled by default.
    /// </summary>
    public bool UseOrientation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_BriefDescriptorExtractor_getUseOrientation(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_BriefDescriptorExtractor_setUseOrientation(Handle, value ? 1 : 0));
        }
    }
}
