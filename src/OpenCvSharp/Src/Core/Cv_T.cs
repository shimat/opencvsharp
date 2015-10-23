using System;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region TermCriteria
#if LANG_JP
        /// <summary>
        /// 反復アルゴリズムのための終了条件を生成する
        /// </summary>
        /// <param name="type">終了条件</param>
        /// <param name="maxIter">反復数の最大値</param>
        /// <param name="epsilon">目標精度</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates termination criteria for iterative algorithms.
        /// </summary>
        /// <param name="type">A combination of Iteration and Epsilon</param>
        /// <param name="maxIter">Maximum number of iterations</param>
        /// <param name="epsilon">Required accuracy</param>
        /// <returns></returns>
#endif
        public static CvTermCriteria TermCriteria(CriteriaType type, int maxIter, double epsilon)
        {
            return new CvTermCriteria(type, maxIter, epsilon);
        }
        #endregion
        #region ThreshHist
#if LANG_JP
        /// <summary>
        /// ヒストグラムの閾値処理を行う.
        /// 指定した閾値以下のヒストグラムのビンをクリアする.
        /// </summary>
        /// <param name="hist">ヒストグラムへの参照</param>
        /// <param name="threshold">閾値レベル</param>
#else
        /// <summary>
        /// Clears histogram bins that are below the specified threshold.
        /// </summary>
        /// <param name="hist">Reference to the histogram. </param>
        /// <param name="threshold">Threshold level. </param>
#endif
        public static void ThreshHist(CvHistogram hist, double threshold)
        {
            if (hist == null)
            {
                throw new ArgumentNullException("hist");
            }
            NativeMethods.cvThreshHist(hist.CvPtr, threshold);

            GC.KeepAlive(hist);
        }
        #endregion
        #region Threshold
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列に対して，固定閾値での閾値処理を行う
        /// </summary>
        /// <param name="src">入力配列 (シングルチャンネル，8ビット，あるいは32ビット浮動小数点型）</param>
        /// <param name="dst">出力配列．src と同じデータタイプ，または8ビット． </param>
        /// <param name="threshold">閾値</param>
        /// <param name="maxValue">threshold_type が Binary と BinaryInv のときに使用する最大値</param>
        /// <param name="thresholdType">閾値処理の種類</param>
#else
        /// <summary>
        /// Applies fixed-level threshold to array elements.
        /// </summary>
        /// <param name="src">Source array (single-channel, 8-bit of 32-bit floating point). </param>
        /// <param name="dst">Destination array; must be either the same type as src or 8-bit. </param>
        /// <param name="threshold">Threshold value. </param>
        /// <param name="maxValue">Maximum value to use with CV_THRESH_BINARY and CV_THRESH_BINARY_INV thresholding types. </param>
        /// <param name="thresholdType">Thresholding type.</param>
#endif
        public static double Threshold(CvArr src, CvArr dst, double threshold, double maxValue, ThresholdType thresholdType)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            double ret = NativeMethods.cvThreshold(src.CvPtr, dst.CvPtr, threshold, maxValue, thresholdType);

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            return ret;
        }
        #endregion
        #region Trace
#if LANG_JP
        /// <summary>
        /// 行列のトレース(対角成分の和)を返す
        /// </summary>
        /// <param name="mat">入力行列</param>
        /// <returns>対角成分の和</returns>
#else
        /// <summary>
        /// Returns trace of matrix
        /// </summary>
        /// <param name="mat">The source matrix. </param>
        /// <returns>sum of diagonal elements of the matrix src1</returns>
#endif
        public static CvScalar Trace(CvArr mat)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            
            var ret = NativeMethods.cvTrace(mat.CvPtr);

            GC.KeepAlive(mat);
            return ret;
        }
        #endregion
        #region TrackFace
        /// <summary>
        /// 
        /// </summary>
        /// <param name="faceTracker"></param>
        /// <param name="imgGray"></param>
        /// <param name="rects"></param>
        /// <param name="ptRotate"></param>
        /// <param name="angleRotate"></param>
        /// <returns></returns>
        public static bool TrackFace(CvFaceTracker faceTracker, IplImage imgGray, CvRect[] rects, out CvPoint ptRotate, out double angleRotate)
        {
            if (faceTracker == null)
                throw new ArgumentNullException("faceTracker");
            if (imgGray == null)
                throw new ArgumentNullException("imgGray");
            if (rects == null)
                throw new ArgumentNullException("rects");
            if (rects.Length < 3)
                throw new ArgumentException("rects.Length >= 3");

            var ret = NativeMethods.cvTrackFace(faceTracker.CvPtr, imgGray.CvPtr, rects, rects.Length, out ptRotate, out angleRotate);

            GC.KeepAlive(faceTracker);
            GC.KeepAlive(imgGray);
            return ret;
        }
        #endregion
        #region Transform
#if LANG_JP
        /// <summary>
        /// すべての配列要素を行列により変換する
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="transmat">変換行列</param>
#else
        /// <summary>
        /// Performs matrix transform of every array element
        /// </summary>
        /// <param name="src">The first source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="transmat">Transformation matrix. </param>
#endif
        public static void Transform(CvArr src, CvArr dst, CvMat transmat)
        {
            Transform(src, dst, transmat, null);
        }
#if LANG_JP
        /// <summary>
        /// すべての配列要素を行列により変換する
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="transmat">変換行列</param>
        /// <param name="shiftvec">オプションのシフトベクトル</param>
#else
        /// <summary>
        /// Performs matrix transform of every array element
        /// </summary>
        /// <param name="src">The first source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="transmat">Transformation matrix. </param>
        /// <param name="shiftvec">Optional shift vector. </param>
