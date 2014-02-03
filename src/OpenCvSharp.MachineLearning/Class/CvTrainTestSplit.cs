/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;

#pragma warning disable 1591

namespace OpenCvSharp.MachineLearning
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
        private bool disposed = false;

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
            ptr = MLInvoke.CvTrainTestSplit_construct1();
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train_sample_count"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSampleCount"></param>
#endif
        public CvTrainTestSplit(int trainSampleCount)
            : this(trainSampleCount, true)
        {
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train_sample_count"></param>
        /// <param name="mix"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSampleCount"></param>
        /// <param name="mix"></param>
#endif
        public CvTrainTestSplit(int trainSampleCount, bool mix)
        {
            ptr = MLInvoke.CvTrainTestSplit_construct2(trainSampleCount, mix);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train_sample_portion"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSamplePortion"></param>
#endif
        public CvTrainTestSplit(float trainSamplePortion)
            : this(trainSamplePortion, true)
        {
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train_sample_portion"></param>
        /// <param name="mix"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainSamplePortion"></param>
        /// <param name="mix"></param>
#endif
        public CvTrainTestSplit(float trainSamplePortion, bool mix)
        {
            ptr = MLInvoke.CvTrainTestSplit_construct3(trainSamplePortion, mix);
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
                        MLInvoke.CvTrainTestSplit_destruct(ptr);
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

        #region Properties
        /// <summary>
        /// sizeof(CvTrainTestSplit)
        /// </summary>
        public static readonly int SizeOf = MLInvoke.CvTrainTestSplit_sizeof();

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int TrainSamplePart_Count
        {
            get { return MLInvoke.CvTrainTestSplit_train_sample_part_count_get(ptr); }
            set { MLInvoke.CvTrainTestSplit_train_sample_part_count_set(ptr, value); }
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
        public float TrainSamplePart_Portion
        {
            get { return MLInvoke.CvTrainTestSplit_train_sample_part_portion_get(ptr); }
            set { MLInvoke.CvTrainTestSplit_train_sample_part_portion_set(ptr, value); }
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
        public PartMode TrainSamplePartMode
        {
            get { return (PartMode)MLInvoke.CvTrainTestSplit_train_sample_part_mode_get(ptr); }
            set { MLInvoke.CvTrainTestSplit_train_sample_part_mode_set(ptr, (int)value); }
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
            get { return MLInvoke.CvTrainTestSplit_mix_get(ptr); }
            set { MLInvoke.CvTrainTestSplit_mix_set(ptr, value); }
        }
        #endregion
    }
}
