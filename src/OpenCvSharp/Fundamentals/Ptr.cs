using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// Template class for smart reference-counting pointers
/// </summary>
public abstract class Ptr : DisposableCvObject
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ptr"></param>
    protected Ptr(IntPtr ptr)
    {
        this.ptr = ptr;
    }

    /// <summary>
    /// Returns Ptr&lt;T&gt;.get() pointer
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1716: Identifiers should not match keywords")]
    public abstract IntPtr Get();
}
