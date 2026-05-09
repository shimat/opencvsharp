namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Order of image moments.
    /// </summary>
    public enum MomentsOrder
    {
        /// <summary>
        /// Compute spatial moments up to the 1st order. 
        /// Includes m00, m10, and m01. 
        /// Sufficient for calculating the area and the centroid (center of mass).
        /// </summary>
        FirstOrder = 1,

        /// <summary>
        /// Compute moments up to the 2nd order. 
        /// Includes all 1st order moments plus m20, m11, and m02. 
        /// Useful for determining object orientation, eccentricity, and the principal axes.
        /// </summary>
        SecondOrder = 2,

        /// <summary>
        /// Compute moments up to the 3rd order. 
        /// Includes all 2nd order moments plus m30, m21, m12, and m03. 
        /// Provides a more detailed description of the shape, including its skewness (asymmetry).
        /// </summary>
        ThirdOrder = 3
    }
}
