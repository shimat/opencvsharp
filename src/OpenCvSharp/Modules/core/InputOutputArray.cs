
using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// Proxy data type for passing Mat's and vector&lt;&gt;'s as input parameters.
/// Synonym for OutputArray.
/// </summary>
public class InputOutputArray : OutputArray
{
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
