using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
    /// <param name="struct_dblptr"></param>
    /// <returns></returns>
#else
    /// <summary>
    /// 
    /// </summary>
    /// <param name="struct_dblptr"></param>
    /// <returns></returns>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CvReleaseFunc(ref IntPtr struct_dblptr);

}
