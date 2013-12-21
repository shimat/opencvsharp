using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// ドロネー
    /// </summary>
    /// <remarks>samples/c/delaunay.c から改変</remarks>
    class Delaunay
    {        
        public Delaunay()
        {
            CvRect rect = new CvRect(0, 0, 600, 600);
            CvColor activeFacetColor = new CvColor(255, 0, 0);
            CvColor delaunayColor = new CvColor(0, 0, 0);
            CvColor voronoiColor = new CvColor(0, 180, 0);
            CvColor bkgndColor = new CvColor(255, 255, 255);
            Random rand = new Random();
            
            using (CvMemStorage storage = new CvMemStorage(0))
            using (IplImage img = new IplImage(rect.Size, BitDepth.U8, 3))
            using (CvWindow window = new CvWindow("delaunay"))
            {
                img.Set(bkgndColor);
                CvSubdiv2D subdiv = new CvSubdiv2D(rect, storage);
                for (int i = 0; i < 200; i++)
                {
                    CvPoint2D32f fp = new CvPoint2D32f
                    {
                        X = (float)rand.Next(5, rect.Width - 10),
                        Y = (float)rand.Next(5, rect.Height - 10)
                    };
                    LocatePoint(subdiv, fp, img, activeFacetColor);
                    window.Image = img;

                    if (CvWindow.WaitKey(100) >= 0)
                    {
                        break;
                    }
                    subdiv.Insert(fp);
                    subdiv.CalcVoronoi2D();
                    img.Set(bkgndColor);
                    DrawSubdiv(img, subdiv, delaunayColor, voronoiColor);
                    window.Image = img;
                    if (CvWindow.WaitKey(100) >= 0)
                    {
                        break;
                    }
                }
                img.Set(bkgndColor);
                PaintVoronoi(subdiv, img);
                window.Image = img;

                CvWindow.WaitKey(0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subdiv"></param>
        /// <param name="fp"></param>
        /// <param name="img"></param>
        /// <param name="active_color"></param>
        private void LocatePoint(CvSubdiv2D subdiv, CvPoint2D32f fp, IplImage img, CvScalar active_color)
        {
            CvSubdiv2DEdge e;
            CvSubdiv2DEdge e0 = 0;

            subdiv.Locate(fp, out e0);

            if (e0 != 0)
            {
                e = e0;
                do
                {
                    //Console.WriteLine(e);
                    DrawSubdivEdge(img, e, active_color);
                    e = e.GetEdge(CvNextEdgeType.NextAroundLeft);                    
                }
                while (e != e0);
            }

            DrawSubdivPoint(img, fp, active_color);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="subdiv"></param>
        /// <param name="delaunay_color"></param>
        /// <param name="voronoi_color"></param>
        private void DrawSubdiv(IplImage img, CvSubdiv2D subdiv, CvColor delaunay_color, CvColor voronoi_color)
        {
            CvSeqReader reader = new CvSeqReader();
            int total = subdiv.Edges.Total;
            int elem_size = subdiv.Edges.ElemSize;

            subdiv.Edges.StartRead(reader, false);

            for (int i = 0; i < total; i++)
            {
                //CvQuadEdge2D edge = (CvQuadEdge2D)reader.CvPtr;
                CvQuadEdge2D edge = CvQuadEdge2D.FromSeqReader(reader);

                if (Cv.IS_SET_ELEM(edge))
                {
                    DrawSubdivEdge(img, (CvSubdiv2DEdge)edge + 1, voronoi_color);
                    DrawSubdivEdge(img, (CvSubdiv2DEdge)edge, delaunay_color);
                }

                //reader.NextSeqElem(elem_size);
                Cv.NEXT_SEQ_ELEM(elem_size, reader);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="edge"></param>
        /// <param name="color"></param>
        private void DrawSubdivEdge(IplImage img, CvSubdiv2DEdge edge, CvScalar color)
        {
            CvSubdiv2DPoint org_pt = edge.Org();
            CvSubdiv2DPoint dst_pt = edge.Dst();

            if (org_pt != null && dst_pt != null)
            {
                CvPoint2D32f org = org_pt.Pt;
                CvPoint2D32f dst = dst_pt.Pt;

                CvPoint iorg = new CvPoint(Cv.Round(org.X), Cv.Round(org.Y));
                CvPoint idst = new CvPoint(Cv.Round(dst.X), Cv.Round(dst.Y));

                //Console.WriteLine("{0} / {1}", iorg, idst);
                img.Line(iorg, idst, color, 1, LineType.AntiAlias, 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subdiv"></param>
        /// <param name="img"></param>
        private void PaintVoronoi(CvSubdiv2D subdiv, IplImage img)
        {
            CvSeqReader reader = new CvSeqReader();
            int total = subdiv.Edges.Total;
            int elem_size = subdiv.Edges.ElemSize;

            subdiv.CalcVoronoi2D();

            subdiv.Edges.StartRead(reader, false);

            for (int i = 0; i < total; i++)
            {
                CvQuadEdge2D edge = CvQuadEdge2D.FromSeqReader(reader);
                //CvQuadEdge2D edge = CvQuadEdge2D.FromPtr(reader.Ptr);

                if (Cv.IS_SET_ELEM(edge))
                {
                    CvSubdiv2DEdge e = edge.ToCvSubdiv2DEdge();
                    // left
                    DrawSubdivFacet(img, e.RotateEdge(RotateEdgeFlag.Rotate));
                    // right
                    DrawSubdivFacet(img, e.RotateEdge(RotateEdgeFlag.ReverseRotate));
                }
                reader.NextSeqElem(elem_size);
                //Cv.NEXT_SEQ_ELEM(elem_size, reader);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="edge"></param>
        private void DrawSubdivFacet(IplImage img, CvSubdiv2DEdge edge)
        {
            CvSubdiv2DEdge t = edge;
            int count = 0;

            // count number of edges in facet
            do
            {
                count++;
                t = t.GetEdge(CvNextEdgeType.NextAroundLeft);
            } while (t != edge);

            CvPoint[] buf = new CvPoint[count];

            // gather points
            t = edge;
            int i;
            for (i = 0; i < count; i++)
            {
                CvSubdiv2DPoint pt = t.Org();
                if (pt == null)
                {
                    break;
                }
                buf[i] = pt.Pt;
                t = t.GetEdge(CvNextEdgeType.NextAroundLeft);
            }

            if (i == count)
            {
                Random rand = new Random();
                CvSubdiv2DPoint pt = edge.RotateEdge(RotateEdgeFlag.Rotate).Dst();
                img.FillConvexPoly(buf, CvColor.Random(), LineType.AntiAlias, 0);
                img.PolyLine(new CvPoint[][] { buf }, true, CvColor.Black, 1, LineType.AntiAlias, 0);
                DrawSubdivPoint(img, pt.Pt, CvColor.Black);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="fp"></param>
        /// <param name="color"></param>
        private void DrawSubdivPoint(IplImage img, CvPoint2D32f fp, CvColor color)
        {
            img.Circle(fp, 3, color, Cv.FILLED, LineType.AntiAlias, 0);
        }
    }
}
