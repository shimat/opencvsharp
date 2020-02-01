﻿using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_new(
            IntPtr img, Point pt1, Point pt2, int connectivity, int leftToRight, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_getValuePosAndShiftToNext(
            IntPtr obj, out IntPtr returnValue, out Point returnPos);

        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_operatorEntity(IntPtr obj, out IntPtr returnValue);

        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_operatorPP(IntPtr obj);

        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_pos(IntPtr obj, out Point returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_ptr_get(IntPtr obj, out IntPtr returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_ptr_set(IntPtr obj, IntPtr val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_ptr0_get(IntPtr obj, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_step_get(IntPtr obj, out int returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_step_set(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_elemSize_get(IntPtr obj, out int returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_elemSize_set(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_err_get(IntPtr obj, out int returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_err_set(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_count_get(IntPtr obj, out int returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_count_set(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_minusDelta_get(IntPtr obj, out int returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_minusDelta_set(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_plusDelta_get(IntPtr obj, out int returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_plusDelta_set(IntPtr obj, int val);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_minusStep_get(IntPtr obj, out int returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_minusStep_set(IntPtr obj, int val);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus imgproc_LineIterator_plusStep_get(IntPtr obj, out int returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus imgproc_LineIterator_plusStep_set(IntPtr obj, int val);
    }
}