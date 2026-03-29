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
    public static BriefDescriptorExtractor Create(int bytes = 32)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_BriefDescriptorExtractor_create(bytes, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_BriefDescriptorExtractor_get(ptr, out var rawPtr));
        return new BriefDescriptorExtractor(ptr, rawPtr);
    }
}
