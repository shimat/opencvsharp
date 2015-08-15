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

        private bool disposed;

        /// <summary>
        /// cv::Ptr&lt;BriefDescriptorExtractor&gt;
        /// </summary>
        private Ptr<BriefDescriptorExtractor> ptrObj;

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
            ptrObj = new Ptr<BriefDescriptorExtractor>(ptr);
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
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
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
                        }
                        ptrObj = null;
                        ptr = IntPtr.Zero;
                    }
                    
                    // releases unmanaged resources
                    
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
