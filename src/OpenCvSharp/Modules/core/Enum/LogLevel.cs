namespace OpenCvSharp;

/// <summary>
/// cv::utils::logging::LogLevel
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// for using in setLogVevel() call
    /// </summary>
    LOG_LEVEL_SILENT = 0,

    /// <summary>
    /// Fatal (critical) error (unrecoverable internal error)
    /// </summary>
    LOG_LEVEL_FATAL = 1,

    /// <summary>
    /// Error message.
    /// </summary>
    LOG_LEVEL_ERROR = 2,

    /// <summary>
    /// Warning message.
    /// </summary>
    LOG_LEVEL_WARNING = 3,

    /// <summary>
    /// Info message.
    /// </summary>
    LOG_LEVEL_INFO = 4,

    /// <summary>
    /// Debug message. Disabled in the "Release" build.
    /// </summary>
    LOG_LEVEL_DEBUG = 5,

    /// <summary>
    /// Verbose (trace) messages. Requires verbosity level. Disabled in the "Release" build.
    /// </summary>
    LOG_LEVEL_VERBOSE = 6
}
