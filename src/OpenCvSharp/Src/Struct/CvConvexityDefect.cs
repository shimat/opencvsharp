/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 輪郭の凸包の凹状欠損を表す構造体
    /// </summary>
#else
    /// <summary>
    /// Structure describing a single contour convexity detect
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CvConvexityDefect
    {
        #region Fields
        private IntPtr start;
        private IntPtr end;
        private IntPtr depth_point;
        private float depth;
        /// <summary>
        /// sizeof(CvConvexityDefect)
        /// </summary>
        public static readonly int SizeOf = (IntPtr.Size * 3) + sizeof(float);
        #endregion

        #region Properties
#if LANG_JP
        /// <summary>
        /// 輪郭の凹状欠損の始点
        /// </summary>
#else
        /// <summary>
        /// Point of the contour where the defect begins
        /// </summary>
#endif
        public CvPoint Start
        {
            get { return (CvPoint)Marshal.PtrToStructure(start, typeof(CvPoint)); }
        }

#if LANG_JP
        /// <summary>
        /// 輪郭の凹状欠損の終点
        /// </summary>
#else
        /// <summary>
        /// Point of the contour where the defect ends
        /// </summary>
#endif
        public CvPoint End
        {
            get { return (CvPoint)Marshal.PtrToStructure(end, typeof(CvPoint)); }
        }

#if LANG_JP
        /// <summary>
        /// 凹状欠損のうちで凸包から最も遠い点
        /// </summary>
#else
        /// <summary>
        /// The farthest from the convex hull point within the defect
        /// </summary>
#endif
        public CvPoint DepthPoint
        {
            get { return (CvPoint)Marshal.PtrToStructure(depth_point, typeof(CvPoint)); }
        }

#if LANG_JP
        /// <summary>
        /// 最も遠い点と凸包間の距離
        /// </summary>
#else
        /// <summary>
        /// Distance between the farthest point and the convex hull
        /// </summary>
#endif
        public float Depth
        {
            get { return depth; }
        }



        #endregion


#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="start">輪郭の凹状欠損の始点</param>
        /// <param name="end">輪郭の凹状欠損の終点</param>
        /// <param name="depth_point">凹状欠損のうちで凸包から最も遠い点</param>
        /// <param name="depth">最も遠い点と凸包間の距離</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="depth_point"></param>
        /// <param name="depth"></param>
#endif
        public CvConvexityDefect(IntPtr start, IntPtr end, IntPtr depth_point, float depth)
        {
            this.start = start;
            this.end = end;
            this.depth_point = depth_point;
            this.depth = depth;
        }

    }
}
