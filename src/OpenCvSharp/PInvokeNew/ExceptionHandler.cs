using System;
using System.Threading;

namespace OpenCvSharp
{
    /// <summary>
    /// This static class defines one instance which than can be used by multiple threads to gather exception information from opencv
    /// Implemented as a singleton
    /// </summary>
    public static class ExceptionHandler
    {
        // ThreadLocal variables to save the exception for the current thread
        private static ThreadLocal<bool> exceptionHappened  = new ThreadLocal<bool>(false);
        private static ThreadLocal<OpenCvSharp.ErrorCode> localStatus = new ThreadLocal<OpenCvSharp.ErrorCode>();
        private static ThreadLocal<string> localFuncName    = new ThreadLocal<string>();
        private static ThreadLocal<string> localErrMsg      = new ThreadLocal<string>();
        private static ThreadLocal<string> localFileName    = new ThreadLocal<string>();
        private static ThreadLocal<int> localLine           = new ThreadLocal<int>();

        /// <summary>
        /// Registers the callback function to opencv, so exception caught befor the p/invoke boundary 
        /// </summary>
        public static void registerExceptionCallback()
        {
            Console.WriteLine("Register callback");
            IntPtr zero = IntPtr.Zero;
            OpenCvSharp.NativeMethods.redirectError(ErrorHandlerCallback, zero, ref zero);
        }

        /// <summary>
        /// Throws approptiate exception if one happened
        /// </summary>
        public static void throwPossibleException()
        {
            if(checkForException)
            {
                throw new OpenCVException(  localStatus.Value, localFuncName.Value, localErrMsg.Value, 
                                            localFileName.Value, localLine.Value);
            }
        }

        /// <summary>
        /// Returns a boolean which indicates if an exception occured for the current thread
        /// Reading this value changes its state, so an exception is handled only once
        /// </summary>
        private static bool checkForException{
            get{
                var value = exceptionHappened.Value;
                // reset exception value
                exceptionHappened.Value = false;
                return value;
            }
        }



        /// <summary>
        /// Callback function invoked by opencv when exception occurs 
        /// Stores the information locally for every thread
        /// </summary>
        public static  readonly OpenCvSharp.CvErrorCallback ErrorHandlerCallback =
        delegate(OpenCvSharp.ErrorCode status, string funcName, string errMsg, string fileName, int line, IntPtr userdata)
        {
            try
            {
                return 0;
            }
            finally
            {
                Console.WriteLine("Callback intercepted exception: {0}", errMsg);
                Console.WriteLine("Threadid: {0}", Thread.CurrentThread.ManagedThreadId);
                exceptionHappened.Value = true;
                localStatus.Value   = status;
                localErrMsg.Value   = errMsg;
                localFileName.Value = fileName;
                localLine.Value     = line;
                localFuncName.Value = funcName;
            }
        };
    }
}