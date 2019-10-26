namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MatRowColExprIndexer
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly Mat Parent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        protected internal MatRowColExprIndexer(Mat parent)
        {
            Parent = parent;
        }

        /// <summary>
        /// Creates a matrix header for the specified matrix row/column.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public abstract MatExpr this[int pos] { get; set; }

        /// <summary>
        /// Creates a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public abstract MatExpr this[int start, int end] { get; set; }

        /// <summary>
        /// Creates a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public virtual MatExpr this[Range range]
        {
            get => this[range.Start, range.End];
            set => this[range.Start, range.End] = value;
        }

        /// <summary>
        /// Creates a matrix header for the specified matrix row/column.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public MatExpr Get(int pos)
        {
            return this[pos];
        }
        /// <summary>
        /// Creates a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public MatExpr Get(int start, int end)
        {
            return this[start, end];
        }
        /// <summary>
        /// Creates a matrix header for the specified row/column span.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public MatExpr Get(Range range)
        {
            return this[range];
        }

        /// <summary>
        /// Sets a matrix header for the specified matrix row/column.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set(int pos, MatExpr value)
        {
            this[pos] = value;
        }

        /// <summary>
        /// Sets a matrix header for the specified matrix row/column span.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set(int start, int end, MatExpr value)
        {
            this[start, end] = value;
        }
        /// <summary>
        /// Sets a matrix header for the specified matrix row/column span.
        /// </summary>
        /// <param name="range"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Set(Range range, MatExpr value)
        {
            this[range] = value;
        }
    }
}
