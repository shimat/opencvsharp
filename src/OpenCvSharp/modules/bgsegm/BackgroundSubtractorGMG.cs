using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Background Subtractor module. Takes a series of images and returns a sequence of mask (8UC1)
    ///  images of the same size, where 255 indicates Foreground and 0 represents Background.
    /// </summary>
    public class BackgroundSubtractorGMG : BackgroundSubtractor
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
        /// <param name="initializationFrames"></param>
        /// <param name="decisionThreshold"></param>
        /// <returns></returns>
        public static BackgroundSubtractorGMG Create(
            int initializationFrames = 120, double decisionThreshold = 0.8)
        {
            IntPtr ptr = NativeMethods.bgsegm_createBackgroundSubtractorGMG(
                initializationFrames, decisionThreshold);
            return new BackgroundSubtractorGMG(ptr);
        }

        internal BackgroundSubtractorGMG(IntPtr ptr)
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
        public int MaxFeatures
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getMaxFeatures(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMaxFeatures(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double DefaultLearningRate
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NumFrames
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getNumFrames(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setNumFrames(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int QuantizationLevels
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setQuantizationLevels(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double BackgroundPrior
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setBackgroundPrior(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SmoothingRadius
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setSmoothingRadius(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double DecisionThreshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setDecisionThreshold(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool UpdateBackgroundModel
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel(ptr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double MinVal
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getMinVal(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMinVal(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double MaxVal
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorGMG_getMaxVal(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorGMG_setMaxVal(ptr, value);
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
                return NativeMethods.bgsegm_Ptr_BackgroundSubtractorGMG_get(ptr);
            }

            protected override void Release()
            {
                NativeMethods.bgsegm_Ptr_BackgroundSubtractorGMG_delete(ptr);
            }
        }
    }
}