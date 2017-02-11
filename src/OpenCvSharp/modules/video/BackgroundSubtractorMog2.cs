using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// The Base Class for Background/Foreground Segmentation.
    /// The class is only used to define the common interface for
    /// the whole family of background/foreground segmentation algorithms.
    /// </summary>
    public class BackgroundSubtractorMOG2 : BackgroundSubtractor
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
        /// <param name="varThreshold"></param>
        /// <param name="detectShadows"></param>
        /// <returns></returns>
        public static BackgroundSubtractorMOG2 Create(
            int history = 500, double varThreshold = 16, bool detectShadows = true)
        {
            IntPtr ptr = NativeMethods.video_createBackgroundSubtractorMOG2(
                history, varThreshold, detectShadows ? 1 : 0);
            return new BackgroundSubtractorMOG2(ptr);
        }

        internal BackgroundSubtractorMOG2(IntPtr ptr)
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
                return NativeMethods.video_BackgroundSubtractorMOG2_getHistory(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setHistory(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NMixtures
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorMOG2_getNMixtures(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setNMixtures(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double BackgroundRatio
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorMOG2_getBackgroundRatio(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setBackgroundRatio(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double VarThreshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorMOG2_getHistory(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setVarThreshold(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double VarThresholdGen
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorMOG2_getVarThresholdGen(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setVarThresholdGen(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double VarInit
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorMOG2_getVarInit(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setVarInit(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double VarMin
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorMOG2_getVarMin(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setVarMin(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double VarMax
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorMOG2_getVarMax(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setVarMax(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double ComplexityReductionThreshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.video_BackgroundSubtractorMOG2_getComplexityReductionThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setComplexityReductionThreshold(ptr, value);
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
                return NativeMethods.video_BackgroundSubtractorMOG2_getDetectShadows(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setDetectShadows(ptr, value ? 1 : 0);
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
                return NativeMethods.video_BackgroundSubtractorMOG2_getShadowValue(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setShadowValue(ptr, value);
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
                return NativeMethods.video_BackgroundSubtractorMOG2_getShadowThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.video_BackgroundSubtractorMOG2_setShadowThreshold(ptr, value);
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
                return NativeMethods.video_Ptr_BackgroundSubtractorMOG2_get(ptr);
            }

            protected override void Release()
            {
                NativeMethods.video_Ptr_BackgroundSubtractorMOG2_delete(ptr);
            }
        }
    }
}