using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#pragma warning disable 1591

    [Serializable]
    public class LoadLibraryException : SystemException
    {
        public LoadLibraryException() { }
        public LoadLibraryException(string message) : base(message) { }
        public LoadLibraryException(string message, Exception inner) : base(message, inner) { }
        protected LoadLibraryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
