/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region BackProjectPCA
#if LANG_JP
        /// <summary>
        /// 投影係数から元のベクトルを再構築する
        /// </summary>
        /// <param name="proj">入力データ．</param>
        /// <param name="avg">平均ベクトル．もし単一行ベクトルの場合，出力ベクトルがresultの行として保存されていることを意味する．そうでない場合は，単一列ベクトルであり，そのときはresultの列として保存される．</param>
        /// <param name="eigenvects">固有ベクトル（主成分）．一つの行が一つのベクトルを意味する．</param>
        /// <param name="result">出力である再構築されたベクトルの行列．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Reconstructs the original vectors from the projection coefficients
        /// </summary>
        /// <param name="proj">The input data; in the same format as result in cvProjectPCA. </param>
        /// <param name="avg">The mean (average) vector. If it is a single-row vector, it means that the output vectors are stored as rows of result; otherwise, it should be a single-column vector, then the vectors are stored as columns of result. </param>
        /// <param name="eigenvects">The eigenvectors (principal components); one vector per row. </param>
        /// <param name="result">The output matrix of reconstructed vectors. </param>
        /// <returns></returns>
#endif
        public static void BackProjectPCA(CvArr proj, CvArr avg, CvArr eigenvects, CvArr result)
        {
            if (proj == null)
                throw new ArgumentNullException("proj");
            if (avg == null)
                throw new ArgumentNullException("avg");
            if (eigenvects == null)
                throw new ArgumentNullException("eigenvects");
            
            CvInvoke.cvBackProjectPCA(proj.CvPtr, avg.CvPtr, eigenvects.CvPtr, result.CvPtr);
        }
        #endregion
        #region BGCodeBookClearStale
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="staleThresh"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="staleThresh"></param>
#endif
        public static void BGCodeBookClearStale(CvBGCodeBookModel model, int staleThresh)
        {
            BGCodeBookClearStale(model, staleThresh, new CvRect(0, 0, 0, 0), null);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="staleThresh"></param>
        /// <param name="roi"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="staleThresh"></param>
        /// <param name="roi"></param>
#endif
        public static void BGCodeBookClearStale(CvBGCodeBookModel model, int staleThresh, CvRect roi)
        {
            BGCodeBookClearStale(model, staleThresh, roi, null);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="staleThresh"></param>
        /// <param name="roi"></param>
        /// <param name="mask"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="staleThresh"></param>
        /// <param name="roi"></param>
        /// <param name="mask"></param>
#endif
        public static void BGCodeBookClearStale(CvBGCodeBookModel model, int staleThresh, CvRect roi, CvArr mask)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            IntPtr maskPtr = ToPtr(mask);
            CvInvoke.cvBGCodeBookClearStale(model.CvPtr, staleThresh, roi, maskPtr);
        }
        #endregion
        #region BGCodeBookDiff
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <returns></returns>
#endif
        public static int BGCodeBookDiff(CvBGCodeBookModel model, CvArr image, CvArr fgmask)
        {
            return BGCodeBookDiff(model, image, fgmask, new CvRect(0, 0, 0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <param name="roi"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <param name="roi"></param>
        /// <returns></returns>
#endif
        public static int BGCodeBookDiff(CvBGCodeBookModel model, CvArr image, CvArr fgmask, CvRect roi)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (image == null)
                throw new ArgumentNullException("image");
            if (fgmask == null)
                throw new ArgumentNullException("fgmask");

            return CvInvoke.cvBGCodeBookDiff(model.CvPtr, image.CvPtr, fgmask.CvPtr, roi);
        }
        #endregion
        #region BGCodeBookUpdate
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
#endif
        public static void BGCodeBookUpdate(CvBGCodeBookModel model, CvArr image)
        {
            BGCodeBookUpdate(model, image, new CvRect(0, 0, 0, 0), null);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
        /// <param name="roi"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
        /// <param name="roi"></param>
#endif
        public static void BGCodeBookUpdate(CvBGCodeBookModel model, CvArr image, CvRect roi)
        {
            BGCodeBookUpdate(model, image, roi, null);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
        /// <param name="roi"></param>
        /// <param name="mask"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
        /// <param name="roi"></param>
        /// <param name="mask"></param>
#endif
        public static void BGCodeBookUpdate(CvBGCodeBookModel model, CvArr image, CvRect roi, CvArr mask)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (image == null)
                throw new ArgumentNullException("image");

            IntPtr maskPtr = ToPtr(mask);
            CvInvoke.cvBGCodeBookUpdate(model.CvPtr, image.CvPtr, roi, maskPtr);
        }
        #endregion
        #region BoundingRect
#if LANG_JP
        /// <summary>
        /// 2次元点列を包含するまっすぐな矩形を返す．
        /// </summary>
        /// <param name="points">シーケンス（CvSeq, CvContour）か，点のベクトル（CvMat）か，非0のピクセルが点列とみなされる8ビット1チャンネルマスク画像 （CvMat, IplImage）のいずれかで表現された2次元の点列．</param>
        /// <returns>矩形</returns>
#else
        /// <summary>
        /// Calculates up-right bounding rectangle of point set.
        /// </summary>
        /// <param name="points">Either a 2D point set, represented as a sequence (CvSeq, CvContour) or vector (CvMat) of points, 
        /// or 8-bit single-channel mask image (CvMat, IplImage), in which non-zero pixels are considered. </param>
        /// <returns></returns>
#endif
        public static CvRect BoundingRect(CvArr points)
        {
            return BoundingRect(points, false);
        }
#if LANG_JP
        /// <summary>
        /// 2次元点列を包含するまっすぐな矩形を返す．
        /// </summary>
        /// <param name="points">シーケンス（CvSeq, CvContour）か，点のベクトル（CvMat）か，非0のピクセルが点列とみなされる8ビット1チャンネルマスク画像 （CvMat, IplImage）のいずれかで表現された2次元の点列．</param>
        /// <param name="update">更新フラグ. 
        /// pointsがCvContour で，update=falseの場合： 包含矩形は計算されず，輪郭ヘッダのrectフィールドから読み込まれる． 
        /// pointsがCvContour で，update=trueの場合： 包含矩形は計算され，輪郭ヘッダのrectフィールドに書き込まれる． 
        /// pointsがCvSeqかCvMatの場合： updateは無視されて，包含矩形は計算されて返される． </param>
        /// <returns>矩形</returns>
#else
        /// <summary>
        /// Calculates up-right bounding rectangle of point set.
        /// </summary>
        /// <param name="points">Either a 2D point set, represented as a sequence (CvSeq, CvContour) or vector (CvMat) of points, 
        /// or 8-bit single-channel mask image (CvMat, IplImage), in which non-zero pixels are considered. </param>
        /// <param name="update">The update flag</param>
        /// <returns></returns>
#endif
        public static CvRect BoundingRect(CvArr points, bool update)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            return CvInvoke.cvBoundingRect(points.CvPtr, update);
        }
#if LANG_JP
        /// <summary>
        /// 2次元点列を包含するまっすぐな矩形を返す．
        /// </summary>
        /// <param name="points">CvPointの列挙子(CvPoint[], List&lt;CvPoint&gt;など). 内部でCvSeqに変換される.</param>
        /// <returns>矩形</returns>
#else
        /// <summary>
        /// Calculates up-right bounding rectangle of point set.
        /// </summary>
        /// <param name="points">An IEnumerable&lt;CvPoint&gt; object (ex. CvPoint[], List&lt;CvPoint&gt;, ....)</param>
        /// <returns></returns>
#endif
        public static CvRect BoundingRect(IEnumerable<CvPoint> points)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            
            CvRect result;
            using (CvMemStorage storage = new CvMemStorage(0))
            {
                CvSeq<CvPoint> seq = new CvSeq<CvPoint>(SeqType.EltypePoint, CvSeq.SizeOf, storage);
                foreach (CvPoint p in points)
                {
                    SeqPush(seq, p);
                }
                result = CvInvoke.cvBoundingRect(seq.CvPtr, false);
            }
            
            return result;
        }

        #endregion
        #region BoxPoints
#if LANG_JP
        /// <summary>
        /// 箱の頂点を見つける
        /// </summary>
        /// <param name="box">箱</param>
        /// <param name="pt">頂点の配列</param>
#else
        /// <summary>
        /// Finds box vertices
        /// </summary>
        /// <param name="box">Box</param>
        /// <param name="pt">Array of vertices</param>
#endif
        public static void BoxPoints(CvBox2D box, out CvPoint2D32f[] pt)
        {
            pt = new CvPoint2D32f[4];
            CvInvoke.cvBoxPoints(box, pt);

            // cvgeometry.cpp  line 89~103
            /*
            double angle = box.Angle * CvConst.CV_PI / 180.0;
            float a = (float)Math.Cos(angle)*0.5f;
            float b = (float)Math.Sin(angle)*0.5f;

            pt[0].X = box.Center.X - a * box.Size.Height - b * box.Size.Width;
            pt[0].Y = box.Center.Y + b * box.Size.Height - a * box.Size.Width;
            pt[1].X = box.Center.X + a * box.Size.Height - b * box.Size.Width;
            pt[1].Y = box.Center.Y - b * box.Size.Height - a * box.Size.Width;
            pt[2].X = 2 * box.Center.X - pt[0].X;
            pt[2].Y = 2 * box.Center.Y - pt[0].Y;
            pt[3].X = 2 * box.Center.X - pt[1].X;
            pt[3].Y = 2 * box.Center.Y - pt[1].Y;
            //*/
        }
        #endregion       
    }
}