using System;
using System.Collections.Generic;

namespace OpenCvSharp
{
    static partial class Cv2
    {
        /// <summary>
        /// Groups the object candidate rectangles.
        /// </summary>
        /// <param name="rectList"> Input/output vector of rectangles. Output vector includes retained and grouped rectangles.</param>
        /// <param name="groupThreshold">Minimum possible number of rectangles minus 1. The threshold is used in a group of rectangles to retain it.</param>
        /// <param name="eps"></param>
        public static void GroupRectangles(IList<Rect> rectList, int groupThreshold, double eps = 0.2)
        {
            if (rectList == null)
                throw new ArgumentNullException(nameof(rectList));

            using (var rectListVec = new VectorOfRect(rectList))
            {
                NativeMethods.objdetect_groupRectangles1(rectListVec.CvPtr, groupThreshold, eps);
                ClearAndAddRange(rectList, rectListVec.ToArray());
            }
        }

        /// <summary>
        /// Groups the object candidate rectangles.
        /// </summary>
        /// <param name="rectList"> Input/output vector of rectangles. Output vector includes retained and grouped rectangles.</param>
        /// <param name="weights"></param>
        /// <param name="groupThreshold">Minimum possible number of rectangles minus 1. The threshold is used in a group of rectangles to retain it.</param>
        /// <param name="eps">Relative difference between sides of the rectangles to merge them into a group.</param>
        public static void GroupRectangles(IList<Rect> rectList, out int[] weights, int groupThreshold, double eps = 0.2)
        {
            if (rectList == null)
                throw new ArgumentNullException(nameof(rectList));

            using (var rectListVec = new VectorOfRect(rectList))
            using (var weightsVec = new VectorOfInt32())
            {
                NativeMethods.objdetect_groupRectangles2(rectListVec.CvPtr, weightsVec.CvPtr, groupThreshold, eps);
                ClearAndAddRange(rectList, rectListVec.ToArray());
                weights = weightsVec.ToArray();
            }
        }

        /// <summary>
        /// Groups the object candidate rectangles.
        /// </summary>
        /// <param name="rectList"></param>
        /// <param name="groupThreshold"></param>
        /// <param name="eps"></param>
        /// <param name="weights"></param>
        /// <param name="levelWeights"></param>
        public static void GroupRectangles(IList<Rect> rectList, int groupThreshold, double eps, out int[] weights, out double[] levelWeights)
        {
            if (rectList == null)
                throw new ArgumentNullException(nameof(rectList));

            using (var rectListVec = new VectorOfRect(rectList))
            using (var weightsVec = new VectorOfInt32())
            using (var levelWeightsVec = new VectorOfDouble())
            {
                NativeMethods.objdetect_groupRectangles3(rectListVec.CvPtr, groupThreshold, eps, weightsVec.CvPtr, levelWeightsVec.CvPtr);
                ClearAndAddRange(rectList, rectListVec.ToArray());
                weights = weightsVec.ToArray();
                levelWeights = levelWeightsVec.ToArray();
            }
        }

        /// <summary>
        /// Groups the object candidate rectangles.
        /// </summary>
        /// <param name="rectList"></param>
        /// <param name="rejectLevels"></param>
        /// <param name="levelWeights"></param>
        /// <param name="groupThreshold"></param>
        /// <param name="eps"></param>
        public static void GroupRectangles(IList<Rect> rectList, out int[] rejectLevels, out double[] levelWeights, int groupThreshold, double eps = 0.2)
        {
            if (rectList == null)
                throw new ArgumentNullException(nameof(rectList));

            using (var rectListVec = new VectorOfRect(rectList))
            using (var rejectLevelsVec = new VectorOfInt32())
            using (var levelWeightsVec = new VectorOfDouble())
            {
                NativeMethods.objdetect_groupRectangles4(rectListVec.CvPtr, rejectLevelsVec.CvPtr, levelWeightsVec.CvPtr, groupThreshold, eps);
                ClearAndAddRange(rectList, rectListVec.ToArray());
                rejectLevels = rejectLevelsVec.ToArray();
                levelWeights = levelWeightsVec.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectList"></param>
        /// <param name="foundWeights"></param>
        /// <param name="foundScales"></param>
        /// <param name="detectThreshold"></param>
        /// <param name="winDetSize"></param>
        public static void GroupRectanglesMeanshift(IList<Rect> rectList, out double[] foundWeights,
            out double[] foundScales, double detectThreshold = 0.0, Size? winDetSize = null)
        {
            if (rectList == null)
                throw new ArgumentNullException(nameof(rectList));

            Size winDetSize0 = winDetSize.GetValueOrDefault(new Size(64, 128));

            using (var rectListVec = new VectorOfRect(rectList))
            using (var foundWeightsVec = new VectorOfDouble())
            using (var foundScalesVec = new VectorOfDouble())
            {
                NativeMethods.objdetect_groupRectangles_meanshift(
                    rectListVec.CvPtr, foundWeightsVec.CvPtr, foundScalesVec.CvPtr, detectThreshold, winDetSize0);
                ClearAndAddRange(rectList, rectListVec.ToArray());
                foundWeights = foundWeightsVec.ToArray();
                foundScales = foundScalesVec.ToArray();
            }
        }

        /// <summary>
        /// IListの要素にvaluesを設定する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="values"></param>
        private static void ClearAndAddRange<T>(IList<T> list, IEnumerable<T> values)
        {
            list.Clear();
            foreach (T t in values)
            {
                list.Add(t);
            }
        }
    }
}
