namespace OpenCvSharp
{
    /// <summary>
    /// [findTransformECC] specifying the type of motion
    /// </summary>
    public enum MotionTypes
    {
        /// <summary>
        /// sets a translational motion model; warpMatrix is \f$2\times 3\f$ with
        /// the first \f$2\times 2\f$ part being the unity matrix and the rest two parameters being estimated.
        /// </summary>
        Translation = 0,

        /// <summary>
        /// sets a Euclidean (rigid) transformation as motion model; three parameters are estimated; warpMatrix is \f$2\times 3\f$.
        /// </summary>
        Euclidean = 1,

        /// <summary>
        /// sets an affine motion model (DEFAULT); six parameters are estimated; warpMatrix is \f$2\times 3\f$.
        /// </summary>
        Affine = 2,

        /// <summary>
        /// sets a homography as a motion model; eight parameters are estimated;\`warpMatrix\` is \f$3\times 3\f$.
        /// </summary>
        Homography = 3
    }
}