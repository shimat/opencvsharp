/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region OpenFileStorage
#if LANG_JP
        /// <summary>
        /// データの読み書きのためのファイルを開く．
        /// 書き込みの場合は，新しいファイルが作成されるか，ファイルが存在する場合には上書きされる．
        /// また，読み書きされるファイルの種類は拡張子で判別される． XMLの場合は.xml，YAMLの場合は.ymlまたは.yamlである．
        /// </summary>
        /// <param name="filename">ストレージに関連づけられたファイルの名前</param>
        /// <param name="memstorage">一時的なデータや，CvSeqや CvGraphなどの動的構造体の保存に使われるメモリストレージ．nullの場合，一時的なメモリが確保されて使用される．</param>
        /// <param name="flags">ファイルを開く方法または作成する方法</param>
        /// <returns>開いたファイルと関連付けられたCvFileStorageクラスへの参照</returns>
#else
        /// <summary>
        /// Opens file storage for reading or writing data
        /// </summary>
        /// <param name="filename">Name of the file associated with the storage. </param>
        /// <param name="memstorage">Memory storage used for temporary data and for storing dynamic structures, such as CvSeq or CvGraph. If it is null, a temporary memory storage is created and used. </param>
        /// <param name="flags"></param>
        /// <returns>pointer to CvFileStorage structure.</returns>
#endif
        public static CvFileStorage OpenFileStorage(string filename, CvMemStorage memstorage, FileStorageMode flags)
        {
            return new CvFileStorage(filename, memstorage, flags);
        }
#if LANG_JP
        /// <summary>
        /// データの読み書きのためのファイルを開く．
        /// 書き込みの場合は，新しいファイルが作成されるか，ファイルが存在する場合には上書きされる．
        /// また，読み書きされるファイルの種類は拡張子で判別される． XMLの場合は.xml，YAMLの場合は.ymlまたは.yamlである．
        /// </summary>
        /// <param name="filename">ストレージに関連づけられたファイルの名前</param>
        /// <param name="memstorage">一時的なデータや，CvSeqや CvGraphなどの動的構造体の保存に使われるメモリストレージ．nullの場合，一時的なメモリが確保されて使用される．</param>
        /// <param name="flags">ファイルを開く方法または作成する方法</param>
        /// <param name="encoding"></param>
        /// <returns>開いたファイルと関連付けられたCvFileStorageクラスへの参照</returns>
#else
        /// <summary>
        /// Opens file storage for reading or writing data
        /// </summary>
        /// <param name="filename">Name of the file associated with the storage. </param>
        /// <param name="memstorage">Memory storage used for temporary data and for storing dynamic structures, such as CvSeq or CvGraph. If it is null, a temporary memory storage is created and used. </param>
        /// <param name="flags"></param>
        /// <param name="encoding"></param>
        /// <returns>pointer to CvFileStorage structure.</returns>
#endif
        public static CvFileStorage OpenFileStorage(string filename, CvMemStorage memstorage, FileStorageMode flags, string encoding)
        {
            return new CvFileStorage(filename, memstorage, flags, encoding);
        }
        #endregion
        #region Or
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの論理和（OR）を計算する. 
        /// dst(I)=src1(I)|src2(I)
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise disjunction of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void Or(CvArr src1, CvArr src2, CvArr dst)
        {
            Or(src1, src2, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの論理和（OR）を計算する. 
        /// dst(I)=src1(I)|src2(I) [mask(I)!=0の場合]
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）． </param>
#else
        /// <summary>
        /// Calculates per-element bit-wise disjunction of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void Or(CvArr src1, CvArr src2, CvArr dst, CvArr mask)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvOr(src1.CvPtr, src2.CvPtr, dst.CvPtr, maskPtr);
        }
        #endregion
        #region OrS
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の論理和(OR)を計算する.
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)|value
        /// </summary>
        /// <param name="src1">入力配列</param>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise disjunction of array and scalar
        /// </summary>
        /// <param name="src1">The source array. </param>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void OrS(CvArr src1, CvScalar value, CvArr dst)
        {
            OrS(src1, value, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の論理和(OR)を計算する. 
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)|value [mask(I)!=0の場合]
        /// </summary>
        /// <param name="src1">入力配列</param>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise disjunction of array and scalar
        /// </summary>
        /// <param name="src1">The source array. </param>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void OrS(CvArr src1, CvScalar value, CvArr dst, CvArr mask)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvOrS(src1.CvPtr, value, dst.CvPtr, maskPtr);
        }
        #endregion
    }
}
