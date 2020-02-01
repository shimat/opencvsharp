﻿using System;

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
        private Ptr? ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected HausdorffDistanceExtractor(IntPtr p)
        {
            ptrObj = new Ptr(p);
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
            NativeMethods.HandleException(
                NativeMethods.shape_createHausdorffDistanceExtractor(
                    (int) distanceFlag, rankProp, out var ret));
            return new HausdorffDistanceExtractor(ret);
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

        #region Properties

        /// <summary>
        /// Flag indicating which norm is used to compute the Hausdorff distance (NORM_L1, NORM_L2).
        /// </summary>
        public DistanceTypes DistanceFlag 
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.shape_HausdorffDistanceExtractor_getDistanceFlag(ptr, out var ret));
                GC.KeepAlive(this);
                return (DistanceTypes)ret;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.shape_HausdorffDistanceExtractor_setDistanceFlag(ptr, (int) value));
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// fractional value (between 0 and 1).
        /// </summary>
        public float RankProportion 
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.shape_HausdorffDistanceExtractor_getRankProportion(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.shape_HausdorffDistanceExtractor_setRankProportion(ptr, value));
                GC.KeepAlive(this);
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
                NativeMethods.HandleException(
                    NativeMethods.shape_Ptr_HausdorffDistanceExtractor_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.shape_Ptr_HausdorffDistanceExtractor_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
