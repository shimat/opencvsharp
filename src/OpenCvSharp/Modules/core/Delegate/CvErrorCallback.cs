﻿using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// エラーハンドラ
    /// </summary>
    /// <param name="status">エラーステータス</param>
    /// <param name="funcName">エラーが発生したOpenCVの関数名</param>
    /// <param name="errMsg">エラーについての追加情報/診断結果</param>
    /// <param name="fileName">エラーが発生したファイル名</param>
    /// <param name="line">エラーが発生した行番号</param>
    /// <param name="userData"></param>    
#else
    /// <summary>
    /// Error Handler
    /// </summary>
    /// <param name="status">The numeric code for error status</param>
    /// <param name="funcName">The source file name where error is encountered</param>
    /// <param name="errMsg">A description of the error</param>
    /// <param name="fileName">The source file name where error is encountered</param>
    /// <param name="line">The line number in the source where error is encountered</param>
    /// <param name="userData">Pointer to the user data. Ignored by the standard handlers</param>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CvErrorCallback(
        [MarshalAs(UnmanagedType.I4)] ErrorCode status, 
        [MarshalAs(UnmanagedType.LPStr)] string funcName, 
        [MarshalAs(UnmanagedType.LPStr)] string errMsg,
        [MarshalAs(UnmanagedType.LPStr)] string fileName, 
        int line,
        IntPtr userData
    );
}
