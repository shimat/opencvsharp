using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming
#pragma warning disable 1591

    /// <summary>
    /// The base class for stereo correspondence algorithms.
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

        /// <summary>
        /// Computes disparity map for the specified stereo pair
        /// </summary>
        /// <param name="left">Left 8-bit single-channel image.</param>
        /// <param name="right">Right image of the same size and the same type as the left one.</param>
        /// <param name="disparity">Output disparity map. It has the same size as the input images. Some algorithms, 
        /// like StereoBM or StereoSGBM compute 16-bit fixed-point disparity map(where each disparity value has 4 fractional bits), 
        /// whereas other algorithms output 32 - bit floating - point disparity map.</param>
        public virtual void Compute(InputArray left, InputArray right, OutputArray disparity)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));
            if (right == null)
                throw new ArgumentNullException(nameof(right));
            if (disparity == null)
                throw new ArgumentNullException(nameof(disparity));
            left.ThrowIfDisposed();
            right.ThrowIfDisposed();
            disparity.ThrowIfNotReady();
            NativeMethods.calib3d_StereoMatcher_compute(ptr, left.CvPtr, right.CvPtr, disparity.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(left);
            GC.KeepAlive(right);
            disparity.Fix();
        }

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int MinDisparity
        {
            get
            {
                var res = NativeMethods.calib3d_StereoMatcher_getMinDisparity(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setMinDisparity(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NumDisparities
        {
            get
            {
                var res = NativeMethods.calib3d_StereoMatcher_getNumDisparities(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setNumDisparities(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int BlockSize
        {
            get
            {
                var res = NativeMethods.calib3d_StereoMatcher_getBlockSize(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setBlockSize(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SpeckleWindowSize
        {
            get
            {
                var res = NativeMethods.calib3d_StereoMatcher_getSpeckleWindowSize(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setSpeckleWindowSize(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SpeckleRange
        {
            get
            {
                var res = NativeMethods.calib3d_StereoMatcher_getSpeckleRange(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setSpeckleRange(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Disp12MaxDiff
        {
            get
            {
                var res = NativeMethods.calib3d_StereoMatcher_getDisp12MaxDiff(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.calib3d_StereoMatcher_setDisp12MaxDiff(ptr, value);
                GC.KeepAlive(this);
            }
        }

        #endregion

    }
}
