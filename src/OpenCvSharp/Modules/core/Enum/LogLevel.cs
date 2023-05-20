namespace OpenCvSharp;

/// <summary>
/// cv::utils::logging::LogLevel
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// for using in setLogVevel() call
    /// </summary>
    SILENT = 0,

    /// <summary>
    /// Fatal (critical) error (unrecoverable internal error)
    /// </summary>
    FATAL = 1,

    /// <summary>
    /// Error message.
    /// </summary>
    ERROR = 2,

    /// <summary>
    /// Warning message.
    /// </summary>
    WARNING = 3,

    /// <summary>
    /// Info message.
    /// </summary>
    INFO = 4,

    /// <summary>
    /// Debug message. Disabled in the "Release" build.
    /// </summary>
    DEBUG = 5,

    /// <summary>
    /// Verbose (trace) messages. Requires verbosity level. Disabled in the "Release" build.
    /// </summary>
    VERBOSE = 6
}
