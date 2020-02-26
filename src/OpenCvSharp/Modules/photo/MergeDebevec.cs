using System;

namespace OpenCvSharp
{
    /// <summary>
    /// The base class algorithms that can merge exposure sequence to a single image.
    /// </summary>
    public class MergeDebevec : MergeExposures
    {
        private Ptr? ptrObj;

        /// <summary>
        /// Creates instance by raw pointer cv::ml::Boost*
        /// </summary>
        protected MergeDebevec(IntPtr p)
            : base()
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates the empty model.
        /// </summary>
        /// <returns></returns>
        public static MergeDebevec Create()
        {
            var ptr = NativeMethods.photo_createMergeDebevec();
            return new MergeDebevec(ptr);
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
                var res = NativeMethods.photo_Ptr_MergeDebevec_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.photo_Ptr_MergeDebevec_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}