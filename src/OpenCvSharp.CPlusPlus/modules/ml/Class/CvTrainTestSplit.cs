using System;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
#else
	/// <summary>
    /// 
    /// </summary>
#endif
    public class CvTrainTestSplit : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvTrainTestSplit()
        {
            ptr = NativeMethods.ml_CvTrainTestSplit_new1();
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSampleCount"></param>
        /// <param name="mix"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSampleCount"></param>
        /// <param name="mix"></param>
#endif
        public CvTrainTestSplit(int trainSampleCount, bool mix = true)
        {
            ptr = NativeMethods.ml_CvTrainTestSplit_new2(trainSampleCount, mix ? 1 : 0);
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSamplePortion"></param>
        /// <param name="mix"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSamplePortion"></param>
        /// <param name="mix"></param>
#endif
        public CvTrainTestSplit(float trainSamplePortion, bool mix = true)
        {
            ptr = NativeMethods.ml_CvTrainTestSplit_new3(trainSamplePortion, mix ? 1 : 0);
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
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        if (ptr != IntPtr.Zero)
                            NativeMethods.ml_CvTrainTestSplit_delete(ptr);
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

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int TrainSamplePartCount
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvTrainTestSplit"); 
                return NativeMethods.ml_CvTrainTestSplit_train_sample_part_count_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("CvTrainTestSplit"); 
                NativeMethods.ml_CvTrainTestSplit_train_sample_part_count_set(ptr, value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public float TrainSamplePartPortion
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvTrainTestSplit"); 
                return NativeMethods.ml_CvTrainTestSplit_train_sample_part_portion_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("CvTrainTestSplit"); 
                NativeMethods.ml_CvTrainTestSplit_train_sample_part_portion_set(ptr, value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public TrainSamplePartMode TrainSamplePartMode
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvTrainTestSplit"); 
                return (TrainSamplePartMode)NativeMethods.ml_CvTrainTestSplit_train_sample_part_mode_get(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("CvTrainTestSplit"); 
                NativeMethods.ml_CvTrainTestSplit_train_sample_part_mode_set(ptr, (int)value);
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public bool Mix
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvTrainTestSplit"); 
                return NativeMethods.ml_CvTrainTestSplit_mix_get(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException("CvTrainTestSplit"); 
                NativeMethods.ml_CvTrainTestSplit_mix_set(ptr, value ? 1 : 0);
            }
        }
        #endregion
    }
}
