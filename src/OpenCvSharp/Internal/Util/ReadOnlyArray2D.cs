namespace OpenCvSharp.Internal.Util;

/// <summary>
/// Readonly rectangular array (T[,])
/// </summary>
/// <typeparam name="T"></typeparam>
public class ReadOnlyArray2D<T>
{
    private readonly T[,] data;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data"></param>
    public ReadOnlyArray2D(T[,] data)
    {
        this.data = data ?? throw new ArgumentNullException(nameof(data));
    }

    /// <summary>
    /// Indexer
    /// </summary>
    /// <param name="index0"></param>
    /// <param name="index1"></param>
    /// <returns></returns>
    public ref readonly T this[int index0, int index1] => ref data[index0, index1];

    /// <summary>
    /// Gets the total number of elements in all the dimensions of the System.Array.
    /// </summary>
#pragma warning disable CA1721 
    public int Length => data.Length;
#pragma warning restore CA1721 

    /// <summary>
    /// Gets a 32-bit integer that represents the number of elements in the specified dimension of the System.Array.
    /// </summary>
    /// <param name="dimension"></param>
    /// <returns></returns>
    public int GetLength(int dimension) => data.GetLength(dimension);

    /// <summary>
    /// Returns internal buffer
    /// </summary>
    /// <returns></returns>
    public T[,] GetBuffer() => data;
}
