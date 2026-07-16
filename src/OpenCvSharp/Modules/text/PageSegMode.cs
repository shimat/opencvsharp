namespace OpenCvSharp.Text;

/// <summary>
/// Tesseract page segmentation mode.
/// </summary>
public enum PageSegMode
{
    /// <summary>
    /// Orientation and script detection only.
    /// </summary>
    OsdOnly,

    /// <summary>
    /// Automatic page segmentation with orientation and script detection.
    /// </summary>
    AutoOsd,

    /// <summary>
    /// Automatic page segmentation, but no orientation, script detection, or OCR.
    /// </summary>
    AutoOnly,

    /// <summary>
    /// Fully automatic page segmentation, but no orientation and script detection.
    /// </summary>
    Auto,

    /// <summary>
    /// Assume a single column of text of variable sizes.
    /// </summary>
    SingleColumn,

    /// <summary>
    /// Assume a single uniform block of vertically aligned text.
    /// </summary>
    SingleBlockVertText,

    /// <summary>
    /// Assume a single uniform block of text.
    /// </summary>
    SingleBlock,

    /// <summary>
    /// Treat the image as a single text line.
    /// </summary>
    SingleLine,

    /// <summary>
    /// Treat the image as a single word.
    /// </summary>
    SingleWord,

    /// <summary>
    /// Treat the image as a single word in a circle.
    /// </summary>
    CircleWord,

    /// <summary>
    /// Treat the image as a single character.
    /// </summary>
    SingleChar,
}
