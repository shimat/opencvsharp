using System;
using System.Collections.Generic;
using System.Diagnostics;
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
#if DOTNET_FRAMEWORK && !net20
    [SuppressUnmanagedCodeSecurity]
#endif
    public static partial class NativeMethods
    {
        public const string DllExtern = "OpenCvSharpExtern";

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

        // ReSharper disable once StringLiteralTypo
        [Conditional("DOTNETCORE")]
        public static void HandleExceptionIfUnix(int thrown)
        {
#if DOTNETCORE
            // Check if there has been an exception
            if (IsUnix())
            {
                ExceptionHandler.ThrowPossibleException();
            }
#endif
        }

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

            var ap = (additionalPaths == null) ? new string[0] : EnumerableEx.ToArray(additionalPaths);

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
            if (tried)
                return;
            tried = true;

            try
            {
                core_Mat_sizeof();
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
        }

        /// <summary>
        /// Returns whether the OS is Windows or not
        /// </summary>
        /// <returns></returns>
        public static bool IsWindows()
        {
            return !IsUnix();
        }

        /// <summary>
        /// Returns whether the OS is *nix or not
        /// </summary>
        /// <returns></returns>
        public static bool IsUnix()
        {
#if DOTNET_FRAMEWORK
            var p = Environment.OSVersion.Platform;
            return (p == PlatformID.Unix ||
                    p == PlatformID.MacOSX ||
                    (int)p == 128);
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
            (status, funcName, errMsg, fileName, line, userdata) =>
            {
                try
                {
                    //cvSetErrStatus(CvStatus.StsOk);
                    return 0;
                }
                finally
                {
                    throw new OpenCVException(status, funcName, errMsg, fileName, line);
                }
            };

        /// <summary>
        /// Custom error handler to ignore all OpenCV errors
        /// </summary>
        public static readonly CvErrorCallback ErrorHandlerIgnorance =
            (status, funcName, errMsg, fileName, line, userData) => 0;

        /// <summary>
        /// Default error handler
        /// </summary>
        public static CvErrorCallback? ErrorHandlerDefault;
    }
}