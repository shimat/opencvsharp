using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvSubdiv2D
    {
        public int flags;
        public int header_size;
        public void* h_prev;
        public void* h_next;
        public void* v_prev;
        public void* v_next;

        public int total;
        public int elem_size;
        public sbyte* block_max;
        public sbyte* ptr;
        public int delta_elems;
        public void* storage;
        public void* free_blocks;
        public void* first;

        public void* free_elems;
        public int active_count;

        public void* edges;

        public int quad_edges;
        public int is_geometry_valid;
        public CvSubdiv2DEdge recent_edge;
        public CvPoint2D32f topleft;
        public CvPoint2D32f bottomright;
    }
}
