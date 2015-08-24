using System;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// A simple Hausdorff distance measure between shapes defined by contours
    /// </summary>
    /// <remarks>
    /// according to the paper "Comparing Images using the Hausdorff distance." 
    /// by D.P. Huttenlocher, G.A. Klanderman, and W.J. Rucklidge. (PAMI 1993). :
    /// </remarks>
    public class HausdorffDistanceExtractor : ShapeDistanceExtractor
    {
        private bool disposed;
        private Ptr<HausdorffDistanceExtractor> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected HausdorffDistanceExtractor(IntPtr p)
        {
            ptrObj = new Ptr<HausdorffDistanceExtractor>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Complete constructor
        /// </summary>
        /// <param name="distanceFlag">Flag indicating which norm is used to compute the Hausdorff distance (NORM_L1, NORM_L2).</param>
        /// <param name="rankProp">fractional value (between 0 and 1).</param>
        /// <returns></returns>
        public static HausdorffDistanceExtractor Create(
            DistanceTypes distanceFlag = DistanceTypes.L2, float rankProp = 0.6f)
        {
            IntPtr ptr = NativeMethods.shape_createHausdorffDistanceExtractor(
                (int)distanceFlag, rankProp);
            return new HausdorffDistanceExtractor(ptr);
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
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
                    }
                    // releases unmanaged resources
                    ptr = IntPtr.Zero;
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
        /// Flag indicating which norm is used to compute the Hausdorff distance (NORM_L1, NORM_L2).
        /// </summary>
        public DistanceTypes DistanceFlag 
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return (DistanceTypes)NativeMethods.shape_HausdorffDistanceExtractor_getDistanceFlag(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_HausdorffDistanceExtractor_setDistanceFlag(ptr, (int)value);
            }
        }

        /// <summary>
        /// fractional value (between 0 and 1).
        /// </summary>
        public float RankProportion 
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.shape_HausdorffDistanceExtractor_getRankProportion(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_HausdorffDistanceExtractor_setRankProportion(ptr, value);
            }
        }

        #endregion
    }
}
