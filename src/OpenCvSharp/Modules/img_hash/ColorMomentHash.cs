using System;

namespace OpenCvSharp.ImgHash
{
    /// <inheritdoc />
    /// <summary>
    /// Image hash based on color moments.
    /// </summary>
    public class ColorMomentHash : ImgHashBase
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr ptrObj;

        /// <summary>
        /// 
        /// </summary>
        protected ColorMomentHash(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public static ColorMomentHash Create()
        {
            IntPtr p = NativeMethods.img_hash_ColorMomentHash_create();
            return new ColorMomentHash(p);
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        // ReSharper disable once RedundantOverriddenMember
        /// <inheritdoc />
        /// <summary>
        /// Computes color moment hash of the input, the algorithm is come from the paper "Perceptual Hashing for Color Images Using Invariant Moments"
        /// </summary>
        /// <param name="inputArr">input image want to compute hash value, type should be CV_8UC4, CV_8UC3 or CV_8UC1.</param>
        /// <param name="outputArr">42 hash values with type CV_64F(double)</param>
        /// <returns></returns>
        public override void Compute(InputArray inputArr, OutputArray outputArr)
        {
            base.Compute(inputArr, outputArr);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.img_hash_Ptr_ColorMomentHash_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.img_hash_Ptr_ColorMomentHash_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}