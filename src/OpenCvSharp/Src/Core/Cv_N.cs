/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region NamedWindow
#if LANG_JP
        /// <summary>
        /// 画像とトラックバーのプレースホルダとして利用されるウィンドウを作成する．
        /// このウィンドウは，その名前によって参照される．
        /// </summary>
        /// <param name="name">ウィンドウの識別に用いられるウィンドウ名で，ウィンドウのタイトルバ ーに表示される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates a window which can be used as a placeholder for images and trackbars. Created windows are reffered by their names. 
        /// </summary>
        /// <param name="name">Name of the window which is used as window identifier and appears in the window caption. </param>
        /// <returns></returns>
#endif
        public static int NamedWindow(string name)
        {
            return NamedWindow(name, WindowMode.AutoSize);
        }
#if LANG_JP
        /// <summary>
        /// 画像とトラックバーのプレースホルダとして利用されるウィンドウを作成する．
        /// このウィンドウは，その名前によって参照される．
        /// </summary>
        /// <param name="name">ウィンドウの識別に用いられるウィンドウ名で，ウィンドウのタイトルバ ーに表示される</param>
        /// <param name="flags">ウィンドウのフラグ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates a window which can be used as a placeholder for images and trackbars. Created windows are reffered by their names. 
        /// </summary>
        /// <param name="name">Name of the window which is used as window identifier and appears in the window caption. </param>
        /// <param name="flags">Flags of the window. Currently the only supported flag is WindowMode.AutoSize. 
        /// If it is set, window size is automatically adjusted to fit the displayed image (see cvShowImage), while user can not change the window size manually. </param>
        /// <returns></returns>
