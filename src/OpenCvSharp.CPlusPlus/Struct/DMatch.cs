using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Struct for matching: query descriptor index, train descriptor index, train image index and distance between descriptors.
    /// </summary>
    public struct DMatch
    {
        /// <summary>
        /// query descriptor index
        /// </summary>
        public int QueryIdx; 
        /// <summary>
        /// train descriptor index
        /// </summary>
        public int TrainIdx; 
        /// <summary>
        /// train image index
        /// </summary>
        public int ImgIdx; 
        /// <summary>
        /// 
        /// </summary>
        public float Distance;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DMatch Empty()
        {
            return new DMatch(-1, -1, -1, Single.MaxValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryIdx"></param>
        /// <param name="trainIdx"></param>
        /// <param name="distance"></param>
        public DMatch(int queryIdx, int trainIdx, float distance) :
            this(queryIdx, trainIdx, -1, distance)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryIdx"></param>
        /// <param name="trainIdx"></param>
        /// <param name="imgIdx"></param>
        /// <param name="distance"></param>
        public DMatch(int queryIdx, int trainIdx, int imgIdx, float distance)
        {
            QueryIdx = queryIdx;
            TrainIdx = trainIdx;
            ImgIdx = imgIdx;
            Distance = distance;
        }

        /// <summary>
        /// Compares by distance (less is beter)
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator <(DMatch d1, DMatch d2)
        {
            return d1.Distance < d2.Distance;
        }
        /// <summary>
        /// Compares by distance (less is beter)
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator >(DMatch d1, DMatch d2)
        {
            return d1.Distance > d2.Distance;
        }
    }

}
