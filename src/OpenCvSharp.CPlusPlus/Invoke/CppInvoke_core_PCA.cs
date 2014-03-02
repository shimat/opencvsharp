/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Utilities;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// P/Invoke methods of OpenCV 2.x C++ interface
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static partial class CppInvoke
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_PCA_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_PCA_new2(IntPtr data, IntPtr mean, int flags,
            int maxComponents);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_PCA_new3(IntPtr data, IntPtr mean, int flags,
            double retainedVariance);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_PCA_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_PCA_operatorThis(IntPtr obj, IntPtr data, IntPtr mean,
            int flags, int maxComponents);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_PCA_computeVar(IntPtr obj, IntPtr data, IntPtr mean,
            int flags, double retainedVariance);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_PCA_project1")]
        public static extern IntPtr core_PCA_project(IntPtr obj, IntPtr vec);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_PCA_project2")]
        public static extern void core_PCA_project(IntPtr obj, IntPtr vec, IntPtr result);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_PCA_backProject1")]
        public static extern IntPtr core_PCA_backProject(IntPtr obj, IntPtr vec);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_PCA_backProject2")]
        public static extern void core_PCA_backProject(IntPtr obj, IntPtr vec, IntPtr result);

    }
}