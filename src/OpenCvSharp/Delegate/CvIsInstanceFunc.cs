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
    /// <param name="structPtr"></param>
    /// <returns></returns>
#else
    /// <summary>
    /// 
    /// </summary>
    /// <param name="structPtr"></param>
    /// <returns></returns>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CvIsInstanceFunc(IntPtr structPtr);

}
