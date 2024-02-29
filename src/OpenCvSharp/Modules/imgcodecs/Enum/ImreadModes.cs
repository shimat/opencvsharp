#pragma warning disable CA1008 // Enums should have zero value
#pragma warning disable CA2217 // Do not mark enums with FlagsAttribute

namespace OpenCvSharp;

/// <summary>
/// Specifies colorness and Depth of the loaded image
/// </summary>
[Flags]
public enum ImreadModes
{
    /// <summary>
    /// If set, return the loaded image as is (with alpha channel, otherwise it gets cropped).
    /// </summary>
    Unchanged = -1,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image.
    /// </summary>
    Grayscale = 0,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image.
    /// </summary>
    Color = 1,

    /// <summary>
    /// If set, return 16-bit/32-bit image when the input has the corresponding depth, otherwise convert it to 8-bit.
    /// </summary>
    AnyDepth = 2,

    /// <summary>
    /// If set, the image is read in any possible color format.
    /// </summary>
    AnyColor = 4,

    /// <summary>
    /// If set, use the gdal driver for loading the image.
    /// </summary>
    LoadGdal = 8,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image and the image size reduced 1/2.
    /// </summary>
    ReducedGrayscale2 = 16,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image and the image size reduced 1/2.
    /// </summary>
    ReducedColor2 = 17,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image and the image size reduced 1/4.
    /// </summary>
    ReducedGrayscale4 = 32,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image and the image size reduced 1/4.
    /// </summary>
    ReducedColor4 = 33,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image and the image size reduced 1/8.
    /// </summary>
    ReducedGrayscale8 = 64,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image and the image size reduced 1/8.
    /// </summary>
    ReducedColor8 = 65,

    /// <summary>
    /// If set, do not rotate the image according to EXIF's orientation flag.
    /// </summary>
    IgnoreOrientation = 128 
};
