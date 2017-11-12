using System;

namespace OpenCvSharp
{
    /// <summary>
    /// The base class for camera response calibration algorithms.
    /// </summary>
    public class CalibrateDebevec : CalibrateCRF
    {
        private Ptr ptrObj;

        /// <summary>
        /// Creates instance by raw pointer cv::ml::Boost*
        /// </summary>
        protected CalibrateDebevec(IntPtr p)
            : base()
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates the empty model.
        /// </summary>
        /// <param name="samples">number of pixel locations to use</param>
        /// <param name="lambda">smoothness term weight. Greater values produce smoother results, 
        /// but can alter the response.</param>
        /// <param name="random">if true sample pixel locations are chosen at random, 
        /// otherwise the form a rectangular grid.</param>
        /// <returns></returns>
        public static CalibrateDebevec Create(int samples = 70, float lambda = 10.0f, bool random = false)
        {
            IntPtr ptr = NativeMethods.photo_createCalibrateDebevec(samples, lambda, random ? 1 : 0);
            return new CalibrateDebevec(ptr);
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
                var res = NativeMethods.photo_Ptr_CalibrateDebevec_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.photo_Ptr_CalibrateDebevec_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
