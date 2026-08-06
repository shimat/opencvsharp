using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// cv::ocl functions.
    /// </summary>
    public static partial class Ocl
    {
        /// <summary>
        /// Returns whether an OpenCL runtime with at least one platform is available.
        /// </summary>
        public static bool HaveOpenCL()
        {
            NativeMethods.HandleException(
                NativeMethods.core_ocl_haveOpenCL(out var returnValue));
            return returnValue != 0;
        }

        /// <summary>
        /// Returns whether OpenCL is currently enabled for the calling thread.
        /// </summary>
        public static bool UseOpenCL()
        {
            NativeMethods.HandleException(
                NativeMethods.core_ocl_useOpenCL(out var returnValue));
            return returnValue != 0;
        }

        /// <summary>
        /// Enables or disables OpenCL use for the calling thread.
        /// </summary>
        /// <param name="flag">True to enable OpenCL when a suitable runtime and device are available; otherwise, false.</param>
        public static void SetUseOpenCL(bool flag)
        {
            NativeMethods.HandleException(
                NativeMethods.core_ocl_setUseOpenCL(flag ? 1 : 0));
        }

        /// <summary>
        /// Waits for all queued OpenCL operations in the current default queue to complete.
        /// </summary>
        /// <remarks>
        /// This method blocks the calling thread and is primarily useful at synchronization boundaries and when measuring OpenCL execution time.
        /// Calling it after every operation can reduce performance by preventing asynchronous execution.
        /// </remarks>
        public static void Finish()
        {
            NativeMethods.HandleException(
                NativeMethods.core_ocl_finish());
        }

        /// <summary>
        /// Returns snapshots of the available OpenCL platforms and their devices.
        /// </summary>
        /// <remarks>
        /// Returns an empty list when no OpenCL runtime is available. The returned objects do not own native OpenCL handles.
        /// </remarks>
        public static IReadOnlyList<OclPlatformInfo> GetPlatformsInfo()
        {
            if (!HaveOpenCL())
                return Array.Empty<OclPlatformInfo>();

            NativeMethods.HandleException(
                NativeMethods.core_ocl_getPlatformsInfo(out var nativePointer));
            using var nativePlatforms = new OclPlatformInfoVector(nativePointer);

            NativeMethods.HandleException(
                NativeMethods.core_ocl_PlatformInfoVector_size(
                    nativePlatforms.Handle,
                    out var platformCount));

            var platforms = new OclPlatformInfo[platformCount];
            for (var platformIndex = 0; platformIndex < platformCount; platformIndex++)
            {
                platforms[platformIndex] = ReadPlatform(nativePlatforms, platformIndex);
            }
            return Array.AsReadOnly(platforms);
        }

        private static OclPlatformInfo ReadPlatform(OclPlatformInfoVector nativePlatforms, int platformIndex)
        {
            using var name = new StdString();
            using var vendor = new StdString();
            using var version = new StdString();
            NativeMethods.HandleException(
                NativeMethods.core_ocl_PlatformInfoVector_getPlatform(
                    nativePlatforms.Handle,
                    platformIndex,
                    name.CvPtr,
                    vendor.CvPtr,
                    version.CvPtr,
                    out var versionMajor,
                    out var versionMinor,
                    out var deviceCount));

            var devices = new OclDeviceInfo[deviceCount];
            for (var deviceIndex = 0; deviceIndex < deviceCount; deviceIndex++)
            {
                devices[deviceIndex] = ReadDevice(nativePlatforms, platformIndex, deviceIndex);
            }

            return new OclPlatformInfo(
                name.ToString(),
                vendor.ToString(),
                version.ToString(),
                versionMajor,
                versionMinor,
                Array.AsReadOnly(devices));
        }

        private static OclDeviceInfo ReadDevice(
            OclPlatformInfoVector nativePlatforms,
            int platformIndex,
            int deviceIndex)
        {
            using var name = new StdString();
            using var vendorName = new StdString();
            using var version = new StdString();
            using var openCLVersion = new StdString();
            using var openCLCVersion = new StdString();
            using var driverVersion = new StdString();
            NativeMethods.HandleException(
                NativeMethods.core_ocl_PlatformInfoVector_getDevice(
                    nativePlatforms.Handle,
                    platformIndex,
                    deviceIndex,
                    name.CvPtr,
                    vendorName.CvPtr,
                    version.CvPtr,
                    openCLVersion.CvPtr,
                    openCLCVersion.CvPtr,
                    driverVersion.CvPtr,
                    out var type,
                    out var addressBits,
                    out var available,
                    out var compilerAvailable,
                    out var linkerAvailable,
                    out var maxClockFrequency,
                    out var maxComputeUnits,
                    out var globalMemorySize,
                    out var localMemorySize,
                    out var hostUnifiedMemory,
                    out var imageSupport));

            return new OclDeviceInfo(
                name.ToString(),
                vendorName.ToString(),
                version.ToString(),
                openCLVersion.ToString(),
                openCLCVersion.ToString(),
                driverVersion.ToString(),
                (OclDeviceTypes) type,
                addressBits,
                available != 0,
                compilerAvailable != 0,
                linkerAvailable != 0,
                maxClockFrequency,
                maxComputeUnits,
                globalMemorySize,
                localMemorySize,
                hostUnifiedMemory != 0,
                imageSupport != 0);
        }

        private sealed class OclPlatformInfoVector : CvObject
        {
            public OclPlatformInfoVector(IntPtr ptr)
            {
                SetSafeHandle(new OpenCvPtrSafeHandle(
                    ptr,
                    ownsHandle: true,
                    releaseAction: static p => NativeMethods.HandleException(
                        NativeMethods.core_ocl_PlatformInfoVector_delete(p))));
            }
        }
    }
}
