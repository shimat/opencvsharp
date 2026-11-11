using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// Porter-Duff operations for <see cref="Cv2.AlphaComposite"/>.
/// </summary>
[SuppressMessage("Microsoft.Design", "CA1717: Only FlagsAttribute enums should have plural names")]
public enum AlphaCompositeOperations
{
    /// <summary>Clears both images.</summary>
    Clear = 0,

    /// <summary>Keeps the overlay only.</summary>
    Source = 1,

    /// <summary>Keeps the background only.</summary>
    Dest = 2,

    /// <summary>Draws the overlay over the background.</summary>
    Over = 3,

    /// <summary>Draws the background over the overlay.</summary>
    DestOver = 4,

    /// <summary>Keeps the overlay weighted by the background alpha.</summary>
    In = 5,

    /// <summary>Keeps the background weighted by the overlay alpha.</summary>
    DestIn = 6,

    /// <summary>Keeps the overlay weighted by the inverse background alpha.</summary>
    Out = 7,

    /// <summary>Keeps the background weighted by the inverse overlay alpha.</summary>
    DestOut = 8,

    /// <summary>Draws the overlay over the background, clipped to the background alpha.</summary>
    Atop = 9,

    /// <summary>Draws the background over the overlay, clipped to the overlay alpha.</summary>
    DestAtop = 10,

    /// <summary>Keeps the nonoverlapping parts of both images.</summary>
    Xor = 11,

    /// <summary>Adds the premultiplied colors and alphas with saturation.</summary>
    Plus = 12
}
