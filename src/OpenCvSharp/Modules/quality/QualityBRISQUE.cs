using System;
using OpenCvSharp.ML;

namespace OpenCvSharp.Quality
{
    /// <summary>
    /// BRISQUE (Blind/Referenceless Image Spatial Quality Evaluator) is a No Reference Image Quality Assessment (NR-IQA) algorithm.
    /// BRISQUE computes a score based on extracting Natural Scene Statistics(https://en.wikipedia.org/wiki/Scene_statistics)
    /// and calculating feature vectors. See Mittal et al. @cite Mittal2 for original paper and original implementation @cite Mittal2_software.
    /// A trained model is provided in the /samples/ directory and is trained on the LIVE-R2 database @cite Sheikh as in the original implementation.
    /// When evaluated against the TID2008 database @cite Ponomarenko, the SROCC is -0.8424 versus the SROCC of -0.8354 in the original implementation.
    /// C++ code for the BRISQUE LIVE-R2 trainer and TID2008 evaluator are also provided in the /samples/ directory.
    /// </summary>
    public class QualityBRISQUE : QualityBase
    {
        private Ptr ptrObj;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected QualityBRISQUE(IntPtr p)
            : base()
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Create an object which calculates quality
        /// </summary>
        /// <param name="modelFilePath">String which contains a path to the BRISQUE model data, eg. /path/to/brisque_model_live.yml</param>
        /// <param name="rangeFilePath">String which contains a path to the BRISQUE range data, eg. /path/to/brisque_range_live.yml</param>
        /// <returns></returns>
        public static QualityBRISQUE Create(string modelFilePath, string rangeFilePath)
        {
            if (string.IsNullOrEmpty(modelFilePath))
                throw new ArgumentNullException(nameof(modelFilePath));
            if (string.IsNullOrEmpty(rangeFilePath))
                throw new ArgumentNullException(nameof(rangeFilePath));

            var ptr = NativeMethods.quality_createQualityBRISQUE1(modelFilePath, rangeFilePath);
            return new QualityBRISQUE(ptr);
        }

        /// <summary>
        /// Create an object which calculates quality
        /// </summary>
        /// <param name="model">cv::ml::SVM* which contains a loaded BRISQUE model</param>
        /// <param name="range">cv::Mat which contains BRISQUE range data</param>
        /// <returns></returns>
        public static QualityBRISQUE Create(SVM model, Mat range)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            if (range == null)
                throw new ArgumentNullException(nameof(range));
            model.ThrowIfDisposed();
            range.ThrowIfDisposed();

            var ptr = NativeMethods.quality_createQualityBRISQUE2(model.CvPtr, range.CvPtr);
            GC.KeepAlive(model);
            GC.KeepAlive(range);
            return new QualityBRISQUE(ptr);
        }

        /// <summary>
        /// static method for computing quality
        /// </summary>
        /// <param name="img">image for which to compute quality</param>
        /// <param name="modelFilePath">String which contains a path to the BRISQUE model data, eg. /path/to/brisque_model_live.yml</param>
        /// <param name="rangeFilePath">cv::String which contains a path to the BRISQUE range data, eg. /path/to/brisque_range_live.yml</param>
        /// <returns>cv::Scalar with the score in the first element.  The score ranges from 0 (best quality) to 100 (worst quality)</returns>
        public static Scalar Compute(InputArray img, string modelFilePath, string rangeFilePath)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (string.IsNullOrEmpty(modelFilePath))
                throw new ArgumentNullException(nameof(modelFilePath));
            if (string.IsNullOrEmpty(rangeFilePath))
                throw new ArgumentNullException(nameof(rangeFilePath));
            img.ThrowIfDisposed();

            var ret = NativeMethods.quality_QualityBRISQUE_staticCompute(img.CvPtr, modelFilePath, rangeFilePath);

            GC.KeepAlive(img);
            return ret;
        }

        /// <summary>
        /// static method for computing image features used by the BRISQUE algorithm
        /// </summary>
        /// <param name="img">image (BGR(A) or grayscale) for which to compute features</param>
        /// <param name="features">output row vector of features to cv::Mat or cv::UMat</param>
        public static void ComputeFeatures(InputArray img, OutputArray features)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (features == null)
                throw new ArgumentNullException(nameof(features));

            NativeMethods.quality_QualityBRISQUE_computeFeatures(img.CvPtr, features.CvPtr);

            GC.KeepAlive(img);
            GC.KeepAlive(features);
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
                var res = NativeMethods.quality_Ptr_QualityBRISQUE_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.quality_Ptr_QualityBRISQUE_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
