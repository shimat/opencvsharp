namespace OpenCvSharp.Internal.Util;
#pragma warning disable 1591

internal static class EnumerableExtensions
{
    /// <summary>
    /// enumerable as T[] ?? enumerable.ToArray()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static T[] CastOrToArray<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable is T[] array)
            return array;
        return enumerable.ToArray();
    }

    /// <summary>
    /// Converts a nuint[] (e.g. std::vector sizes) to a long[] in a single pass, without LINQ enumerator overhead.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static long[] ToInt64Array(this nuint[] source)
    {
        return Array.ConvertAll(source, static s => (long)s);
    }
}
