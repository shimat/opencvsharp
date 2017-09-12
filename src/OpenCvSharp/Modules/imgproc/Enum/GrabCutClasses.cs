namespace OpenCvSharp
{
    /// <summary>
    /// class of the pixel in GrabCut algorithm
    /// </summary>
    public enum GrabCutClasses 
    {
        /// <summary>
        /// an obvious background pixels
        /// </summary>
        BGD = 0,  

        /// <summary>
        /// an obvious foreground (object) pixel
        /// </summary>
        FGD = 1,  

        /// <summary>
        /// a possible background pixel
        /// </summary>
        PR_BGD = 2, 

        /// <summary>
        /// a possible foreground pixel
        /// </summary>
        PR_FGD = 3   
    }
}
