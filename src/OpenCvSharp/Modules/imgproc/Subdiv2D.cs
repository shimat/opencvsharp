using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp;

/// <summary>
/// Planar Subdivision
/// </summary>
public class Subdiv2D : DisposableCvObject
{
    #region Init and Disposal

    /// <summary>
    /// Creates an empty Subdiv2D object.
    /// To create a new empty Delaunay subdivision you need to use the #initDelaunay function.
    /// </summary>
    public Subdiv2D()
    {
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_new1(out ptr));
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(Subdiv2D)}");
    }

    /// <summary>
    /// Creates an empty Subdiv2D object.
    /// </summary>
    /// <param name="rect">Rectangle that includes all of the 2D points that are to be added to the subdivision.</param>
    public Subdiv2D(Rect rect)
    {
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_new2(rect, out ptr));
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(Subdiv2D)}");
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    public void Release()
    {
        Dispose();
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_delete(ptr));
        base.DisposeUnmanaged();
    }
        
    #endregion

    #region Constants
        
#pragma warning disable 1591
    public const int
        PTLOC_ERROR = -2,
        PTLOC_OUTSIDE_RECT = -1,
        PTLOC_INSIDE = 0,
        PTLOC_VERTEX = 1,
        PTLOC_ON_EDGE = 2;
    public const int
        NEXT_AROUND_ORG = 0x00,
        NEXT_AROUND_DST = 0x22,
        PREV_AROUND_ORG = 0x11,
        PREV_AROUND_DST = 0x33,
        NEXT_AROUND_LEFT = 0x13,
        NEXT_AROUND_RIGHT = 0x31,
        PREV_AROUND_LEFT = 0x20,
        PREV_AROUND_RIGHT = 0x02;
