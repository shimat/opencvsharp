/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using OpenCvSharp;
using OpenCvSharp.Utilities;


namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// P/Invoke methods of OpenCV 2.x C++ interface
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static partial class NativeMethods
    {
        /// <summary>
        /// DLL file name
        /// </summary>
        public const string DllExtern = "OpenCvSharpExtern";


        /// <summary>
        /// Static constructor
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        static NativeMethods()
        {
            // call cv to enable redirecting 
            TryPInvoke();
        }

#if LANG_JP
        /// <summary>
        /// PInvokeが正常に行えるかチェックする
        /// </summary>
#else
        /// <summary>
        /// Checks whether PInvoke functions can be called
        /// </summary>
#endif
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
                try
                {
                    Console.WriteLine(exception.Message);
                }
                catch
                {
                }
                try
                {
                    Debug.WriteLine(exception.Message);
                }
                catch
                {
                }
                throw exception;
            }
            catch (BadImageFormatException e)
            {
                var exception = PInvokeHelper.CreateException(e);
                try
                {
                    Console.WriteLine(exception.Message);
                }
                catch
                {
                }
                try
                {
                    Debug.WriteLine(exception.Message);
                }
                catch
                {
                }
                throw exception;
            }
            catch (Exception e)
            {
                Exception ex = e.InnerException ?? e;
                try
                {
                    Console.WriteLine(ex.Message);
                }
                catch
                {
                }
                try
                {
                    Debug.WriteLine(ex.Message);
                }
                catch
                {
                }
                throw;
            }
        }
        private static bool tried = false;

    }
}