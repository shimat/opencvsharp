using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using OpenCvSharp.ML;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1707 // Underscore
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        #region uchar
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_uchar_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_uchar_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_uchar_new3([In] byte[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_uchar_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_uchar_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_uchar_copy(IntPtr vector, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_uchar_delete(IntPtr vector);
        #endregion
        #region char
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_char_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_char_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_char_new3([In] sbyte[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_char_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_char_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_char_copy(IntPtr vector, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_char_delete(IntPtr vector);
        #endregion
        #region int
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_int32_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_int32_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_int32_new3([In] int[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_int32_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_int32_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_int32_delete(IntPtr vector);
        #endregion
        #region float
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_float_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_float_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_float_new3([In] float[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_float_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_float_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_float_delete(IntPtr vector);
        #endregion
        #region double
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_double_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_double_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_double_new3([In] double[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_double_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_double_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_double_delete(IntPtr vector);
        #endregion
        #region cv::Vec2f
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec2f_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec2f_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec2f_new3([In] Vec2f[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec2f_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec2f_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Vec2f_delete(IntPtr vector);
        #endregion
        #region cv::Vec3f
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec3f_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec3f_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec3f_new3([In] Vec3f[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec3f_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec3f_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Vec3f_delete(IntPtr vector);
        #endregion
        #region cv::Vec4f
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4f_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4f_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4f_new3([In] Vec4f[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4f_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4f_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Vec4f_delete(IntPtr vector);
        #endregion
        #region cv::Vec4i
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4i_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4i_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4i_new3([In] Vec4i[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4i_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4i_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Vec4i_delete(IntPtr vector);
        #endregion
        #region cv::Vec6f
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec6f_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec6f_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec6f_new3([In] Vec6f[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec6f_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec6f_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Vec6f_delete(IntPtr vector);
        #endregion
        #region cv::Vec6d
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec6d_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec6d_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec6d_new3([In] Vec6d[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec6d_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec6d_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Vec6d_delete(IntPtr vector);
        #endregion
        #region cv::Point2i
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2i_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2i_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2i_new3([In] Point[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2i_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2i_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Point2i_delete(IntPtr vector);
        #endregion
        #region cv::Point2f
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2f_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2f_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2f_new3([In] Point2f[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2f_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2f_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Point2f_delete(IntPtr vector);
        #endregion
        #region cv::Point2d
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2d_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2d_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2d_new3([In] Point2d[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2d_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point2d_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Point2d_delete(IntPtr vector);
        #endregion
        #region cv::Point3f
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point3f_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point3f_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point3f_new3([In] Point3f[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point3f_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Point3f_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Point3f_delete(IntPtr vector);
        #endregion
        #region cv::Rect
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Rect_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Rect_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Rect_new3([In] Rect[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Rect_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Rect_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Rect_delete(IntPtr vector);
        #endregion
        #region cv::Rect2d
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Rect2d_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Rect2d_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Rect2d_new3([In] Rect2d[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Rect2d_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Rect2d_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Rect2d_delete(IntPtr vector);
        #endregion
        #region cv::RotatedRect
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_RotatedRect_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_RotatedRect_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_RotatedRect_new3([In] RotatedRect[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_RotatedRect_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_RotatedRect_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_RotatedRect_delete(IntPtr vector);
        #endregion
        #region cv::KeyPoint
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_KeyPoint_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_KeyPoint_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_KeyPoint_new3([In]KeyPoint[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_KeyPoint_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_KeyPoint_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_KeyPoint_delete(IntPtr vector);
        #endregion
        #region cv::KeyPoint
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DMatch_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DMatch_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DMatch_new3([In] DMatch[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DMatch_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DMatch_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_DMatch_delete(IntPtr vector);
        #endregion
        #region vector<int>
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_int_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_int_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_int_getSize1(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_int_getSize2(IntPtr vector, [In, Out] IntPtr[] size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_int_copy(IntPtr vec, IntPtr[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_int_delete(IntPtr vector);
        #endregion
        #region vector<float>
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_float_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_float_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_float_getSize1(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_float_getSize2(IntPtr vector, [In, Out] IntPtr[] size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_float_copy(IntPtr vec, IntPtr[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_float_delete(IntPtr vector);
        #endregion
        #region vector<double>
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_double_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_double_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_double_getSize1(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_double_getSize2(IntPtr vector, [In, Out] IntPtr[] size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_double_copy(IntPtr vec, IntPtr[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_double_delete(IntPtr vector);
        #endregion
        #region vector<cv::KeyPoint>
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_KeyPoint_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_KeyPoint_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_KeyPoint_new3(
            IntPtr[] values, int size1, int[] size2);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_KeyPoint_getSize1(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_KeyPoint_getSize2(IntPtr vector, [In, Out] IntPtr[] size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_KeyPoint_copy(IntPtr vec, IntPtr[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_KeyPoint_delete(IntPtr vector);
        #endregion
        #region vector<cv::DMatch>
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_DMatch_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_DMatch_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_DMatch_getSize1(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_DMatch_getSize2(IntPtr vector, [In, Out] IntPtr[] size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_DMatch_copy(IntPtr vec, IntPtr[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_DMatch_delete(IntPtr vector);
        #endregion
        #region vector<cv::Point>
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_Point_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_Point_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_Point_getSize1(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_Point_getSize2(IntPtr vector, [In, Out] IntPtr[] size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_Point_copy(IntPtr vec, IntPtr[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_Point_delete(IntPtr vector);
        #endregion
        #region vector<cv::Point2f>
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_Point2f_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_Point2f_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_Point2f_getSize1(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_Point2f_getSize2(IntPtr vector, [In, Out] IntPtr[] size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_Point2f_copy(IntPtr vec, IntPtr[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_Point2f_delete(IntPtr vector);
        #endregion
        #region vector<std::string>
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_string_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_string_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_string_getSize(IntPtr vec);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_string_getElements(
            IntPtr vector, 
            [MarshalAs(UnmanagedType.LPArray)] IntPtr[] cStringPointers,
            [MarshalAs(UnmanagedType.LPArray)] int[] stringLengths);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_string_delete(IntPtr vector);
        #endregion
        #region cv::Mat
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Mat_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Mat_new2(uint size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Mat_new3(IntPtr[] data, uint dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Mat_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Mat_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Mat_delete(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Mat_assignToArray(IntPtr vector, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] arr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Mat_addref(IntPtr vector);

        #endregion

        #region cv::ml::DTrees::Node

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DTrees_Node_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DTrees_Node_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DTrees_Node_new3([In]DTrees.Node[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DTrees_Node_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DTrees_Node_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_DTrees_Node_delete(IntPtr vector);

        #endregion

        #region cv::ml::DTrees::Split

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DTrees_Split_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DTrees_Split_new2(IntPtr size);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DTrees_Split_new3([In]DTrees.Split[] data, IntPtr dataLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DTrees_Split_getSize(IntPtr vector);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_DTrees_Split_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_DTrees_Split_delete(IntPtr vector);

        #endregion

    }
}