#pragma warning restore 1591

    #endregion

    #region Methods

    /// <summary>
    /// Creates a new empty Delaunay subdivision
    /// </summary>
    /// <param name="rect">Rectangle that includes all of the 2D points that are to be added to the subdivision.</param>
    public void InitDelaunay(Rect rect)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_initDelaunay(ptr, rect));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Insert a single point into a Delaunay triangulation.
    /// </summary>
    /// <param name="pt">Point to insert.</param>
    /// <returns></returns>
    public int Insert(Point2f pt)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_insert1(ptr, pt, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Insert multiple points into a Delaunay triangulation.
    /// </summary>
    /// <param name="ptVec">Points to insert.</param>
    public void Insert(IEnumerable<Point2f> ptVec)
    {
        ThrowIfDisposed();
        if (ptVec is null)
            throw new ArgumentNullException(nameof(ptVec));

        var ptVecArray = ptVec.CastOrToArray();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_insert2(ptr, ptVecArray, ptVecArray.Length));

        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns the location of a point within a Delaunay triangulation.
    /// </summary>
    /// <param name="pt">Point to locate.</param>
    /// <param name="edge">Output edge that the point belongs to or is located to the right of it.</param>
    /// <param name="vertex">Optional output vertex the input point coincides with.</param>
    /// <returns>an integer which specify one of the following five cases for point location:
    /// -  The point falls into some facet. The function returns #PTLOC_INSIDE and edge will contain one of edges of the facet.
    /// -  The point falls onto the edge. The function returns #PTLOC_ON_EDGE and edge will contain this edge.
    /// -  The point coincides with one of the subdivision vertices. The function returns #PTLOC_VERTEX and vertex will contain a pointer to the vertex.
    /// -  The point is outside the subdivision reference rectangle. The function returns #PTLOC_OUTSIDE_RECT and no pointers are filled.
    /// -  One of input arguments is invalid. A runtime error is raised or, if silent or "parent" error processing mode is selected, #PTLOC_ERROR is returned.</returns>
    public int Locate(Point2f pt, out int edge, out int vertex)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_locate(ptr, pt, out edge, out vertex, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Finds the subdivision vertex closest to the given point.
    /// </summary>
    /// <param name="pt">Input point.</param>
    /// <param name="nearestPt">Output subdivision vertex point.</param>
    /// <returns>vertex ID.</returns>
    public int FindNearest(Point2f pt, out Point2f nearestPt)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_findNearest(ptr, pt, out nearestPt, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Returns a list of all edges.
    /// </summary>
    /// <returns>Output vector.</returns>
    public Vec4f[] GetEdgeList()
    {
        ThrowIfDisposed();
        using var vec = new VectorOfVec4f();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_getEdgeList(ptr, vec.CvPtr));
        GC.KeepAlive(this);
        return vec.ToArray();
    }

    /// <summary>
    /// Returns a list of the leading edge ID connected to each triangle.
    /// The function gives one edge ID for each triangle.
    /// </summary>
    /// <returns>Output vector.</returns>
    public int[] GetLeadingEdgeList()
    {
        ThrowIfDisposed();

        using var leadingEdgeList = new VectorOfInt32();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_getLeadingEdgeList(ptr, leadingEdgeList.CvPtr));
            
        GC.KeepAlive(this);
        return leadingEdgeList.ToArray();
    }

    /// <summary>
    /// Returns a list of all triangles.
    /// </summary>
    /// <returns>Output vector.</returns>
    public Vec6f[] GetTriangleList()
    {
        ThrowIfDisposed();
        using var vec = new VectorOfVec6f();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_getTriangleList(ptr, vec.CvPtr));
        GC.KeepAlive(this);
        return vec.ToArray();
    }

    /// <summary>
    /// Returns a list of all Voronoi facets.
    /// </summary>
    /// <param name="idx">Vector of vertices IDs to consider. For all vertices you can pass empty vector.</param>
    /// <param name="facetList">Output vector of the Voronoi facets.</param>
    /// <param name="facetCenters">Output vector of the Voronoi facets center points.</param>
    public void GetVoronoiFacetList(IEnumerable<int>? idx, out Point2f[][] facetList, out Point2f[] facetCenters)
    {
        ThrowIfDisposed();

        int[]? idxArray = idx?.CastOrToArray();
        using var facetListVec = new VectorOfVectorPoint2f();
        using var facetCentersVec = new VectorOfPoint2f();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_getVoronoiFacetList(
                ptr, idxArray, idxArray?.Length ?? 0, facetListVec.CvPtr, facetCentersVec.CvPtr));
        GC.KeepAlive(this);
        facetList = facetListVec.ToArray();
        facetCenters = facetCentersVec.ToArray();
    }

    /// <summary>
    /// Returns vertex location from vertex ID.
    /// </summary>
    /// <param name="vertex">vertex ID.</param>
    /// <param name="firstEdge">The first edge ID which is connected to the vertex.</param>
    /// <returns>vertex (x,y)</returns>
    public Point2f GetVertex(int vertex, out int firstEdge)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_getVertex(ptr, vertex, out firstEdge, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Returns one of the edges related to the given edge.
    /// </summary>
    /// <param name="edge">Subdivision edge ID.</param>
    /// <param name="nextEdgeType">Parameter specifying which of the related edges to return.
    /// The following values are possible:
    /// -   NEXT_AROUND_ORG next around the edge origin ( eOnext on the picture below if e is the input edge)
    /// -   NEXT_AROUND_DST next around the edge vertex ( eDnext )
    /// -   PREV_AROUND_ORG previous around the edge origin (reversed eRnext )
    /// -   PREV_AROUND_DST previous around the edge destination (reversed eLnext )
    /// -   NEXT_AROUND_LEFT next around the left facet ( eLnext )
    /// -   NEXT_AROUND_RIGHT next around the right facet ( eRnext )
    /// -   PREV_AROUND_LEFT previous around the left facet (reversed eOnext )
    /// -   PREV_AROUND_RIGHT previous around the right facet (reversed eDnext )</param>
    /// <returns></returns>
    public int GetEdge(int edge, NextEdgeType nextEdgeType)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_getEdge(ptr, edge, (int)nextEdgeType, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Subdivision edge ID.
    /// </summary>
    /// <param name="edge">Subdivision edge ID.</param>
    /// <returns>an integer which is next edge ID around the edge origin: eOnext on the picture above if e is the input edge).</returns>
    public int NextEdge(int edge)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_nextEdge(ptr, edge, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Returns another edge of the same quad-edge.
    /// </summary>
    /// <param name="edge">Subdivision edge ID.</param>
    /// <param name="rotate">Parameter specifying which of the edges of the same quad-edge as the input
    /// one to return. The following values are possible:
    /// -   0 - the input edge ( e on the picture below if e is the input edge)
    /// -   1 - the rotated edge ( eRot )
    /// -   2 - the reversed edge (reversed e (in green))
    /// -   3 - the reversed rotated edge (reversed eRot (in green))</param>
    /// <returns>one of the edges ID of the same quad-edge as the input edge.</returns>
    public int RotateEdge(int edge, int rotate)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_rotateEdge(ptr, edge, rotate, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="edge"></param>
    /// <returns></returns>
    public int SymEdge(int edge)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_symEdge(ptr, edge, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Returns the edge origin.
    /// </summary>
    /// <param name="edge">Subdivision edge ID.</param>
    /// <param name="orgPt">Output vertex location.</param>
    /// <returns>vertex ID.</returns>
    public int EdgeOrg(int edge, out Point2f orgPt)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_edgeOrg(ptr, edge, out orgPt, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Returns the edge destination.
    /// </summary>
    /// <param name="edge">Subdivision edge ID.</param>
    /// <param name="dstPt">Output vertex location.</param>
    /// <returns>vertex ID.</returns>
    public int EdgeDst(int edge, out Point2f dstPt)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_Subdiv2D_edgeDst(ptr, edge, out dstPt, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    #endregion
}
    
/// <summary>
/// Parameter for Subdiv2D.GetEdge() specifying which of the related edges to return.
/// </summary>
public enum NextEdgeType
{
    /// <summary>
    /// next around the edge origin ( eOnext on the picture below if e is the input edge)
    /// </summary>
    NEXT_AROUND_ORG = 0x00,

    /// <summary>
    /// next around the edge vertex ( eDnext )
    /// </summary>
    NEXT_AROUND_DST = 0x22,

    /// <summary>
    /// previous around the edge origin (reversed eRnext )
    /// </summary>
    PREV_AROUND_ORG = 0x11,

    /// <summary>
    /// previous around the edge destination (reversed eLnext )
    /// </summary>
    PREV_AROUND_DST = 0x33,

    /// <summary>
    /// next around the left facet ( eLnext )
    /// </summary>
    NEXT_AROUND_LEFT = 0x13,

    /// <summary>
    /// next around the right facet ( eRnext )
    /// </summary>
    NEXT_AROUND_RIGHT = 0x31,

    /// <summary>
    /// previous around the left facet (reversed eOnext )
    /// </summary>
    PREV_AROUND_LEFT = 0x20,

    /// <summary>
    /// previous around the right facet (reversed eDnext )
    /// </summary>
    PREV_AROUND_RIGHT = 0x02
}
