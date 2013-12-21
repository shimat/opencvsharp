using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    /// <summary>
    /// Moment state structure 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public class CvMoments
    {
        public double M00, M10, M01, M20, M11, M02, M30, M21, M12, M03; /* spatial moments */
        public double Mu20, Mu11, Mu02, Mu30, Mu21, Mu12, Mu03; /* central moments */
        public double InvSqrtM00; /* m00 != 0 ? 1/sqrt(m00) : 0 */

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public CvMoments()
        {
            M00 = M10 = M01 = M20 = M11 = M02 = M30 = M21 = M12 = M03 = default(double);
            Mu20 = Mu11 = Mu02 = Mu30 = Mu21 = Mu12 = Mu03 = default(double);
            InvSqrtM00 = default(double);
        }

#if LANG_JP
        /// <summary>
        /// cvMomentsにより初期化
        /// </summary>
        /// <param name="arr">画像（1チャンネル，あるいはCOIをもつ3チャンネル画像） あるいはポリゴン （CvSeqで表される点群，または点のベクトル）．</param>
        /// <param name="binary">（画像の場合のみ）このフラグがtrueの場合，値0のピクセルは0として，その他のピクセル値は1として扱われる． </param>
#else
        /// <summary>
        /// Initialize by cvMoments
        /// </summary>
        /// <param name="arr">Image (1-channel or 3-channel with COI set) or polygon (CvSeq of points or a vector of points). </param>
        /// <param name="binary">(For images only) If the flag is non-zero, all the zero pixel values are treated as zeroes, all the others are treated as 1’s. </param>
#endif
        public CvMoments(CvArr arr, bool binary)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            CvInvoke.cvMoments(arr.CvPtr, this, binary);
        }
        #endregion

        #region Methods
        #region GetCentralMoment
#if LANG_JP
        /// <summary>
        /// 画像モーメント構造体から中心モーメントを計算する
        /// </summary>
        /// <param name="x_order">取り出すモーメントのx方向の次数，x_order &gt;= 0. </param>
        /// <param name="y_order">取り出すモーメントのy方向の次数， y_order &gt;= 0 かつ x_order + y_order &lt;= 3. </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves central moment from moment state structure
        /// </summary>
        /// <param name="x_order">x order of the retrieved moment, x_order &gt;= 0</param>
        /// <param name="y_order">y order of the retrieved moment, y_order &gt;= 0 and x_order + y_order &lt;= 3</param>
        /// <returns>Central moment</returns>
#endif
        public double GetCentralMoment(int x_order, int y_order)
        {
            return Cv.GetCentralMoment(this, x_order, y_order);
        }
        #endregion
        #region GetHuMoments
#if LANG_JP
        /// <summary>
        /// ７つのHuモーメント不変量を計算する
        /// </summary>
        /// <param name="humoments">Huモーメント構造体への参照</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates seven Hu invariants
        /// </summary>
        /// <param name="humoments">Pointer to Hu moments structure</param>
#endif
        public void GetHuMoments(out CvHuMoments humoments)
        {
            Cv.GetHuMoments(this, out humoments);
        }
        #endregion
        #region GetNormalizedCentralMoment
#if LANG_JP
        /// <summary>
        /// 画像モーメント構造体から正規化された中心モーメントを計算する
        /// </summary>
        /// <param name="x_order">取り出すモーメントのx方向の次数，x_order &gt;= 0. </param>
        /// <param name="y_order">取り出すモーメントのy方向の次数， y_order &gt;= 0 かつ x_order + y_order &lt;= 3. </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves normalized central moment from moment state structure
        /// </summary>
        /// <param name="x_order">x order of the retrieved moment, x_order &gt;= 0</param>
        /// <param name="y_order">y order of the retrieved moment, y_order &gt;= 0 and x_order + y_order &lt;= 3</param>
        /// <returns>Central moment</returns>
#endif
        public double GetNormalizedCentralMoment(int x_order, int y_order)
        {
            return Cv.GetNormalizedCentralMoment(this, x_order, y_order);
        }
        #endregion
        #region GetSpatialMoments
#if LANG_JP
        /// <summary>
        /// 画像モーメント構造体から空間モーメントを計算する
        /// </summary>
        /// <param name="x_order">取り出すモーメントのx方向の次数，x_order >= 0. </param>
        /// <param name="y_order">取り出すモーメントのy方向の次数， y_order >= 0 かつ x_order + y_order &lt;= 3. </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves spatial moment from moment state structure
        /// </summary>
        /// <param name="x_order">x order of the retrieved moment, x_order &gt;= 0</param>
        /// <param name="y_order">y order of the retrieved moment, y_order &gt;= 0 and x_order + y_order &lt;= 3</param>
        /// <returns>Spatial moments</returns>
#endif
        public double GetSpatialMoment(int x_order, int y_order)
        {
            return Cv.GetSpatialMoment(this, x_order, y_order);
        }
        #endregion
        #endregion
    }
}
