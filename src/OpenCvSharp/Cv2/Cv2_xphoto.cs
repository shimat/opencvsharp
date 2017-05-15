using System;
using OpenCvSharp.XPhoto;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    using FeatureDetector = Feature2D;

    static partial class Cv2
    {
        #region WhiteBalance

        public static void ApplyChannelGains(InputArray src, OutputArray dst, float gainB, float gainG, float gainR)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.xphoto_applyChannelGains(src.CvPtr, dst.CvPtr, gainB, gainG, gainR);
            GC.KeepAlive(src);
            dst.Fix();
        }

        public static GrayworldWB CreateGrayworldWB()
        {
            var ptr = NativeMethods.xphoto_createGrayworldWB();
            return new GrayworldWB(ptr);
        }

        public static LearningBasedWB CreateLearningBasedWB(string model)
        {
            var ptr = NativeMethods.xphoto_createLearningBasedWB(model ?? "");
            return new LearningBasedWB(ptr);
        }

        public static SimpleWB CreateSimpleWB()
        {
            var ptr = NativeMethods.xphoto_createSimpleWB();
            return new SimpleWB(ptr);
        }

        #endregion
    }
}
