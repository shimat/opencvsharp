// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// Descriptor type for cv::xfeatures2d::VGG.
/// </summary>
public enum VGGDescriptorType
{
    /// <summary>
    /// 120-dimensional float descriptor
    /// </summary>
    Vgg120 = 100,

    /// <summary>
    /// 80-dimensional float descriptor
    /// </summary>
    Vgg80 = 101,

    /// <summary>
    /// 64-dimensional float descriptor
    /// </summary>
    Vgg64 = 102,

    /// <summary>
    /// 48-dimensional float descriptor
    /// </summary>
    Vgg48 = 103
}
