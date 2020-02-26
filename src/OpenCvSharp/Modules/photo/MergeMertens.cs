using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    public class MergeMertens : MergeExposures
    {
        private Ptr? ptrObj;

        /// <summary>
        /// Creates instance by raw pointer cv::ml::Boost*
        /// </summary>
        protected MergeMertens(IntPtr p)
            : base()
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates the empty model.
        /// </summary>
        /// <returns></returns>
        public static MergeMertens Create()
        {
            var ptr = NativeMethods.photo_createMergeMertens();
            return new MergeMertens(ptr);
        }

        /// <summary>
        /// Short version of process, that doesn't take extra arguments.
        /// </summary>
        /// <param name="src">vector of input images</param>
        /// <param name="dst">result image</param>
        public virtual void Process(IEnumerable<Mat> src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            dst.ThrowIfNotReady();

            var srcArray = EnumerableEx.SelectPtrs(src);

            NativeMethods.photo_MergeMertens_process(ptr, srcArray, srcArray.Length, dst.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(src);
            dst.Fix();
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

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.photo_Ptr_MergeMertens_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.photo_Ptr_MergeMertens_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}