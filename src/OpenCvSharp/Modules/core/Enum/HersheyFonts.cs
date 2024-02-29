#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

/// <summary>
/// Font name identifier. 
/// Only a subset of Hershey fonts (http://sources.isc.org/utils/misc/hershey-font.txt) are supported now.
/// </summary>
[Flags]
public enum HersheyFonts
{
    /// <summary>
    /// normal size sans-serif font
    /// </summary>
    HersheySimplex = 0, 

    /// <summary>
    /// small size sans-serif font
    /// </summary>
    HersheyPlain = 1,  

    /// <summary>
    /// normal size sans-serif font (more complex than HERSHEY_SIMPLEX)
    /// </summary>
    HersheyDuplex = 2,  

    /// <summary>
    /// normal size serif font
    /// </summary>
    HersheyComplex = 3,  

    /// <summary>
    /// normal size serif font (more complex than HERSHEY_COMPLEX)
    /// </summary>
    HersheyTriplex = 4, 

    /// <summary>
    /// smaller version of HERSHEY_COMPLEX
    /// </summary>
    HersheyComplexSmall = 5, 

    /// <summary>
    /// hand-writing style font
    /// </summary>
    HersheyScriptSimplex = 6, 

    /// <summary>
    /// more complex variant of HERSHEY_SCRIPT_SIMPLEX
    /// </summary>
    HersheyScriptComplex = 7, 

    /// <summary>
    /// flag for italic font
    /// </summary>
    Italic = 16 
}
