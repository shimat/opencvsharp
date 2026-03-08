using System.Runtime.InteropServices;
using OpenCvSharp.Detail;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1707 // Underscore
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region uchar
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_uchar_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_uchar_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_uchar_new3([In] byte[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_uchar_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_uchar_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_uchar_copy(IntPtr vector, IntPtr dst);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_uchar_delete(IntPtr vector);
    #endregion
    #region int
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_int32_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_int32_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_int32_new3([In] int[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_int32_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_int32_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_int32_delete(IntPtr vector);
    #endregion
    #region float
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_float_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_float_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_float_new3([In] float[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_float_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_float_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_float_delete(IntPtr vector);
    #endregion
    #region double
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_double_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_double_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_double_new3([In] double[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_double_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_double_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_double_delete(IntPtr vector);
    #endregion
    #region cv::Vec2f
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec2f_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Vec2f_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec2f_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Vec2f_delete(IntPtr vector);
    #endregion
    #region cv::Vec3f
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec3f_new1();

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Vec3f_getSize(IntPtr vector);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec3f_getPointer(IntPtr vector);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Vec3f_delete(IntPtr vector);
    #endregion
    #region cv::Vec4f
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec4f_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec4f_new3([In] Vec4f[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Vec4f_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec4f_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Vec4f_delete(IntPtr vector);
    #endregion
    #region cv::Vec4i
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec4i_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec4i_new3([In] Vec4i[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Vec4i_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec4i_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Vec4i_delete(IntPtr vector);
    #endregion
    #region cv::Vec6f
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec6f_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Vec6f_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Vec6f_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Vec6f_delete(IntPtr vector);
    #endregion
    #region cv::Point2i
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point2i_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point2i_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point2i_new3([In] Point[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Point2i_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point2i_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Point2i_delete(IntPtr vector);
    #endregion
    #region cv::Point2f
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point2f_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point2f_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point2f_new3([In] Point2f[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Point2f_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point2f_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Point2f_delete(IntPtr vector);
    #endregion
    #region cv::Point2d
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point2d_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Point2d_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point2d_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Point2d_delete(IntPtr vector);
    #endregion
    #region cv::Point3f
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point3f_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point3f_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point3f_new3([In] Point3f[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Point3f_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Point3f_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Point3f_delete(IntPtr vector);
    #endregion
    #region cv::Rect
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Rect_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Rect_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Rect_new3([In] Rect[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Rect_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Rect_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Rect_delete(IntPtr vector);
    #endregion
    #region cv::Rect2d
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Rect2d_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Rect2d_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Rect2d_new3([In] Rect2d[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Rect2d_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Rect2d_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Rect2d_delete(IntPtr vector);
    #endregion
    #region cv::RotatedRect
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_RotatedRect_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_RotatedRect_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_RotatedRect_new3([In] RotatedRect[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_RotatedRect_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_RotatedRect_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_RotatedRect_delete(IntPtr vector);
    #endregion
    #region cv::KeyPoint
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_KeyPoint_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_KeyPoint_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_KeyPoint_new3([In]KeyPoint[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_KeyPoint_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_KeyPoint_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_KeyPoint_delete(IntPtr vector);
    #endregion
    #region cv::KeyPoint
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_DMatch_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_DMatch_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_DMatch_new3([In] DMatch[] data, nuint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_DMatch_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_DMatch_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_DMatch_delete(IntPtr vector);
    #endregion
    #region cv::Mat
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Mat_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Mat_new2(uint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Mat_new3(IntPtr[] data, uint dataLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_Mat_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_Mat_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Mat_delete(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_Mat_assignToArray(IntPtr vector, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] arr);

    #endregion

    #region cv::ml::DTrees::Node

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_DTrees_Node_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_DTrees_Node_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_DTrees_Node_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_DTrees_Node_delete(IntPtr vector);

    #endregion
    #region cv::ml::DTrees::Split

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_DTrees_Split_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_DTrees_Split_getSize(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_DTrees_Split_getPointer(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_DTrees_Split_delete(IntPtr vector);

    #endregion
    #region cv::detail::ImageFeatures

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_ImageFeatures_new1();

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_ImageFeatures_getSize(IntPtr vector);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_ImageFeatures_getKeypointsSize(
        IntPtr vector, [Out] nuint[] dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_ImageFeatures_getElements(IntPtr vector, [Out] WImageFeatures[] dst);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_ImageFeatures_delete(IntPtr vector);

    #endregion
    #region cv::line_descriptor::KeyLine
#if false
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_KeyLine_new1();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern nuint vector_KeyLine_getSize(IntPtr vector);

        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern void vector_KeyLine_getElements(IntPtr vector, [Out] KeyLine[] dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_KeyLine_getPointer(IntPtr vector);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_KeyLine_delete(IntPtr vector);
#endif
    #endregion

    #region vector<uchar>
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_vector_uchar_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_vector_uchar_getSize1(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_uchar_getSize2(IntPtr vector, [In, Out] nuint[] size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_uchar_copy(IntPtr vec, IntPtr[] dst);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_uchar_delete(IntPtr vector);
    #endregion
    #region vector<int>
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_vector_int_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_vector_int_getSize1(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_int_getSize2(IntPtr vector, [In, Out] nuint[] size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_int_copy(IntPtr vec, IntPtr[] dst);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_int_delete(IntPtr vector);
    #endregion
    #region vector<double>
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_vector_double_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_vector_double_getSize1(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_double_getSize2(IntPtr vector, [In, Out] nuint[] size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_double_copy(IntPtr vec, IntPtr[] dst);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_double_delete(IntPtr vector);
    #endregion
    #region vector<cv::KeyPoint>
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_vector_KeyPoint_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_vector_KeyPoint_new3(
        IntPtr[] values, int size1, int[] size2);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_vector_KeyPoint_getSize1(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_KeyPoint_getSize2(IntPtr vector, [In, Out] nuint[] size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_KeyPoint_copy(IntPtr vec, IntPtr[] dst);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_KeyPoint_delete(IntPtr vector);
    #endregion
    #region vector<cv::DMatch>
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_vector_DMatch_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_vector_DMatch_getSize1(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_DMatch_getSize2(IntPtr vector, [In, Out] nuint[] size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_DMatch_copy(IntPtr vec, IntPtr[] dst);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_DMatch_delete(IntPtr vector);
    #endregion
    #region vector<cv::Point>
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_vector_Point_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_vector_Point_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_vector_Point_getSize1(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_Point_getSize2(IntPtr vector, [In, Out] nuint[] size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_Point_copy(IntPtr vec, IntPtr[] dst);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_Point_delete(IntPtr vector);
    #endregion
    #region vector<cv::Point2f>
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_vector_Point2f_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_vector_Point2f_getSize1(IntPtr vector);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_Point2f_getSize2(IntPtr vector, [In, Out] nuint[] size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_Point2f_copy(IntPtr vec, IntPtr[] dst);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_vector_Point2f_delete(IntPtr vector);
    #endregion
    #region vector<std::string>
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_string_new1();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr vector_string_new2(nuint size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nuint vector_string_getSize(IntPtr vec);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_string_getElements(
        IntPtr vector,
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] cStringPointers,
        [MarshalAs(UnmanagedType.LPArray)] int[] stringLengths);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vector_string_delete(IntPtr vector);
    #endregion
    #region vector<cv::line_descriptor::KeyLine>
#if false
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_vector_KeyLine_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern nuint vector_vector_KeyLine_getSize1(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_KeyLine_getSize2(IntPtr vector, [In, Out] nuint[] size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_KeyLine_copy(IntPtr vec, IntPtr[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_vector_KeyLine_delete(IntPtr vector);
#endif
    #endregion
}
