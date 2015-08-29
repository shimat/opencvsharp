using System.Runtime.InteropServices;

namespace OpenCvSharp.Gpu
{
    /// <summary>
    /// Abstract definition of Mat indexer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GpuMatIndexer<T> where T : struct
    {
        /// <summary>
        /// 2-dimensional indexer
        /// </summary>
        /// <param name="i0">Index along the dimension 0</param>
        /// <param name="i1">Index along the dimension 1</param>
        /// <returns>A value to the specified array element.</returns>
        public abstract T this[int i0, int i1] { get; set; }

        /// <summary>
        /// Parent matrix object
        /// </summary>
        protected readonly GpuMat parent;

        /// <summary>
        /// Step byte length for each dimension
        /// </summary>
        protected readonly long step;

        /// <summary>
        /// sizeof(T)
        /// </summary>
        protected readonly int sizeOfT;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent"></param>
        internal GpuMatIndexer(GpuMat parent)
        {
            this.parent = parent;
            this.step = parent.Step();
            this.sizeOfT = Marshal.SizeOf(typeof(T));
        }
    }
}