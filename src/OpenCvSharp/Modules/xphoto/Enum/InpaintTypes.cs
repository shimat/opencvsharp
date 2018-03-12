namespace OpenCvSharp.XPhoto
{
    /// <summary>
    /// various inpainting algorithms
    /// </summary>
    public enum InpaintTypes : int
    {
        /// <summary>
        /// This algorithm searches for dominant correspondences(transformations) of image patches 
        /// and tries to seamlessly fill-in the area to be inpainted using this transformations
        /// </summary>
        SHIFTMAP = 0
    }
}
