using System;

namespace OpenCvSharp.Face
{
    /// <inheritdoc />
    /// <summary>
    /// Training and prediction must be done on grayscale images, use cvtColor to convert between the color spaces.
    /// -   **THE FISHERFACES METHOD MAKES THE ASSUMPTION, THAT THE TRAINING AND TEST IMAGES ARE OF EQUAL SIZE.
    ///     ** (caps-lock, because I got so many mails asking for this). You have to make sure your input data 
    ///       has the correct shape, else a meaningful exception is thrown.Use resize to resize the images.
    /// -   This model does not support updating.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class FisherFaceRecognizer : BasicFaceRecognizer
    {
        /// <summary>
        ///
        /// </summary>
        private Ptr recognizerPtr;

        /// <inheritdoc />
        ///  <summary>
        ///  </summary>
        protected FisherFaceRecognizer()
        {
            recognizerPtr = null;
            ptr = IntPtr.Zero;
        }
        
        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            recognizerPtr?.Dispose();
            recognizerPtr = null;
            base.DisposeManaged();
        }

        /// <summary>
        /// Training and prediction must be done on grayscale images, use cvtColor to convert between the color spaces.
        /// -   **THE FISHERFACES METHOD MAKES THE ASSUMPTION, THAT THE TRAINING AND TEST IMAGES ARE OF EQUAL SIZE.
        ///     ** (caps-lock, because I got so many mails asking for this). You have to make sure your input data 
        ///       has the correct shape, else a meaningful exception is thrown.Use resize to resize the images.
        /// -   This model does not support updating.
        /// </summary>
        /// <param name="numComponents">The number of components (read: Fisherfaces) kept for this Linear Discriminant Analysis 
        /// with the Fisherfaces criterion. It's useful to keep all components, that means the number of your classes c 
        /// (read: subjects, persons you want to recognize). If you leave this at the default (0) or set it 
        /// to a value less-equal 0 or greater (c-1), it will be set to the correct number (c-1) automatically.</param>
        /// <param name="threshold">The threshold applied in the prediction. If the distance to the nearest neighbor 
        /// is larger than the threshold, this method returns -1.</param>
        /// <returns></returns>
        public static FisherFaceRecognizer Create(int numComponents = 0, double threshold = Double.MaxValue)
        {
            IntPtr p = NativeMethods.face_FisherFaceRecognizer_create(numComponents, threshold);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(FisherFaceRecognizer)}> pointer");
            var ptrObj = new Ptr(p);
            var detector = new FisherFaceRecognizer
            {
                recognizerPtr = ptrObj,
                ptr = ptrObj.Get()
            };
            return detector;
        }
        
        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.face_Ptr_FisherFaceRecognizer_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.face_Ptr_FisherFaceRecognizer_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}