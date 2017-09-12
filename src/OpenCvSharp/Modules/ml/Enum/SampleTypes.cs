
namespace OpenCvSharp.ML
{
    /// <summary>
    /// Sample types
    /// </summary>
    public enum SampleTypes : int
    {
        /// <summary>
        /// each training sample is a row of samples
        /// </summary>
        RowSample = 0,

        /// <summary>
        /// each training sample occupies a column of samples
        /// </summary>
        ColSample = 1,
    }
}
