using System;


namespace OpenCvSharp
{
    /// <summary>
    /// cv::AKAZE descriptor type
    /// </summary>
    public enum AKAZEDescriptor : int
    {
        /// <summary>
        /// 
        /// </summary>
        DescriptorKazeUpright = CppConst.AKAZE_DESCRIPTOR_KAZE_UPRIGHT,

        /// <summary>
        /// 
        /// </summary>
        DescriptorKaze = CppConst.AKAZE_DESCRIPTOR_KAZE,

        /// <summary>
        /// 
        /// </summary>
        DescriptorMldbUpright = CppConst.AKAZE_DESCRIPTOR_MLDB_UPRIGHT,

        /// <summary>
        /// 
        /// </summary>
        DescriptorMldb = CppConst.AKAZE_DESCRIPTOR_MLDB,
    }
}
