using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>Fuzzy transform image processing from opencv_contrib.</summary>
    public static class Fuzzy
    {
        /// <summary>Creates a 32-bit floating point kernel from a linear basic function.</summary>
        public static void CreateKernel(FuzzyFunction function, int radius, OutputArray kernel, int channels)
        {
            ValidateFunction(function);
            ValidateRadius(radius);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(channels);
            NativeMethods.HandleException(NativeMethods.fuzzy_createKernel(
                (int)function, radius, kernel.Proxy, channels));
            GC.KeepAlive(kernel.Source);
        }

        /// <summary>Creates a kernel from horizontal and vertical basic functions.</summary>
        public static void CreateKernel(InputArray horizontal, InputArray vertical, OutputArray kernel, int channels)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(channels);
            NativeMethods.HandleException(NativeMethods.fuzzy_createKernelFromFunctions(
                horizontal.Proxy, vertical.Proxy, kernel.Proxy, channels));
            GC.KeepAlive(horizontal.Source);
            GC.KeepAlive(vertical.Source);
            GC.KeepAlive(kernel.Source);
        }

        /// <summary>Filters an image with a fuzzy transform kernel. The output is 32-bit floating point.</summary>
        public static void Filter(InputArray image, InputArray kernel, OutputArray output)
        {
            NativeMethods.HandleException(NativeMethods.fuzzy_filter(image.Proxy, kernel.Proxy, output.Proxy));
            GC.KeepAlive(image.Source);
            GC.KeepAlive(kernel.Source);
            GC.KeepAlive(output.Source);
        }

        /// <summary>Inpaints an image from the unmasked pixels. The output is 32-bit floating point.</summary>
        public static void Inpaint(
            InputArray image, InputArray mask, OutputArray output, int radius,
            FuzzyFunction function = FuzzyFunction.Linear,
            FuzzyInpaintAlgorithm algorithm = FuzzyInpaintAlgorithm.OneStep)
        {
            ValidateFunction(function);
            ValidateRadius(radius);
            if (!Enum.IsDefined(algorithm))
                throw new ArgumentOutOfRangeException(nameof(algorithm));
            NativeMethods.HandleException(NativeMethods.fuzzy_inpaint(
                image.Proxy, mask.Proxy, output.Proxy, radius, (int)function, (int)algorithm));
            GC.KeepAlive(image.Source);
            GC.KeepAlive(mask.Source);
            GC.KeepAlive(output.Source);
        }

        /// <summary>Applies the zero-degree fuzzy transform and its inverse in one step.</summary>
        public static void Ft02DProcess(
            InputArray image, InputArray kernel, OutputArray output, InputArray mask = default)
        {
            NativeMethods.HandleException(NativeMethods.fuzzy_ft02dProcess(
                image.Proxy, kernel.Proxy, output.Proxy, mask.Proxy));
            GC.KeepAlive(image.Source);
            GC.KeepAlive(kernel.Source);
            GC.KeepAlive(output.Source);
            GC.KeepAlive(mask.Source);
        }

        /// <summary>Applies the first-degree fuzzy transform and its inverse in one step.</summary>
        public static void Ft12DProcess(
            InputArray image, InputArray kernel, OutputArray output, InputArray mask = default)
        {
            NativeMethods.HandleException(NativeMethods.fuzzy_ft12dProcess(
                image.Proxy, kernel.Proxy, output.Proxy, mask.Proxy));
            GC.KeepAlive(image.Source);
            GC.KeepAlive(kernel.Source);
            GC.KeepAlive(output.Source);
            GC.KeepAlive(mask.Source);
        }

        /// <summary>Applies an optimized zero-degree linear transform to a three-channel image.</summary>
        public static void Ft02DFastLinearProcess(InputArray image, int radius, OutputArray output)
        {
            ValidateRadius(radius);
            NativeMethods.HandleException(NativeMethods.fuzzy_ft02dFastLinearProcess(
                image.Proxy, radius, output.Proxy));
            GC.KeepAlive(image.Source);
            GC.KeepAlive(output.Source);
        }

        /// <summary>Applies a more accurate floating point optimized zero-degree linear transform.</summary>
        public static void Ft02DFastLinearProcessFloat(InputArray image, int radius, OutputArray output)
        {
            ValidateRadius(radius);
            NativeMethods.HandleException(NativeMethods.fuzzy_ft02dFastLinearProcessFloat(
                image.Proxy, radius, output.Proxy));
            GC.KeepAlive(image.Source);
            GC.KeepAlive(output.Source);
        }

        private static void ValidateRadius(int radius)
            => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(radius);

        private static void ValidateFunction(FuzzyFunction function)
        {
            if (function != FuzzyFunction.Linear)
                throw new ArgumentOutOfRangeException(nameof(function), "Only the linear basic function is implemented by OpenCV.");
        }
    }
}
