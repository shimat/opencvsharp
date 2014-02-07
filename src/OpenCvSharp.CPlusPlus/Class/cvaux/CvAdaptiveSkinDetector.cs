using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.CPlusPlus.Prototype;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public class CvAdaptiveSkinDetector : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// 
        /// </summary>
        public CvAdaptiveSkinDetector()
            : this(1, MorphingMethod.None)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="samplingDivider"></param>
        public CvAdaptiveSkinDetector(int samplingDivider)
            : this(samplingDivider, MorphingMethod.None)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="samplingDivider"></param>
        /// <param name="morphingMethod"></param>
        public CvAdaptiveSkinDetector(int samplingDivider, MorphingMethod morphingMethod)
        {
            ptr = CppInvoke.CvAdaptiveSkinDetector_new(samplingDivider, morphingMethod);
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
                        CppInvoke.CvAdaptiveSkinDetector_delete(ptr);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputBgrImage"></param>
        /// <param name="outputHueMask"></param>
        public virtual void Process(IplImage inputBgrImage, IplImage outputHueMask)
        {
            if (disposed)
                throw new ObjectDisposedException("CvAdaptiveSkinDetector");
            if (inputBgrImage == null)
                throw new ArgumentNullException("inputBgrImage");
            if (outputHueMask == null)
                throw new ArgumentNullException("outputHueMask");
            CppInvoke.CvAdaptiveSkinDetector_process(ptr, inputBgrImage.CvPtr, outputHueMask.CvPtr);
        }
    }
}
