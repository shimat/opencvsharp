
using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// Proxy data type for passing Mat's and vector&lt;&gt;'s as input parameters.
/// Synonym for OutputArray.
/// </summary>
public class InputOutputArray : OutputArray
{
    // Migration scaffold (issue #1976, strategy 3): wraps this class's native cv::_InputOutputArray*
    // as an ArrayProxy so externs taking _InputOutputArray* can move to the ArrayProxy ABI one module
    // at a time. The caller must keep this object alive across the native call (GC.KeepAlive).
    internal InputOutputArrayProxy ToInputOutputProxy() => new() { Handle = CvPtr, Kind = (int)ArrayProxyKind.RawInputOutputArray };

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mat"></param>
    internal InputOutputArray(Mat mat)
        : base(mat)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mat"></param>
    internal InputOutputArray(UMat mat)
        : base(mat)
    {
    }

    /// <summary>
    /// Creates a proxy class of the specified Mat
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public new static InputOutputArray Create(Mat mat)
    {
        return new(mat);
    }
        
    /// <summary>
    /// Creates a proxy class of the specified UMat
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public new static InputOutputArray Create(UMat mat)
    {
        return new(mat);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mat"></param>
    [SuppressMessage("Microsoft.Design", "CA2225: Operator overloads have named alternates")]
    public static implicit operator InputOutputArray(Mat mat)
    {
        return new(mat);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Design", "CA2225: Operator overloads have named alternates")]
    public static implicit operator InputOutputArray(UMat mat)
    {
        return new(mat);
    }
}
