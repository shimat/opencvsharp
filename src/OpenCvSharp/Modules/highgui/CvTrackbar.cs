using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Trackbar that is shown on OpenCV Window
/// </summary>
public class CvTrackbar : DisposableObject
{
    private readonly int result;
    private TrackbarCallbackNative callbackNative;
    private GCHandle gchCallback;
    private GCHandle gchCallbackNative;
        
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
        get
        {
            NativeMethods.HandleException(
                NativeMethods.highgui_getTrackbarPos(TrackbarName, WindowName, out var ret));
            return ret;
        }
        set => NativeMethods.HandleException(
            NativeMethods.highgui_setTrackbarPos(TrackbarName, WindowName, value));
    }

    /// <summary>
    /// Result value of cv::createTrackbar
    /// </summary>
    public int Result => result;

    #endregion
        
    #region Init and Disposal
        
    /// <summary>
    /// Constructor (value=0, max=100)
    /// </summary>
    /// <param name="name">Trackbar name</param>
    /// <param name="window">Window name</param>
    /// <param name="callback">Callback handler</param>
    internal CvTrackbar(string name, string window, TrackbarCallback callback)
        : this(name, window, 0, 100, callback)
    {
    }
        
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="trackbarName">Trackbar name</param>
    /// <param name="windowName">Window name</param>
    /// <param name="initialPos">Initial slider position</param>
    /// <param name="max">The upper limit of the range this trackbar is working with. </param>
    /// <param name="callback">Callback handler</param>
    internal CvTrackbar(string trackbarName, string windowName, int initialPos, int max, TrackbarCallback callback)
    {
        if (string.IsNullOrEmpty(trackbarName))
            throw new ArgumentNullException(nameof(trackbarName));
        if (string.IsNullOrEmpty(windowName))
            throw new ArgumentNullException(nameof(windowName));

        Callback = callback ?? throw new ArgumentNullException(nameof(callback));
        TrackbarName = trackbarName;
        WindowName = windowName;

        // userData wrapper             
        callbackNative = (pos, ud) => callback(pos);

        gchCallback = GCHandle.Alloc(callback);
        gchCallbackNative = GCHandle.Alloc(callbackNative);
        var callbackPtr = Marshal.GetFunctionPointerForDelegate(callbackNative);

        NativeMethods.HandleException(
            NativeMethods.highgui_createTrackbar(
                trackbarName, windowName, IntPtr.Zero, max, callbackPtr, IntPtr.Zero, out result));
            
        // Set initial trackbar position
        NativeMethods.HandleException(
            NativeMethods.highgui_setTrackbarPos(
                trackbarName, windowName, initialPos));

        if (result == 0)
            throw new OpenCvSharpException("Failed to create CvTrackbar.");
    }
        
    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        if (gchCallback.IsAllocated)
            gchCallback.Free();
        if (gchCallbackNative.IsAllocated)
            gchCallbackNative.Free();
        base.DisposeUnmanaged();
    }

    #endregion

    /// <summary>
    /// Sets the trackbar maximum position.
    /// The function sets the maximum position of the specified trackbar in the specified window.
    /// </summary>
    /// <param name="maxVal">New maximum position.</param>
    public void SetMax(int maxVal)
    {
        NativeMethods.HandleException(
            NativeMethods.highgui_setTrackbarMax(TrackbarName, WindowName, maxVal));
    }

    /// <summary>
    /// Sets the trackbar minimum position.
    /// The function sets the minimum position of the specified trackbar in the specified window.
    /// </summary>
    /// <param name="minVal">New minimum position.</param>
    public void SetMin(int minVal)
    {
        NativeMethods.HandleException(
            NativeMethods.highgui_setTrackbarMin(TrackbarName, WindowName, minVal));
    }
}
