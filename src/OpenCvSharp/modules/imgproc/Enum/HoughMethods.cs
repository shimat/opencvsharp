
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// ハフ変換の種類
	/// </summary>
#else
    /// <summary>
    /// Variants of a Hough transform
    /// </summary>
#endif
	public enum HoughMethods : int
    {
        /*  */
        /// <summary>
        /// classical or standard Hough transform. 
        /// Every line is represented by two floating-point numbers \f$(\rho, \theta)\f$ , 
        /// where \f$\rho\f$ is a distance between (0,0) point and the line, 
        /// and \f$\theta\f$ is the angle between x-axis and the normal to the line. 
        /// Thus, the matrix must be (the created sequence will be) of CV_32FC2 type
        /// </summary>
        Standard = 0,

        /// <summary>
        /// probabilistic Hough transform (more efficient in case if the picture contains 
        /// a few long linear segments). It returns line segments rather than the whole line. 
        /// Each segment is represented by starting and ending points, and the matrix must be 
        /// (the created sequence will be) of the CV_32SC4 type.
        /// </summary>
        Probabilistic = 1,

        /// <summary>
        /// multi-scale variant of the classical Hough transform. 
        /// The lines are encoded the same way as HOUGH_STANDARD.
        /// </summary>
        MultiScale = 2,

        /// <summary>
        /// basically *21HT*, described in @cite Yuen90
        /// </summary>
        Gradient = 3 
	}
}
