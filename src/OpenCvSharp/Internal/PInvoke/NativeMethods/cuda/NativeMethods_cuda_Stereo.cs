using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Internal;
#pragma warning disable 1591
static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_drawColorDisp(IntPtr srcDisp, IntPtr dstDisp, int ndisp, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_reprojectImageTo3D(IntPtr disp, IntPtr xyzw, IntPtr Q, int dstCn, IntPtr stream);

 
}
