using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// CvTrackbarが操作されたときのイベント処理を行うデリゲート
    /// </summary>
#else
    /// <summary>
    /// Delegate to be called every time the slider changes the position.
    /// </summary>
    /// <param name="pos"></param>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CvTrackbarCallback(int pos);





#if LANG_JP
    /// <summary>
    /// CvTrackbarが操作されたときのイベント処理を行うデリゲート
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="userdata"></param>
#else
    /// <summary>
    /// Delegate to be called every time the slider changes the position.
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="userdata"></param>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CvTrackbarCallback2(int pos, object userdata);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="userdata"></param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void CvTrackbarCallback2Native(int pos, IntPtr userdata); 
}
