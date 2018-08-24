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
    public static partial class NativeMethodsExc
    {
        //public const string DllVCRuntime = "vcruntime140";
        //public const string DllMsvcp = "msvcp140";
        public const string DllExtern = "OpenCvSharpExtern";
    }
}