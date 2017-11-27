using System;

namespace OpenCvSharp.XFeatures2D
{
    using DescriptorExtractor = Feature2D;

    /// <summary>
    /// BRIEF Descriptor
    /// </summary>
    public class BriefDescriptorExtractor : DescriptorExtractor
    {
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
        public const int PATCH_SIZE = 48;
        public const int KERNEL_SIZE = 9;
// ReSharper restore InconsistentNaming
#pragma warning restore 1591

        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

        /// <summary>
        /// 
        /// </summary>
        protected BriefDescriptorExtractor()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        protected BriefDescriptorExtractor(IntPtr ptr)
        {
            ptrObj = new Ptr(ptr);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// bytes is a length of descriptor in bytes. It can be equal 16, 32 or 64 bytes.
        /// </summary>
        /// <param name="bytes"></param>
        public static BriefDescriptorExtractor Create(int bytes = 32)
        {
            IntPtr p = NativeMethods.xfeatures2d_BriefDescriptorExtractor_create(bytes);
            return new BriefDescriptorExtractor(p);
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
                var res =  NativeMethods.xfeatures2d_Ptr_BriefDescriptorExtractor_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.xfeatures2d_Ptr_BriefDescriptorExtractor_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
