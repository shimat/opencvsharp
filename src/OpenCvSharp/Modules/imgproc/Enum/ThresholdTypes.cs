#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

/// <summary>
/// Thresholding type
/// </summary>
[Flags]
public enum ThresholdTypes
{
    /// <summary>
    /// \f[\texttt{dst} (x,y) =  \fork{\texttt{maxval}}{if \(\texttt{src}(x,y) > \texttt{thresh}\)}{0}{otherwise}\f]
    /// </summary>
    Binary = 0,

    /// <summary>
    /// \f[\texttt{dst} (x,y) =  \fork{0}{if \(\texttt{src}(x,y) > \texttt{thresh}\)}{\texttt{maxval}}{otherwise}\f]
    /// </summary>
    BinaryInv = 1,

    /// <summary>
    /// \f[\texttt{dst} (x,y) =  \fork{\texttt{threshold}}{if \(\texttt{src}(x,y) > \texttt{thresh}\)}{\texttt{src}(x,y)}{otherwise}\f]
    /// </summary>
    Trunc = 2,

    /// <summary>
    /// \f[\texttt{dst} (x,y) =  \fork{\texttt{src}(x,y)}{if \(\texttt{src}(x,y) > \texttt{thresh}\)}{0}{otherwise}\f]
    /// </summary>
    Tozero = 3,

    /// <summary>
    /// \f[\texttt{dst} (x,y) =  \fork{0}{if \(\texttt{src}(x,y) > \texttt{thresh}\)}{\texttt{src}(x,y)}{otherwise}\f]
    /// </summary>
    TozeroInv = 4,

    /// <summary>
    /// 
    /// </summary>
    Mask = 7,

    /// <summary>
    /// flag, use Otsu algorithm to choose the optimal threshold value
    /// </summary>
    Otsu = 8, 

    /// <summary>
    /// flag, use Triangle algorithm to choose the optimal threshold value
    /// </summary>
    Triangle = 16
}
