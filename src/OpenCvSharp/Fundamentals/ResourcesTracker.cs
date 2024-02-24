namespace OpenCvSharp;

/// <summary>
/// Used for managing the resources of OpenCVSharp, like Mat, MatExpr, etc.
/// </summary>
public sealed class ResourcesTracker : IDisposable
{
    private readonly ISet<DisposableObject> trackedObjects = new HashSet<DisposableObject>();
    private readonly object asyncLock = new ();

    /// <summary>
    /// Trace the object obj, and return it
    /// </summary>
    /// <typeparam name="TCvObject"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public TCvObject T<TCvObject>(TCvObject obj) 
        where TCvObject : DisposableObject
    {
        if (obj is null)
            throw new ArgumentNullException(nameof(obj));

        lock (asyncLock)
        {
            trackedObjects.Add(obj);
        }
        return obj;
    }

    /// <summary>
    /// Trace an array of objects , and return them
    /// </summary>
    /// <typeparam name="TCvObject"></typeparam>
    /// <param name="objects"></param>
    /// <returns></returns>
    public TCvObject[] T<TCvObject>(TCvObject[] objects)
        where TCvObject : DisposableObject
    {
        if (objects is null)
            throw new ArgumentNullException(nameof(objects));

        foreach (var obj in objects)
        {
            T(obj);
        }
        return objects;
    }

    /// <summary>
    /// Create a new Mat instance, and trace it
    /// </summary>
    /// <returns></returns>
    public Mat NewMat()
    {
        return T(new Mat());
    }

    /// <summary>
    ///  Create a new Mat instance, and trace it
    /// </summary>
    /// <param name="size">size</param>
    /// <param name="matType">matType</param>
    /// <param name="scalar">scalar</param>
    /// <returns></returns>
    public Mat NewMat(Size size, MatType matType, Scalar scalar)
    {
        return T(new Mat(size, matType, scalar));
    }

    /// <summary>
    /// Create a new UMat instance, and trace it
    /// </summary>
    /// <returns></returns>
    public UMat NewUMat()
    {
        return T(new UMat());
    }

    /// <summary>
    ///  Create a new UMat instance, and trace it
    /// </summary>
    /// <param name="size">size</param>
    /// <param name="matType">matType</param>
    /// <param name="scalar">scalar</param>
    /// <returns></returns>
    public UMat NewUMat(Size size, MatType matType, Scalar scalar)
    {
        return T(new UMat(size, matType, scalar));
    }

    /// <summary>
    /// Dispose all traced objects
    /// </summary>
    public void Dispose()
    {
        lock (asyncLock)
        {
            foreach (var obj in trackedObjects)
            {
                if (obj.IsDisposed == false)
                {
                    obj.Dispose();
                }
            }
            trackedObjects.Clear();
        }
    }
}
