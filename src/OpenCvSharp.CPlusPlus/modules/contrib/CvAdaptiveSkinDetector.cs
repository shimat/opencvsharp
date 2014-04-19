using System;

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
        private bool disposed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="samplingDivider"></param>
        /// <param name="morphingMethod"></param>
        public CvAdaptiveSkinDetector(
            int samplingDivider = 1, 
            MorphingMethod morphingMethod = MorphingMethod.None)
        {
            ptr = NativeMethods.contrib_CvAdaptiveSkinDetector_new(samplingDivider, (int)morphingMethod);
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
                        NativeMethods.contrib_CvAdaptiveSkinDetector_delete(ptr);
                    }
                    disposed = true;
                }
                finally
                {
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
            inputBgrImage.ThrowIfDisposed();
            outputHueMask.ThrowIfDisposed();
            NativeMethods.contrib_CvAdaptiveSkinDetector_process(ptr, inputBgrImage.CvPtr, outputHueMask.CvPtr);
        }
    }
}
