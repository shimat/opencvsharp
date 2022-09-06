using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// 
/// </summary>
public abstract class MatExprRowColIndexer
{
    /// <summary> 
    /// </summary>
    protected MatExpr Parent { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent"></param>
    protected internal MatExprRowColIndexer(MatExpr parent)
    {
        Parent = parent;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public abstract MatExpr this[int pos] { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Design", "CA1716: Identifiers should not match keywords")]
    public virtual MatExpr Get(int pos)
    {
        return this[pos];
    }
}
