namespace OpenCvSharp;

/// <summary>
/// The default exception to be thrown by OpenCV 
/// </summary>
[Serializable]
// ReSharper disable once InconsistentNaming
public class OpenCVException : Exception
{
    /// <summary>
    /// The numeric code for error status
    /// </summary>
    public ErrorCode Status { get; set; }

    /// <summary>
    /// The source file name where error is encountered
    /// </summary>
    public string FuncName { get; set; }

    /// <summary>
    /// A description of the error
    /// </summary>
    public string ErrMsg { get; set; }

    /// <summary>
    /// The source file name where error is encountered
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// The line number in the source where error is encountered
    /// </summary>
    public int Line { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="status">The numeric code for error status</param>
    /// <param name="funcName">The source file name where error is encountered</param>
    /// <param name="errMsg">A description of the error</param>
    /// <param name="fileName">The source file name where error is encountered</param>
    /// <param name="line">The line number in the source where error is encountered</param>
    public OpenCVException(ErrorCode status, string funcName, string errMsg, string fileName, int line)
        : base(errMsg)
    {
        Status = status;
        FuncName = funcName;
        ErrMsg = errMsg;
        FileName = fileName;
        Line = line;
    }

    /// <inheritdoc />
    public OpenCVException()
    {
        Status = 0;
        FuncName = "";
        ErrMsg = "";
        FileName = "";
        Line = 0;
    }

    /// <inheritdoc />
    public OpenCVException(string message) : base(message)
    {
        Status = 0;
        FuncName = "";
        ErrMsg = "";
        FileName = "";
        Line = 0;
    }

    /// <inheritdoc />
    public OpenCVException(string message, Exception innerException) : base(message, innerException)
    {
        Status = 0;
        FuncName = "";
        ErrMsg = "";
        FileName = "";
        Line = 0;
    }
}
