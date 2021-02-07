using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp
{
#pragma warning disable CA1051

    /// <summary>
    /// Struct for matching: query descriptor index, train descriptor index, train image index and distance between descriptors.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
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
            return new (-1, -1, -1, float.MaxValue);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="queryIdx"></param>
        /// <param name="trainIdx"></param>
        /// <param name="distance"></param>
        public DMatch(int queryIdx, int trainIdx, float distance) :
            this(queryIdx, trainIdx, -1, distance)
        {
        }

        /// <summary>
        /// Constructor
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
        /// Compares by distance (less is better)
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator <(DMatch d1, DMatch d2)
        {
            return d1.Distance < d2.Distance;
        }

        /// <summary>
        /// Compares by distance (less is better)
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator >(DMatch d1, DMatch d2)
        {
            return d1.Distance > d2.Distance;
        }

        /// <summary>
        /// Compares by distance (less is better)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(DMatch other) => Distance.CompareTo(other.Distance);

#pragma warning disable 1591

        public static explicit operator Vec4f(DMatch self) => self.ToVec4f();

        // ReSharper disable once InconsistentNaming
        public Vec4f ToVec4f() => new(QueryIdx, TrainIdx, ImgIdx, Distance);

        public static explicit operator DMatch(Vec4f v) => FromVec4f(v);

        // ReSharper disable once InconsistentNaming
        public static DMatch FromVec4f(Vec4f v) => new ((int)v.Item0, (int)v.Item1, (int)v.Item2, v.Item3);

#pragma warning restore 1591

        /// <inheritdoc />
        public override readonly string ToString()
        {
            // ReSharper disable once UseStringInterpolation
            return $"DMatch (QueryIdx:{QueryIdx}, TrainIdx:{TrainIdx}, ImgIdx:{ImgIdx}, Distance:{Distance})";
        }
    }
}
