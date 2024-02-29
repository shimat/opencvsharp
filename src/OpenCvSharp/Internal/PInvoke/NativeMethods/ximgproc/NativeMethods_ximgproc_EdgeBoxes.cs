using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getBoundingBoxes(
        IntPtr obj, IntPtr edgeMap, IntPtr orientationMap, IntPtr boxes);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getAlpha(IntPtr obj, out float returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setAlpha(IntPtr obj, float value);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getBeta(IntPtr obj, out float returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setBeta(IntPtr obj, float value);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getEta(IntPtr obj, out float returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setEta(IntPtr obj, float value);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getMinScore(IntPtr obj, out float returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setMinScore(IntPtr obj, float value);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getMaxBoxes(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setMaxBoxes(IntPtr obj, int value);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getEdgeMinMag(IntPtr obj, out float returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setEdgeMinMag(IntPtr obj, float value);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getEdgeMergeThr(IntPtr obj, out float returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setEdgeMergeThr(IntPtr obj, float value);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getClusterMinMag(IntPtr obj, out float returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setClusterMinMag(IntPtr obj, float value);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getMaxAspectRatio(IntPtr obj, out float returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setMaxAspectRatio(IntPtr obj, float value);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getMinBoxArea(IntPtr obj, out float returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setMinBoxArea(IntPtr obj, float value);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getGamma(IntPtr obj, out float returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setGamma(IntPtr obj, float value);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_getKappa(IntPtr obj, out float returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_EdgeBoxes_setKappa(IntPtr obj, float value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_createEdgeBoxes(
        float alpha, float beta, float eta, float minScore, int maxBoxes, float edgeMinMag, float edgeMergeThr,
        float clusterMinMag, float maxAspectRatio, float minBoxArea, float gamma, float kappa, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_Ptr_EdgeBoxes_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_Ptr_EdgeBoxes_get(IntPtr ptr, out IntPtr returnValue);
}
