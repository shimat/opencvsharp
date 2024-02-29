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
}
