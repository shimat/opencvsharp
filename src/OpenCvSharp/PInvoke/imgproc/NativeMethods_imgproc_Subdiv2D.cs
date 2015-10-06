using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_Subdiv2D_new1")]
        public static extern IntPtr imgproc_Subdiv2D_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_Subdiv2D_new2")]
        public static extern IntPtr imgproc_Subdiv2D_new(Rect rect);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Subdiv2D_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Subdiv2D_initDelaunay(IntPtr obj, Rect rect);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_Subdiv2D_insert1")]
        public static extern int imgproc_Subdiv2D_insert(IntPtr obj, Point2f pt);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_Subdiv2D_insert2")]
        public static extern void imgproc_Subdiv2D_insert(IntPtr obj, [MarshalAs(UnmanagedType.LPArray)] Point2f[] ptArray, int length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_Subdiv2D_locate(IntPtr obj, Point2f pt, out int edge, out int vertex);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_Subdiv2D_findNearest(IntPtr obj, Point2f pt, out Point2f nearestPt);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Subdiv2D_getEdgeList(IntPtr obj, out IntPtr edgeList);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Subdiv2D_getTriangleList(IntPtr obj, out IntPtr triangleList);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Subdiv2D_getVoronoiFacetList(IntPtr obj, [MarshalAs(UnmanagedType.LPArray)] int[] idx, int idxCount,
            out IntPtr facetList, out IntPtr facetCenters);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Subdiv2D_getVoronoiFacetList(IntPtr obj, IntPtr idx, int idxCount,
            out IntPtr facetList, out IntPtr facetCenters);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern Point2f imgproc_Subdiv2D_getVertex(IntPtr obj, int vertex, out int firstEdge);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_Subdiv2D_getEdge(IntPtr obj, int edge, int nextEdgeType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_Subdiv2D_nextEdge(IntPtr obj, int edge);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_Subdiv2D_rotateEdge(IntPtr obj, int edge, int rotate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_Subdiv2D_symEdge(IntPtr obj, int edge);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_Subdiv2D_edgeOrg(IntPtr obj, int edge, out Point2f orgpt);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_Subdiv2D_edgeDst(IntPtr obj, int edge, out Point2f dstpt);

    }
}