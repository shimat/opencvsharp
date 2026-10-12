using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// Intensity transformations and low-light image enhancement from opencv_contrib.
    /// </summary>
    public static class IntensityTransform
    {
        /// <summary>Applies a logarithmic intensity transformation to an 8-bit grayscale or BGR image.</summary>
        public static void LogTransform(Mat input, Mat output)
        {
            Validate(input, output);
            NativeMethods.HandleException(NativeMethods.intensity_transform_logTransform(input.CvPtr, output.CvPtr));
            GC.KeepAlive(input);
            GC.KeepAlive(output);
        }

        /// <summary>Applies a power-law (gamma) transformation to an 8-bit grayscale or BGR image.</summary>
        public static void GammaCorrection(Mat input, Mat output, float gamma)
        {
            Validate(input, output);
            NativeMethods.HandleException(
                NativeMethods.intensity_transform_gammaCorrection(input.CvPtr, output.CvPtr, gamma));
            GC.KeepAlive(input);
            GC.KeepAlive(output);
        }

        /// <summary>Stretches image intensities to the 0-255 range.</summary>
        public static void Autoscaling(Mat input, Mat output)
        {
            Validate(input, output);
            NativeMethods.HandleException(NativeMethods.intensity_transform_autoscaling(input.CvPtr, output.CvPtr));
            GC.KeepAlive(input);
            GC.KeepAlive(output);
        }

        /// <summary>Applies piecewise-linear contrast stretching to an 8-bit grayscale or BGR image.</summary>
        public static void ContrastStretching(Mat input, Mat output, int r1, int s1, int r2, int s2)
        {
            Validate(input, output);
            NativeMethods.HandleException(
                NativeMethods.intensity_transform_contrastStretching(input.CvPtr, output.CvPtr, r1, s1, r2, s2));
            GC.KeepAlive(input);
            GC.KeepAlive(output);
        }

        /// <summary>Enhances a low-light color image with BIMEF. Requires OpenCV built with Eigen.</summary>
        public static void Bimef(
            InputArray input, OutputArray output,
            float mu = 0.5f, float a = -0.3293f, float b = 1.1258f)
        {
            NativeMethods.HandleException(
                NativeMethods.intensity_transform_bimef1(input.Proxy, output.Proxy, mu, a, b));
            GC.KeepAlive(input.Source);
            GC.KeepAlive(output.Source);
        }

        /// <summary>Enhances a low-light color image with BIMEF using an explicit exposure ratio. Requires OpenCV built with Eigen.</summary>
        public static void Bimef(
            InputArray input, OutputArray output,
            float exposureRatio, float mu, float a, float b)
        {
            NativeMethods.HandleException(
                NativeMethods.intensity_transform_bimef2(
                    input.Proxy, output.Proxy, exposureRatio, mu, a, b));
            GC.KeepAlive(input.Source);
            GC.KeepAlive(output.Source);
        }

        private static void Validate(Mat input, Mat output)
        {
            ArgumentNullException.ThrowIfNull(input);
            ArgumentNullException.ThrowIfNull(output);
            input.ThrowIfDisposed();
            output.ThrowIfDisposed();
        }
    }
}
