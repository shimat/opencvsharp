using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ml_KNearest_getDefaultK(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ml_KNearest_setDefaultK(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ml_KNearest_getIsClassifier(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ml_KNearest_setIsClassifier(IntPtr obj, int val);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ml_KNearest_getEmax(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ml_KNearest_setEmax(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ml_KNearest_getAlgorithmType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ml_KNearest_setAlgorithmType(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ml_KNearest_findNearest(IntPtr obj, IntPtr samples, int k,
            IntPtr results, IntPtr neighborResponses, IntPtr dist);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ml_KNearest_create();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ml_Ptr_KNearest_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ml_Ptr_KNearest_get(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ml_KNearest_load(string filePath);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ml_KNearest_loadFromString(string strModel);
    }
}