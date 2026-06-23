#pragma warning disable CS1591

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Dnn;

/// <summary>
/// Enum of image processing mode.
/// To facilitate the specialization pre-processing requirements of the dnn model.
/// For example, the letter box often used in the Yolo series of models.
/// </summary>
public enum ImagePaddingMode
{
    /// <summary>
    /// Default. Resize to required input size without extra processing.
    /// </summary>
    NULL = 0,

    /// <summary>
    /// Crop after resize.
    /// </summary>
    CROP_CENTER = 1,

    /// <summary>
    /// Resize image to the desired size while preserving the aspect ratio of original image.
    /// </summary>
    LETTERBOX = 2,
}
