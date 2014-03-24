using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public class CvCamShiftTracker : DisposableCvObject
    {
        #region Fields
        /// <summary>
        /// sizeof(CvCamShiftTracker) 
        /// </summary>
        public static readonly int SizeOf = NativeMethods.legacy_CvCamShiftTracker_sizeof().ToInt32();
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;
        #endregion

        #region Init and Disposal
        /// <summary>
        /// 
        /// </summary>
        public CvCamShiftTracker()
        {
            ptr = NativeMethods.legacy_CvCamShiftTracker_new();
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        NativeMethods.legacy_CvCamShiftTracker_delete(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Methods
        /**** Characteristics of the object that are calculated by track_object method *****/

        /// <summary>
        /// orientation of the object in degrees
        /// </summary>
        /// <returns></returns>
        public float GetOrientation()
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_get_orientation(ptr);         
        }
        /// <summary>
        /// the larger linear size of the object
        /// </summary>
        /// <returns></returns>
        public float GetLength()
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_get_length(ptr);
        }
        /// <summary>
        /// the smaller linear size of the object
        /// </summary>
        /// <returns></returns>
        public float GetWidth()
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_get_width(ptr); 
        }
        /// <summary>
        /// center of the object
        /// </summary>
        /// <returns></returns>
        public CvPoint2D32f GetCenter()
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_get_center(ptr);
        }
        /// <summary>
        /// bounding rectangle for the object
        /// </summary>
        /// <returns></returns>
        public CvRect GetWindow()
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_get_window(ptr);
        }

        /*********************** Tracking parameters ************************/

        /// <summary>
        /// thresholding value that applied to back project
        /// </summary>
        /// <returns></returns>
        public int GetThreshold()
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_get_threshold(ptr); 
        }
        /// <summary>
        /// returns number of histogram dimensions and sets
        /// </summary>
        /// <param name="dims"></param>
        /// <returns></returns>
        public int GetHistDims(params int[] dims)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_get_hist_dims(ptr, dims); 
        }
        /// <summary>
        /// get the minimum allowed value of the specified channel
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public int GetMinChVal(int channel)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_get_min_ch_val(ptr, channel);
        }
        /// <summary>
        /// get the maximum allowed value of the specified channel
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public int GetMaxChVal(int channel)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_get_max_ch_val(ptr, channel); 
        }

        /// <summary>
        /// set initial object rectangle (must be called before initial calculation of the histogram)
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public bool SetWindow(CvRect window)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_set_window(ptr, window) != 0;
        }
        /// <summary>
        /// threshold applied to the histogram bins
        /// </summary>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public bool SetThreshold(int threshold)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_set_threshold(ptr, threshold) != 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dim"></param>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public bool SetHistBinRange(int dim, int minVal, int maxVal)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_set_hist_bin_range(ptr, dim, minVal, maxVal) != 0;
        }
        /// <summary>
        /// set the histogram parameters
        /// </summary>
        /// <param name="cDims"></param>
        /// <param name="dims"></param>
        /// <returns></returns>
        public bool SetHistDims(int cDims, params int[] dims)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_set_hist_dims(ptr, cDims, dims) != 0;
        }
        /// <summary>
        /// set the minimum allowed value of the specified channel
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool SetMinChVal(int channel, int val)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_set_min_ch_val(ptr, channel, val) != 0;
        }
        /// <summary>
        /// set the maximum allowed value of the specified channel
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool SetMaxChVal(int channel, int val)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_set_max_ch_val(ptr, channel, val) != 0;
        }

        /************************ The processing methods *********************************/
        /// <summary>
        /// update object position
        /// </summary>
        /// <param name="curFrame"></param>
        /// <returns></returns>
        public virtual bool TrackObject(IplImage curFrame)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            if (curFrame == null)
                throw new ArgumentNullException("curFrame");
            return NativeMethods.legacy_CvCamShiftTracker_track_object(ptr, curFrame.CvPtr) != 0;
        }
        /// <summary>
        /// update object histogram
        /// </summary>
        /// <param name="curFrame"></param>
        /// <returns></returns>
        public virtual bool UpdateHistogram(IplImage curFrame)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            if (curFrame == null)
                throw new ArgumentNullException("curFrame");
            return NativeMethods.legacy_CvCamShiftTracker_update_histogram(ptr, curFrame.CvPtr) != 0;
        }
        /// <summary>
        /// reset histogram
        /// </summary>
        public virtual void ResetHistogram()
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            NativeMethods.legacy_CvCamShiftTracker_reset_histogram(ptr);
        }

        /************************ Retrieving internal data *******************************/

        /// <summary>
        /// get back project image
        /// </summary>
        /// <returns></returns>
        public virtual IplImage GetBackProject()
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            IntPtr p = NativeMethods.legacy_CvCamShiftTracker_get_back_project(ptr);
            if (p == IntPtr.Zero)
                return null;
            return new IplImage(p, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bin"></param>
        /// <returns></returns>
        public float Query(params int[] bin)
        {
            if (disposed)
                throw new ObjectDisposedException("CvCamShiftTracker");
            return NativeMethods.legacy_CvCamShiftTracker_query(ptr, bin);
        }
        #endregion
    }
}
