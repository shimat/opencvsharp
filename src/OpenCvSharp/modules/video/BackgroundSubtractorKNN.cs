using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// K nearest neigbours algorithm
    /// </summary>
    public class BackgroundSubtractorKNN : BackgroundSubtractor
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr objectPtr;
        /// <summary>
        /// 
        /// </summary>
        private bool disposed;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="history"></param>
        /// <param name="dist2Threshold"></param>
        /// <param name="detectShadows"></param>
        /// <returns></returns>
        public static BackgroundSubtractorKNN Create(
            int history=500, double dist2Threshold=400.0, bool detectShadows=true)
        {
            IntPtr ptr = NativeMethods.video_createBackgroundSubtractorKNN(
                history, dist2Threshold, detectShadows ? 1 : 0);
            return new BackgroundSubtractorKNN(ptr);
        }

        internal BackgroundSubtractorKNN(IntPtr ptr)
        {
            this.objectPtr = new Ptr(ptr);
            this.ptr = objectPtr.Get(); 
        }

#if LANG_JP
    /// <summary>
    /// ���\�[�X�̉��
    /// </summary>
    /// <param name="disposing">
    /// true�̏ꍇ�́A���̃��\�b�h�����[�U�R�[�h���璼�ڂ��Ă΂ꂽ���Ƃ������B�}�l�[�W�E�A���}�l�[�W�o���̃��\�[�X����������B
    /// false�̏ꍇ�́A���̃��\�b�h�̓����^�C������t�@�C�i���C�U�ɂ���ČĂ΂�A�����ق��̃I�u�W�F�N�g����Q�Ƃ���Ă��Ȃ����Ƃ������B�A���}�l�[�W���\�[�X�̂݉�������B
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
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        objectPtr?.Dispose();
                        objectPtr = null;
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int History
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getHistory(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setHistory(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NSamples
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getNSamples(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setNSamples(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Dist2Threshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getDist2Threshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setDist2Threshold(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int KNNSamples
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getkNNSamples(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setkNNSamples(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool DetectShadows
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getDetectShadows(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setDetectShadows(ptr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ShadowValue
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getShadowValue(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setShadowValue(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double ShadowThreshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorKNN_getShadowThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorKNN_setShadowThreshold(ptr, value);
            }
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.video_Ptr_BackgroundSubtractorKNN_get(ptr);
            }

            protected override void Release()
            {
                NativeMethods.video_Ptr_BackgroundSubtractorKNN_delete(ptr);
            }
        }
    }
}