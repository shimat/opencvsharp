
using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 輪郭データの二分木
    /// </summary>
#else
    /// <summary>
    /// Contour tree
    /// </summary>
#endif
    public class CvContourTree : CvSeq
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ネイティブのデータポインタから初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvContourTree(IntPtr ptr)
            : base(ptr)
        {
            this.ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// 輪郭の階層的表現を生成する
        /// </summary>
        /// <param name="contour">入力輪郭</param>
        /// <param name="storage">結果のツリーの出力先</param>
        /// <param name="threshold">近似精度</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates hierarchical representation of contour
        /// </summary>
        /// <param name="contour">Input contour. </param>
        /// <param name="storage">Container for output tree. </param>
        /// <param name="threshold">Approximation accuracy. </param>
        /// <returns></returns>
#endif
        public CvContourTree(CvSeq contour, CvMemStorage storage, double threshold)
            : base( NativeMethods.cvCreateContourTree(contour.CvPtr, storage.CvPtr, threshold) )
        {
        }

        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvContourTree) 
        /// </summary>
        new public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvContourTree));

        /// <summary>
        /// The first point of the binary tree root segment
        /// </summary>
        public CvPoint P1
        {
            get
            {
                unsafe
                {
                    return ((WCvContourTree*)ptr)->p1;
                }
            }
        }
        /// <summary>
        /// The last point of the binary tree root segment
        /// </summary>
        public CvPoint P2
        {
            get
            {
                unsafe
                {
                    return ((WCvContourTree*)ptr)->p2;
                }
            }
        }
        #endregion

        #region Methods
        #region ContourFromContourTree
#if LANG_JP
        /// <summary>
        /// ツリーから輪郭を復元する
        /// </summary>
        /// <param name="storage">復元した輪郭の出力先</param>
        /// <param name="criteria">復元を止める基準</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Restores contour from tree.
        /// </summary>
        /// <param name="storage">Container for the reconstructed contour. </param>
        /// <param name="criteria">Criteria, where to stop reconstruction. </param>
        /// <returns></returns>
#endif
        public CvSeq ContourFromContourTree(CvMemStorage storage, CvTermCriteria criteria)
        {
            return Cv.ContourFromContourTree(this, storage, criteria);
        }
        #endregion
        #endregion
    }
}
