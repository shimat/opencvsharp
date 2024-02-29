using System.Runtime.InteropServices;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;

// ReSharper disable UnusedMember.Local

namespace OpenCvSharp;

/// <summary>
/// Wrapper of HighGUI window
/// </summary>
public class Window : DisposableObject
{
    #region Field

    internal static Dictionary<string, Window> Windows = new Dictionary<string, Window>();
    private static uint windowCount;

    private string name;
    private Mat? image;
    private MouseCallback? mouseCallback;
    // ReSharper disable once IdentifierTypo
    private readonly Dictionary<string, CvTrackbar> trackbars;
    private ScopedGCHandle? callbackHandle;

    #endregion

    #region Init and Disposal

    /// <summary>
    /// Creates a window with a random name
    /// </summary>
    public Window()
        : this(DefaultName(), null, WindowFlags.AutoSize)
    {
    }

    /// <summary>
    /// Creates a window
    /// </summary>
    /// <param name="name">Name of the window which is used as window identifier and appears in the window caption. </param>
    public Window(string name)
        : this(name, null, WindowFlags.AutoSize)
    {
    }

    /// <summary>
    /// Creates a window
    /// </summary>
    /// <param name="name">Name of the window which is used as window identifier and appears in the window caption. </param>
    /// <param name="flags">Flags of the window. Currently the only supported flag is WindowMode.AutoSize. 
    /// If it is set, window size is automatically adjusted to fit the displayed image (see cvShowImage), while user can not change the window size manually. </param>
    public Window(string name, WindowFlags flags = WindowFlags.AutoSize)
        : this(name, null, flags)
    {
    }

    /// <summary>
    /// Creates a window
    /// </summary>
    /// <param name="name">Name of the window which is used as window identifier and appears in the window caption. </param>
    /// <param name="image">Image to be shown.</param>
    public Window(string name, Mat image)
        : this(name, image ?? throw new ArgumentNullException(nameof(image)), WindowFlags.AutoSize)
    {
    }

    /// <summary>
    /// Creates a window
    /// </summary>
    /// <param name="name">Name of the window which is used as window identifier and appears in the window caption. </param>
    /// <param name="image">Image to be shown.</param>
    /// <param name="flags">Flags of the window. Currently the only supported flag is WindowMode.AutoSize. 
    /// If it is set, window size is automatically adjusted to fit the displayed image (see cvShowImage), while user can not change the window size manually. </param>
    public Window(string name, Mat? image = null, WindowFlags flags = WindowFlags.AutoSize)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Null or empty window name.", nameof(name));
            
        this.name = name;
        NativeMethods.HandleException(
            NativeMethods.highgui_namedWindow(name, (int) flags));

        if (image is not null)
            ShowImage(image);
            
        trackbars = new Dictionary<string, CvTrackbar>();

        if (!Windows.ContainsKey(name))
            Windows.Add(name, this);
            
