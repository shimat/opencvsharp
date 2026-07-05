namespace OpenCvSharp;

/// <summary>
/// Trackbar that is shown on an OpenCV Window
/// </summary>
public sealed class CvTrackbar
{
    #region Properties

    /// <summary>
    /// Name of this trackbar
    /// </summary>
    public string TrackbarName { get; }

    /// <summary>
    /// Name of parent window
    /// </summary>
    public string WindowName { get; }

    /// <summary>
    ///
    /// </summary>
    public TrackbarCallback Callback { get; }

    /// <summary>
    /// Gets or sets a numeric value that represents the current position of the scroll box on the track bar.
    /// </summary>
    public int Pos
    {
        get => Cv2.GetTrackbarPos(TrackbarName, WindowName);
        set => Cv2.SetTrackbarPos(TrackbarName, WindowName, value);
    }

    #endregion

    #region Init

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="trackbarName">Trackbar name</param>
    /// <param name="windowName">Window name</param>
    /// <param name="callback">Callback handler</param>
    /// <param name="initialPos">Initial slider position</param>
    /// <param name="max">The upper limit of the range this trackbar is working with. </param>
    internal CvTrackbar(string trackbarName, string windowName, TrackbarCallback callback, int initialPos = 0, int max = 100)
    {
        if (string.IsNullOrEmpty(trackbarName))
            throw new ArgumentException("Null or empty trackbar name.", nameof(trackbarName));
        if (string.IsNullOrEmpty(windowName))
            throw new ArgumentException("Null or empty window name.", nameof(windowName));

        ArgumentNullException.ThrowIfNull(callback);
        Callback = callback;
        TrackbarName = trackbarName;
        WindowName = windowName;

        // Adapt the user-facing void(int) callback to OpenCV's void(int, userdata) shape.
        // Cv2.CreateTrackbar roots the native-shaped delegate for the window's lifetime, so no
        // GCHandle is needed here.
        TrackbarCallbackNative callbackNative = (pos, _) => callback(pos);
        var result = Cv2.CreateTrackbar(trackbarName, windowName, max, callbackNative);
        if (result == 0)
            throw new OpenCvSharpException("Failed to create CvTrackbar.");

        // Set initial trackbar position
        Cv2.SetTrackbarPos(trackbarName, windowName, initialPos);
    }

    #endregion

    /// <summary>
    /// Sets the trackbar maximum position.
    /// The function sets the maximum position of the specified trackbar in the specified window.
    /// </summary>
    /// <param name="maxVal">New maximum position.</param>
    public void SetMax(int maxVal)
    {
        Cv2.SetTrackbarMax(TrackbarName, WindowName, maxVal);
    }

    /// <summary>
    /// Sets the trackbar minimum position.
    /// The function sets the minimum position of the specified trackbar in the specified window.
    /// </summary>
    /// <param name="minVal">New minimum position.</param>
    public void SetMin(int minVal)
    {
        Cv2.SetTrackbarMin(TrackbarName, WindowName, minVal);
    }
}
