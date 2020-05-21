﻿using System.Collections.Generic;

namespace OpenCvSharp
{
    /// <summary>
    /// Abstract definition of Mat indexer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MatIndexer<T> where T : struct
    {
        /// <summary>
        /// 1-dimensional indexer
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <returns>A value to the specified array element.</returns>
        public abstract T this[int i0] { get; set; }

        /// <summary>
        /// 2-dimensional indexer
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <returns>A value to the specified array element.</returns>
        public abstract T this[int i0, int i1] { get; set; }

        /// <summary>
        /// 3-dimensional indexer
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <param name="i2"> Index along the dimension 2</param>
        /// <returns>A value to the specified array element.</returns>
        public abstract T this[int i0, int i1, int i2] { get; set; }

        /// <summary>
        /// n-dimensional indexer
        /// </summary>
        /// <param name="idx">Array of Mat::dims indices.</param>
        /// <returns>A value to the specified array element.</returns>
        public abstract T this[params int[] idx] { get; set; }

        /// <summary>
        /// Parent matrix object
        /// </summary>
        protected Mat Parent { get; }

        /// <summary>
        /// Step byte length for each dimension
        /// </summary>
        protected IReadOnlyList<long> Steps { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent"></param>
        internal MatIndexer(Mat parent)
        {
            Parent = parent;

            var dims = parent.Dims;
            var steps = new long[dims];
            for (var i = 0; i < dims; i++)
            {
                steps[i] = parent.Step(i);
            }
            Steps = steps;
        }
    }
}
