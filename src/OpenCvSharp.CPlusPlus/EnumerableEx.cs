using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    internal delegate TResult Func<in T1, out TResult>(T1 t1);

    /// <summary>
    /// IEnumerable&lt;T&gt; extension methods for .NET Framework 2.0 
    /// </summary>
    internal static class EnumerableEx
    {
        /// <summary>
        /// Enumerable.Select
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Select<TSource, TResult>(
            IEnumerable<TSource> enumerable, Func<TSource, TResult> selector)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            if (selector == null)
                throw new ArgumentNullException("selector");
            foreach (TSource elem in enumerable)
            {
                yield return selector(elem);
            }
        }

        /// <summary>
        /// Enumerable.Select -> ToArray
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static TResult[] SelectToArray<TSource, TResult>(
            IEnumerable<TSource> enumerable, Func<TSource, TResult> selector)
        {
            return ToArray(Select(enumerable, selector));
        }

        /// <summary>
        /// Enumerable.Where
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Where<TSource>(
            IEnumerable<TSource> enumerable, Func<TSource, bool> predicate)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            foreach (TSource elem in enumerable)
            {
                if(predicate(elem))
                    yield return elem;
            }
        }

        /// <summary>
        /// Enumerable.Where -> ToArray
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static TSource[] WhereToArray<TSource>(
            IEnumerable<TSource> enumerable, Func<TSource, bool> predicate)
        {
            return ToArray(Where(enumerable, predicate));
        }

        /// <summary>
        /// Enumerable.ToArray
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static TSource[] ToArray<TSource>(IEnumerable<TSource> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException();
            TSource[] arr = enumerable as TSource[];
            if (arr != null)
                return arr;
            return new List<TSource>(enumerable).ToArray();
        }

        /// <summary>
        /// Enumerable.Any
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool Any<TSource>(
            IEnumerable<TSource> enumerable, Func<TSource, bool> predicate)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            foreach (TSource elem in enumerable)
            {
                if (predicate(elem))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Enumerable.All
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool All<TSource>(
            IEnumerable<TSource> enumerable, Func<TSource, bool> predicate)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            foreach (TSource elem in enumerable)
            {
                if (!predicate(elem))
                    return false;
            }
            return true;
        }
    }
}
