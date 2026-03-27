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
    protected BriefDescriptorExtractor()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ptr"></param>
    protected BriefDescriptorExtractor(IntPtr ptr)
    {
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_BriefDescriptorExtractor_get(ptr, out var rawPtr));
        SetSafeHandle(new OpenCvPtrSafeHandle(rawPtr, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_BriefDescriptorExtractor_delete(ptr))));
    }

    /// <summary>
    /// bytes is a length of descriptor in bytes. It can be equal 16, 32 or 64 bytes.
    /// </summary>
    /// <param name="bytes"></param>
    public static BriefDescriptorExtractor Create(int bytes = 32)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_BriefDescriptorExtractor_create(bytes, out var p));
        return new BriefDescriptorExtractor(p);
    }
}
