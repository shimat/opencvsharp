using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Gaussian Mixture-based Backbround/Foreground Segmentation Algorithm
    /// </summary>
    public class BackgroundSubtractorMOG : BackgroundSubtractor
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
        /// <param name="nMixtures"></param>
        /// <param name="backgroundRatio"></param>
        /// <param name="noiseSigma"></param>
        /// <returns></returns>
        public static BackgroundSubtractorMOG Create(
            int history = 200, int nMixtures = 5, double backgroundRatio = 0.7, double noiseSigma = 0)
        {
            IntPtr ptr = NativeMethods.bgsegm_createBackgroundSubtractorMOG(
                history, nMixtures, backgroundRatio, noiseSigma);
            return new BackgroundSubtractorMOG(ptr);
        }

        internal BackgroundSubtractorMOG(IntPtr ptr)
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
                return NativeMethods.bgsegm_BackgroundSubtractorMOG_getHistory(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setHistory(ptr, value);
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
                return NativeMethods.bgsegm_BackgroundSubtractorMOG_getNMixtures(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setNMixtures(ptr, value);
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
                return NativeMethods.bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double NoiseSigma
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.bgsegm_BackgroundSubtractorMOG_getNoiseSigma(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.bgsegm_BackgroundSubtractorMOG_setNoiseSigma(ptr, value);
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
                return NativeMethods.bgsegm_Ptr_BackgroundSubtractorMOG_get(ptr);
            }

            protected override void Release()
            {
                NativeMethods.bgsegm_Ptr_BackgroundSubtractorMOG_delete(ptr);
            }
        }
    }
}