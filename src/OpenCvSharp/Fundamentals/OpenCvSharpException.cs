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
    public OpenCvSharpException(string message)
        : base(message)
    {
    }

    /// <inheritdoc />
    public OpenCvSharpException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

}
