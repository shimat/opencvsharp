// ReSharper disable CommentTypo

namespace OpenCvSharp;

/// <summary>
/// Imwrite PAM specific tupletype flags used to define the 'TUPETYPE' field of a PAM file.
/// </summary>
// ReSharper disable once IdentifierTypo
// ReSharper disable once UnusedMember.Global
// ReSharper disable once InconsistentNaming
public enum ImwritePAMFlags
{
#pragma warning disable CS1591
    FormatNull = 0,
    FormatBlackAndWhite = 1,
    FormatGrayscale = 2,
    FormatGrayscaleAlpha = 3,
    FormatRgb = 4,
    FormatRgbAlpha = 5,
}
