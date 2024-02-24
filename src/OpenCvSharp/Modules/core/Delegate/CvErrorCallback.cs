using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// Error Handler
/// </summary>
/// <param name="status">The numeric code for error status</param>
/// <param name="funcName">The source file name where error is encountered</param>
/// <param name="errMsg">A description of the error</param>
/// <param name="fileName">The source file name where error is encountered</param>
/// <param name="line">The line number in the source where error is encountered</param>
/// <param name="userData">Pointer to the user data. Ignored by the standard handlers</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate int CvErrorCallback(
    [MarshalAs(UnmanagedType.I4)] ErrorCode status, 
    [MarshalAs(UnmanagedType.LPStr)] string funcName, 
    [MarshalAs(UnmanagedType.LPStr)] string errMsg,
    [MarshalAs(UnmanagedType.LPStr)] string fileName, 
    int line,
    IntPtr userData
);
