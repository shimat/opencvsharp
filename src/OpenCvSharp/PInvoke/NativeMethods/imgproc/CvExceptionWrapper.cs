using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// cv::Exception wrapper
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class CvExceptionWrapper
    {
        /// <summary>
        /// the formatted error message
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public StringBuilder Msg;

        /// <summary>
        /// 
        /// </summary>
        public int MsgBufferLength;

        /// <summary>
        /// error code @see CVStatus
        /// </summary>
        public int Code;

        /// <summary>
        /// error description
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public StringBuilder Err; 

        /// <summary>
        /// 
        /// </summary>
        public int ErrBufferLength;

        /// <summary>
        /// function name. Available only when the compiler supports getting it
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public StringBuilder Func;

        /// <summary>
        /// 
        /// </summary>
        public int FuncBufferLength;

        /// <summary>
        /// source file name where the error has occurred
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public StringBuilder File;

        /// <summary>
        /// 
        /// </summary>
        public int FileBufferLength;

        /// <summary>
        /// line number in the source file where the error has occurred
        /// </summary>
        public int Line;

        public CvExceptionWrapper(
            int msgBufferLength = 4096,
            int errBufferLength = 512,
            int funcBufferLength = 512,
            int fileBufferLength = 512)
        {
            MsgBufferLength = msgBufferLength;
            Msg = new StringBuilder(msgBufferLength);
            ErrBufferLength = errBufferLength;
            Err = new StringBuilder(errBufferLength);
            FuncBufferLength = errBufferLength;
            Func = new StringBuilder(errBufferLength);
            FileBufferLength = fileBufferLength;
            File = new StringBuilder(fileBufferLength);
        }
    }
}