using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// Proxy datatype for passing Mat's and List&lt;&gt;'s as output parameters
/// </summary>
public sealed class OutputArrayOfMatList : OutputArray
{
    private readonly List<Mat> list;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    internal OutputArrayOfMatList(List<Mat> list)
        : base(list)
    {
        this.list = list ?? throw new ArgumentNullException(nameof(list));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<Mat> GetVectorOfMat()
    {
        return list;
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AssignResult()
    {
        if (!IsReady())
            throw new NotSupportedException();
            
        using var vectorOfMat = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.core_OutputArray_getVectorOfMat(ptr, vectorOfMat.CvPtr));
        GC.KeepAlive(this);
        list.Clear();
        list.AddRange(vectorOfMat.ToArray());
    }
}
