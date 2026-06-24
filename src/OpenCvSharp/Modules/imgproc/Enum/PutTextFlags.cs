namespace OpenCvSharp;

/// <summary>
/// Flags for the FontFace-based <see cref="Cv2.PutText(InputOutputArray, string, Point, Scalar, FontFace, int, int, PutTextFlags, OpenCvSharp.Range?)"/>
/// and <see cref="Cv2.GetTextSize(Size, string, Point, FontFace, int, int, PutTextFlags, OpenCvSharp.Range?)"/> (OpenCV 5).
/// </summary>
[Flags]
public enum PutTextFlags
{
    /// <summary>
    /// Put the text to the right from the origin.
    /// </summary>
    AlignLeft = 0,

    /// <summary>
    /// Center the text at the origin (not implemented yet in OpenCV).
    /// </summary>
    AlignCenter = 1,

    /// <summary>
    /// Put the text to the left of the origin.
    /// </summary>
    AlignRight = 2,

    /// <summary>
    /// Alignment mask.
    /// </summary>
    AlignMask = 3,

    /// <summary>
    /// Treat the target image as having a top-left origin (default).
    /// </summary>
    OriginTL = 0,

    /// <summary>
    /// Treat the target image as having a bottom-left origin.
    /// </summary>
    OriginBL = 32,

    /// <summary>
    /// Wrap text to the next line if it does not fit.
    /// </summary>
    Wrap = 128
}
