using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.XImgProc;

/// <summary>
/// Class implementing EdgeBoxes algorithm from @cite ZitnickECCV14edgeBoxes
/// </summary>
public class EdgeBoxes : Algorithm
{
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private EdgeBoxes(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_EdgeBoxes_delete(p)))
    { }
    /// <summary>
    /// Creates a EdgeBoxes
    /// </summary>
    /// <param name="alpha">step size of sliding window search.</param>
    /// <param name="beta">nms threshold for object proposals.</param>
    /// <param name="eta">adaptation rate for nms threshold.</param>
    /// <param name="minScore">min score of boxes to detect.</param>
    /// <param name="maxBoxes">max number of boxes to detect.</param>
    /// <param name="edgeMinMag">edge min magnitude. Increase to trade off accuracy for speed.</param>
    /// <param name="edgeMergeThr">edge merge threshold. Increase to trade off accuracy for speed.</param>
    /// <param name="clusterMinMag">cluster min magnitude. Increase to trade off accuracy for speed.</param>
    /// <param name="maxAspectRatio">max aspect ratio of boxes.</param>
    /// <param name="minBoxArea">minimum area of boxes.</param>
    /// <param name="gamma">affinity sensitivity.</param>
    /// <param name="kappa">scale sensitivity.</param>
    /// <returns></returns>
    public static EdgeBoxes Create(
        float alpha = 0.65f,
        float beta = 0.75f,
        float eta = 1,
        float minScore = 0.01f,
        int maxBoxes = 10000,
        float edgeMinMag = 0.1f,
        float edgeMergeThr = 0.5f,
        float clusterMinMag = 0.5f,
        float maxAspectRatio = 3,
        float minBoxArea = 1000,
        float gamma = 2,
        float kappa = 1.5f)
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_createEdgeBoxes(
                alpha, beta, eta, minScore, maxBoxes, edgeMinMag, edgeMergeThr,
                clusterMinMag, maxAspectRatio, minBoxArea, gamma, kappa, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_EdgeBoxes_get(smartPtr, out var rawPtr));
        return new EdgeBoxes(smartPtr, rawPtr);
    }

    /// <summary>
    /// Gets or sets the step size of sliding window search.
    /// </summary>
    public virtual float Alpha
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getAlpha(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setAlpha(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the nms threshold for object proposals.
    /// </summary>
    public virtual float Beta
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getBeta(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setBeta(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets adaptation rate for nms threshold.
    /// </summary>
    public virtual float Eta
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getEta(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setEta(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the min score of boxes to detect.
    /// </summary>
    public virtual float MinScore
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getMinScore(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setMinScore(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the max number of boxes to detect.
    /// </summary>
    public virtual int MaxBoxes
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getMaxBoxes(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setMaxBoxes(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the edge min magnitude.
    /// </summary>
    public virtual float EdgeMinMag
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getEdgeMinMag(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setEdgeMinMag(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the edge merge threshold.
    /// </summary>
    public virtual float EdgeMergeThr
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getEdgeMergeThr(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setEdgeMergeThr(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the cluster min magnitude.
    /// </summary>
    public virtual float ClusterMinMag
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getClusterMinMag(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setClusterMinMag(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the max aspect ratio of boxes.
    /// </summary>
    public virtual float MaxAspectRatio
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getMaxAspectRatio(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setMaxAspectRatio(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the minimum area of boxes.
    /// </summary>
    public virtual float MinBoxArea
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getMinBoxArea(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setMinBoxArea(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the affinity sensitivity.
    /// </summary>
    public virtual float Gamma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getGamma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setGamma(Handle, value));
        }
    }

    /// <summary>
    /// Gets or sets the scale sensitivity.
    /// </summary>
    public virtual float Kappa
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_getKappa(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_EdgeBoxes_setKappa(Handle, value));
        }
    }

    /// <summary>
    /// Returns array containing proposal boxes.
    /// </summary>
    /// <param name="edgeMap">edge image.</param>
    /// <param name="orientationMap">orientation map.</param>
    /// <param name="boxes">proposal boxes.</param>
    public virtual void GetBoundingBoxes(InputArray edgeMap, InputArray orientationMap, out Rect[] boxes)
    {
        ThrowIfDisposed();
        if (edgeMap is null)
            throw new ArgumentNullException(nameof(edgeMap));
        if (orientationMap is null)
            throw new ArgumentNullException(nameof(orientationMap));
        edgeMap.ThrowIfDisposed();
        orientationMap.ThrowIfDisposed();

        using var boxesVec = new StdVector<Rect>();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeBoxes_getBoundingBoxes(
                Handle, edgeMap.CvPtr, orientationMap.CvPtr, boxesVec.CvPtr));
        boxes = boxesVec.ToArray();

        GC.KeepAlive(edgeMap);
        GC.KeepAlive(orientationMap);
    }
}
