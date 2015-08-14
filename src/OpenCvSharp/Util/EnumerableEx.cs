using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenCvSharp.Util
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
        /// Enumerable.Select -> ToArray
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static TResult[] SelectToArray<TSource, TResult>(
            IEnumerable enumerable, Func<TSource, TResult> selector)
        {
            var result = new List<TResult>();
            foreach (TSource source in enumerable)
            {
                result.Add(selector(source));
            }
            return result.ToArray();
        }

        /// <summary>
        /// Enumerable.Select -> ToArray
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IntPtr[] SelectPtrs(IEnumerable<Mat> enumerable)
        {
            return SelectToArray(enumerable, delegate(Mat obj)
            {
                if (obj == null)
                    throw new ArgumentException("enumerable contains null");
                obj.ThrowIfDisposed();
                return obj.CvPtr;
            });
        }

        /// <summary>
        /// Enumerable.Select -> ToArray
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IntPtr[] SelectPtrs(IEnumerable<InputArray> enumerable)
        {
            return SelectToArray(enumerable, delegate(InputArray obj)
            {
                if (obj == null)
                    throw new ArgumentException("enumerable contains null");
                obj.ThrowIfDisposed();
                return obj.CvPtr;
            });
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
                if (predicate(elem))
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
                return null;
            var arr = enumerable as TSource[];
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
        /// Enumerable.Any
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyNull<TSource>(IEnumerable<TSource> enumerable)
            where TSource : class
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            if (typeof (TSource).IsValueType)
                return false;

            foreach (TSource elem in enumerable)
            {
                if (elem == null)
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

        /// <summary>
        /// Enumerable.Count
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int Count<TSource>(
            IEnumerable<TSource> enumerable, Func<TSource, bool> predicate)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");

            int count = 0;
            foreach (TSource elem in enumerable)
            {
                if (predicate(elem))
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Enumerable.Count
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static int Count<TSource>(IEnumerable<TSource> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");

            TSource[] array = enumerable as TSource[];
            if (array != null)
                return array.Length;

            ICollection<TSource> collection = enumerable as ICollection<TSource>;
            if (collection != null)
                return collection.Count;

            int count = 0;
            foreach (TSource elem in enumerable)
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsEmpty<TSource>(IEnumerable<TSource> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");

            foreach (TSource elem in enumerable)
            {
                return false;
            }
            return true;
        }
    }
}
