using OpenCvSharp.ImgHash;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// cv::img_hash functions.
    /// </summary>
    public static partial class ImgHash
    {
        /// <summary>
        /// Computes the average hash of an image.
        /// </summary>
        public static void AverageHash(InputArray input, OutputArray output)
        {
            NativeMethods.HandleException(NativeMethods.img_hash_averageHash(input.Proxy, output.Proxy));
            GC.KeepAlive(input.Source);
            GC.KeepAlive(output.Source);
        }

        /// <summary>
        /// Computes the block mean hash of an image.
        /// </summary>
        public static void BlockMeanHash(
            InputArray input, OutputArray output, BlockMeanHashMode mode = BlockMeanHashMode.Mode0)
        {
            NativeMethods.HandleException(
                NativeMethods.img_hash_blockMeanHash(input.Proxy, output.Proxy, (int)mode));
            GC.KeepAlive(input.Source);
            GC.KeepAlive(output.Source);
        }

        /// <summary>
        /// Computes the color moment hash of an image.
        /// </summary>
        public static void ColorMomentHash(InputArray input, OutputArray output)
        {
            NativeMethods.HandleException(NativeMethods.img_hash_colorMomentHash(input.Proxy, output.Proxy));
            GC.KeepAlive(input.Source);
            GC.KeepAlive(output.Source);
        }

        /// <summary>
        /// Computes the Marr-Hildreth hash of an image.
        /// </summary>
        public static void MarrHildrethHash(
            InputArray input, OutputArray output, float alpha = 2.0f, float scale = 1.0f)
        {
            NativeMethods.HandleException(
                NativeMethods.img_hash_marrHildrethHash(input.Proxy, output.Proxy, alpha, scale));
            GC.KeepAlive(input.Source);
            GC.KeepAlive(output.Source);
        }

        /// <summary>
        /// Computes the perceptual hash of an image.
        /// </summary>
        public static void PHash(InputArray input, OutputArray output)
        {
            NativeMethods.HandleException(NativeMethods.img_hash_pHash(input.Proxy, output.Proxy));
            GC.KeepAlive(input.Source);
            GC.KeepAlive(output.Source);
        }

        /// <summary>
        /// Computes the radial variance hash of an image.
        /// </summary>
        public static void RadialVarianceHash(
            InputArray input, OutputArray output, double sigma = 1, int numOfAngleLine = 180)
        {
            NativeMethods.HandleException(
                NativeMethods.img_hash_radialVarianceHash(
                    input.Proxy, output.Proxy, sigma, numOfAngleLine));
            GC.KeepAlive(input.Source);
            GC.KeepAlive(output.Source);
        }
    }
}
