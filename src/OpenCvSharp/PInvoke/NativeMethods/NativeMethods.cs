using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
#if DOTNET_FRAMEWORK
using System.Security;
using System.Security.Permissions;
#endif
using OpenCvSharp.Util;

// ReSharper disable InconsistentNaming
#pragma warning disable 1591

namespace OpenCvSharp
{
    /// <summary>
    /// P/Invoke methods of OpenCV 2.x C++ interface
    /// </summary>
#if DOTNET_FRAMEWORK
    [SuppressUnmanagedCodeSecurity]
#endif
    public static partial class NativeMethods
    {
        public const string DllExtern = "OpenCvSharpExtern";

        //public const string DllFfmpegX86 = "opencv_videoio_ffmpeg430";
        //public const string DllFfmpegX64 = "opencv_videoio_ffmpeg430_64";

        //private const UnmanagedType StringUnmanagedType = UnmanagedType.LPStr;

        private const UnmanagedType StringUnmanagedTypeWindows = UnmanagedType.LPStr;

        private const UnmanagedType StringUnmanagedTypeNotWindows =
#if NET461 || NETSTANDARD2_0
            UnmanagedType.LPStr;
#else
            UnmanagedType.LPUTF8Str;
#endif

        /// <summary>
        /// Is tried P/Invoke once
        /// </summary>
        private static bool tried;

        /// <summary>
        /// Static constructor
        /// </summary>
#if DOTNET_FRAMEWORK
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
#endif
        static NativeMethods()
        {
            LoadLibraries(WindowsLibraryLoader.Instance.AdditionalPaths);

            // call cv to enable redirecting 
            TryPInvoke();
        }

#pragma warning disable CA1801
        public static void HandleException(ExceptionStatus status)
        {
#if DOTNETCORE
            // Check if there has been an exception
            if (status == ExceptionStatus.Occurred /*&& IsUnix()*/) // thrown can be 1 when unix 
            {
                ExceptionHandler.ThrowPossibleException();
            }
#else
#endif
        }
#pragma warning restore CA1801

        /// <summary>
        /// Load DLL files dynamically using Win32 LoadLibrary
        /// </summary>
        /// <param name="additionalPaths"></param>
        public static void LoadLibraries(IEnumerable<string>? additionalPaths = null)
        {
            if (IsUnix())
            {
#if DOTNETCORE
                ExceptionHandler.RegisterExceptionCallback();
#endif
                return;
            }

            var ap = (additionalPaths == null) ? Array.Empty<string>() : additionalPaths.ToArray();

            /*
            if (Environment.Is64BitProcess)
                WindowsLibraryLoader.Instance.LoadLibrary(DllFfmpegX64, ap);
            else
                WindowsLibraryLoader.Instance.LoadLibrary(DllFfmpegX86, ap);
            //*/
            WindowsLibraryLoader.Instance.LoadLibrary(DllExtern, ap);

            // Redirection of error occurred in native library 
            var zero = IntPtr.Zero;
            var current = redirectError(ErrorHandlerThrowException, zero, ref zero);
            GC.KeepAlive(current);
        }

        /// <summary>
        /// Checks whether PInvoke functions can be called
        /// </summary>
        public static void TryPInvoke()
        {
#pragma warning disable CA1031
            if (tried)
                return;
            tried = true;

            try
            {
                var ret = core_Mat_sizeof();
                GC.KeepAlive(ret);
            }
            catch (DllNotFoundException e)
            {
                var exception = PInvokeHelper.CreateException(e);
                try{Console.WriteLine(exception.Message); }
                // ReSharper disable once EmptyGeneralCatchClause
                catch { }
                try{Debug.WriteLine(exception.Message); }
                // ReSharper disable once EmptyGeneralCatchClause
                catch { }
                throw exception;
            }
            catch (BadImageFormatException e)
            {
                var exception = PInvokeHelper.CreateException(e);
                try { Console.WriteLine(exception.Message); }
                // ReSharper disable once EmptyGeneralCatchClause
                catch { }
                try { Debug.WriteLine(exception.Message); }
                // ReSharper disable once EmptyGeneralCatchClause
                catch { }
                throw exception;
            }
            catch (Exception e)
            {
                var ex = e.InnerException ?? e;
                try{ Console.WriteLine(ex.Message); }
                // ReSharper disable once EmptyGeneralCatchClause
                catch { }
                try { Debug.WriteLine(ex.Message); }
                // ReSharper disable once EmptyGeneralCatchClause
                catch { }
                throw;
            }
#pragma warning restore CA1031
        }

        /// <summary>
        /// Returns whether the OS is Windows or not
        /// </summary>
        /// <returns></returns>
        public static bool IsWindows()
        {
#if NET461
            return !IsUnix();
#else
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#endif
        }

        /// <summary>
        /// Returns whether the OS is *nix or not
        /// </summary>
        /// <returns></returns>
        public static bool IsUnix()
        {
#if NET461
            var p = Environment.OSVersion.Platform;
            return (p == PlatformID.Unix ||
                    p == PlatformID.MacOSX ||
                    (int)p == 128);
#elif NETCOREAPP3_1
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || 
                RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD);
#else
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
#endif
        }

        /// <summary>
        /// Returns whether the runtime is Mono or not
        /// </summary>
        /// <returns></returns>
        public static bool IsMono()
        {
            return (Type.GetType("Mono.Runtime") != null);
        }

        /// <summary>
        /// Custom error handler to be thrown by OpenCV
        /// </summary>
        public static readonly CvErrorCallback ErrorHandlerThrowException =
            (status, funcName, errMsg, fileName, line, userData) => throw new OpenCVException(status, funcName, errMsg, fileName, line);

        /// <summary>
        /// Custom error handler to ignore all OpenCV errors
        /// </summary>
        public static readonly CvErrorCallback ErrorHandlerIgnorance =
            (status, funcName, errMsg, fileName, line, userData) => 0;

#pragma warning disable CA2211
        /// <summary>
        /// Default error handler
        /// </summary>
        public static CvErrorCallback? ErrorHandlerDefault = null;
#pragma warning restore CA2211
    }
}