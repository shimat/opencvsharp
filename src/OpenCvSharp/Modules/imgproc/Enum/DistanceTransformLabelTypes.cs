namespace OpenCvSharp
{
    /// <summary>
    /// distanceTransform algorithm flags
    /// </summary>
    public enum DistanceTransformLabelTypes : int
    {
        /// <summary>
        /// each connected component of zeros in src 
        /// (as well as all the non-zero pixels closest to the connected component) 
        /// will be assigned the same label 
        /// </summary>
        CComp = 0,

        /// <summary>
        /// each zero pixel (and all the non-zero pixels closest to it) gets its own label.
        /// </summary>
        Pixel = 1,
    }
}
