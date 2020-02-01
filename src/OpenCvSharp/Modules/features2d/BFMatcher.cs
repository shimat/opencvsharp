﻿using System;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// Brute-force descriptor matcher.
    /// For each descriptor in the first set, this matcher finds the closest descriptor in the second set by trying each one.
    /// </summary>
    public class BFMatcher : DescriptorMatcher
    {
        private Ptr? detectorPtr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="normType"></param>
        /// <param name="crossCheck"></param>
        public BFMatcher(NormTypes normType = NormTypes.L2, bool crossCheck = false)
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_BFMatcher_new((int) normType, crossCheck ? 1 : 0, out ptr));
            detectorPtr = null;
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;T&gt;
        /// </summary>
        internal BFMatcher(Ptr detectorPtr)
        {
            this.detectorPtr = detectorPtr;
            ptr = detectorPtr.Get();
        }

        /// <summary>
        /// Creates instance by raw pointer T*
        /// </summary>
        internal BFMatcher(IntPtr rawPtr)
        {
            detectorPtr = null;
            ptr = rawPtr;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal new static BFMatcher FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<BFMatcher> pointer");
            var ptrObj = new Ptr(ptr);
            return new BFMatcher(ptrObj);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            if (detectorPtr != null)
            {
                detectorPtr.Dispose();
                detectorPtr = null;
                ptr = IntPtr.Zero;
            }
            base.DisposeManaged();
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            if (detectorPtr == null && ptr != IntPtr.Zero)
                NativeMethods.HandleException(
                    NativeMethods.features2d_BFMatcher_delete(ptr));
            ptr = IntPtr.Zero;
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// Return true if the matcher supports mask in match methods.
        /// </summary>
        /// <returns></returns>
        public override bool IsMaskSupported()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_BFMatcher_isMaskSupported(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                NativeMethods.HandleException(
                    NativeMethods.features2d_Ptr_BFMatcher_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.features2d_Ptr_BFMatcher_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
