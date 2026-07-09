// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// Type of metadata chunk stored in / retrieved from an image file by the *WithMetadata family of functions.
/// </summary>
public enum ImageMetadataType
{
    /// <summary>
    /// Used when metadata type is unrecognized or not set.
    /// </summary>
    Unknown = -1,

    /// <summary>
    /// EXIF metadata (e.g., camera info, GPS, orientation).
    /// </summary>
    EXIF = 0,

    /// <summary>
    /// XMP metadata (eXtensible Metadata Platform - Adobe format).
    /// </summary>
    XMP = 1,

    /// <summary>
    /// ICC Profile (color profile for color management).
    /// </summary>
    ICCP = 2,

    /// <summary>
    /// cICP Profile (video signal type).
    /// </summary>
    CICP = 3
}
