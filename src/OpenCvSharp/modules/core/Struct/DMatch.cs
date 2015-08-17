using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 2つのキーポイントディスクリプタ同士のマッチング情報
    /// </summary>
#else
    /// <summary>
    /// Struct for matching: query descriptor index, train descriptor index, train image index and distance between descriptors.
    /// </summary>
#endif
    public struct DMatch
    {
#if LANG_JP
        /// <summary>
        /// クエリディスクリプタインデックス
        /// </summary>
#else
        /// <summary>
        /// query descriptor index
        /// </summary>
#endif
        public int QueryIdx; 

#if LANG_JP
        /// <summary>
        /// 訓練ディスクリプタインデックス
        /// </summary>
#else
        /// <summary>
        /// train descriptor index
        /// </summary>
#endif
        public int TrainIdx; 

#if LANG_JP
        /// <summary>
        /// 訓練画像インデックス
        /// </summary>
#else
        /// <summary>
        /// train image index
        /// </summary>
#endif
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator Vec4f(DMatch self)
        {
            return new Vec4f(self.QueryIdx, self.TrainIdx, self.ImgIdx, self.Distance);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static explicit operator DMatch(Vec4f v)
        {
            return new DMatch((int)v.Item0, (int)v.Item1, (int)v.Item2, v.Item3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("DMatch (QueryIdx:{0}, TrainIdx:{1}, ImgIdx:{2}, Distance:{3})",
                QueryIdx, TrainIdx, ImgIdx, Distance);
        }
    }

}
