using System;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Represents std::vector 
    /// </summary>
    internal interface IStdVector : IDisposable
    {
        /// <summary>
        /// vector.size()
        /// </summary>
        int Size { get; }
        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        IntPtr ElemPtr { get; }
    }
}
