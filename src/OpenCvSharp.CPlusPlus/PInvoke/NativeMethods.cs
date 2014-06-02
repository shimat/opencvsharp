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
        public const string DllContrib = "opencv_contrib" + Version;
        public const string DllGpu = "opencv_gpu" + Version;
        public const string DllNonfree = "opencv_nonfree" + Version;
        public const string DllOcl = "opencv_ocl" + Version;
        public const string DllStitching = "opencv_stitching" + Version;
        public const string DllSuperres = "opencv_superres" + Version;
        public const string DllVideoStab = "opencv_videostab" + Version;

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

            // contrib: core, flann, imgproc, highgui, features2d, calib3d, ml, video, objdetect 
            WindowsLibraryLoader.Instance.LoadLibrary(DllContrib, ap);
            // gpu: core, flann, imgproc, features2d, calib3d, video, objdetect
            WindowsLibraryLoader.Instance.LoadLibrary(DllGpu, ap);
            // ocl: core, flann, imgproc, features2d, ml, objdetect
            WindowsLibraryLoader.Instance.LoadLibrary(DllOcl, ap);
            // nonfree: core, flann, imgproc, features2d, ml, objdetect, gpu, ocl
            WindowsLibraryLoader.Instance.LoadLibrary(DllNonfree, ap);
            // stitching: core, flann, imgproc, features, calib3d, objdetect, gpu, nonfree
            WindowsLibraryLoader.Instance.LoadLibrary(DllStitching, ap);
            // superres: core, flann, imgproc, highgui, features2d, ml, video, objdetect, gpu, ocl
            WindowsLibraryLoader.Instance.LoadLibrary(DllSuperres, ap);
            // videostab: core, imgproc, highgui, features2d, video, objdetect, photo, gpu
            WindowsLibraryLoader.Instance.LoadLibrary(DllVideoStab, ap);
            
            // Extern: calib3d, contrib, core, features2d, flann, highgui, imgproc, legacy,
            //         ml, nonfree, objdetect, photo, superres, video, videostab
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