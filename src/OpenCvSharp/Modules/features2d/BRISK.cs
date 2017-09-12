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
    // ReSharper disable once InconsistentNaming
    public class BRISK : Feature2D
    {
        private Ptr ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

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
            ptrObj = new Ptr(p);
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
                throw new ArgumentNullException(nameof(radiusList));
            if (numberList == null)
                throw new ArgumentNullException(nameof(numberList));
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

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        #endregion

        #region Methods

        #endregion

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.features2d_Ptr_BRISK_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_BRISK_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
