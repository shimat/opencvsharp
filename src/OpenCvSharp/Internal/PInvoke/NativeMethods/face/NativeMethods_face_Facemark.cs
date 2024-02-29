using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    #region Facemark

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Facemark_loadModel(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string model);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Facemark_fit(
        IntPtr obj, IntPtr image, IntPtr faces, IntPtr landmarks, out int returnValue);

    #endregion

    #region FacemarkLBF

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_create(IntPtr @params, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Ptr_FacemarkLBF_get(IntPtr obj, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Ptr_FacemarkLBF_delete(IntPtr obj);

    #region Params

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_new(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_shape_offset_get(IntPtr obj, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_shape_offset_set(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_cascade_face_get(IntPtr obj, IntPtr s);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_cascade_face_set(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string s);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_verbose_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_verbose_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_n_landmarks_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_n_landmarks_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_initShape_n_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_initShape_n_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_stages_n_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_stages_n_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_tree_n_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_tree_n_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_tree_depth_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_tree_depth_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_bagging_overlap_get(IntPtr obj, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_bagging_overlap_set(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_model_filename_get(IntPtr obj, IntPtr s);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_model_filename_set(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string s);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_save_model_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_save_model_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_seed_get(IntPtr obj, out uint returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_seed_set(IntPtr obj, uint val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_feats_m_get(IntPtr obj, IntPtr v);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_feats_m_set(IntPtr obj, IntPtr v);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_radius_m_get(IntPtr obj, IntPtr v);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_radius_m_set(IntPtr obj, IntPtr v);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_pupils0_get(IntPtr obj, IntPtr v);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_pupils0_set(IntPtr obj, IntPtr v);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_pupils1_get(IntPtr obj, IntPtr v);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_pupils1_set(IntPtr obj, IntPtr v);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_detectROI_get(IntPtr obj, out Rect returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_detectROI_set(IntPtr obj, Rect val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_read(IntPtr obj, IntPtr fn);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkLBF_Params_write(IntPtr obj, IntPtr fs);

    #endregion

    #endregion

    #region FacemarkAAM

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_create(IntPtr @params, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Ptr_FacemarkAAM_get(IntPtr obj, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Ptr_FacemarkAAM_delete(IntPtr obj);

    #region Params

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_new(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_model_filename_get(IntPtr obj, IntPtr s);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_model_filename_set(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string s);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_m_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_m_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_n_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_n_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_n_iter_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_n_iter_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_verbose_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_verbose_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_save_model_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_save_model_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_max_m_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_max_m_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_max_n_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_max_n_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_texture_max_m_get(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_texture_max_m_set(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_scales_get(IntPtr obj, IntPtr v);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_scales_set(IntPtr obj, IntPtr v);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_read(IntPtr obj, IntPtr fn);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FacemarkAAM_Params_write(IntPtr obj, IntPtr fs);

    #endregion

    #endregion
}