#endif
        public static int NamedWindow(string name, WindowMode flags)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            //return CvDll.cvNamedWindow(name, flags);
            try
            {
                new CvWindow(name, flags);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        #endregion
        #region NextGraphItem
#if LANG_JP
        /// <summary>
        /// グラフ走査処理を1ステップ，あるいは数ステップ進める
        /// </summary>
        /// <param name="scanner">グラフ走査状態．この関数で更新される． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns index of graph vertex
        /// </summary>
        /// <param name="scanner">Graph traversal state. It is updated by the function. </param>
        /// <returns>The function cvNextGraphItem traverses through the graph until an event interesting to the user (that is, an event, specified in the mask in cvCreateGraphScanner call) is met or the traversal is over. In the first case it returns one of the events, listed in the description of mask parameter above and with the next call it resumes the traversal. In the latter case it returns CV_GRAPH_OVER (-1). When the event is CV_GRAPH_VERTEX, or CV_GRAPH_BACKTRACKING or CV_GRAPH_NEW_TREE, the currently observed vertex is stored in scanner->vtx. And if the event is edge-related, the edge itself is stored at scanner->edge, the previously visited vertex - at scanner->vtx and the other ending vertex of the edge - at scanner->dst.</returns>
#endif
        public static int NextGraphItem(CvGraphScanner scanner)
        {
            if (scanner == null)
            {
                throw new ArgumentNullException("scanner");
            }

            return CvInvoke.cvNextGraphItem(scanner.CvPtr);
        }
        #endregion
        #region NextLinePoint
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineIterator"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Moves iterator to the next line point
        /// </summary>
        /// <param name="lineIterator">LineIterator object </param>
        /// <returns></returns>
#endif
        public static void NextLinePoint(CvLineIterator lineIterator)
        {
            lineIterator.NextLinePoint();
        }
        #endregion
        #region NextTreeNode
#if LANG_JP
        /// <summary>
        /// 現在のノードを返し，イテレータを次のノードに移動させる．
        /// </summary>
        /// <param name="treeIterator">初期化されるツリーのイテレータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns the currently observed node and moves iterator toward the next node
        /// </summary>
        /// <param name="treeIterator">Tree iterator initialized by the function. </param>
        /// <returns></returns>
#endif
        public static IntPtr NextTreeNode(CvTreeNodeIterator treeIterator)
        {
            if (treeIterator == null)
                throw new ArgumentNullException("treeIterator");
            
            return CvInvoke.cvNextTreeNode(treeIterator);
        }
#if LANG_JP
        /// <summary>
        /// 現在のノードを返し，イテレータを次のノードに移動させる．
        /// </summary>
        /// <param name="treeIterator">初期化されるツリーのイテレータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns the currently observed node and moves iterator toward the next node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="treeIterator">Tree iterator initialized by the function. </param>
        /// <returns></returns>
#endif
        public static T NextTreeNode<T>(CvTreeNodeIterator treeIterator) where T : CvArr
        {
            if (treeIterator == null)
                throw new ArgumentNullException("treeIterator");
            
            IntPtr result = CvInvoke.cvNextTreeNode(treeIterator);
            if (result == IntPtr.Zero)
                return null;
            else
                return Util.Cast<T>(result);
        }
#if LANG_JP
        /// <summary>
        /// 現在のノードを返し，イテレータを次のノードに移動させる．
        /// </summary>
        /// <param name="treeIterator">初期化されるツリーのイテレータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns the currently observed node and moves iterator toward the next node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="treeIterator">Tree iterator initialized by the function. </param>
        /// <returns></returns>
#endif
        public static T NextTreeNode<T>(CvTreeNodeIterator<T> treeIterator) where T : CvArr
        {
            return NextTreeNode<T>((CvTreeNodeIterator)treeIterator);
        }
        #endregion
        #region Norm
#if LANG_JP
        /// <summary>
        /// 配列の絶対値ノルム（absolute array norm）を計算する
        /// </summary>
        /// <param name="arr1">1番目の入力画像</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates absolute array norm, absolute difference norm or relative difference norm
        /// </summary>
        /// <param name="arr1">The first source image. </param>
        /// <returns></returns>
#endif
        public static double Norm(CvArr arr1)
        {
            return Norm(arr1, null, NormType.L2, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列の絶対値ノルム（absolute array norm），絶対値差分ノルム（absolute difference norm），相対値差分ノルム（relative difference norm）を計算する
        /// </summary>
        /// <param name="arr1">1番目の入力画像</param>
        /// <param name="arr2">2番目の入力画像．null の場合，arr1の絶対値ノルムが計算され，そうでない場合は，arr1-arr2 の絶対値あるいは相対値ノルムが計算される． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates absolute array norm, absolute difference norm or relative difference norm
        /// </summary>
        /// <param name="arr1">The first source image. </param>
        /// <param name="arr2">The second source image. If it is null, the absolute norm of arr1 is calculated, otherwise absolute or relative norm of arr1-arr2 is calculated. </param>
        /// <returns></returns>
#endif
        public static double Norm(CvArr arr1, CvArr arr2)
        {
            return Norm(arr1, arr2, NormType.L2, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列の絶対値ノルム（absolute array norm），絶対値差分ノルム（absolute difference norm），相対値差分ノルム（relative difference norm）を計算する
        /// </summary>
        /// <param name="arr1">1番目の入力画像</param>
        /// <param name="arr2">2番目の入力画像．null の場合，arr1の絶対値ノルムが計算され，そうでない場合は，arr1-arr2 の絶対値あるいは相対値ノルムが計算される． </param>
        /// <param name="normType">ノルムのタイプ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates absolute array norm, absolute difference norm or relative difference norm
        /// </summary>
        /// <param name="arr1">The first source image. </param>
        /// <param name="arr2">The second source image. If it is null, the absolute norm of arr1 is calculated, otherwise absolute or relative norm of arr1-arr2 is calculated. </param>
        /// <param name="normType">Type of norm</param>
        /// <returns></returns>
#endif
        public static double Norm(CvArr arr1, CvArr arr2, NormType normType)
        {
            return Norm(arr1, arr2, normType, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列の絶対値ノルム（absolute array norm），絶対値差分ノルム（absolute difference norm），相対値差分ノルム（relative difference norm）を計算する
        /// </summary>
        /// <param name="arr1">1番目の入力画像</param>
        /// <param name="arr2">2番目の入力画像．null の場合，arr1の絶対値ノルムが計算され，そうでない場合は，arr1-arr2 の絶対値あるいは相対値ノルムが計算される． </param>
        /// <param name="normType">ノルムのタイプ</param>
        /// <param name="mask">オプションの処理マスク</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates absolute array norm, absolute difference norm or relative difference norm
        /// </summary>
        /// <param name="arr1">The first source image. </param>
        /// <param name="arr2">The second source image. If it is null, the absolute norm of arr1 is calculated, otherwise absolute or relative norm of arr1-arr2 is calculated. </param>
        /// <param name="normType">Type of norm</param>
        /// <param name="mask">The optional operation mask. </param>
        /// <returns></returns>
#endif
        public static double Norm(CvArr arr1, CvArr arr2, NormType normType, CvArr mask)
        {
            if (arr1 == null)
            {
                throw new ArgumentNullException("arr1");
            }
            IntPtr arr2Ptr = (arr2 == null) ? IntPtr.Zero : arr2.CvPtr;
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            return CvInvoke.cvNorm(arr1.CvPtr, arr2Ptr, normType, maskPtr);
        }
        #endregion
        #region Normalize
#if LANG_JP
        /// <summary>
        /// 指定のノルムになるように，あるいは値が指定の範囲になるように，配列を正規化する
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列．インプレース処理が可能．</param>
#else
        /// <summary>
        /// Normalizes array to a certain norm or value range
        /// </summary>
        /// <param name="src">The input array. </param>
        /// <param name="dst">The output array; in-place operation is supported. </param>
#endif
        public static void Normalize(CvArr src, CvArr dst)
        {
            Normalize(src, dst, 1, 0, NormType.L2, null);
        }
#if LANG_JP
        /// <summary>
        /// 指定のノルムになるように，あるいは値が指定の範囲になるように，配列を正規化する
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列．インプレース処理が可能．</param>
        /// <param name="a">出力配列の最小値または最大値，あるいは出力配列のノルム．</param>
        /// <param name="b">出力配列の最大値または最小値．</param>
#else
        /// <summary>
        /// Normalizes array to a certain norm or value range
        /// </summary>
        /// <param name="src">The input array. </param>
        /// <param name="dst">The output array; in-place operation is supported. </param>
        /// <param name="a">The minimum/maximum value of the output array or the norm of output array. </param>
        /// <param name="b">The maximum/minimum value of the output array. </param>
#endif
        public static void Normalize(CvArr src, CvArr dst, double a, double b)
        {
            Normalize(src, dst, a, b, NormType.L2, null);
        }
#if LANG_JP
        /// <summary>
        /// 指定のノルムになるように，あるいは値が指定の範囲になるように，配列を正規化する
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列．インプレース処理が可能．</param>
        /// <param name="a">出力配列の最小値または最大値，あるいは出力配列のノルム．</param>
        /// <param name="b">出力配列の最大値または最小値．</param>
        /// <param name="normType">正規化のタイプ. C, L1, L2, MinMaxのうち1つ.</param>
#else
        /// <summary>
        /// Normalizes array to a certain norm or value range
        /// </summary>
        /// <param name="src">The input array. </param>
        /// <param name="dst">The output array; in-place operation is supported. </param>
        /// <param name="a">The minimum/maximum value of the output array or the norm of output array. </param>
        /// <param name="b">The maximum/minimum value of the output array. </param>
        /// <param name="normType">The normalization type.</param>
#endif
        public static void Normalize(CvArr src, CvArr dst, double a, double b, NormType normType)
        {
            Normalize(src, dst, a, b, normType, null);
        }
#if LANG_JP
        /// <summary>
        /// 指定のノルムになるように，あるいは値が指定の範囲になるように，配列を正規化する
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列．インプレース処理が可能．</param>
        /// <param name="a">出力配列の最小値または最大値，あるいは出力配列のノルム．</param>
        /// <param name="b">出力配列の最大値または最小値．</param>
        /// <param name="normType">正規化のタイプ. C, L1, L2, MinMaxのうち1つ.</param>
        /// <param name="mask">操作マスク．特定の配列要素のみを正規化するためのマスク．</param>
#else
        /// <summary>
        /// Normalizes array to a certain norm or value range
        /// </summary>
        /// <param name="src">The input array. </param>
        /// <param name="dst">The output array; in-place operation is supported. </param>
        /// <param name="a">The minimum/maximum value of the output array or the norm of output array. </param>
        /// <param name="b">The maximum/minimum value of the output array. </param>
        /// <param name="normType">The normalization type.</param>
        /// <param name="mask">The operation mask. Makes the function consider and normalize only certain array elements. </param>
#endif
        public static void Normalize(CvArr src, CvArr dst, double a, double b, NormType normType, CvArr mask)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvNormalize(src.CvPtr, dst.CvPtr, a, b, normType, maskPtr);
        }
        #endregion
        #region NormalizeHist
#if LANG_JP
        /// <summary>
        /// ヒストグラムの正規化を行う.
        /// ビンの値の合計が factor に等しくなるようにスケーリングする事で，ヒストグラムのビンを正規化する．
        /// </summary>
        /// <param name="hist">ヒストグラムへの参照</param>
        /// <param name="factor">正規化係数</param>
#else
        /// <summary>
        /// Normalizes the histogram bins by scaling them, such that the sum of the bins becomes equal to factor.
        /// </summary>
        /// <param name="hist">Reference to the histogram. </param>
        /// <param name="factor">Threshold level. </param>
#endif
        public static void NormalizeHist(CvHistogram hist, double factor)
        {
            if (hist == null)
            {
                throw new ArgumentNullException("hist");
            }
            CvInvoke.cvNormalizeHist(hist.CvPtr, factor);
        }
        #endregion
        #region Not
#if LANG_JP
        /// <summary>
        /// 各配列要素のビット単位の反転を行う
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs per-element bit-wise inversion of array elements
        /// </summary>
        /// <param name="src">The source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void Not(CvArr src, CvArr dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvNot(src.CvPtr, dst.CvPtr);
        }
        #endregion
    }
}
