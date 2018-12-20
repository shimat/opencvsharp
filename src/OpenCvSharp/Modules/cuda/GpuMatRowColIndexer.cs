#if ENABLED_CUDA

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class GpuMatRowColIndexer
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly GpuMat parent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        protected internal GpuMatRowColIndexer(GpuMat parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Creates/Sets a matrix header for the specified matrix row/column.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public abstract GpuMat this[int pos] { get; set; }

        /// <summary>
        /// Creates/Sets a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public abstract GpuMat this[int start, int end] { get; set; }

        /// <summary>
        /// Creates/Sets a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public virtual GpuMat this[Range range]
        {
            get { return this[range.Start, range.End]; }
        }

        /// <summary>
        /// Creates a matrix header for the specified matrix row/column.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual GpuMat Get(int pos)
        {
            return this[pos];
        }
        /// <summary>
        /// Creates a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public virtual GpuMat Get(int start, int end)
        {
            return this[start, end];
        }
        /// <summary>
        /// Creates a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public virtual GpuMat Get(Range range)
        {
            return this[range];
        }

        /// <summary>
        /// Creates/Sets a matrix header for the specified matrix row/column.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        public virtual void Set(int pos, GpuMat value)
        {
            this[pos] = value;
        }

        /// <summary>
        /// Creates/Sets a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        public virtual void Set(int start, int end, GpuMat value)
        {
            this[start, end] = value;
        }

        /// <summary>
        /// Creates/Sets a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="range"></param>
        /// <param name="value"></param>
        public virtual void Set(Range range, GpuMat value)
        {
            this[range.Start, range.End] = value; 
        }
    }
}

#endif
