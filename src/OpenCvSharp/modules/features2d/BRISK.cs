using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

#if LANG_JP
    /// <summary>
    /// BRISK 実装
    /// </summary>
#else
    /// <summary>
    /// BRISK implementation
    /// </summary>
#endif
    public class BRISK : Feature2D
    {
        private bool disposed;
        private Ptr<BRISK> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected BRISK()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        protected BRISK(IntPtr p)
            : base()
        {
            ptrObj = new Ptr<BRISK>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thresh"></param>
        /// <param name="octaves"></param>
        /// <param name="patternScale"></param>
        public static BRISK Create(int thresh = 30, int octaves = 3, float patternScale = 1.0f)
        {
            IntPtr p = NativeMethods.features2d_BRISK_create1(thresh, octaves, patternScale);
            return new BRISK(p);
        }

        /// <summary>
        /// custom setup
        /// </summary>
        /// <param name="radiusList"></param>
        /// <param name="numberList"></param>
        /// <param name="dMax"></param>
        /// <param name="dMin"></param>
        /// <param name="indexChange"></param>
        /// <returns></returns>
        public static BRISK Create(
            IEnumerable<float> radiusList, IEnumerable<int> numberList,
            float dMax = 5.85f, float dMin = 8.2f,
            IEnumerable<int> indexChange = null)
        {
            if (radiusList == null)
                throw new ArgumentNullException("radiusList");
            if (numberList == null)
                throw new ArgumentNullException("numberList");
            float[] radiusListArray = EnumerableEx.ToArray(radiusList);
            int[] numberListArray = EnumerableEx.ToArray(numberList);
            int[] indexChangeArray = EnumerableEx.ToArray(indexChange);

            IntPtr p = NativeMethods.features2d_BRISK_create2(
                radiusListArray, radiusListArray.Length,
                numberListArray, numberListArray.Length,
                dMax, dMin,
                indexChangeArray, indexChangeArray.Length);
            return new BRISK(p);
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
        /// Releases the resources
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
                    // releases managed resources
                    if (disposing)
                    {
                        // releases unmanaged resources
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
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

        #region Methods

        #endregion
    }
}
