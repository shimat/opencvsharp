namespace OpenCvSharp.Aruco
{
    /// <summary>
    /// corner refinement method
    /// </summary>
    public enum CornerRefineMethod
    {
        /// <summary>
        /// default corners
        /// </summary>
        None,  

        /// <summary>
        /// refine the corners using subpix
        /// </summary>
        Subpix, 

        /// <summary>
        /// refine the corners using the contour-points
        /// </summary>
        Contour  
    }
}