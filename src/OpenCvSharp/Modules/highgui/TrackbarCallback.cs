using System;
using System.Runtime.InteropServices;

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
    public delegate void TrackbarCallback(int pos);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="userData"></param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TrackbarCallbackNative(int pos, IntPtr userData); 
}
