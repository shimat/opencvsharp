using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;
using OpenCvSharp;
using OpenCvSharp.Utilities;

// ReSharper disable InconsistentNaming
#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// P/Invoke methods of OpenCV 2.x C++ interface
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    public static partial class NativeMethods
    {
        /// <summary>
        /// Is tried P/Invoke once
        /// </summary>
        private static bool tried = false;

        /// <summary>
        /// DLL file name
        /// </summary>
        public const string DllExtern = "OpenCvSharpExtern";

        public const string Version = OpenCvSharp.NativeMethods.Version;

        private static readonly string[] DllNames =
        {
            "opencv_world",
            /*
            "opencv_cudacodec", // core
            "opencv_cudaarithm", // core
            "opencv_cudalegacy", // objdetect
            "opencv_cudawarping", // cudalegacy
            "opencv_cuda", // cudaarithm, cudalegacy, cudawarping
            "opencv_cudafilters", // cudaarithm
            "opencv_cudafeatures2d", // cudafilters
            "opencv_cudaoptflow", // cudaimgproc, cudalegacy, cudawarping
            "opencv_stitching", // core, flann, imgproc, features, calib3d, objdetect, gpu, cudawarping
            "opencv_superres", // core, flann, imgproc, highgui, features2d, ml, video, objdetect, gpu, ocl
            "opencv_videostab", // videostab: core, imgproc, highgui, features2d, video, objdetect, photo, gpu
            "opencv_bgsegm",
            "opencv_face",
            "opencv_optflow",
            "opencv_xfeatures2d",*/
        };

        /// <summary>
        /// Static constructor
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        static NativeMethods()
        {
            LoadLibraries();

            // call cv to enable redirecting 
            TryPInvoke();
        }

        /// <summary>
        /// Load DLL files dynamically using Win32 LoadLibrary
        /// </summary>
        /// <param name="additionalPaths"></param>
        public static void LoadLibraries(IEnumerable<string> additionalPaths = null)
        {
            if (OpenCvSharp.NativeMethods.IsUnix())
                return;

            string[] ap = EnumerableEx.ToArray(additionalPaths);

            OpenCvSharp.NativeMethods.LoadLibraries(ap);

            foreach (string dll in DllNames)
            {
                WindowsLibraryLoader.Instance.LoadLibrary(dll + Version, ap);
            }

            // calib3d, contrib, core, features2d, flann, highgui, imgproc, legacy,
            // ml, nonfree, objdetect, photo, superres, video, videostab
            WindowsLibraryLoader.Instance.LoadLibrary(DllExtern, ap);
        }

        /// <summary>
        /// Checks whether PInvoke functions can be called
        /// </summary>
        private static void TryPInvoke()
        {
            if (tried)
                return;
            tried = true;

            try
            {
                Cv.GetTickCount();
                core_Mat_sizeof();
            }
            catch (DllNotFoundException e)
            {
                var exception = PInvokeHelper.CreateException(e);
                try{Console.WriteLine(exception.Message);}
                catch{}
                try{Debug.WriteLine(exception.Message);}
                catch{}
                throw exception;
            }
            catch (BadImageFormatException e)
            {
                var exception = PInvokeHelper.CreateException(e);
                try { Console.WriteLine(exception.Message); }
                catch { }
                try { Debug.WriteLine(exception.Message); }
                catch { }
                throw exception;
            }
            catch (Exception e)
            {
                Exception ex = e.InnerException ?? e;
                try{ Console.WriteLine(ex.Message); }
                catch{}
                try{ Debug.WriteLine(ex.Message); }
                catch{}
                throw;
            }
        }
    }
}