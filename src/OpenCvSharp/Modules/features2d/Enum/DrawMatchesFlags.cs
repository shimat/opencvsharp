using System;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum DrawMatchesFlags : int
    {
        /// <summary>
        /// Output image matrix will be created (Mat::create),
        /// i.e. existing memory of output image may be reused.
        /// Two source image, matches and single keypoints will be drawn.
        /// For each keypoint only the center point will be drawn (without
        /// the circle around keypoint with keypoint size and orientation).
        /// </summary>
        Default = 0,
        
        /// <summary>
        /// Output image matrix will not be created (Mat::create).
        /// Matches will be drawn on existing content of output image.
        /// </summary>
        DrawOverOutImg = 1,

        /// <summary>
        /// Single keypoints will not be drawn.
        /// </summary>
        NotDrawSinglePoints = 2,  
        
        /// <summary>
        /// For each keypoint the circle around keypoint with keypoint size and
        /// orientation will be drawn.
        /// </summary>
        DrawRichKeypoints = 4
    }
}


