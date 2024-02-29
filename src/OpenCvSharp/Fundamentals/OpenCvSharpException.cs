using System.Runtime.Serialization;

namespace OpenCvSharp;

/// <summary>
/// The exception that is thrown by OpenCvSharp. 
/// </summary>
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
