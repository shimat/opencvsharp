namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Descriptor storage format for CUDA HOG.
    /// </summary>
    public enum HOGDescriptorFormat
    {
        /// <summary>
        /// Descriptors are stored column by column.
        /// </summary>
        ColByCol = 0,

        /// <summary>
        /// Descriptors are stored row by row.
        /// </summary>
        RowByRow = 1
    }
}
