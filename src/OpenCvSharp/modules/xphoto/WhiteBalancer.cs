namespace OpenCvSharp.XPhoto
{

    /// <summary>
    /// The base class for auto white balance algorithms.
    /// </summary>
    public abstract class WhiteBalancer : Algorithm
    {

        /// <summary>
        /// Applies white balancing to the input image.
        /// </summary>
        /// <param name="src">Input image</param>
        /// <param name="dst">White balancing result</param>
        public abstract void BalanceWhite(InputArray src, OutputArray dst);

    }
}
