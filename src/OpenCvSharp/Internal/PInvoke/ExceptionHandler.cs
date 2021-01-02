#if DOTNETCORE
using System;
using System.Threading;

namespace OpenCvSharp.Internal
{
    /// <summary>
    /// This static class defines one instance which than can be used by multiple threads to gather exception information from OpenCV
    /// Implemented as a singleton
    /// </summary>
    public static class ExceptionHandler
    {
        // ThreadLocal variables to save the exception for the current thread
        private static readonly ThreadLocal<bool> exceptionHappened = new ThreadLocal<bool>(false);
        private static readonly ThreadLocal<ErrorCode> localStatus = new ThreadLocal<ErrorCode>();
        private static readonly ThreadLocal<string> localFuncName = new ThreadLocal<string>();
        private static readonly ThreadLocal<string> localErrMsg = new ThreadLocal<string>();
        private static readonly ThreadLocal<string> localFileName = new ThreadLocal<string>();
        private static readonly ThreadLocal<int> localLine = new ThreadLocal<int>();
        
        /// <summary>
        /// Callback function invoked by OpenCV when exception occurs 
        /// Stores the information locally for every thread
        /// </summary>
        public static readonly CvErrorCallback ErrorHandlerCallback =
            delegate (ErrorCode status, string funcName, string errMsg, string fileName, int line, IntPtr userData)
            {
                try
                {
                    return 0;
                }
                finally
                {
                    exceptionHappened.Value = true;
                    localStatus.Value = status;
                    localErrMsg.Value = errMsg;
                    localFileName.Value = fileName;
                    localLine.Value = line;
                    localFuncName.Value = funcName;
                }
            };

        /// <summary>
        /// Registers the callback function to OpenCV, so exception caught before the p/invoke boundary 
        /// </summary>
        public static void RegisterExceptionCallback()
        {
            IntPtr zero = IntPtr.Zero;
            IntPtr ret = NativeMethods.redirectError(ErrorHandlerCallback, zero, ref zero);
        }

        /// <summary>
        /// Throws appropriate exception if one happened
        /// </summary>
        public static void ThrowPossibleException()
        {
            if (CheckForException())
            {
                throw new OpenCVException(
                    localStatus.Value, 
                    localFuncName.Value ?? "", 
                    localErrMsg.Value ?? "",
                    localFileName.Value ?? "", 
                    localLine.Value);
            }
        }

        /// <summary>
        /// Returns a boolean which indicates if an exception occured for the current thread
        /// Reading this value changes its state, so an exception is handled only once
        /// </summary>
        private static bool CheckForException()
        {
            var value = exceptionHappened.Value;
            // reset exception value
            exceptionHappened.Value = false;
            return value;
        }
    }
}
#endif