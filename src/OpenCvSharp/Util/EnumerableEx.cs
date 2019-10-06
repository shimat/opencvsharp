using System;
using System.Collections;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Reflection;

namespace OpenCvSharp.Util
{
#if NET20
    internal delegate TResult Func<in T1, out TResult>(T1 t1);
#endif

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
#if NET20
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));
            foreach (TSource elem in enumerable)
            {
                yield return selector(elem);
            }
#else
            return enumerable.Select(selector);
#endif
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
#if NET20
            return ToArray(Select(enumerable, selector));
#else
            return enumerable.Select(selector).ToArray();
#endif
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
#if NET20
            var result = new List<TResult>();
            foreach (TSource source in enumerable)
            {
                result.Add(selector(source));
            }
            return result.ToArray();
#else
            return enumerable.Cast<TSource>().Select(selector).ToArray();
#endif
        }

        /// <summary>
        /// Enumerable.Select -> ToArray
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IntPtr[] SelectPtrs(IEnumerable<Mat> enumerable)
        {
            return SelectToArray(enumerable, obj =>
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
            return SelectToArray(enumerable, obj =>
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
#if NET20
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            foreach (TSource elem in enumerable)
            {
                if (predicate(elem))
                    yield return elem;
            }
#else
            return enumerable.Where(predicate);
#endif
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
#if NET20
            return ToArray(Where(enumerable, predicate));
#else
            return enumerable.Where(predicate).ToArray();
#endif
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
                throw new ArgumentNullException(nameof(enumerable));
#if NET20
            if (enumerable is TSource[] arr)
                return arr;
            return new List<TSource>(enumerable).ToArray();
#else
            return enumerable.ToArray();
#endif
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
#if NET20
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            foreach (TSource elem in enumerable)
            {
                if (predicate(elem))
                    return true;
            }
            return false;
#else
            return enumerable.Any(predicate);
#endif
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
                throw new ArgumentNullException(nameof(enumerable));

#if NET20
            foreach (TSource elem in enumerable)
            {
                if (elem == null)
                    return true;
            }
            return false;
#else
            return enumerable.Any(e => e == null);
#endif
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
#if NET20
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            foreach (TSource elem in enumerable)
            {
                if (!predicate(elem))
                    return false;
            }
            return true;
#else
            return enumerable.All(predicate);
#endif
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
#if NET20
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            int count = 0;
            foreach (TSource elem in enumerable)
            {
                if (predicate(elem))
                    count++;
            }
            return count;
#else
            return enumerable.Count(predicate);
#endif
        }

        /// <summary>
        /// Enumerable.Count
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static int Count<TSource>(IEnumerable<TSource> enumerable)
        {
#if NET20
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            if (enumerable is TSource[] array)
                return array.Length;
            if (enumerable is ICollection<TSource> collection)
                return collection.Count;

            int count = 0;
            foreach (TSource elem in enumerable)
            {
                count++;
            }
            return count;
#else
            return enumerable.Count();
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsEmpty<TSource>(IEnumerable<TSource> enumerable)
        {
#if NET20
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            foreach (TSource elem in enumerable)
            {
                return false;
            }
            return true;
#else
            return !enumerable.Any();
#endif
        }
    }
}
