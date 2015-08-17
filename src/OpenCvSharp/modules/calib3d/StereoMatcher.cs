using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming
#pragma warning disable 1591

    /// <summary>
    /// 
    /// </summary>
    public class StereoMatcher : Algorithm
    {
        /// <summary>
        /// constructor
        /// </summary>
        protected StereoMatcher(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int MinDisparity
        {
            get
            {
                return NativeMethods.calib3d_StereoMatcher_getMinDisparity(ptr);
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setMinDisparity(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NumDisparities
        {
            get
            {
                return NativeMethods.calib3d_StereoMatcher_getNumDisparities(ptr);
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setNumDisparities(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int BlockSize
        {
            get
            {
                return NativeMethods.calib3d_StereoMatcher_getBlockSize(ptr);
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setBlockSize(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SpeckleWindowSize
        {
            get
            {
                return NativeMethods.calib3d_StereoMatcher_getSpeckleWindowSize(ptr);
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setSpeckleWindowSize(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SpeckleRange
        {
            get
            {
                return NativeMethods.calib3d_StereoMatcher_getSpeckleRange(ptr);
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setSpeckleRange(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Disp12MaxDiff
        {
            get
            {
                return NativeMethods.calib3d_StereoMatcher_getDisp12MaxDiff(ptr);
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setDisp12MaxDiff(ptr, value);
            }
        }

        #endregion

    }
}
