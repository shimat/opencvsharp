using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// 
/// </summary>
internal abstract class MatExprRowColIndexer
{
    /// <summary> 
    /// </summary>
    protected NativeMatExpr Parent { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent"></param>
    internal protected MatExprRowColIndexer(NativeMatExpr parent)
    {
        Parent = parent;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public abstract NativeMatExpr this[int pos] { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Design", "CA1716: Identifiers should not match keywords")]
    public virtual NativeMatExpr Get(int pos)
    {
        return this[pos];
    }
}
