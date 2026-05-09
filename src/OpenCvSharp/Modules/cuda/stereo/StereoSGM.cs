#if ENABLED_CUDA
using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// The class implements the Semi-Global Matching algorithm.
    /// </summary>
    public class StereoSGM : OpenCvSharp.Cuda.StereoMatcher
    {
        protected StereoSGM(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_StereoSGM_delete(p)))
        {
        }

        /// <summary>
        /// Creates StereoSGM object.
        /// </summary>
        /// <param name="minDisparity">Minimum possible disparity value.</param>
        /// <param name="numDisparities">Maximum disparity minus minimum disparity. This parameter must be divisible by 16.</param>
        /// <param name="P1">The first parameter controlling the disparity smoothness. Typically 10.</param>
        /// <param name="P2">The second parameter controlling the disparity smoothness. Typically 120.</param>
        /// <param name="uniquenessRatio">Margin in percentage by which the best (minimum) computed cost function value should "win" the second best value to consider the found match correct. Range 5-15.</param>
        /// <param name="mode">Algorithm mode (HH or HH4).</param>
        /// <returns></returns>
        public static StereoSGM Create(
            int minDisparity = 0, int numDisparities = 128, int P1 = 10, int P2 = 120,
            int uniquenessRatio = 5, StereoSGMMode mode = StereoSGMMode.HH4)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_createStereoSGM(
                    minDisparity, numDisparities, P1, P2, uniquenessRatio, (int)mode, out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_StereoSGM_get(smartPtr, out var rawPtr));

            return new StereoSGM(smartPtr, rawPtr);
        }
    }
}
#endif
