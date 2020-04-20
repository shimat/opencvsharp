namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// The algorithm variant to use for SuperpixelSLIC:
    /// SLIC segments image using a desired region_size, and in addition SLICO will optimize using adaptive compactness factor,
    /// while MSLIC will optimize using manifold methods resulting in more content-sensitive superpixels.
    /// </summary>
    public enum SLICType
    {
        /// <summary>
        /// SLIC(Simple Linear Iterative Clustering) clusters pixels using pixel channels and image plane space
        /// to efficiently generate compact, nearly uniform superpixels.The simplicity of approach makes it
        /// extremely easy to use a lone parameter specifies the number of superpixels and the efficiency of
        /// the algorithm makes it very practical.
        /// </summary>
        SLIC = 100,

        /// <summary>
        /// SLICO stands for "Zero parameter SLIC" and it is an optimization of baseline SLIC described in @cite Achanta2012.
        /// </summary>
        SLICO = 101,

        /// <summary>
        /// MSLIC stands for "Manifold SLIC" and it is an optimization of baseline SLIC described in @cite Liu_2017_IEEE.
        /// </summary>
        MSLIC = 102
    }
}