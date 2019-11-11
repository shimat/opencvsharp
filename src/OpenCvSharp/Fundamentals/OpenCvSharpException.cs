using System;
using System.Runtime.Serialization;

namespace OpenCvSharp
{
#if LANG_JP
/// <summary>
/// OpenCvSharpから投げられる例外
/// </summary>
#else
    /// <summary>
    /// The exception that is thrown by OpenCvSharp. 
    /// </summary>
#endif
    [Serializable]
    public class OpenCvSharpException : Exception
    {
        /// <inheritdoc />
        public OpenCvSharpException()
        {
        }

        /// <inheritdoc />
        /// <param name="message"></param>
        public OpenCvSharpException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        /// <param name="messageFormat"></param>
        /// <param name="args"></param>
        public OpenCvSharpException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        }

        /// <inheritdoc />
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public OpenCvSharpException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <inheritdoc />
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected OpenCvSharpException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
