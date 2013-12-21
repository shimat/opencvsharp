using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// エラーハンドラ
    /// </summary>
    /// <param name="status">エラーステータス</param>
    /// <param name="func_name">エラーが発生したOpenCVの関数名</param>
    /// <param name="err_msg">エラーについての追加情報/診断結果</param>
    /// <param name="file_name">エラーが発生したファイル名</param>
    /// <param name="line">エラーが発生した行番号</param>
    /// <param name="userdata"></param>    
#else
    /// <summary>
    /// Error Handler
    /// </summary>
    /// <param name="status">The numeric code for error status</param>
    /// <param name="func_name">The source file name where error is encountered</param>
    /// <param name="err_msg">A description of the error</param>
    /// <param name="file_name">The source file name where error is encountered</param>
    /// <param name="line">The line number in the souce where error is encountered</param>
    /// <param name="userdata">Pointer to the user data. Ignored by the standard handlers</param>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CvErrorCallback(
        [MarshalAs(UnmanagedType.I4)] CvStatus status, 
        [MarshalAs(UnmanagedType.LPStr)] string func_name, 
        [MarshalAs(UnmanagedType.LPStr)] string err_msg,
        [MarshalAs(UnmanagedType.LPStr)] string file_name, 
        int line,
        IntPtr userdata
    );
}
