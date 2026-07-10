using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// cv::videoio_registry functions.
    /// This section contains API description how to query/configure available Video I/O backends.
    /// </summary>
    public static partial class VideoIO
    {
        /// <summary>
        /// Returns backend API name or "UnknownVideoAPI(xxx)"
        /// </summary>
        /// <param name="api">backend ID (VideoCaptureAPIs)</param>
        /// <returns></returns>
        public static string GetBackendName(VideoCaptureAPIs api)
        {
            using var returnString = new StdString();
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_getBackendName((int)api, returnString.CvPtr));
            return returnString.ToString();
        }

        /// <summary>
        /// Returns list of all available backends
        /// </summary>
        /// <returns></returns>
        public static VideoCaptureAPIs[] GetBackends()
        {
            using var vec = new StdVector<int>();
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_getBackends(vec.CvPtr));
            return Array.ConvertAll(vec.ToArray(), v => (VideoCaptureAPIs)v);
        }

        /// <summary>
        /// Returns list of available backends which works via VideoCapture(int index)
        /// </summary>
        /// <returns></returns>
        public static VideoCaptureAPIs[] GetCameraBackends()
        {
            using var vec = new StdVector<int>();
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_getCameraBackends(vec.CvPtr));
            return Array.ConvertAll(vec.ToArray(), v => (VideoCaptureAPIs)v);
        }

        /// <summary>
        /// Returns list of available backends which works via VideoCapture(filename)
        /// </summary>
        /// <returns></returns>
        public static VideoCaptureAPIs[] GetStreamBackends()
        {
            using var vec = new StdVector<int>();
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_getStreamBackends(vec.CvPtr));
            return Array.ConvertAll(vec.ToArray(), v => (VideoCaptureAPIs)v);
        }

        /// <summary>
        /// Returns list of available backends which works via VideoCapture(buffer)
        /// </summary>
        /// <returns></returns>
        public static VideoCaptureAPIs[] GetStreamBufferedBackends()
        {
            using var vec = new StdVector<int>();
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_getStreamBufferedBackends(vec.CvPtr));
            return Array.ConvertAll(vec.ToArray(), v => (VideoCaptureAPIs)v);
        }

        /// <summary>
        /// Returns list of available backends which works via VideoWriter()
        /// </summary>
        /// <returns></returns>
        public static VideoCaptureAPIs[] GetWriterBackends()
        {
            using var vec = new StdVector<int>();
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_getWriterBackends(vec.CvPtr));
            return Array.ConvertAll(vec.ToArray(), v => (VideoCaptureAPIs)v);
        }

        /// <summary>
        /// Returns true if backend is available
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        public static bool HasBackend(VideoCaptureAPIs api)
        {
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_hasBackend((int)api, out var ret));
            return ret != 0;
        }

        /// <summary>
        /// Returns true if backend is built in (false if backend is used as plugin)
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        public static bool IsBackendBuiltIn(VideoCaptureAPIs api)
        {
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_isBackendBuiltIn((int)api, out var ret));
            return ret != 0;
        }

        /// <summary>
        /// Returns description and ABI/API version of videoio plugin's camera interface
        /// </summary>
        /// <param name="api"></param>
        /// <param name="versionAbi"></param>
        /// <param name="versionApi"></param>
        /// <returns></returns>
        public static string GetCameraBackendPluginVersion(VideoCaptureAPIs api, out int versionAbi, out int versionApi)
        {
            using var returnString = new StdString();
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_getCameraBackendPluginVersion(
                    (int)api, out versionAbi, out versionApi, returnString.CvPtr));
            return returnString.ToString();
        }

        /// <summary>
        /// Returns description and ABI/API version of videoio plugin's stream capture interface
        /// </summary>
        /// <param name="api"></param>
        /// <param name="versionAbi"></param>
        /// <param name="versionApi"></param>
        /// <returns></returns>
        public static string GetStreamBackendPluginVersion(VideoCaptureAPIs api, out int versionAbi, out int versionApi)
        {
            using var returnString = new StdString();
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_getStreamBackendPluginVersion(
                    (int)api, out versionAbi, out versionApi, returnString.CvPtr));
            return returnString.ToString();
        }

        /// <summary>
        /// Returns description and ABI/API version of videoio plugin's buffer capture interface
        /// </summary>
        /// <param name="api"></param>
        /// <param name="versionAbi"></param>
        /// <param name="versionApi"></param>
        /// <returns></returns>
        public static string GetStreamBufferedBackendPluginVersion(VideoCaptureAPIs api, out int versionAbi, out int versionApi)
        {
            using var returnString = new StdString();
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_getStreamBufferedBackendPluginVersion(
                    (int)api, out versionAbi, out versionApi, returnString.CvPtr));
            return returnString.ToString();
        }

        /// <summary>
        /// Returns description and ABI/API version of videoio plugin's writer interface
        /// </summary>
        /// <param name="api"></param>
        /// <param name="versionAbi"></param>
        /// <param name="versionApi"></param>
        /// <returns></returns>
        public static string GetWriterBackendPluginVersion(VideoCaptureAPIs api, out int versionAbi, out int versionApi)
        {
            using var returnString = new StdString();
            NativeMethods.HandleException(
                NativeMethods.videoio_registry_getWriterBackendPluginVersion(
                    (int)api, out versionAbi, out versionApi, returnString.CvPtr));
            return returnString.ToString();
        }
    }
}
