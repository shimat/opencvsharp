using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// Template class for smart reference-counting pointers
/// </summary>
public abstract class Ptr : DisposableCvObject
{
    /// <summary>
    /// Constructor.
    /// When <paramref name="releaseAction"/> is provided, the pointer is wrapped
    /// in an owning SafeHandle that will call the action on disposal.
    /// Otherwise a non-owning SafeHandle is created (e.g. for base-only initialization
    /// before a derived class replaces it).
    /// </summary>
    /// <param name="ptr">The native cv::Ptr handle.</param>
    /// <param name="releaseAction">
    /// Optional release action. When non-null the SafeHandle owns the pointer
    /// and will invoke this action during disposal.
    /// </param>
    protected Ptr(IntPtr ptr, Action<IntPtr>? releaseAction = null)
    {
        if (ptr != IntPtr.Zero)
            SetSafeHandle(new OpenCvPtrSafeHandle(ptr, ownsHandle: releaseAction is not null, releaseAction: releaseAction));
    }

    /// <summary>
    /// Returns Ptr&lt;T&gt;.get() pointer
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1716: Identifiers should not match keywords")]
    public abstract IntPtr Get();
}
