using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
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
        Default = CppConst.DrawMatchesFlags_DEFAULT,
        
        /// <summary>
        /// Output image matrix will not be created (Mat::create).
        /// Matches will be drawn on existing content of output image.
        /// </summary>
        DrawOverOutImg = CppConst.DrawMatchesFlags_DRAW_OVER_OUTIMG,

        /// <summary>
        /// Single keypoints will not be drawn.
        /// </summary>
        NotDrawSinglePoints = CppConst.DrawMatchesFlags_NOT_DRAW_SINGLE_POINTS,  
        
        /// <summary>
        /// For each keypoint the circle around keypoint with keypoint size and
        /// orientation will be drawn.
        /// </summary>
        DrawRichKeypoints = CppConst.DrawMatchesFlags_DRAW_RICH_KEYPOINTS
        
    }
}


