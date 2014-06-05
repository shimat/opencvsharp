using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvERTrees_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvERTrees_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern int ml_CvERTrees_train1(
            IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, 
            IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern int ml_CvERTrees_train2(
            IntPtr obj, IntPtr data, IntPtr param);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern int ml_CvERTrees_grow_forest(
            IntPtr obj, CvTermCriteria termCrit);
    }
}