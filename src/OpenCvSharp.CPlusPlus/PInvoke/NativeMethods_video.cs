/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// P/Invoke methods of OpenCV 2.x C++ interface
    /// </summary>
    internal static partial class NativeMethods
    {
        #region BackgroundSubtractor
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractor_getBackgroundImage(IntPtr self, IntPtr backgroundImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractor_operator(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_Ptr_BackgroundSubtractor_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_Ptr_BackgroundSubtractor_obj(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractor_info(IntPtr obj);
        #endregion
        #region BackgroundSubtractorMOG
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorMOG_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorMOG_new2(int history, int nmixtures, double backgroundRatio, double noiseSigma);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG_operator(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG_initialize(IntPtr self, CvSize frameSize, int frameType);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_Ptr_BackgroundSubtractorMOG_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_Ptr_BackgroundSubtractorMOG_obj(IntPtr ptr);
        #endregion
        #region BackgroundSubtractorMOG2
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorMOG2_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorMOG2_new2(int history, float varThreshold, int bShadowDetection);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_operator(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_getBackgroundImage(IntPtr self, IntPtr backgroundImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_initialize(IntPtr self, CvSize frameSize, int frameType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_Ptr_BackgroundSubtractorMOG2_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_Ptr_BackgroundSubtractorMOG2_obj(IntPtr ptr);
        #endregion
    }
}