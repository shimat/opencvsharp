using OpenCvSharp.Flann;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Brute-force descriptor matcher.
/// For each descriptor in the first set, this matcher finds the closest descriptor in the second set by trying each one.
/// </summary>
public class FlannBasedMatcher : DescriptorMatcher
{
    private IndexParams? indexParams;
    private SearchParams? searchParams;

    /// <summary>
    /// 
    /// </summary>
    protected FlannBasedMatcher()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="indexParams"></param>
    /// <param name="searchParams"></param>
    public FlannBasedMatcher(IndexParams? indexParams = null, SearchParams? searchParams = null)
    {
        indexParams?.ThrowIfDisposed();
        searchParams?.ThrowIfDisposed();

        var indexParamsPtr = indexParams?.CvPtr ?? IntPtr.Zero;
        var searchParamsPtr = searchParams?.CvPtr ?? IntPtr.Zero;
        NativeMethods.HandleException(
            NativeMethods.features2d_FlannBasedMatcher_new(indexParamsPtr, searchParamsPtr, out var p));
        this.indexParams = indexParams;
        this.searchParams = searchParams;
        InitSafeHandle(p);
    }

    /// <summary>
    /// Creates instance by raw pointer T*
    /// </summary>
    internal FlannBasedMatcher(IntPtr rawPtr)
    {
        InitSafeHandle(rawPtr);
    }

    /// <summary>
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes. 
    /// </summary>
    /// <param name="ptr"></param>
    internal new static FlannBasedMatcher FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid cv::Ptr<FlannBasedMatcher> pointer");
        var matcher = new FlannBasedMatcher();
        matcher.SetSafeHandle(new OpenCvPtrSafeHandle(ptr, ownsHandle: true,
            _ => NativeMethods.HandleException(NativeMethods.features2d_Ptr_FlannBasedMatcher_delete(ptr))));
        return matcher;
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        indexParams = null;
        searchParams = null;
        base.DisposeUnmanaged();
    }

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.features2d_FlannBasedMatcher_delete(h))));
    }
        
    /// <summary>
    /// Return true if the matcher supports mask in match methods.
    /// </summary>
    /// <returns></returns>
    public override bool IsMaskSupported()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.features2d_FlannBasedMatcher_isMaskSupported(ptr, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }

    /// <summary>
    /// Add descriptors to train descriptor collection.
    /// </summary>
    /// <param name="descriptors">Descriptors to add. Each descriptors[i] is a descriptors set from one image.</param>
    public override void Add(IEnumerable<Mat> descriptors)
    {
        ThrowIfDisposed();
        if (descriptors is null)
            throw new ArgumentNullException(nameof(descriptors));

        var descriptorsArray = descriptors.ToArray();
        if (descriptorsArray.Length == 0)
            return;

        var descriptorsPtrs = descriptorsArray.Select(x => x.CvPtr).ToArray();
        NativeMethods.HandleException(
            NativeMethods.features2d_DescriptorMatcher_add(ptr, descriptorsPtrs, descriptorsPtrs.Length));
        GC.KeepAlive(descriptorsArray);
    }

    /// <summary>
    /// Clear train descriptors collection.
    /// </summary>
    public override void Clear()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.features2d_FlannBasedMatcher_clear(ptr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Train matcher (e.g. train flann index).
    /// In all methods to match the method train() is run every time before matching.
    /// Some descriptor matchers (e.g. BruteForceMatcher) have empty implementation
    /// of this method, other matchers really train their inner structures
    /// (e.g. FlannBasedMatcher trains flann::Index). So nonempty implementation
    /// of train() should check the class object state and do traing/retraining
    /// only if the state requires that (e.g. FlannBasedMatcher trains flann::Index
    /// if it has not trained yet or if new descriptors have been added to the train collection).
    /// </summary>
    public override void Train()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.features2d_FlannBasedMatcher_train(ptr));
        GC.KeepAlive(this);
    }
}