#endif
        public static void Transform(CvArr src, CvArr dst, CvMat transmat, CvMat shiftvec)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (transmat == null)
                throw new ArgumentNullException("transmat");

            NativeMethods.cvTransform(src.CvPtr, dst.CvPtr, transmat.CvPtr, ToPtr(shiftvec));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(transmat);
            GC.KeepAlive(shiftvec);
        }
#if LANG_JP
        /// <summary>
        /// すべての配列要素を行列により変換する
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="transmat">変換行列</param>
#else
        /// <summary>
        /// Performs matrix transform of every array element
        /// </summary>
        /// <param name="src">The first source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="transmat">Transformation matrix. </param>
#endif
        public static void MatMulAddS(CvArr src, CvArr dst, CvMat transmat)
        {
            Transform(src, dst, transmat, null);
        }
#if LANG_JP
        /// <summary>
        /// すべての配列要素を行列により変換する
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="transmat">変換行列</param>
        /// <param name="shiftvec">オプションのシフトベクトル</param>
#else
        /// <summary>
        /// Performs matrix transform of every array element
        /// </summary>
        /// <param name="src">The first source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="transmat">Transformation matrix. </param>
        /// <param name="shiftvec">Optional shift vector. </param>
#endif
        public static void MatMulAddS(CvArr src, CvArr dst, CvMat transmat, CvMat shiftvec)
        {
            Transform(src, dst, transmat, shiftvec);
        }
        #endregion
        #region Transpose
#if LANG_JP
        /// <summary>
        /// 行列の転置を行う.
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">出力行列</param>
#else
        /// <summary>
        /// Transposes matrix
        /// </summary>
        /// <param name="src">The source matrix. </param>
        /// <param name="dst">The destination matrix. </param>
#endif
        public static void Transpose(CvArr src, CvArr dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            NativeMethods.cvTranspose(src.CvPtr, dst.CvPtr);

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
        }
#if LANG_JP
        /// <summary>
        /// 行列の転置を行う.
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">出力行列</param>
#else
        /// <summary>
        /// Transposes matrix
        /// </summary>
        /// <param name="src">The source matrix. </param>
        /// <param name="dst">The destination matrix. </param>
#endif
        public static void T(CvArr src, CvArr dst)
        {
            Transpose(src, dst);
        }
        #endregion
        #region TreeToNodeSeq
#if LANG_JP
        /// <summary>
        /// すべてのノードへのポインタを一つのシーケンスに集める
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">ツリーの先頭ノード．</param>
        /// <param name="headerSize">作成したシーケンスのヘッダサイズ（sizeof(CvSeq) が用いられることが多い）．</param>
        /// <param name="storage">シーケンスのためのコンテナ．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Gathers all node pointers to the single sequence
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The initial tree node. </param>
        /// <param name="headerSize">Header size of the created sequence (sizeof(CvSeq) is the most used value). </param>
        /// <param name="storage">Container for the sequence. </param>
        /// <returns></returns>
#endif
        public static CvSeq TreeToNodeSeq<T>(CvTreeNode<T> first, int headerSize, CvMemStorage storage)
            where T : CvTreeNode<T>
        {
            if (first == null)
                throw new ArgumentNullException("first");
            if (storage == null)
                throw new ArgumentNullException("storage");

            IntPtr result = NativeMethods.cvTreeToNodeSeq(first.CvPtr, headerSize, storage);
            KeepAlive(first, storage);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq(result);
        }
        #endregion
        #region TriangulatePoints
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projMatr1"></param>
        /// <param name="projMatr2"></param>
        /// <param name="projPoints1"></param>
        /// <param name="projPoints2"></param>
        /// <param name="points4D"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projMatr1"></param>
        /// <param name="projMatr2"></param>
        /// <param name="projPoints1"></param>
        /// <param name="projPoints2"></param>
        /// <param name="points4D"></param>
#endif
        public static void TriangulatePoints(CvMat projMatr1, CvMat projMatr2, CvMat projPoints1, CvMat projPoints2, CvMat points4D)
        {
            if (projMatr1 == null)
                throw new ArgumentNullException("projMatr1");
            if (projMatr2 == null)
                throw new ArgumentNullException("projMatr2");
            if (projPoints1 == null)
                throw new ArgumentNullException("projPoints1");
            if (projPoints2 == null)
                throw new ArgumentNullException("projPoints2");
            if (points4D == null)
                throw new ArgumentNullException("points4D");

            NativeMethods.cvTriangulatePoints(projMatr1.CvPtr, projMatr2.CvPtr, projPoints1.CvPtr, projPoints2.CvPtr, points4D.CvPtr);

            GC.KeepAlive(projMatr1);
            GC.KeepAlive(projMatr2);
            GC.KeepAlive(projPoints1);
            GC.KeepAlive(projPoints2);
            GC.KeepAlive(points4D);
        }
        #endregion
        #region TypeOf
#if LANG_JP
        /// <summary>
        /// オブジェクトの型を返す
        /// </summary>
        /// <param name="structPtr">オブジェクトへのポインタ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns type of the object
        /// </summary>
        /// <param name="structPtr">The object pointer. </param>
        /// <returns></returns>
#endif
        public static CvTypeInfo TypeOf(IntPtr structPtr)
        {
            IntPtr result = NativeMethods.cvTypeOf(structPtr);
            if (result == IntPtr.Zero)
                return null;
            return new CvTypeInfo(structPtr);
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトの型を返す
        /// </summary>
        /// <param name="structPtr">OpenCVのオブジェクト</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns type of the object
        /// </summary>
        /// <param name="structPtr">The OpenCV object. </param>
        /// <returns></returns>
#endif
        public static CvTypeInfo TypeOf(ICvPtrHolder structPtr)
        {
            return TypeOf(structPtr.CvPtr);
        }
        #endregion
    }
}