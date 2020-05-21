
namespace OpenCvSharp
{
    /// <summary>
    /// Proxy data type for passing Mat's and vector&lt;&gt;'s as input parameters.
    /// Synonym for OutputArray.
    /// </summary>
    public class InputOutputArray : OutputArray
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal InputOutputArray(Mat mat)
            : base(mat)
        {
        }

        /// <summary>
        /// Creates a proxy class of the specified Mat
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static new InputOutputArray Create(Mat mat)
        {
            return new InputOutputArray(mat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator InputOutputArray(Mat mat)
        {
            return new InputOutputArray(mat);
        }
    }
}
