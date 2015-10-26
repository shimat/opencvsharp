using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// The base class for camera response calibration algorithms.
    /// </summary>
    public class CalibrateDebevec : CalibrateCRF
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;
        private Ptr<CalibrateDebevec> ptrObj;

        /// <summary>
        /// Creates instance by raw pointer cv::ml::Boost*
        /// </summary>
        protected CalibrateDebevec(IntPtr p)
            : base()
        {
            ptrObj = new Ptr<CalibrateDebevec>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates the empty model.
        /// </summary>
        /// <param name="samples">number of pixel locations to use</param>
        /// <param name="lambda">smoothness term weight. Greater values produce smoother results, 
        /// but can alter the response.</param>
        /// <param name="random">if true sample pixel locations are chosen at random, 
        /// otherwise the form a rectangular grid.</param>
        /// <returns></returns>
        public static CalibrateDebevec Create(int samples = 70, float lambda = 10.0f, bool random = false)
	    {
            IntPtr ptr = NativeMethods.photo_createCalibrateDebevec(samples, lambda, random ? 1 : 0);
            return new CalibrateDebevec(ptr);
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
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
                    }
                    ptr = IntPtr.Zero;
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
    }
}
