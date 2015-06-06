using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// Abstract definition of Mat indexer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SparseMatIndexer<T> where T : struct
    {
        /// <summary>
        /// 1-dimensional indexer
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="hashVal">If hashVal is not null, the element hash value is not computed but hashval is taken instead.</param>
        /// <returns>A value to the specified array element.</returns>
        public abstract T this[int i0, long? hashVal = null] { get; set; }

        /// <summary>
        /// 2-dimensional indexer
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <param name="hashVal">If hashVal is not null, the element hash value is not computed but hashval is taken instead.</param>
        /// <returns>A value to the specified array element.</returns>
        public abstract T this[int i0, int i1, long? hashVal = null] { get; set; }

        /// <summary>
        /// 3-dimensional indexer
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <param name="i2"> Index along the dimension 2</param>
        /// <param name="hashVal">If hashVal is not null, the element hash value is not computed but hashval is taken instead.</param>
        /// <returns>A value to the specified array element.</returns>
        public abstract T this[int i0, int i1, int i2, long? hashVal = null] { get; set; }

        /// <summary>
        /// n-dimensional indexer
        /// </summary>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <param name="hashVal">If hashVal is not null, the element hash value is not computed but hashval is taken instead.</param>
        /// <returns>A value to the specified array element.</returns>
        public abstract T this[int[] idx, long? hashVal = null] { get; set; }

        /// <summary>
        /// Parent matrix object
        /// </summary>
        protected readonly SparseMat parent;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent"></param>
        internal SparseMatIndexer(SparseMat parent)
        {
            this.parent = parent;
        }
    }
}
