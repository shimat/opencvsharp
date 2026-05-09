using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Class providing functions to query CUDA architectures supported by the OpenCV binary.
    /// </summary>
    public static class TargetArchs
    {
        /// <summary>
        /// Checks whether the module was built with the support of the given feature.
        /// </summary>
        public static bool BuiltWith(FeatureSet featureSet)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_TargetArchs_builtWith((int)featureSet, out var ret));
            return ret != 0;
        }

        /// <summary>
        /// Checks whether the module contains intermediate (PTX) or binary CUDA code for the given architecture.
        /// </summary>
        public static bool Has(int major, int minor)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_TargetArchs_has(major, minor, out var ret));
            return ret != 0;
        }

        /// <summary>
        /// Checks whether the module contains binary CUDA code for the given architecture.
        /// </summary>
        public static bool HasBin(int major, int minor)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_TargetArchs_hasBin(major, minor, out var ret));
            return ret != 0;
        }

        /// <summary>
        /// Checks whether the module contains intermediate (PTX) CUDA code for the given architecture.
        /// </summary>
        public static bool HasPtx(int major, int minor)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_TargetArchs_hasPtx(major, minor, out var ret));
            return ret != 0;
        }

        public static bool HasEqualOrGreater(int major, int minor)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_TargetArchs_hasEqualOrGreater(major, minor, out var ret));
            return ret != 0;
        }

        public static bool HasEqualOrGreaterBin(int major, int minor)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_TargetArchs_hasEqualOrGreaterBin(major, minor, out var ret));
            return ret != 0;
        }

        public static bool HasEqualOrGreaterPtx(int major, int minor)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_TargetArchs_hasEqualOrGreaterPtx(major, minor, out var ret));
            return ret != 0;
        }

        public static bool HasEqualOrLessPtx(int major, int minor)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_TargetArchs_hasEqualOrLessPtx(major, minor, out var ret));
            return ret != 0;
        }
    }
}
