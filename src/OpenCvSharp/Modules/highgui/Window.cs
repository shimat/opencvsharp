using System.Collections.Concurrent;
using System.Threading;
using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Local

namespace OpenCvSharp;

/// <summary>
/// Wrapper of HighGUI window
/// </summary>
public sealed class Window : IDisposable
{
    #region Field

    internal static readonly ConcurrentDictionary<string, Window> Windows = new();
    private static int windowCount;

    private readonly string name;
    private Mat? image;
    // ReSharper disable once IdentifierTypo
    private readonly Dictionary<string, CvTrackbar> trackbars;

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

        Windows[name] = this;
    }

    /// <summary>
    /// Creates a fallback window name when none is supplied.
    /// </summary>
    /// <returns></returns>
    private static string DefaultName()
    {
        return $"window{Interlocked.Increment(ref windowCount) - 1}";
    }

    /// <summary>
    /// Gets whether this window has already been destroyed.
    /// </summary>
    public bool IsDisposed { get; private set; }

    /// <summary>
    /// Destroys this window.
    /// </summary>
    public void Dispose()
    {
        if (IsDisposed)
            return;
        IsDisposed = true;

        Windows.TryRemove(name, out _);
        trackbars.Clear();

        // Destroying the window also releases OpenCV's references to its mouse/trackbar
        // callbacks (Cv2.DestroyWindow forgets the registered delegates).
        Cv2.DestroyWindow(name);
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
        Windows.Clear();
        Cv2.DestroyAllWindows();
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
    public string Name => name;

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
        trackbars[trackbarName] = trackbar;
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
        var trackbar = new CvTrackbar(trackbarName, name, callback, initialPos, max);
        trackbars[trackbarName] = trackbar;
        return trackbar;
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

        ShowImagesAndWaitKey(images.Select(img => new Window { Image = img }));
    }

    /// <summary>
    /// Shows each of the given (title, image) pairs in its own window.
    /// Pairing each title with its image in a single tuple makes a length mismatch
    /// between titles and images structurally impossible.
    /// </summary>
    /// <param name="images">Pairs of window title and image to display</param>
    public static void ShowImages(params (string Title, Mat Image)[] images)
    {
        if (images is null)
            throw new ArgumentNullException(nameof(images));

        ShowImagesAndWaitKey(images.Select(t => new Window(t.Title, image: t.Image)));
    }

    /// <summary>
    /// Opens the given windows, blocks until a key is pressed, then closes them all.
    /// </summary>
    private static void ShowImagesAndWaitKey(IEnumerable<Window> windows)
    {
        var windowList = windows.ToList();
        if (windowList.Count == 0)
            return;

        WaitKey();

        foreach (var w in windowList)
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

        if (Windows.TryGetValue(name, out var window))
            return window;

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
