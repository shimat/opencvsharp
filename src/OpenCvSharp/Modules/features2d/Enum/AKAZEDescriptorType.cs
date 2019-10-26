﻿namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// cv::AKAZE descriptor type
    /// </summary>

    public enum AKAZEDescriptorType
    {
        /// <summary>
        /// Upright descriptors, not invariant to rotation
        /// </summary>
        KAZEUpright = 2, 
        
        /// <summary>
        /// 
        /// </summary>
        KAZE = 3,

        /// <summary>
        /// 
        /// </summary>
        MLDBUpright = 4, 

        /// <summary>
        /// Upright descriptors, not invariant to rotation
        /// </summary>
        MLDB = 5
    }
}
