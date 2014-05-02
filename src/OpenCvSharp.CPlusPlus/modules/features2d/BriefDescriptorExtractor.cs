using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
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
        /// cv::Ptr&lt;DescriptorExtractor&gt;
        /// </summary>
        private Ptr<BriefDescriptorExtractor> extractorPtr;

        /// <summary>
        /// bytes is a length of descriptor in bytes. It can be equal 16, 32 or 64 bytes.
        /// </summary>
        /// <param name="bytes"></param>
        public BriefDescriptorExtractor(int bytes = 32)
        {
            ptr = NativeMethods.features2d_BriefDescriptorExtractor_new(bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        internal BriefDescriptorExtractor(Ptr<BriefDescriptorExtractor> extractorPtr, IntPtr ptr)
        {
            this.extractorPtr = null;
            this.ptr = IntPtr.Zero;
        }
        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal new static BriefDescriptorExtractor FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid BriefDescriptorExtractor pointer");

            var ptrObj = new Ptr<BriefDescriptorExtractor>(ptr);
            var extractor = new BriefDescriptorExtractor(ptrObj,ptrObj.Obj);
            return extractor;
        }
        /// <summary>
        /// Creates instance from raw T*
        /// </summary>
        /// <param name="ptr"></param>
        internal new static BriefDescriptorExtractor FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid BriefDescriptorExtractor pointer");
            var extractor = new BriefDescriptorExtractor(null, ptr);
            return extractor;
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
                    }
                    // releases unmanaged resources
                    if (IsEnabledDispose)
                    {
                        if (extractorPtr != null)
                        {
                            extractorPtr.Dispose();
                        }
                        else
                        {
                            NativeMethods.features2d_BriefDescriptorExtractor_delete(ptr);
                        }
                        extractorPtr = null;
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get { return NativeMethods.features2d_BriefDescriptorExtractor_info(ptr); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int DescriptorSize()
        {
            if (disposed)
                throw new ObjectDisposedException("BriefDescriptorExtractor");
            return NativeMethods.features2d_BriefDescriptorExtractor_descriptorSize(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int DescriptorType()
        {
            if (disposed)
                throw new ObjectDisposedException("BriefDescriptorExtractor");
            return NativeMethods.features2d_BriefDescriptorExtractor_descriptorType(ptr);
        }
    }
}
