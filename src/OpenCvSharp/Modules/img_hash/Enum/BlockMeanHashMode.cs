namespace OpenCvSharp.ImgHash
{
    /// <summary>
    /// 
    /// </summary>
    public enum BlockMeanHashMode
    {
        /// <summary>
        /// use fewer block and generate 16*16/8 uchar hash value
        /// </summary>
        Mode0 = 0, 

        /// <summary>
        /// use block blocks(step sizes/2), generate 31*31/8 + 1 uchar hash value
        /// </summary>
        Mode1 = 1,
    }
}