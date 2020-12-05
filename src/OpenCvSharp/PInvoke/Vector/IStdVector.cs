using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Represents std::vector 
    /// </summary>
    public interface IStdVector<out T> : IDisposable
    {
        /// <summary>
        /// vector.size()
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Convert std::vector&lt;T&gt; to managed array T[]
        /// </summary>
        /// <returns></returns>
        T[] ToArray();
    }
}