        callbackHandle = null;
    }

    /// <summary>
    /// ウィンドウ名が指定されなかったときに、適当な名前を作成して返す.
    /// </summary>
    /// <returns></returns>
    private static string DefaultName()
    {
        return $"window{windowCount++}";
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        foreach (var pair in trackbars)
        {
            pair.Value?.Dispose();
        }
        if (Windows.ContainsKey(name))
        {
            Windows.Remove(name);
        }
        if (callbackHandle is not null && callbackHandle.IsAllocated)
        {
            callbackHandle.Dispose();
        }

        NativeMethods.HandleException(
            NativeMethods.highgui_destroyWindow(name));

        base.DisposeManaged();
    }

    /// <summary>
    /// Destroys this window. 
    /// </summary>
    public void Close()
    {
        Dispose();
    }

    /// <summary>
    /// Destroys all the opened HighGUI windows. 
    /// </summary>
    public static void DestroyAllWindows()
    {
        foreach (var window in Windows.Values)
        {
            if (window is null || window.IsDisposed)
            {
                continue;
            }                
            NativeMethods.HandleException(
                NativeMethods.highgui_destroyWindow(window.name));
            foreach (var trackbar in window.trackbars.Values)
            {
                trackbar?.Dispose();
            }
            //w.Dispose();
        }
        Windows.Clear();

        NativeMethods.HandleException(
            NativeMethods.highgui_destroyAllWindows());
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets an image to be shown
    /// </summary>
    public Mat? Image
    {
        get => image;
        set => ShowImage(value);
    }

    /// <summary>
    /// Gets window name
    /// </summary>
    public string Name
    {
        get => name;
        private set => name = value;
    }

    /// <summary>
    /// 
    /// </summary>
    internal MouseCallback? MouseCallback
    {
        get => mouseCallback;
        set
        {
            if (callbackHandle is not null && callbackHandle.IsAllocated)
            {
                callbackHandle.Dispose();
            }
            mouseCallback = value;
            callbackHandle = (mouseCallback is null) ? null : new ScopedGCHandle(mouseCallback, GCHandleType.Normal);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Creates the trackbar and attaches it to this window
    /// </summary>
    /// <param name="trackbarName">Name of created trackbar. </param>
    /// <param name="callback">the function to be called every time the slider changes the position. This function should be prototyped as void Foo(int);</param>
    /// <returns></returns>
    public CvTrackbar CreateTrackbar(string trackbarName, TrackbarCallback callback)
    {
        var trackbar = new CvTrackbar(trackbarName, name, callback);
        trackbars.Add(trackbarName, trackbar);
        return trackbar;
    }

    /// <summary>
    /// Creates the trackbar and attaches it to this window
    /// </summary>
    /// <param name="trackbarName">Name of created trackbar. </param>
    /// <param name="initialPos">The position of the slider</param>
    /// <param name="max">Maximal position of the slider. Minimal position is always 0. </param>
    /// <param name="callback">the function to be called every time the slider changes the position. This function should be prototyped as void Foo(int);</param>
    /// <returns></returns>

    public CvTrackbar CreateTrackbar(string trackbarName, int initialPos, int max, TrackbarCallback callback)
    {
        var trackbar = new CvTrackbar(trackbarName, name, initialPos, max, callback);
        trackbars.Add(trackbarName, trackbar);
        return trackbar;
    }

    /// <summary>
    /// Display text on the window's image as an overlay for delay milliseconds. This is not editing the image's data. The text is display on the top of the image.
    /// </summary>
    /// <param name="text">Overlay text to write on the window’s image</param>
    /// <param name="delayMs">Delay to display the overlay text. If this function is called before the previous overlay text time out, the timer is restarted and the text updated.
    /// If this value is zero, the text never disappears.</param>
    public void DisplayOverlay(string text, int delayMs)
    {
        throw new NotImplementedException();
        //Cv.DisplayOverlay(name, text, delayms);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text">Text to write on the window’s statusbar</param>
    /// <param name="delayms">Delay to display the text. If this function is called before the previous text time out, the timer is restarted and the text updated. If this value is zero, the text never disapers.</param>
    public void DisplayStatusBar(string text, int delayms)
    {
        throw new NotImplementedException();
        //Cv.DisplayStatusBar(name, text, delayms);
    }

    /// <summary>
    /// Get Property of the window
    /// </summary>
    /// <param name="propId">Property identifier</param>
    /// <returns>Value of the specified property</returns>
    public double GetProperty(WindowPropertyFlags propId)
    {
        return Cv2.GetWindowProperty(name, propId);
    }
        
    /// <summary>
    /// Sets window position
    /// </summary>
    /// <param name="x">New x coordinate of top-left corner </param>
    /// <param name="y">New y coordinate of top-left corner </param>
    public void Move(int x, int y)
    {
        NativeMethods.HandleException(
            NativeMethods.highgui_moveWindow(name, x, y));
    }

    /// <summary>
    /// Sets window size
    /// </summary>
    /// <param name="width">New width </param>
    /// <param name="height">New height </param>
    public void Resize(int width, int height)
    {
        NativeMethods.HandleException(
            NativeMethods.highgui_resizeWindow(name, width, height));
    }

    /// <summary>
    /// Set Property of the window
    /// </summary>
    /// <param name="propId">Property identifier</param>
    /// <param name="propValue">New value of the specified property</param>
    public void SetProperty(WindowPropertyFlags propId, double propValue)
    {
        Cv2.SetWindowProperty(name, propId, propValue);
    }

    /// <summary>
    /// Shows the image in this window
    /// </summary>
    /// <param name="img">Image to be shown. </param>
    public void ShowImage(Mat? img)
    {
        if (img is not null)
        {
            image = img;
            NativeMethods.HandleException(
                NativeMethods.highgui_imshow(name, img.CvPtr));
            GC.KeepAlive(img);
        }
    }

    /// <summary>
    /// Shows the image in this window
    /// </summary>
    /// <param name="img">Image to be shown. </param>
    public void ShowImage(UMat? img)
    {
        if (img is not null)
        {
            //image = img;
            NativeMethods.HandleException(
                NativeMethods.highgui_imshow_umat(name, img.CvPtr));
            GC.KeepAlive(img);
        }
    }

    /// <summary>
    /// get native window handle (HWND in case of Win32 and Widget in case of X Window) 
    /// </summary>
    public IntPtr GetHandle()
    {
        NativeMethods.HandleException(
            NativeMethods.highgui_cvGetWindowHandle(name, out var ret));
        return ret;
    }

    /// <summary>
    /// Waits for a pressed key
    /// </summary>
    /// <param name="delay">Delay in milliseconds. </param>
    /// <returns>Key code</returns>
    public static int WaitKey(int delay = 0)
    {
        return Cv2.WaitKey(delay);
    }

    /// <summary>
    /// Waits for a pressed key.
    /// Similar to #waitKey, but returns full key code. 
    /// Key code is implementation specific and depends on used backend: QT/GTK/Win32/etc
    /// </summary>
    /// <param name="delay">Delay in milliseconds. 0 is the special value that means ”forever”</param>
    /// <returns>Returns the code of the pressed key or -1 if no key was pressed before the specified time had elapsed.</returns>
    public static int WaitKeyEx(int delay = 0)
    {
        return Cv2.WaitKeyEx(delay);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="images"></param>
    public static void ShowImages(params Mat[] images)
    {
        if (images is null)            
            throw new ArgumentNullException(nameof(images));
        if (images.Length == 0)
            return;

        var windows = new List<Window>();
        foreach (var img in images)
        {
            windows.Add(new Window { Image = img });
        }

        WaitKey();

        foreach (var w in windows)
        {
            w.Close();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="images"></param>
    /// <param name="names"></param>
    public static void ShowImages(IEnumerable<Mat> images, IEnumerable<string> names)
    {
        if (images is null)
            throw new ArgumentNullException(nameof(images));
        if (names is null)
            throw new ArgumentNullException(nameof(names));

        var imagesArray = images.ToArray();
        var namesArray = names.ToArray();

        if (imagesArray.Length == 0)
            return;
        if (namesArray.Length < imagesArray.Length)
            throw new ArgumentException("names.Length < images.Length");

        var windows = new List<Window>();
        for (var i = 0; i < imagesArray.Length; i++)
        {
            windows.Add(new Window(namesArray[i], image: imagesArray[i]));
        }

        Cv2.WaitKey();

        foreach (var w in windows)
        {
            w.Close();
        }
    }
        
    /// <summary>
    /// Retrieves a created window by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Window? GetWindowByName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));
            
        if (Windows.ContainsKey(name))
            return Windows[name];
            
        return null;
    }

    /// <summary>
    /// Sets the callback function for mouse events occuting within the specified window.
    /// </summary>
    /// <param name="onMouse">Reference to the function to be called every time mouse event occurs in the specified window. </param>
    /// <param name="userData"></param>
    public void SetMouseCallback(MouseCallback onMouse, IntPtr userData = default)
    {
        Cv2.SetMouseCallback(name, onMouse, userData);
    }

    #endregion
}
