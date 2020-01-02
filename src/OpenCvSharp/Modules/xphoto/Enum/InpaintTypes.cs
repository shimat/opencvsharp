// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp.XPhoto
{
    /// <summary>
    /// various inpainting algorithms
    /// </summary>
    public enum InpaintTypes
    {
        /// <summary>
        /// This algorithm searches for dominant correspondences(transformations) of image patches 
        /// and tries to seamlessly fill-in the area to be inpainted using this transformations inpaint
        /// </summary>
        SHIFTMAP = 0
    }
}
