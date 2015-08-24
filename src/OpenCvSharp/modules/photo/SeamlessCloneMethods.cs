namespace OpenCvSharp
{
    /// <summary>
    /// SeamlessClone method
    /// </summary>
    public enum SeamlessCloneMethods
    {
        /// <summary>
        /// The power of the method is fully expressed when inserting objects with 
        /// complex outlines into a new background.
        /// </summary>
        NormalClone = 1,

        /// <summary>
        /// The classic method, color-based selection and alpha masking might be time 
        /// consuming and often leaves an undesirable halo. Seamless cloning, even averaged 
        /// with the original image, is not effective. Mixed seamless cloning based on a 
        /// loose selection proves effective.
        /// </summary>
        MixedClone = 2,

        /// <summary>
        /// Feature exchange allows the user to easily replace certain features of one 
        /// object by alternative features.
        /// </summary>
        MonochromeTransfer = 3
    }
}
