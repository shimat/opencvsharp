/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region SampleLine
#if LANG_JP
        /// <summary>
        /// ラスタ表現の線分を構成する点をサンプリングする
        /// </summary>
        /// <param name="image">線分をサンプリングするための入力画像</param>
        /// <param name="pt1">線分の始点</param>
        /// <param name="pt2">線分の終点</param>
        /// <param name="buffer">線分上の点を保存するためのバッファ</param>
        /// <param name="connectivity">線分の接続性．4 または 8．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Implements a particular case of application of line iterators. 
        /// The function reads all the image points lying on the line between pt1 and pt2, including the ending points, and stores them into the buffer.
        /// </summary>
        /// <param name="image">Image to sample the line from. </param>
        /// <param name="pt1">Starting the line point. </param>
        /// <param name="pt2">Ending the line point. </param>
        /// <param name="buffer">Buffer to store the line points.</param>
        /// <param name="connectivity">The line connectivity, 4 or 8. </param>
        /// <returns></returns>
#endif
        public static int SampleLine(CvArr image, CvPoint pt1, CvPoint pt2, out CvPoint[] buffer, int connectivity)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            int size;
            if (connectivity == 4)
                size = Math.Abs(pt2.X - pt1.X) + Math.Abs(pt2.Y - pt1.Y) + 1;
            else if (connectivity == 8)
                size = Math.Max(Math.Abs(pt2.X - pt1.X) + 1, Math.Abs(pt2.Y - pt1.Y) + 1);
            else
                throw new ArgumentOutOfRangeException("connectivity");
            
            buffer = new CvPoint[size];

            int result;
            using (var bufferPtr = new ArrayAddress1<CvPoint>(buffer))
            {
                result = CvInvoke.cvSampleLine(image.CvPtr, pt1, pt2, bufferPtr, connectivity);
            }
            return result;
        }
        #endregion
        #region Save
        #region IntPtr
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルに保存する
        /// </summary>
        /// <param name="filename">ファイル名.</param>
        /// <param name="structPtr">保存するオブジェクト.</param>
#else
        /// <summary>
        /// Saves object to file
        /// </summary>
        /// <param name="filename">File name. </param>
        /// <param name="structPtr">Object to save. </param>
#endif
        public static void Save(string filename, IntPtr structPtr)
        {
            Save(filename, structPtr, null, null, new CvAttrList());
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルに保存する
        /// </summary>
        /// <param name="filename">ファイル名.</param>
        /// <param name="structPtr">保存するオブジェクト.</param>
        /// <param name="name">オブジェクト名（オプション）．nullの場合，名前はfilenameから生成される．</param>
#else
        /// <summary>
        /// Saves object to file
        /// </summary>
        /// <param name="filename">File name. </param>
        /// <param name="structPtr">Object to save. </param>
        /// <param name="name">Optional object name. If it is null, the name will be formed from filename. </param>
#endif
        public static void Save(string filename, IntPtr structPtr, string name)
        {
            Save(filename, structPtr, name, null, new CvAttrList());
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルに保存する
        /// </summary>
        /// <param name="filename">ファイル名.</param>
        /// <param name="structPtr">保存するオブジェクト.</param>
        /// <param name="name">オブジェクト名（オプション）．nullの場合，名前はfilenameから生成される．</param>
        /// <param name="comment">ファイルの最初に置かれるコメント（オプション）.</param>
#else
        /// <summary>
        /// Saves object to file
        /// </summary>
        /// <param name="filename">File name. </param>
        /// <param name="structPtr">Object to save. </param>
        /// <param name="name">Optional object name. If it is null, the name will be formed from filename. </param>
        /// <param name="comment">Optional comment to put in the beginning of the file. </param>
#endif
        public static void Save(string filename, IntPtr structPtr, string name, string comment)
        {
            Save(filename, structPtr, name, comment, new CvAttrList());
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルに保存する
        /// </summary>
        /// <param name="filename">ファイル名.</param>
        /// <param name="structPtr">保存するオブジェクト.</param>
        /// <param name="name">オブジェクト名（オプション）．nullの場合，名前はfilenameから生成される．</param>
        /// <param name="comment">ファイルの最初に置かれるコメント（オプション）.</param>
        /// <param name="attributes">cvWriteに渡される属性（オプション）.</param>
#else
        /// <summary>
        /// Saves object to file
        /// </summary>
        /// <param name="filename">File name. </param>
        /// <param name="structPtr">Object to save. </param>
        /// <param name="name">Optional object name. If it is null, the name will be formed from filename. </param>
        /// <param name="comment">Optional comment to put in the beginning of the file. </param>
        /// <param name="attributes">Optional attributes passed to cvWrite. </param>
#endif
        public static void Save(string filename, IntPtr structPtr, string name, string comment, CvAttrList attributes)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            if (structPtr == IntPtr.Zero)
                throw new ArgumentNullException("structPtr");
            CvInvoke.cvSave(filename, structPtr, name, comment, attributes);
        }
        #endregion
        #region ICvPtrHolder
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルに保存する
        /// </summary>
        /// <param name="structPtr">保存するオブジェクト.</param>
        /// <param name="filename">ファイル名.</param>
#else
        /// <summary>
        /// Saves object to file
        /// </summary>
        /// <param name="structPtr">Object to save. </param>
        /// <param name="filename">File name. </param>
#endif
        public static void Save(ICvPtrHolder structPtr, string filename)
        {
            Save(structPtr, filename, null, null, new CvAttrList());
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルに保存する
        /// </summary>
        /// <param name="structPtr">保存するオブジェクト.</param>
        /// <param name="filename">ファイル名.</param>
        /// <param name="name">オブジェクト名（オプション）．nullの場合，名前はfilenameから生成される．</param>
#else
        /// <summary>
        /// Saves object to file
        /// </summary>
        /// <param name="structPtr">Object to save. </param>
        /// <param name="filename">File name. </param>
        /// <param name="name">Optional object name. If it is null, the name will be formed from filename. </param>
#endif
        public static void Save(ICvPtrHolder structPtr, string filename, string name)
        {
            Save(structPtr, filename, name, null, new CvAttrList());
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルに保存する
        /// </summary>
        /// <param name="structPtr">保存するオブジェクト.</param>
        /// <param name="filename">ファイル名.</param>
        /// <param name="name">オブジェクト名（オプション）．nullの場合，名前はfilenameから生成される．</param>
        /// <param name="comment">ファイルの最初に置かれるコメント（オプション）.</param>
#else
        /// <summary>
        /// Saves object to file
        /// </summary>
        /// <param name="structPtr">Object to save. </param>
        /// <param name="filename">File name. </param>
        /// <param name="name">Optional object name. If it is null, the name will be formed from filename. </param>
        /// <param name="comment">Optional comment to put in the beginning of the file. </param>
#endif
        public static void Save(ICvPtrHolder structPtr, string filename, string name, string comment)
        {
            Save(structPtr, filename, name, comment, new CvAttrList());
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルに保存する
        /// </summary>
        /// <param name="structPtr">保存するオブジェクト.</param>
        /// <param name="filename">ファイル名.</param>
        /// <param name="name">オブジェクト名（オプション）．nullの場合，名前はfilenameから生成される．</param>
        /// <param name="comment">ファイルの最初に置かれるコメント（オプション）.</param>
        /// <param name="attributes">cvWriteに渡される属性（オプション）.</param>
#else
        /// <summary>
        /// Saves object to file
        /// </summary>
        /// <param name="structPtr">Object to save. </param>
        /// <param name="filename">File name. </param>
        /// <param name="name">Optional object name. If it is null, the name will be formed from filename. </param>
        /// <param name="comment">Optional comment to put in the beginning of the file. </param>
        /// <param name="attributes">Optional attributes passed to cvWrite. </param>
#endif
        public static void Save(ICvPtrHolder structPtr, string filename, string name, string comment, CvAttrList attributes)
        {
            if (structPtr == null)
            {
                throw new ArgumentNullException("structPtr");
            }
            Save(filename, structPtr.CvPtr, name, comment, attributes);
        }
        #endregion
        #endregion
        #region SaveImage
#if LANG_JP
        /// <summary>
        /// 画像を指定したファイルに保存する．画像フォーマットは，filename の拡張子により決定される．
        /// この関数で保存できるのは，8 ビット 1チャンネル，あるいは 8 ビット3 チャンネル（'BGR' の順）画像だけである．
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <param name="image">画像ポインタ</param>
        /// <param name="prms"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Saves the image to the specified file. The image format is chosen depending on the filename extension, see cvLoadImage. 
        /// Only 8-bit single-channel or 3-channel (with 'BGR' channel order) images can be saved using this function. 
        /// </summary>
        /// <param name="filename">Name of the file. </param>
        /// <param name="image">Image to be saved. </param>
        /// <param name="prms"></param>
        /// <returns></returns>
#endif
        public static int SaveImage(string filename, CvArr image, int[] prms)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            if (image == null)
                throw new ArgumentNullException("image");

            string fullPath = Path.GetFullPath(filename);
            string dir = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(dir))
                throw new DirectoryNotFoundException(string.Format("Directory '{0}' not found", dir));

            int[] prmsWithSentinel;
            if (prms != null && prms.Length%2 == 0)
            {
                prmsWithSentinel = new int[prms.Length + 1];
                Array.Copy(prms, prmsWithSentinel, prms.Length);
                prmsWithSentinel[prms.Length - 1] = -1;
            }
            else
            {
                prmsWithSentinel = prms;
            }
            return CvInvoke.cvSaveImage(filename, image.CvPtr, prmsWithSentinel);
        }
#if LANG_JP
        /// <summary>
        /// 画像を指定したファイルに保存する．画像フォーマットは，filename の拡張子により決定される．
        /// この関数で保存できるのは，8 ビット 1チャンネル，あるいは 8 ビット3 チャンネル（'BGR' の順）画像だけである．
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <param name="image">画像ポインタ</param>
        /// <param name="prms"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Saves the image to the specified file. The image format is chosen depending on the filename extension, see cvLoadImage. 
        /// Only 8-bit single-channel or 3-channel (with 'BGR' channel order) images can be saved using this function. 
        /// </summary>
        /// <param name="filename">Name of the file. </param>
        /// <param name="image">Image to be saved. </param>
        /// <param name="prms"></param>
        /// <returns></returns>
#endif
        public static int SaveImage(string filename, CvArr image, params ImageEncodingParam[] prms)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");

            string fullPath = Path.GetFullPath(filename);
            string dir = Path.GetDirectoryName(fullPath);
            if(!Directory.Exists(dir))
                throw new DirectoryNotFoundException(string.Format("Directory '{0}' not found", dir));

            List<int> p = new List<int>();
            if (prms != null)
            {
                foreach (ImageEncodingParam item in prms)
                {
                    p.Add((int)item.EncodingID);
                    p.Add(item.Value);
                }
                p.Add(-1);
                return CvInvoke.cvSaveImage(filename, image.CvPtr, p.ToArray());
            }
            else
            {
                return CvInvoke.cvSaveImage(filename, image.CvPtr, null);
            }
        }
        #endregion
        #region SaveMemStoragePos
#if LANG_JP
        /// <summary>
        /// メモリストレージの位置を保存する
        /// </summary>
        /// <param name="storage">メモリストレージ．</param>
        /// <param name="pos">出力するストレージ先頭の位置．</param>
#else
        /// <summary>
        /// Saves memory storage position
        /// </summary>
        /// <param name="storage">Memory storage. </param>
        /// <param name="pos">The output position of the storage top. </param>
#endif
        public static void SaveMemStoragePos(CvMemStorage storage, out CvMemStoragePos pos)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            pos = new CvMemStoragePos();
            CvInvoke.cvSaveMemStoragePos(storage.CvPtr, pos.CvPtr);
        }
        #endregion
        #region SaveWindowParameters
#if LANG_JP
        /// <summary>
        /// ウィンドウのパラメータを保存します．
        /// </summary>
        /// <param name="name">ウィンドウの名前</param>
#else
        /// <summary>
        /// Save parameters of the window.
        /// </summary>
        /// <param name="name">Name of the window</param>
#endif
        public static void SaveWindowParameters(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            CvInvoke.cvSaveWindowParameters(name);
        }
        #endregion
        #region ScalarAll
#if LANG_JP
        /// <summary>
        /// 指定した値を配列のすべての要素として初期化し、返す
        /// </summary>
        /// <param name="val0123"></param>
#else
        /// <summary>
        /// Initializes val[0]...val[3] with val0123
        /// </summary>
        /// <param name="val0123"></param>
        /// <returns></returns>
#endif
        public static CvScalar ScalarAll(double val0123)
        {
            return new CvScalar(val0123, val0123, val0123, val0123);
        }
        #endregion
        #region ScaleAdd
#if LANG_JP
        /// <summary>
        /// スケーリングされた配列ともう一つの配列の和を計算する.
        /// dst(I)=src1(I)*scale + src2(I)
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="scale">1番目の配列のためのスケールファクタ</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates sum of scaled array and another array
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="scale">Scale factor for the first array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array </param>
#endif
        public static void ScaleAdd(CvArr src1, CvScalar scale, CvArr src2, CvArr dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvScaleAdd(src1.CvPtr, scale, src2.CvPtr, dst.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// スケーリングされた配列ともう一つの配列の和を計算する (cvScaleAddのエイリアス).
        /// dst(I)=src1(I)*scale + src2(I)
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="scale">1番目の配列のためのスケールファクタ</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates sum of scaled array and another array
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="scale">Scale factor for the first array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array </param>
#endif
        public static void MulAddS(CvArr src1, CvScalar scale, CvArr src2, CvArr dst)
        {
            ScaleAdd(src1, scale, src2, dst);
        }
#if LANG_JP
        /// <summary>
        /// cvScaleAdd(A, cvRealScalar(real_scalar), B, C)
        /// </summary>
        /// <param name="A"></param>
        /// <param name="realScalar"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
#else
        /// <summary>
        /// cvScaleAdd(A, cvRealScalar(real_scalar), B, C)
        /// </summary>
        /// <param name="A"></param>
        /// <param name="realScalar"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
#endif
// ReSharper disable InconsistentNaming
        public static void AXPY(CvArr A, double realScalar, CvArr B, CvArr C)
// ReSharper restore InconsistentNaming
        {
            ScaleAdd(A, CvScalar.RealScalar(realScalar), B, C);
        }
        #endregion
        #region SegmentFGMask
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fgmask"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fgmask"></param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> SegmentFGMask(CvArr fgmask)
        {
            return SegmentFGMask(fgmask, true, 4.0f, null, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fgmask"></param>
        /// <param name="poly1Hull0"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fgmask"></param>
        /// <param name="poly1Hull0"></param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> SegmentFGMask(CvArr fgmask, bool poly1Hull0)
        {
            return SegmentFGMask(fgmask, poly1Hull0, 4.0f, null, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fgmask"></param>
        /// <param name="poly1Hull0"></param>
        /// <param name="perimScale"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fgmask"></param>
        /// <param name="poly1Hull0"></param>
        /// <param name="perimScale"></param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> SegmentFGMask(CvArr fgmask, bool poly1Hull0, float perimScale)
        {
            return SegmentFGMask(fgmask, poly1Hull0, perimScale, null, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fgmask"></param>
        /// <param name="poly1Hull0"></param>
        /// <param name="perimScale"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fgmask"></param>
        /// <param name="poly1Hull0"></param>
        /// <param name="perimScale"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> SegmentFGMask(CvArr fgmask, bool poly1Hull0, float perimScale, CvMemStorage storage)
        {
            return SegmentFGMask(fgmask, poly1Hull0, perimScale, storage, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fgmask"></param>
        /// <param name="poly1Hull0"></param>
        /// <param name="perimScale"></param>
        /// <param name="storage"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fgmask"></param>
        /// <param name="poly1Hull0"></param>
        /// <param name="perimScale"></param>
        /// <param name="storage"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> SegmentFGMask(CvArr fgmask, bool poly1Hull0, float perimScale, CvMemStorage storage, CvPoint offset)
        {
            if (fgmask == null)
                throw new ArgumentNullException("fgmask");

            IntPtr storagePtr = ToPtr(storage);
            IntPtr ptr = CvInvoke.cvSegmentFGMask(fgmask.CvPtr, poly1Hull0, perimScale, storagePtr, offset);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvSeq<CvPoint>(ptr);
        }
        #endregion
        #region SegmentMotion
#if LANG_JP
        /// <summary>
        /// 全体のモーションを動作部分毎に分割する
        /// </summary>
        /// <param name="mhi">モーション履歴画像</param>
        /// <param name="segMask">検出されたマスクが格納される画像，シングルチャンネル，32ビット浮動小数点型．</param>
        /// <param name="storage">成分に関連づけられたモーション列が格納されるメモリ領域． </param>
        /// <param name="timestamp">ミリ秒単位，あるいはその他の単位で表される現在時刻． </param>
        /// <param name="segThresh">セグメンテーション閾値．モーション履歴の間隔と同じか，それより大きい値にすることが推奨される． </param>
#else
        /// <summary>
        /// Segments whole motion into separate moving parts
        /// </summary>
        /// <param name="mhi">Motion history image.</param>
        /// <param name="segMask">Image where the mask found should be stored, single-channel, 32-bit floating-point.</param>
        /// <param name="storage">Memory storage that will contain a sequence of motion connected components.</param>
        /// <param name="timestamp">Current time in milliseconds or other units.</param>
        /// <param name="segThresh">Segmentation threshold; recommended to be equal to the interval between motion history "steps" or greater.</param>
#endif
        public static CvSeq SegmentMotion(CvArr mhi, CvArr segMask, CvMemStorage storage, double timestamp, double segThresh)
        {
            if (mhi == null)
                throw new ArgumentNullException("mhi");
            if (storage == null)
                throw new ArgumentNullException("storage");
            return new CvSeq(CvInvoke.cvSegmentMotion(mhi.CvPtr, segMask.CvPtr, storage.CvPtr, timestamp, segThresh));
        }
        #endregion
        #region SeqElemIdx
#if LANG_JP
        /// <summary>
        /// 指定されたシーケンスの要素のインデックスを返す
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="seq">シーケンス．</param>
        /// <param name="element">シーケンス要素</param>
        /// <returns>指定されたシーケンス要素のインデックス</returns>
#else
        /// <summary>
        /// Returns index of concrete sequence element
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="element">the element within the sequence. </param>
        /// <returns>the index of a sequence element or a negative number if the element is not found.</returns>
#endif
        public static int SeqElemIdx<T>(CvSeq seq, T element) //where T : struct
        {
            CvSeqBlock block;
            return SeqElemIdx(seq, element, out block);
        }
#if LANG_JP
        /// <summary>
        /// 指定されたシーケンスの要素のインデックスを返す
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="seq">シーケンス．</param>
        /// <param name="element">シーケンス要素</param>
        /// <param name="block">要素を含むシーケンスブロックのアドレスがこの場所に保存される．</param>
        /// <returns>指定されたシーケンス要素のインデックス</returns>
#else
        /// <summary>
        /// Returns index of concrete sequence element
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="element">the element within the sequence. </param>
        /// <param name="block">the address of the sequence block that contains the element is stored in this location. </param>
        /// <returns>the index of a sequence element or a negative number if the element is not found.</returns>
#endif
        public static int SeqElemIdx<T>(CvSeq seq, T element, out CvSeqBlock block) //where T : struct
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }

            block = new CvSeqBlock();
            IntPtr blockPtr = block.CvPtr;
            if (typeof(T).IsValueType)
            {
                using (StructurePointer<T> elementPtr = new StructurePointer<T>(element))
                {
                    return CvInvoke.cvSeqElemIdx(seq.CvPtr, elementPtr, ref blockPtr);
                }
            }
            else
            {
                try
                {
                    ICvPtrHolder ph = (ICvPtrHolder)element;
                    return CvInvoke.cvSeqElemIdx(seq.CvPtr, ph.CvPtr, ref blockPtr);
                }
                catch(InvalidCastException)
                {
                    throw new OpenCvSharpException("{} is invalid type for this method.", typeof(T).Name);
                }
            }
        }
        #endregion
        #region SeqInsert
#if LANG_JP
        /// <summary>
        /// シーケンスの中に要素を挿入する
        /// </summary>
        /// <typeparam name="T">追加する要素の型.プリミティブ型か、OpenCVの構造体(CvPointなど).</typeparam>
        /// <param name="seq">シーケンス</param>
        /// <param name="beforeIndex">要素が挿入されるインデックス（このインデックスの前に挿入される）</param>
        /// <param name="element">追加される要素. プリミティブ型か、OpenCVの構造体(CvPointなど).</param>
        /// <returns>追加された要素</returns>
#else
        /// <summary>
        /// Inserts element in sequence middle
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="beforeIndex">Index before which the element is inserted. Inserting before 0 (the minimal allowed value of the parameter) is equal to cvSeqPushFront and inserting before seq->total (the maximal allowed value of the parameter) is equal to cvSeqPush. </param>
        /// <param name="element">Inserted element. </param>
        /// <returns>Inserted element. </returns>
#endif
        public static T SeqInsert<T>(CvSeq seq, int beforeIndex, T element) where T : struct
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }

            //if (typeof(T).IsValueType)
            {
                using (StructurePointer<T> elementPtr = new StructurePointer<T>(element))
                {
                    IntPtr ptr = CvInvoke.cvSeqInsert(seq.CvPtr, beforeIndex, elementPtr);
                    return elementPtr.ToStructure();
                }
            }
            /*
            else
            {
                try
                {
                    ICvPtrHolder ph = (ICvPtrHolder)element;
                    IntPtr ptr = CvDll.cvSeqInsert(seq.CvPtr, before_index, ph.CvPtr);
                    return Util.ToObject<T>(ptr);
                }
                catch (InvalidCastException)
                {
                    throw new OpenCvSharpException("{} is invalid type for this method.", typeof(T).Name);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //*/
        }
        #endregion
        #region SeqInsertSlice
#if LANG_JP
        /// <summary>
        /// シーケンス内に配列を挿入する
        /// </summary>
        /// <param name="seq">シーケンス．</param>
        /// <param name="beforeIndex">配列が挿入される場所へのインデックス（インデックスの前に挿入される）．</param>
        /// <param name="fromArr">追加される要素の配列．</param>
#else
        /// <summary>
        /// Inserts array in the middle of sequence
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <param name="beforeIndex">The part of the sequence to remove. </param>
        /// <param name="fromArr">The array to take elements from. </param>
#endif
        public static void SeqInsertSlice(CvSeq seq, int beforeIndex, CvArr fromArr)
        {
            if (seq == null)
                throw new ArgumentNullException("seq");
            if (fromArr == null)
                throw new ArgumentNullException("fromArr");
            CvInvoke.cvSeqInsertSlice(seq.CvPtr, beforeIndex, fromArr.CvPtr);
        }
        #endregion
        #region SeqInvert
#if LANG_JP
        /// <summary>
        /// シーケンス要素の順序を反転させる
        /// </summary>
        /// <param name="seq">シーケンス．</param>
#else
        /// <summary>
        /// Reverses the order of sequence elements
        /// </summary>
        /// <param name="seq">Sequence. </param>
#endif
        public static void SeqInvert(CvSeq seq)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            CvInvoke.cvSeqInvert(seq.CvPtr);
        }
        #endregion
        #region SeqRemove
#if LANG_JP
        /// <summary>
        /// 与えられたインデックスをもつ要素を削除する．
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="index">削除される要素のインデックス</param>
#else
        /// <summary>
        /// Removes element from sequence middle
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <param name="index">Index of removed element. </param>
#endif
        public static void SeqRemove(CvSeq seq, int index)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            CvInvoke.cvSeqRemove(seq.CvPtr, index);
        }
        #endregion
        #region SeqRemoveSlice
#if LANG_JP
        /// <summary>
        /// シーケンススライスを削除する
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="slice">削除するシーケンスの一部分． </param>
#else
        /// <summary>
        /// Removes sequence slice
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <param name="slice">The part of the sequence to remove. </param>
#endif
        public static void SeqRemoveSlice(CvSeq seq, CvSlice slice)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            CvInvoke.cvSeqRemoveSlice(seq.CvPtr, slice);
        }
        #endregion
        #region SeqPartition
#if LANG_JP
        /// <summary>
        /// データシーケンスを同値類（同じクラスに属すると定義されたデータ群）に分割する
        /// </summary>
        /// <param name="seq">分割対象のシーケンス.</param>
        /// <param name="storage">同値類として分割されたシーケンスの保存領域．nullの場合は，seq->storage を使用する．</param>
        /// <param name="labels">出力パラメータ．入力シーケンスの各要素に割り振られた（分割結果を表す）0から始まるラベルシーケンスへのポインタのポインタ．</param>
        /// <param name="isEqual">2つのシーケンス要素が同じクラスである場合，関係関数は 0以外を返す． そうでなければ0を返す．分割アルゴリズムは，同値基準として関係関数の推移閉包を用いる．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Splits sequence into equivalence classes
        /// </summary>
        /// <param name="seq">The sequence to partition. </param>
        /// <param name="storage">The storage to store the sequence of equivalence classes. If it is null, the function uses seq->storage for output labels. </param>
        /// <param name="labels">Output parameter. Double pointer to the sequence of 0-based labels of input sequence elements. </param>
        /// <param name="isEqual">The relation function that should return non-zero if the two particular sequence elements are from the same class, and zero otherwise. The partitioning algorithm uses transitive closure of the relation function as equivalence criteria. </param>
        /// <returns></returns>
#endif
        public static int SeqPartition(CvSeq seq, CvMemStorage storage, out CvSeq labels, CvCmpFunc isEqual)
        {
            if (seq == null)
                throw new ArgumentNullException("seq");
            if (isEqual == null)
                throw new ArgumentNullException("isEqual");

            IntPtr storagePtr = (storage == null) ? IntPtr.Zero : storage.CvPtr;
            IntPtr labelsPtr = IntPtr.Zero;

            GCHandle gch = GCHandle.Alloc(isEqual);
            int result = CvInvoke.cvSeqPartition(seq.CvPtr, storagePtr, ref labelsPtr, isEqual, IntPtr.Zero);
            gch.Free();

            if (labelsPtr == IntPtr.Zero)
                labels = null;
            else
                labels = new CvSeq(labelsPtr);

            return result;
        }

#if LANG_JP
        /// <summary>
        /// データシーケンスを同値類（同じクラスに属すると定義されたデータ群）に分割する
        /// </summary>
        /// <param name="seq">分割対象のシーケンス.</param>
        /// <param name="storage">同値類として分割されたシーケンスの保存領域．nullの場合は，seq->storage を使用する．</param>
        /// <param name="labels">出力パラメータ．入力シーケンスの各要素に割り振られた（分割結果を表す）0から始まるラベルシーケンスへのポインタのポインタ．</param>
        /// <param name="isEqual">2つのシーケンス要素が同じクラスである場合，関係関数は 0以外を返す． そうでなければ0を返す．分割アルゴリズムは，同値基準として関係関数の推移閉包を用いる．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Splits sequence into equivalence classes
        /// </summary>
        /// <param name="seq">The sequence to partition. </param>
        /// <param name="storage">The storage to store the sequence of equivalence classes. If it is null, the function uses seq->storage for output labels. </param>
        /// <param name="labels">Output parameter. Double pointer to the sequence of 0-based labels of input sequence elements. </param>
        /// <param name="isEqual">The relation function that should return non-zero if the two particular sequence elements are from the same class, and zero otherwise. The partitioning algorithm uses transitive closure of the relation function as equivalence criteria. </param>
        /// <returns></returns>
#endif
        public static int SeqPartition<T>(CvSeq<T> seq, CvMemStorage storage, out CvSeq labels, CvCmpFunc<T> isEqual)
            where T : struct
        {
            if (isEqual == null)
                throw new ArgumentNullException("isEqual");

            CvCmpFunc isEqualNongeneric = delegate(IntPtr a, IntPtr b)
            {
                T aValue = (T)Marshal.PtrToStructure(a, typeof(T)); //Util.ToObject<T>(a);
                T bValue = (T)Marshal.PtrToStructure(b, typeof(T)); //Util.ToObject<T>(b);
                return isEqual(aValue, bValue);
            };

            return SeqPartition(seq, storage, out labels, isEqualNongeneric);
        }
        #endregion
        #region SeqPop
#if LANG_JP
        /// <summary>
        /// シーケンスの末尾から一つの要素を削除する．
        /// シーケンスが既に空の場合は，エラーを返す．この関数の計算量は O(1) である．
        /// </summary>
        /// <param name="seq">シーケンス</param>
#else
        /// <summary>
        /// Removes element from sequence end
        /// </summary>
        /// <param name="seq">Sequence. </param>
#endif
        public static void SeqPop(CvSeq seq)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            CvInvoke.cvSeqPop(seq.CvPtr, IntPtr.Zero);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスの末尾から一つの要素を削除する．
        /// シーケンスが既に空の場合は，エラーを返す．この関数の計算量は O(1) である．
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="seq">シーケンス</param>
        /// <param name="element">削除した要素をコピーする出力先</param>
#else
        /// <summary>
        /// Removes element from sequence end
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="element">copied the removed element to this location. </param>
#endif
        public static void SeqPop<T>(CvSeq seq, out T element) where T : struct
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            //if (typeof(T).IsValueType)
            {
                using (StructurePointer<T> elementPtr = new StructurePointer<T>())
                {
                    // ptrにpopした結果を格納してもらう
                    CvInvoke.cvSeqPop(seq.CvPtr, elementPtr);
                    // T型にキャスト
                    element = elementPtr.ToStructure();
                }
            }
            /*
            else
            {
                try
                {
                    using (StructurePointer<IntPtr> result = new StructurePointer<IntPtr>())
                    {
                        CvDll.cvSeqPop(seq.CvPtr, result.Ptr);
                        IntPtr ptr = Marshal.ReadIntPtr(result.Ptr);
                        element = Util.ToObject<T>(ptr);
                    }                    
                }
                catch (InvalidCastException)
                {
                    throw new OpenCvSharpException("{} is invalid type for this method.", typeof(T).Name);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //*/
        }
        #endregion
        #region SeqPopFront
#if LANG_JP
        /// <summary>
        /// シーケンスの先頭から一つの要素を削除する．
        /// シーケンスが既に空の場合は，エラーを返す．この関数の計算量は O(1) である．
        /// </summary>
        /// <param name="seq">シーケンス</param>
#else
        /// <summary>
        /// Removes element from sequence beginning
        /// </summary>
        /// <param name="seq">Sequence. </param>
#endif
        public static void SeqPopFront(CvSeq seq)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            CvInvoke.cvSeqPopFront(seq.CvPtr, IntPtr.Zero);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスの先頭から一つの要素を削除する．
        /// シーケンスが既に空の場合は，エラーを返す．この関数の計算量は O(1) である．
        /// </summary>
        /// <typeparam name="T">出力先オブジェクトの型</typeparam>
        /// <param name="seq">シーケンス</param>
        /// <param name="element">削除した要素をコピーする出力先</param>
#else
        /// <summary>
        /// Removes element from sequence beginning
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="element">copied the removed element to this location. </param>
#endif
        public static void SeqPopFront<T>(CvSeq seq, out T element) where T : struct
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }

            //if (typeof(T).IsValueType)
            {
                using (StructurePointer<T> elementPtr = new StructurePointer<T>())
                {
                    CvInvoke.cvSeqPopFront(seq.CvPtr, elementPtr);
                    element = elementPtr.ToStructure();
                }
            }
            /*
            else
            {
                try
                {
                    using (StructurePointer<IntPtr> result = new StructurePointer<IntPtr>())
                    {
                        CvDll.cvSeqPopFront(seq.CvPtr, result.Ptr);
                        IntPtr ptr = Marshal.ReadIntPtr(result.Ptr);
                        element = Util.ToObject<T>(ptr);
                    }
                }
                catch (InvalidCastException)
                {
                    throw new OpenCvSharpException("{} is invalid type for this method.", typeof(T).Name);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //*/
        }
        #endregion
        #region SeqPopMulti
#if LANG_JP
        /// <summary>
        /// 複数の要素をシーケンスのどちらかの端（先頭か末尾）から削除する
        /// </summary>
        /// <typeparam name="T">削除する要素の型</typeparam>
        /// <param name="seq">シーケンス．</param>
        /// <param name="elements">削除される要素．</param>
        /// <param name="count">削除される要素数． </param>
        /// <param name="inFront">変更するシーケンスの端を指定するフラグ．</param>
#else
        /// <summary>
        /// Removes several elements from the either end of sequence
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="elements">Removed elements. </param>
        /// <param name="count">Number of elements to pop. </param>
        /// <param name="inFront">The flags specifying the modified sequence end</param>
#endif
        public static void SeqPopMulti<T>(CvSeq seq, out T[] elements, int count, InsertPosition inFront) where T : struct
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }

            elements = new T[count];

            //if (typeof(T).IsValueType)  // where T : struct
            {
                using (var elementsPtr = new ArrayAddress1<T>(elements))
                {
                    CvInvoke.cvSeqPopMulti(seq.CvPtr, elementsPtr, elements.Length, inFront);
                }
            }
            /*
            else  // CvSeq, CvMat, etc.
            {
                // IntPtrを取るコンストラクタをもたなければならない
                IntPtr[] ptrArray = new IntPtr[count];
                using (var ptr = new ArrayAddress1<IntPtr>(ptrArray))
                {
                    CvDll.cvSeqPopMulti(seq.CvPtr, ptr, elements.Length, in_front);
                }
                for (int i = 0; i < ptrArray.Length; i++)
                {
                    elements[i] = Util.ToObject<T>(ptrArray[i]);
                }
            }
            //*/
        }
        #endregion
        #region SeqPush
#if LANG_JP
        /// <summary>
        /// シーケンスの末尾に要素一つ分の領域を確保する．
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <returns></returns>
#else
        /// <summary>
        /// allocates a space for one more element.
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <returns>pointer to the allocated element. </returns>
#endif
        public static IntPtr SeqPush(CvSeq seq)
        {
            return CvInvoke.cvSeqPush(seq.CvPtr, IntPtr.Zero);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスの末尾に要素を追加し，割り付けられた要素を返す．
        /// 入力の element が null の場合，この関数は単に要素一つ分の領域を確保する．
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="element">追加される要素. プリミティブ型か、OpenCVの構造体(CvPointなど).</param>
        /// <returns>追加された要素</returns>
#else
        /// <summary>
        /// Adds element to sequence end
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="element">Added element. </param>
        /// <returns>pointer to the allocated element. </returns>
#endif
        public static T SeqPush<T>(CvSeq seq, T element) where T : struct
        {
            IntPtr ptr;
            //if (typeof(T).IsValueType)
            {
                using (StructurePointer elementPtr = new StructurePointer(element))
                {
                    ptr = CvInvoke.cvSeqPush(seq.CvPtr, elementPtr);
                }
            }
            /*
            else
            {
                if (element == null)
                {
                    ptr = CvDll.cvSeqPush(seq.CvPtr, IntPtr.Zero);
                }
                else
                {
                    try
                    {
                        ICvPtrHolder ph = (ICvPtrHolder)element;
                        using (StructurePointer elementPtr = new StructurePointer(ph.CvPtr))
                        {
                            ptr = CvDll.cvSeqPush(seq.CvPtr, elementPtr);
                        }
                    }
                    catch (InvalidCastException)
                    {
                        throw new OpenCvSharpException("{} is invalid type for this method.", typeof(T).Name);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            //*/
            return Util.ToObject<T>(ptr);
        }
        #endregion
        #region SeqPushFront
#if LANG_JP
        /// <summary>
        /// シーケンスの先頭に要素一つ分の領域を確保する．
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <returns>追加された要素へのポインタ</returns>
#else
        /// <summary>
        /// Adds element to sequence beginning
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <returns>pointer to the added element</returns>
#endif
        public static IntPtr SeqPushFront(CvSeq seq) 
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            return CvInvoke.cvSeqPushFront(seq.CvPtr, IntPtr.Zero);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスの先頭に要素を追加し，割り付けられた要素へのポインタを返す．
        /// 入力の element が null の場合，この関数は単に要素一つ分の領域を確保する．
        /// </summary>
        /// <typeparam name="T">追加する要素の型. プリミティブ型か、OpenCVの構造体(CvPointなど).</typeparam>
        /// <param name="seq">シーケンス</param>
        /// <param name="element">追加される要素. プリミティブ型か、OpenCVの構造体(CvPointなど).</param>
        /// <returns>追加された要素</returns>
#else
        /// <summary>
        /// Adds element to sequence beginning
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="element">Added element. </param>
        /// <returns>pointer to the added element</returns>
#endif
        public static T SeqPushFront<T>(CvSeq seq, T element) where T : struct
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }

            IntPtr ptr;
            //if (typeof(T).IsValueType)
            {
                using (StructurePointer elementPtr = new StructurePointer(element))
                {
                    ptr = CvInvoke.cvSeqPushFront(seq.CvPtr, elementPtr);
                }
            }
            /*
            else
            {
                if (element == null)
                {
                    ptr = CvDll.cvSeqPushFront(seq.CvPtr, IntPtr.Zero);
                }
                else
                {
                    try
                    {
                        ICvPtrHolder ph = (ICvPtrHolder)element;
                        using (StructurePointer elementPtr = new StructurePointer(ph.CvPtr))
                        {
                            ptr = CvDll.cvSeqPushFront(seq.CvPtr, elementPtr);
                        }
                    }
                    catch (InvalidCastException)
                    {
                        throw new OpenCvSharpException("{} is invalid type for this method.", typeof(T).Name);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            //*/
            return Util.ToObject<T>(ptr);
        }
        #endregion
        #region SeqPushMulti
#if LANG_JP
        /// <summary>
        /// 複数の要素をシーケンスのどちらかの端（先頭か末尾）に追加する
        /// </summary>
        /// <typeparam name="T">追加する要素の型</typeparam>
        /// <param name="seq">シーケンス．</param>
        /// <param name="elements">追加される要素群．</param>
        /// <param name="inFront">変更するシーケンスの端を指定するフラグ．</param>
#else
        /// <summary>
        /// Pushes several elements to the either end of sequence
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="elements">Added elements. </param>
        /// <param name="inFront">The flags specifying the modified sequence end</param>
#endif
        public static void SeqPushMulti<T>(CvSeq seq, T[] elements, InsertPosition inFront) where T : struct
        {
            if (seq == null)
                throw new ArgumentNullException("seq");
            if (elements == null)
                throw new ArgumentNullException("elements");            

            //if (typeof(T).IsValueType)  // where T : struct
            {
                using (var elementsPtr = new ArrayAddress1<T>(elements))
                {
                    CvInvoke.cvSeqPushMulti(seq.CvPtr, elementsPtr, elements.Length, inFront);
                }
            }
            /*
            else  // CvSeq, CvMat, etc.
            {
                try
                {
                    IntPtr[] ptrArray = new IntPtr[elements.Length];
                    for (int i = 0; i < ptrArray.Length; i++)
                    {
                        ptrArray[i] = ((ICvPtrHolder)elements[i]).CvPtr;
                    }
                    using (var ptr = new ArrayAddress1<IntPtr>(ptrArray))
                    {
                        CvDll.cvSeqPushMulti(seq.CvPtr, ptr, elements.Length, in_front);
                    }
                }
                catch (InvalidCastException)
                {
                    throw new OpenCvSharpException("{} is invalid type for this method.", typeof(T).Name);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //*/
        }
        #endregion
        #region SeqSearch
#if LANG_JP
        /// <summary>
        /// シーケンスの中から要素を検索する
        /// </summary>
        /// <param name="seq">ソートされるシーケンス</param>
        /// <param name="elem">検索する要素</param>
        /// <param name="func">要素の関係に応じて，負・0・正の値を返す比較関数</param>
        /// <param name="isSorted">シーケンスがソート済みか否かを示すフラグ</param>
        /// <param name="elemIdx">出力パラメータ．見つかった要素のインデックス．</param>
#else
        /// <summary>
        /// Searches element in sequence
        /// </summary>
        /// <param name="seq">The sequence </param>
        /// <param name="elem">The element to look for </param>
        /// <param name="func">The comparison function that returns negative, zero or positive value depending on the elements relation</param>
        /// <param name="isSorted">Whether the sequence is sorted or not. </param>
        /// <param name="elemIdx">Output parameter; index of the found element. </param>
        /// <returns></returns>
#endif
        public static IntPtr SeqSearch(CvSeq seq, IntPtr elem, CvCmpFunc func, bool isSorted, out int elemIdx)
        {
            if (seq == null)
                throw new ArgumentNullException("seq");
            if (func == null)
                throw new ArgumentNullException("func");
            using (ScopedGCHandle funcHandle = new ScopedGCHandle(func, GCHandleType.Normal))
            {
                return CvInvoke.cvSeqSearch(seq.CvPtr, elem, funcHandle.AddrOfPinnedObject(), isSorted, out elemIdx);
            }
        }
#if LANG_JP
        /// <summary>
        /// シーケンスの中から要素を検索する
        /// </summary>
        /// <param name="seq">ソートされるシーケンス</param>
        /// <param name="elem">検索する要素</param>
        /// <param name="func">要素の関係に応じて，負・0・正の値を返す比較関数</param>
        /// <param name="isSorted">シーケンスがソート済みか否かを示すフラグ</param>
        /// <param name="elemIdx">出力パラメータ．見つかった要素のインデックス．</param>
#else
        /// <summary>
        /// Searches element in sequence
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">The sequence </param>
        /// <param name="elem">The element to look for </param>
        /// <param name="func">The comparison function that returns negative, zero or positive value depending on the elements relation</param>
        /// <param name="isSorted">Whether the sequence is sorted or not. </param>
        /// <param name="elemIdx">Output parameter; index of the found element. </param>
        /// <returns></returns>
#endif
        public static T SeqSearch<T>(CvSeq seq, T elem, CvCmpFunc<T> func, bool isSorted, out int elemIdx) where T : struct
        {
            if (seq == null)
                throw new ArgumentNullException("seq");
            if (func == null)
                throw new ArgumentNullException("func");

            // delegateを非ジェネリックのものに変換
            CvCmpFunc funcNonGeneric = delegate(IntPtr a, IntPtr b)
            {
                T aValue = (T)Marshal.PtrToStructure(a, typeof(T));//Util.ToObject<T>(a);
                T bValue = (T)Marshal.PtrToStructure(b, typeof(T));//Util.ToObject<T>(b);
                return func(aValue, bValue);
            };

            //if (typeof(T).IsValueType)
            {
                using (StructurePointer<T> elemPtr = new StructurePointer<T>(elem))
                {
                    IntPtr result = SeqSearch(seq, elemPtr, funcNonGeneric, isSorted, out elemIdx);
                    if (result == IntPtr.Zero)
                        throw new OpenCvSharpException("{0} is not found", elem);
                    else
                        return (T)Marshal.PtrToStructure(result, typeof(T));
                }
            }
            /*
            else
            {
                try
                {
                    ICvPtrHolder ph = (ICvPtrHolder)elem;
                    using (StructurePointer<IntPtr> elemPtr = new StructurePointer<IntPtr>(ph.CvPtr))
                    {
                        IntPtr result = SeqSearch(seq, elemPtr, funcNonGeneric, is_sorted, out elem_idx);
                        if (result == IntPtr.Zero)
                            throw new OpenCvSharpException("{0} is not found", elem);
                        else
                            return Util.ToObject<T>(result);
                    }
                }
                catch (InvalidCastException)
                {
                    throw new OpenCvSharpException("{} is invalid type for this method.", typeof(T).Name);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //*/
        }
        #endregion
        #region SeqSlice
#if LANG_JP
        /// <summary>
        /// シーケンススライスのための別のヘッダを作成する
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="slice">抽出するシーケンスの一部分</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes separate header for the sequence slice
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <param name="slice">The part of the sequence to extract. </param>
        /// <returns></returns>
#endif
        public static CvSeq SeqSlice(CvSeq seq, CvSlice slice)
        {
            return SeqSlice(seq, slice, null, false);
        }
#if LANG_JP
        /// <summary>
        /// シーケンススライスのための別のヘッダを作成する
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="slice">抽出するシーケンスの一部分</param>
        /// <param name="storage">新しいシーケンスヘッダとコピーされたデータ（もしデータがあれば）を保存する出力ストレージ． nullの場合，この関数は入力シーケンスに含まれるストレージを使用する</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes separate header for the sequence slice
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <param name="slice">The part of the sequence to extract. </param>
        /// <param name="storage">The destination storage to keep the new sequence header and the copied data if any. If it is null, the function uses the storage containing the input sequence. </param>
        /// <returns></returns>
#endif
        public static CvSeq SeqSlice(CvSeq seq, CvSlice slice, CvMemStorage storage)
        {
            return SeqSlice(seq, slice, storage, false);
        }
#if LANG_JP
        /// <summary>
        /// シーケンススライスのための別のヘッダを作成する
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="slice">抽出するシーケンスの一部分</param>
        /// <param name="storage">新しいシーケンスヘッダとコピーされたデータ（もしデータがあれば）を保存する出力ストレージ． nullの場合，この関数は入力シーケンスに含まれるストレージを使用する</param>
        /// <param name="copyData">抽出されたスライスの要素をコピーするかしないかを示すフラグ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes separate header for the sequence slice
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <param name="slice">The part of the sequence to extract. </param>
        /// <param name="storage">The destination storage to keep the new sequence header and the copied data if any. If it is null, the function uses the storage containing the input sequence. </param>
        /// <param name="copyData">The flag that indicates whether to copy the elements of the extracted slice (copy_data=true) or not (copy_data=false) </param>
        /// <returns></returns>
#endif
        public static CvSeq SeqSlice(CvSeq seq, CvSlice slice, CvMemStorage storage, bool copyData)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            IntPtr storagePtr = (storage == null) ? IntPtr.Zero : storage.CvPtr;
            IntPtr result = CvInvoke.cvSeqSlice(seq.CvPtr, slice, storagePtr, copyData);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq(result);
        }
#if LANG_JP
        /// <summary>
        /// シーケンススライスのための別のヘッダを作成する
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="slice">抽出するシーケンスの一部分</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes separate header for the sequence slice
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="slice">The part of the sequence to extract. </param>
        /// <returns></returns>
#endif
        public static CvSeq<T> SeqSlice<T>(CvSeq<T> seq, CvSlice slice) where T : struct
        {
            return SeqSlice(seq, slice, null, false);
        }
#if LANG_JP
        /// <summary>
        /// シーケンススライスのための別のヘッダを作成する
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="slice">抽出するシーケンスの一部分</param>
        /// <param name="storage">新しいシーケンスヘッダとコピーされたデータ（もしデータがあれば）を保存する出力ストレージ． nullの場合，この関数は入力シーケンスに含まれるストレージを使用する</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes separate header for the sequence slice
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="slice">The part of the sequence to extract. </param>
        /// <param name="storage">The destination storage to keep the new sequence header and the copied data if any. If it is null, the function uses the storage containing the input sequence. </param>
        /// <returns></returns>
#endif
        public static CvSeq<T> SeqSlice<T>(CvSeq<T> seq, CvSlice slice, CvMemStorage storage) where T : struct
        {
            return SeqSlice(seq, slice, storage, false);
        }
#if LANG_JP
        /// <summary>
        /// シーケンススライスのための別のヘッダを作成する
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="slice">抽出するシーケンスの一部分</param>
        /// <param name="storage">新しいシーケンスヘッダとコピーされたデータ（もしデータがあれば）を保存する出力ストレージ． nullの場合，この関数は入力シーケンスに含まれるストレージを使用する</param>
        /// <param name="copyData">抽出されたスライスの要素をコピーするかしないかを示すフラグ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Makes separate header for the sequence slice
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="slice">The part of the sequence to extract. </param>
        /// <param name="storage">The destination storage to keep the new sequence header and the copied data if any. If it is null, the function uses the storage containing the input sequence. </param>
        /// <param name="copyData">The flag that indicates whether to copy the elements of the extracted slice (copy_data=true) or not (copy_data=false) </param>
        /// <returns></returns>
#endif
        public static CvSeq<T> SeqSlice<T>(CvSeq<T> seq, CvSlice slice, CvMemStorage storage, bool copyData) where T : struct
        {
            CvSeq result = SeqSlice((CvSeq)seq, slice, storage, copyData);
            return new CvSeq<T>(result);
        }
        #endregion
        #region SeqSort
#if LANG_JP
        /// <summary>
        /// シーケンスの要素を，指定した比較関数を用いてソートする
        /// </summary>
        /// <param name="seq">ソートされるシーケンス</param>
        /// <param name="func">要素の関係に応じて，負・0・正の値を返す比較関数</param>
#else
        /// <summary>
        /// Sorts sequence element using the specified comparison function
        /// </summary>
        /// <param name="seq">The sequence to sort </param>
        /// <param name="func">The comparison function that returns negative, zero or positive value depending on the elements relation (see the above declaration and the example below) - similar function is used by qsort from C runtime except that in the latter userdata is not used </param>
#endif
        public static void SeqSort(CvSeq seq, CvCmpFunc func)
        {
            if (seq == null)
                throw new ArgumentNullException("seq");
            if (func == null)
                throw new ArgumentNullException("func");

            CvInvoke.cvSeqSort(seq.CvPtr, func, IntPtr.Zero);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスの要素を，指定した比較関数を用いてソートする
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="seq">ソートされるシーケンス</param>
        /// <param name="func">要素の関係に応じて，負・0・正の値を返す比較関数</param>
#else
        /// <summary>
        /// Sorts sequence element using the specified comparison function
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">The sequence to sort </param>
        /// <param name="func">The comparison function that returns negative, zero or positive value depending on the elements relation (see the above declaration and the example below) - similar function is used by qsort from C runtime except that in the latter userdata is not used </param>
#endif
        public static void SeqSort<T>(CvSeq seq, CvCmpFunc<T> func) where T : struct
        {
            // delegateを非ジェネリックのものに変換
            CvCmpFunc funcNonGeneric = delegate(IntPtr a, IntPtr b)
            {
                T aValue = (T)Marshal.PtrToStructure(a, typeof(T));//Util.ToObject<T>(a);
                T bValue = (T)Marshal.PtrToStructure(b, typeof(T));//Util.ToObject<T>(b);
                return func(aValue, bValue);
            };
            SeqSort(seq, funcNonGeneric);
        }
        #endregion
        #region Set
#if LANG_JP
        /// <summary>
        /// スカラー値 value を，配列の選択された各要素にコピーする．
        /// </summary>
        /// <param name="arr">値をセットする配列. IplImage 型の場合， ROI は利用されるが，COI がセットされていてはならない．</param>
        /// <param name="value">配列を埋める値</param>
#else
        /// <summary>
        /// Sets every element of array to given value
        /// </summary>
        /// <param name="arr">The destination array. </param>
        /// <param name="value">Fill value. </param>
#endif
        public static void Set(CvArr arr, CvScalar value)
        {
            Set(arr, value, null);
        }
#if LANG_JP
        /// <summary>
        /// スカラー値 value を，配列の選択された各要素にコピーする．
        /// mask(I) != null の場合，arr(I)=value. 
        /// </summary>
        /// <param name="arr">値をセットする配列. IplImage 型の場合， ROI は利用されるが，COI がセットされていてはならない．</param>
        /// <param name="value">配列を埋める値</param>
        /// <param name="mask">8 ビットシングルチャンネル配列の処理マスク．配列の変更する要素を指定する.</param>
#else
        /// <summary>
        /// Sets every element of array to given value
        /// </summary>
        /// <param name="arr">The destination array. </param>
        /// <param name="value">Fill value. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void Set(CvArr arr, CvScalar value, CvArr mask)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvSet(arr.CvPtr, value, maskPtr);
        }
        #endregion
        #region Set*D
#if LANG_JP
        /// <summary>
        /// 新しい値を指定した配列要素に割り当てる． 
        /// 疎な配列の場合，ノードが存在しなければ，この関数はノードを生成する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public static void Set1D(CvArr arr, int idx0, CvScalar value)
        {
            CvInvoke.cvSet1D(arr.CvPtr, idx0, value);
        }
#if LANG_JP
        /// <summary>
        /// 新しい値を指定した配列要素に割り当てる． 
        /// 疎な配列の場合，ノードが存在しなければ，この関数はノードを生成する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public static void Set2D(CvArr arr, int idx0, int idx1, CvScalar value)
        {
            CvInvoke.cvSet2D(arr.CvPtr, idx0, idx1, value);
        }
#if LANG_JP
        /// <summary>
        /// 新しい値を指定した配列要素に割り当てる． 
        /// 疎な配列の場合，ノードが存在しなければ，この関数はノードを生成する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public static void Set3D(CvArr arr, int idx0, int idx1, int idx2, CvScalar value)
        {
            CvInvoke.cvSet3D(arr.CvPtr, idx0, idx1, idx2, value);
        }
#if LANG_JP
        /// <summary>
        /// 新しい値を指定した配列要素に割り当てる． 
        /// 疎な配列の場合，ノードが存在しなければ，この関数はノードを生成する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="value">割り当てる値</param>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="value">The assigned value </param>
        /// <param name="idx">Array of the element indices</param>
#endif
        public static void SetND(CvArr arr, CvScalar value, params int[] idx)
        {
            CvInvoke.cvSetND(arr.CvPtr, idx, value);
        }
        #endregion
        #region SetAdd
#if LANG_JP
        /// <summary>
        /// セットに新しいノード（要素）を追加する
        /// </summary>
        /// <param name="setHeader">セット</param>
        /// <returns>ノードへのインデックス</returns>
#else
        /// <summary>
        /// Occupies a node in the set
        /// </summary>
        /// <param name="setHeader">Set.</param>
        /// <returns>the index to the node</returns>
#endif
        public static int SetAdd(CvSet setHeader)
        {
            if (setHeader == null)
            {
                throw new ArgumentNullException("setHeader");
            }
            IntPtr elemPtr = IntPtr.Zero;
            IntPtr insteadElemPtr = IntPtr.Zero;
            return CvInvoke.cvSetAdd(setHeader.CvPtr, elemPtr, ref insteadElemPtr);
        }
#if LANG_JP
        /// <summary>
        /// セットに新しいノード（要素）を追加する
        /// </summary>
        /// <param name="setHeader">セット</param>
        /// <param name="elem">挿入する要素． nullでない場合，新たに確保したノードにデータをコピーする （コピーした後，先頭の整数フィールドの最上位ビットはクリアされる）． </param>
        /// <returns>ノードへのインデックス</returns>
#else
        /// <summary>
        /// Occupies a node in the set
        /// </summary>
        /// <param name="setHeader">Set.</param>
        /// <param name="elem">Optional input argument, inserted element. If not null, the function copies the data to the allocated node (The MSB of the first integer field is cleared after copying). </param>
        /// <returns>the index to the node</returns>
#endif
        public static int SetAdd(CvSet setHeader, CvSetElem elem)
        {
            if (setHeader == null)
            {
                throw new ArgumentNullException("setHeader");
            }
            IntPtr elemPtr = (elem == null) ? IntPtr.Zero : elem.CvPtr;
            IntPtr insteadElemPtr = IntPtr.Zero;
            return CvInvoke.cvSetAdd(setHeader.CvPtr, elemPtr, ref insteadElemPtr);
        }
#if LANG_JP
        /// <summary>
        /// セットに新しいノード（要素）を追加する
        /// </summary>
        /// <param name="setHeader">セット</param>
        /// <param name="elem">挿入する要素． nullでない場合，新たに確保したノードにデータをコピーする （コピーした後，先頭の整数フィールドの最上位ビットはクリアされる）． </param>
        /// <param name="insertedElem">割り当てられた要素への参照</param>
        /// <returns>ノードへのインデックス</returns>
#else
        /// <summary>
        /// Occupies a node in the set
        /// </summary>
        /// <param name="setHeader">Set.</param>
        /// <param name="elem">Optional input argument, inserted element. If not null, the function copies the data to the allocated node (The MSB of the first integer field is cleared after copying). </param>
        /// <param name="insertedElem">Optional output argument; the pointer to the allocated cell. </param>
        /// <returns>the index to the node</returns>
#endif
        public static int SetAdd(CvSet setHeader, CvSetElem elem, out CvSetElem insertedElem)
        {
            if (setHeader == null)
                throw new ArgumentNullException("setHeader");
            
            IntPtr elemPtr = (elem == null) ? IntPtr.Zero : elem.CvPtr;
            insertedElem = new CvSetElem();
            IntPtr insteadElemPtr = insertedElem.CvPtr;
            return CvInvoke.cvSetAdd(setHeader.CvPtr, elemPtr, ref insteadElemPtr);
        }
        #endregion
        #region SetBinRanges
#if LANG_JP
        /// <summary>
        /// ヒストグラムのビンのレンジをセットする
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="ranges">ビンのレンジの配列</param>
#else
        /// <summary>
        /// Sets bounds of histogram bins
        /// </summary>
        /// <param name="hist">Histogram. </param>
        /// <param name="ranges">Array of bin ranges arrays.</param>
#endif
        public static void SetHistBinRanges(CvHistogram hist, float[][] ranges)
        {
            SetHistBinRanges(hist, ranges, true);
        }
#if LANG_JP
        /// <summary>
        /// ヒストグラムのビンのレンジをセットする
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="ranges">ビンのレンジの配列</param>
        /// <param name="uniform">一様性フラグ</param>
#else
        /// <summary>
        /// Sets bounds of histogram bins
        /// </summary>
        /// <param name="hist">Histogram. </param>
        /// <param name="ranges">Array of bin ranges arrays.</param>
        /// <param name="uniform">Uniformity flag.</param>
#endif
        public static void SetHistBinRanges(CvHistogram hist, float[][] ranges, bool uniform)
        {
            if (hist == null)
                throw new ArgumentNullException("hist");
            if (ranges == null)
                throw new ArgumentNullException("ranges");

            using (var rangesPtr = new ArrayAddress2<float>(ranges))
            {
                CvInvoke.cvSetHistBinRanges(hist.CvPtr, rangesPtr.Pointer, uniform);
            }
        }
        #endregion
        #region SetCaptureProperty
#if LANG_JP
        /// <summary>
        /// ビデオキャプチャのプロパティをセットする
        /// </summary>
        /// <param name="capture">ビデオキャプチャクラス</param>
        /// <param name="propertyID">プロパティID</param>
        /// <param name="value">プロパティの値</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Sets the specified property of video capturing.
        /// </summary>
        /// <param name="capture">video capturing structure. </param>
        /// <param name="propertyID">property identifier. </param>
        /// <param name="value">value of the property. </param>
        /// <returns></returns>
#endif
        public static int SetCaptureProperty(CvCapture capture, int propertyID, double value)
        {
            if (capture == null)
            {
                throw new ArgumentNullException("capture");
            }
            return CvInvoke.cvSetCaptureProperty(capture.CvPtr, propertyID, value);
        }
#if LANG_JP
        /// <summary>
        /// ビデオキャプチャのプロパティをセットする
        /// </summary>
        /// <param name="capture">ビデオキャプチャクラス</param>
        /// <param name="propertyID">プロパティID</param>
        /// <param name="value">プロパティの値</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Sets the specified property of video capturing.
        /// </summary>
        /// <param name="capture">video capturing structure. </param>
        /// <param name="propertyID">property identifier. </param>
        /// <param name="value">value of the property. </param>
        /// <returns></returns>
#endif
        public static int SetCaptureProperty(CvCapture capture, CaptureProperty propertyID, double value)
        {
            return SetCaptureProperty(capture, (int)propertyID, value);
        }
        #endregion
        #region SetData
#if LANG_JP
        /// <summary>
        /// ユーザデータを配列のヘッダに割り当てる． 
        /// ヘッダは，関数 cvCreate*Header，関数 cvInit*Header あるいは 関数 cvMat（行列の場合）を用いて，あらかじめ初期化されるべきである．
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">配列ヘッダ</param>
        /// <param name="data">ユーザデータ</param>
        /// <param name="step">バイト単位で表された行の長さ</param>
#else
        /// <summary>
        /// Assigns user data to the array header.
        /// Header should be initialized before using cvCreate*Header, cvInit*Header or cvMat (in case of matrix) function. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">Array header. </param>
        /// <param name="data">User data. </param>
        /// <param name="step">Full row length in bytes. </param>
#endif
        public static void SetData<T>(CvArr arr, T[] data, int step) where T : struct
        {
            // CvArrで配列をピン止めしておく
            GCHandle gch = arr.AllocGCHandle(data);
            SetData(arr, gch.AddrOfPinnedObject(), step);
        }
#if LANG_JP
        /// <summary>
        /// ユーザデータを配列のヘッダに割り当てる． 
        /// ヘッダは，関数 cvCreate*Header，関数 cvInit*Header あるいは 関数 cvMat（行列の場合）を用いて，あらかじめ初期化されるべきである．
        /// </summary>
        /// <param name="arr">配列ヘッダ</param>
        /// <param name="data">ユーザデータ</param>
        /// <param name="step">バイト単位で表された行の長さ</param>
#else
        /// <summary>
        /// Assigns user data to the array header.
        /// Header should be initialized before using cvCreate*Header, cvInit*Header or cvMat (in case of matrix) function. 
        /// </summary>
        /// <param name="arr">Array header. </param>
        /// <param name="data">User data. </param>
        /// <param name="step">Full row length in bytes. </param>
#endif
        public static void SetData(CvArr arr, IntPtr data, int step)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            if (data == null)
                throw new ArgumentNullException("data");

            CvInvoke.cvSetData(arr.CvPtr, data, step);
        }
        #endregion
        #region SetErrMode
#if LANG_JP
        /// <summary>
        /// エラーモードをセットする. 直前のエラーモードを返す.
        /// </summary>
        /// <param name="mode">エラーモード</param>
        /// <returns>セットする前のエラーモード</returns>
#else
        /// <summary>
        /// Sets error processing mode, returns previously used mode
        /// </summary>
        /// <param name="mode">The error mode. </param>
        /// <returns>previously used mode</returns>
#endif
        public static ErrMode SetErrMode(ErrMode mode)
        {
            return CvInvoke.cvSetErrMode(mode);
        }
        #endregion
        #region SetErrStatus
#if LANG_JP
        /// <summary>
        /// エラーステータスをセットする
        /// </summary>
        /// <param name="status">エラーステータス</param>
#else
        /// <summary>
        /// Sets the error status
        /// </summary>
        /// <param name="status">The error status. </param>
#endif
        public static void SetErrStatus(CvStatus status)
        {
            CvInvoke.cvSetErrStatus(status);
        }
        #endregion
        #region SetIdentity
#if LANG_JP
        /// <summary>
        /// スカラー倍された単位行列を用いた初期化を行う
        /// </summary>
        /// <param name="mat">初期化される行列（正方である必要はない）</param>
#else
        /// <summary>
        /// Initializes scaled identity matrix
        /// </summary>
        /// <param name="mat">The matrix to initialize (not necessarily square). </param>
#endif
        public static void SetIdentity(CvArr mat)
        {
            SetIdentity(mat, CvScalar.RealScalar(1));
        }
#if LANG_JP
        /// <summary>
        /// スカラー倍された単位行列を用いた初期化を行う
        /// </summary>
        /// <param name="mat">初期化される行列（正方である必要はない）</param>
        /// <param name="value">対角成分の値</param>
#else
        /// <summary>
        /// Initializes scaled identity matrix
        /// </summary>
        /// <param name="mat">The matrix to initialize (not necessarily square). </param>
        /// <param name="value">The value to assign to the diagonal elements. </param>
#endif
        public static void SetIdentity(CvArr mat, CvScalar value)
        {
            if (mat == null)
            {
                throw new ArgumentNullException("mat");
            }
            CvInvoke.cvSetIdentity(mat.CvPtr, value);
        }
        #endregion
        #region SetImageCOI
#if LANG_JP
        /// <summary>
        /// 与えられた値を channel of interest（COI）としてセットする.
        /// 値 0 は全てのチャンネルが選択されている事を意味し，値 1 は最初のチャンネルが選択されている事を意味する．
        /// </summary>
        /// <param name="image">画像ヘッダ</param>
        /// <param name="coi">COI（Channel of interest）</param>
#else
        /// <summary>
        /// Sets channel of interest to given value.
        /// Value 0 means that all channels are selected, 1 means that the first channel is selected etc.
        /// </summary>
        /// <param name="image">Image header. </param>
        /// <param name="coi">Channel of interest. </param>
#endif
        public static void SetImageCOI(IplImage image, int coi)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            CvInvoke.cvSetImageCOI(image.CvPtr, coi);
        }
        #endregion
        #region SetImageROI
#if LANG_JP
        /// <summary>
        /// 与えられた矩形を画像の ROI としてセットする．
        /// </summary>
        /// <param name="image">画像ヘッダ</param>
        /// <param name="rect">ROI を表す矩形</param>
#else
        /// <summary>
        /// Sets image ROI to given rectangle
        /// </summary>
        /// <param name="image">Image header. </param>
        /// <param name="rect">ROI rectangle. </param>
#endif
        public static void SetImageROI(IplImage image, CvRect rect)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            CvInvoke.cvSetImageROI(image.CvPtr, rect);
        }
        #endregion
        #region SetImagesForHaarClassifierCascade
#if LANG_JP
        /// <summary>
        /// 画像を隠れ分類器カスケードに割り当てる．
        /// </summary>
        /// <param name="cascade">cvCreateHidHaarClassifierCascade によって作成された隠れHaar分類器カスケード</param>
        /// <param name="sum">32 ビット整数シングルチャンネルのインテグラルイメージ</param>
        /// <param name="sqsum">64ビット浮動小数点型のシングルチャンネル画像の各ピクセルを二乗した値に対するインテグラルイメージ</param>
        /// <param name="tiltedSum">32 ビット整数型のシングルチャンネル画像を 45°傾けたものに対するインテグラルイメージ</param>
        /// <param name="scale">カスケードのウィンドウスケール</param>
#else
        /// <summary>
        /// Assigns images to the hidden cascade
        /// </summary>
        /// <param name="cascade">Hidden Haar classifier cascade, created by cvCreateHidHaarClassifierCascade. </param>
        /// <param name="sum">Integral (sum) single-channel image of 32-bit integer format. This image as well as the two subsequent images are used for fast feature evaluation and brightness/contrast normalization. They all can be retrieved from input 8-bit or floating point single-channel image using The function cvIntegral. </param>
        /// <param name="sqsum">Square sum single-channel image of 64-bit floating-point format. </param>
        /// <param name="tiltedSum">Tilted sum single-channel image of 32-bit integer format. </param>
        /// <param name="scale">Window scale for the cascade. If scale=1, original window size is used (objects of that size are searched) - the same size as specified in cvLoadHaarClassifierCascade  (24x24 in case of "&lt;default_face_cascade&gt;"), if scale=2, a two times larger window is used (48x48 in case of default face cascade). While this will speed-up search about four times, faces smaller than 48x48 cannot be detected. </param>
#endif
        public static void SetImagesForHaarClassifierCascade(CvHaarClassifierCascade cascade, CvArr sum, CvArr sqsum, CvArr tiltedSum, double scale)
        {
            if (cascade == null)
            {
                throw new ArgumentNullException("cascade");
            }
            IntPtr sumPtr = (sum == null) ? IntPtr.Zero : sum.CvPtr;
            IntPtr sqsumPtr = (sqsum == null) ? IntPtr.Zero : sqsum.CvPtr;
            IntPtr tiltedSumPtr = (tiltedSum == null) ? IntPtr.Zero : tiltedSum.CvPtr;
            CvInvoke.cvSetImagesForHaarClassifierCascade(cascade.CvPtr, sumPtr, sqsumPtr, tiltedSumPtr, scale);
        }
        #endregion
        #region SetMouseCallback
#if LANG_JP
        /// <summary>
        /// 指定されたウィンドウ内で発生するマウスイベントに対するコールバック関数を設定する
        /// </summary>
        /// <param name="windowName">ウィンドウの名前</param>
        /// <param name="onMouse">指定されたウィンドウ内でマウスイベントが発生するたびに呼ばれるデリゲート</param>
#else
        /// <summary>
        /// Sets the callback function for mouse events occuting within the specified window.
        /// </summary>
        /// <param name="windowName">Name of the window. </param>
        /// <param name="onMouse">Reference to the function to be called every time mouse event occurs in the specified window. </param>
#endif
        public static void SetMouseCallback(string windowName, CvMouseCallback onMouse)
        {
            if (string.IsNullOrEmpty(windowName))
                throw new ArgumentNullException("windowName");
            if (onMouse == null)
                throw new ArgumentNullException("onMouse");

            CvWindow window = CvWindow.GetWindowByName(windowName);
            if (window != null)
            {
                window.MouseCallback = onMouse;
            }
        }
        #endregion
        #region SetNew
#if LANG_JP
        /// <summary>
        /// セットに要素を加える（高速版）
        /// </summary>
        /// <param name="setHeader">セット</param>
        /// <returns>ノードへのポインタ</returns>
#else
        /// <summary>
        /// Adds element to set (fast variant)
        /// </summary>
        /// <param name="setHeader">Set. </param>
        /// <returns>pointer to a new node</returns>
#endif
        public static CvSetElem SetNew(CvSet setHeader)
        {
            if (setHeader == null)
            {
                throw new ArgumentNullException("setHeader");
            }

            unsafe
            {
                WCvSet* set = (WCvSet*)(setHeader.CvPtr);
                WCvSetElem* elem = (WCvSetElem*)(set->free_elems);
                IntPtr elemPtr = new IntPtr(elem);

                if (elem != null)
                {
                    set->free_elems = elem->next_free;
                    elem->flags = elem->flags & CvConst.CV_SET_ELEM_IDX_MASK;
                    set->active_count++;
                }
                else
                {
                    CvInvoke.cvSetAdd(setHeader.CvPtr, IntPtr.Zero, ref elemPtr);
                }

                if (elemPtr == IntPtr.Zero)
                    return null;
                else
                    return new CvSetElem(elemPtr);
            }
        }
        #endregion
        #region SetNumThreads
#if LANG_JP
        /// <summary>
        /// 並列化されたOpenCV関数によって使用されるスレッド数を0にセットする．
        /// </summary>
#else
        /// <summary>
        /// Sets the number of threads.
        /// </summary>
#endif
        public static void SetNumThreads()
        {
            CvInvoke.cvSetNumThreads(0);
        }
#if LANG_JP
        /// <summary>
        /// 並列化されたOpenCV関数によって使用されるスレッド数をセットする．
        /// </summary>
        /// <param name="threads">スレッド数.
        /// 負の場合，またプログラム開始時は，スレッド数にOpenMPランタイムの関数omp_get_num_procs() の戻り値であるシステムのプロセッサ数がセットされる． </param>
#else
        /// <summary>
        /// Sets the number of threads.
        /// </summary>
        /// <param name="threads">The number of threads. 
        /// When the argument is zero or negative, and at the beginning of the program, the number of threads is set to the number of processors in the system, as returned by the function omp_get_num_procs() from OpenMP runtime. </param>
#endif
        public static void SetNumThreads(int threads)
        {
            CvInvoke.cvSetNumThreads(threads);
        }
        #endregion
        #region SetPostprocessFuncWin32
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onPostprocess"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onPostprocess"></param>
#endif
        public static void SetPostprocessFuncWin32(CvWin32WindowCallback onPostprocess)
        {
            postProcess = onPostprocess;
            CvInvoke.cvSetPostprocessFuncWin32(onPostprocess);
        }
        private static CvWin32WindowCallback postProcess = null;
        #endregion
        #region SetPreprocessFuncWin32
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onPreprocess"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onPreprocess"></param>
#endif
        public static void SetPreprocessFuncWin32(CvWin32WindowCallback onPreprocess)
        {
            preProcess = onPreprocess;
            CvInvoke.cvSetPreprocessFuncWin32(onPreprocess);
        }
        private static CvWin32WindowCallback preProcess = null;
        #endregion
        #region SetReal*D
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の指定した要素に新しい値を割り当てる．配列がマルチチャンネルのときは，ランタイムエラーが起こる．
        /// 疎な配列の場合に，ノードが存在しなれば，この関数はノードを生成する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public static void SetReal1D(CvArr arr, int idx0, double value)
        {
            CvInvoke.cvSetReal1D(arr.CvPtr, idx0, value);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の指定した要素に新しい値を割り当てる．配列がマルチチャンネルのときは，ランタイムエラーが起こる．
        /// 疎な配列の場合に，ノードが存在しなれば，この関数はノードを生成する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public static void SetReal2D(CvArr arr, int idx0, int idx1, double value)
        {
            CvInvoke.cvSetReal2D(arr.CvPtr, idx0, idx1, value);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の指定した要素に新しい値を割り当てる．配列がマルチチャンネルのときは，ランタイムエラーが起こる．
        /// 疎な配列の場合に，ノードが存在しなれば，この関数はノードを生成する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public static void SetReal3D(CvArr arr, int idx0, int idx1, int idx2, double value)
        {
            CvInvoke.cvSetReal3D(arr.CvPtr, idx0, idx1, idx2, value);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の指定した要素に新しい値を割り当てる．配列がマルチチャンネルのときは，ランタイムエラーが起こる．
        /// 疎な配列の場合に，ノードが存在しなれば，この関数はノードを生成する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="value">割り当てる値</param>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="value">The assigned value </param>
        /// <param name="idx">Array of the element indices </param>
#endif
        public static void SetRealND(CvArr arr, double value, params int[] idx)
        {
            CvInvoke.cvSetRealND(arr.CvPtr, idx, value);
        }
        #endregion
        #region SetRemove
#if LANG_JP
        /// <summary>
        /// セットから要素を削除する
        /// </summary>
        /// <param name="setHeader">セット．</param>
        /// <param name="index">削除する要素のインデックス．</param>
#else
        /// <summary>
        /// Removes element from set
        /// </summary>
        /// <param name="setHeader">Set. </param>
        /// <param name="index">Index of the removed element. </param>
#endif
        public static void SetRemove(CvSet setHeader, int index)
        {
            if (setHeader == null)
                throw new ArgumentNullException("setHeader");
            
            CvInvoke.cvSetRemove(setHeader.CvPtr, index);
        }
        #endregion
        #region SetRemoveByPtr
#if LANG_JP
        /// <summary>
        /// ポインタで指定したセットの要素を削除する
        /// </summary>
        /// <param name="setHeader">セット．</param>
        /// <param name="elem">削除される要素．</param>
#else
        /// <summary>
        /// Removes set element given its pointer
        /// </summary>
        /// <param name="setHeader">Set. </param>
        /// <param name="elem">Removed element. </param>
#endif
        public static void SetRemoveByPtr(CvSet setHeader, IntPtr elem)
        {
            if (setHeader == null)
                throw new ArgumentNullException("setHeader");

            unsafe
            {
                WCvSet* setHeaderPtr = (WCvSet*)setHeader.CvPtr; 
                WCvSetElem* elemPtr = (WCvSetElem*)elem;
                Debug.Assert(elemPtr->flags >= 0 /*&& (elem->flags & CV_SET_ELEM_IDX_MASK) < set_header->total*/ );
                elemPtr->next_free = setHeaderPtr->free_elems;
                elemPtr->flags = (elemPtr->flags & CvConst.CV_SET_ELEM_IDX_MASK) | CvConst.CV_SET_ELEM_FREE_FLAG;
                setHeaderPtr->free_elems = elemPtr;
                setHeaderPtr->active_count--;
            }
        }
        #endregion
        #region SetSeqBlockSize
#if LANG_JP
        /// <summary>
        /// シーケンスのブロックサイズを設定する
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="deltaElems">シーケンス要素のブロックサイズ</param>
#else
        /// <summary>
        /// Sets up sequence block size
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <param name="deltaElems">Desirable sequence block size in elements. </param>
#endif
        public static void SetSeqBlockSize(CvSeq seq, int deltaElems)
        {
            if (seq == null)
                throw new ArgumentNullException("seq");
            
            CvInvoke.cvSetSeqBlockSize(seq.CvPtr, deltaElems);
        }
        #endregion
        #region SetSeqReaderPos
#if LANG_JP
        /// <summary>
        /// 読み込み位置を絶対位置で表された位置に移動する
        /// </summary>
        /// <param name="reader">リーダの状態</param>
        /// <param name="index">移動先の位置</param>
#else
        /// <summary>
        /// Moves the reader to specified position
        /// </summary>
        /// <param name="reader">Reader state. </param>
        /// <param name="index">The destination position. If the positioning mode is used (see the next parameter) the actual position will be index mod reader->seq->total. </param>
#endif
        public static void SetSeqReaderPos(CvSeqReader reader, int index)
        {
            SetSeqReaderPos(reader, index, false);
        }
#if LANG_JP
        /// <summary>
        /// 読み込み位置を絶対位置か相対位置で表された位置に移動する
        /// </summary>
        /// <param name="reader">リーダの状態</param>
        /// <param name="index">移動先の位置．位置決めモード（次のパラメータis_relativeを参照）が使用されている場合， 実際の位置は index を reader->seq->totalで割った剰余になる．</param>
        /// <param name="isRelative">true，index は現在位置からの相対値</param>
#else
        /// <summary>
        /// Moves the reader to specified position
        /// </summary>
        /// <param name="reader">Reader state. </param>
        /// <param name="index">The destination position. If the positioning mode is used (see the next parameter) the actual position will be index mod reader->seq->total. </param>
        /// <param name="isRelative">If it is true, then index is a relative to the current position. </param>
#endif
        public static void SetSeqReaderPos(CvSeqReader reader, int index, bool isRelative)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            CvInvoke.cvSetSeqReaderPos(reader.CvPtr, index, isRelative);
        }
        #endregion
        #region SetTrackbarPos
#if LANG_JP
        /// <summary>
        /// 指定されたトラックバーの位置を設定する
        /// </summary>
        /// <param name="trackbarName">トラックバーの名前</param>
        /// <param name="windowName">トラックバーの親ウィンドウの名前</param>
        /// <param name="pos">新しい位置</param>
#else
        /// <summary>
        /// Sets the position of the specified trackbar.
        /// </summary>
        /// <param name="trackbarName">Name of trackbar. </param>
        /// <param name="windowName">Name of the window which is the parent of trackbar. </param>
        /// <param name="pos">New position. </param>
#endif
        public static void SetTrackbarPos(string trackbarName, string windowName, int pos)
        {
            if (string.IsNullOrEmpty(trackbarName))
                throw new ArgumentNullException("trackbarName");
            if (string.IsNullOrEmpty(windowName))
                throw new ArgumentNullException("windowName");
            CvInvoke.cvSetTrackbarPos(trackbarName, windowName, pos);
        }
        #endregion
        #region SetWindowProperty
#if LANG_JP
        /// <summary>
        /// ウィンドウのプロパティを設定する
        /// </summary>
        /// <param name="name"></param>
        /// <param name="propID">プロパティの種類</param>
        /// <param name="propValue">プロパティに設定する値</param>
#else
        /// <summary>
        /// Set Property of the window
        /// </summary>
        /// <param name="name">Window name</param>
        /// <param name="propID">Property identifier</param>
        /// <param name="propValue">New value of the specified property</param>
#endif
        public static void SetWindowProperty(string name, WindowProperty propID, double propValue)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            
            CvInvoke.cvSetWindowProperty(name, propID, propValue);
        }
        #endregion
        #region SetZero
#if LANG_JP
        /// <summary>
        /// 配列をクリアする
        /// </summary>
        /// <param name="arr">クリアされる配列</param>
#else
        /// <summary>
        /// Clears the array
        /// </summary>
        /// <param name="arr">array to be cleared. </param>
#endif
        public static void SetZero(CvArr arr)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            
            CvInvoke.cvSetZero(arr.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 配列をクリアする
        /// </summary>
        /// <param name="arr">クリアされる配列</param>
#else
        /// <summary>
        /// Clears the array
        /// </summary>
        /// <param name="arr">array to be cleared. </param>
#endif
        public static void Zero(CvArr arr)
        {
            SetZero(arr);
        }
        #endregion
        #region ShowImage
#if LANG_JP 
        /// <summary>
        /// 指定したウィンドウ内に画像を表示する．
        /// そのウィンドウのフラグに CV_WINDOW_AUTOSIZE が指定されていた場合は，画像はオリジナルサイズで表示される．
        /// それ以外の場合，ウィンドウサイズに合わせて 表示画像サイズが変更される． 
        /// </summary>
        /// <param name="name">ウィンドウの名前</param>
        /// <param name="image">画像ヘッダ</param>
#else
        /// <summary>
        /// Shows the image in the specified window. 
        /// If the window was created with CV_WINDOW_AUTOSIZE flag then the image is shown with its original size, otherwise the image is scaled to fit the window. 
        /// </summary>
        /// <param name="name">Name of the window. </param>
        /// <param name="image">Image to be shown. </param>
#endif
        public static void ShowImage(string name, CvArr image)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (image == null)
                throw new ArgumentNullException("image");

            CvWindow window = CvWindow.GetWindowByName(name);
            if (window == null)
            {
                CvInvoke.cvShowImage(name, image.CvPtr);
            }
            else
            {
                window.ShowImage(image);
            }
        }
        #endregion
        #region Size
#if LANG_JP
        /// <summary>
        /// 矩形のピクセル精度でのサイズ構造体を生成する (cvSize相当)
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Create CVSize structure and initializes it
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <returns></returns>
#endif
        public static CvSize Size(int width, int height)
        {
            return new CvSize(width, height);
        }
        #endregion
        #region SliceLength
#if LANG_JP
        /// <summary>
        /// シーケンスのスライス長を計算する
        /// </summary>
        /// <param name="slice"></param>
        /// <param name="seq"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates the sequence slice length
        /// </summary>
        /// <param name="slice">Slice to measure</param>
        /// <param name="seq">Sequence</param>
        /// <returns></returns>
#endif
        public static int SliceLength(CvSlice slice, CvSeq seq)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            return CvInvoke.cvSliceLength(slice, seq.CvPtr);
        }
        #endregion
        #region Smooth
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
#endif
        public static void Smooth(CvArr src, CvArr dst)
        {
            Smooth(src, dst, SmoothType.Gaussian, 3, 0, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="smoothtype">平滑化の方法</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
        /// <param name="smoothtype">Type of the smoothing.</param>
#endif
        public static void Smooth(CvArr src, CvArr dst, SmoothType smoothtype)
        {
            Smooth(src, dst, smoothtype, 3, 0, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="smoothtype">平滑化の方法</param>
        /// <param name="param1">平滑化処理のパラメータ1</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
        /// <param name="smoothtype">Type of the smoothing.</param>
        /// <param name="param1">The first parameter of smoothing operation. </param>
#endif
        public static void Smooth(CvArr src, CvArr dst, SmoothType smoothtype, int param1)
        {
            Smooth(src, dst, smoothtype, param1, 0, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="smoothtype">平滑化の方法</param>
        /// <param name="param1">平滑化処理のパラメータ1</param>
        /// <param name="param2">平滑化処理のパラメータ2．スケーリング有り/無しの単純平滑またはガウシアン平滑化の場合，param2 が0のときは param1 にセットされる.</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
        /// <param name="smoothtype">Type of the smoothing.</param>
        /// <param name="param1">The first parameter of smoothing operation. </param>
        /// <param name="param2">The second parameter of smoothing operation. In case of simple scaled/non-scaled and Gaussian blur if param2 is zero, it is set to param1. </param>
#endif
        public static void Smooth(CvArr src, CvArr dst, SmoothType smoothtype, int param1, int param2)
        {
            Smooth(src, dst, smoothtype, param1, param2, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="smoothtype">平滑化の方法</param>
        /// <param name="param1">平滑化処理のパラメータ1</param>
        /// <param name="param2">平滑化処理のパラメータ2．スケーリング有り/無しの単純平滑またはガウシアン平滑化の場合，param2 が0のときは param1 にセットされる.</param>
        /// <param name="param3">ガウシアン平滑化 の場合，このパラメータがガウシアンsigma（標準偏差）を示す．</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
        /// <param name="smoothtype">Type of the smoothing.</param>
        /// <param name="param1">The first parameter of smoothing operation. </param>
        /// <param name="param2">The second parameter of smoothing operation. In case of simple scaled/non-scaled and Gaussian blur if param2 is zero, it is set to param1. </param>
        /// <param name="param3">In case of Gaussian kernel this parameter may specify Gaussian sigma (standard deviation). If it is zero, it is calculated from the kernel size.</param>
#endif
        public static void Smooth(CvArr src, CvArr dst, SmoothType smoothtype, int param1, int param2, double param3)
        {
            Smooth(src, dst, smoothtype, param1, param2, param3, 0);
        }
#if LANG_JP
        /// <summary>
        /// 画像の平滑化を行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="smoothtype">平滑化の方法</param>
        /// <param name="param1">平滑化処理のパラメータ1</param>
        /// <param name="param2">平滑化処理のパラメータ2．スケーリング有り/無しの単純平滑またはガウシアン平滑化の場合，param2 が0のときは param1 にセットされる.</param>
        /// <param name="param3">ガウシアン平滑化 の場合，このパラメータがガウシアンsigma（標準偏差）を示す．</param>
        /// <param name="param4">非正方形のガウシアンカーネルを使用する場合，垂直方向に異なるsigma 値(param3と違う値)指定するために用いられる．</param>
#else
        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
        /// <param name="smoothtype">Type of the smoothing.</param>
        /// <param name="param1">The first parameter of smoothing operation. </param>
        /// <param name="param2">The second parameter of smoothing operation. In case of simple scaled/non-scaled and Gaussian blur if param2 is zero, it is set to param1. </param>
        /// <param name="param3">In case of Gaussian kernel this parameter may specify Gaussian sigma (standard deviation). If it is zero, it is calculated from the kernel size.</param>
        /// <param name="param4">In case of non-square Gaussian kernel the parameter may be used to specify a different (from param3) sigma in the vertical direction. </param>
#endif
        public static void Smooth(CvArr src, CvArr dst, SmoothType smoothtype, int param1, int param2, double param3, double param4)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvSmooth(src.CvPtr, dst.CvPtr, smoothtype, param1, param2, param3, param4);
        }
        #endregion
        #region SnakeImage
#if LANG_JP
        /// <summary>
        /// 内部エネルギーと外部エネルギーの総和が最小になるように snake を更新する． 
        /// 内部エネルギーは輪郭形状に依存する（滑らかな輪郭ほど内部エネルギーが小さい）．
        /// 外部エネルギーはエネルギー場に依存し，画像勾配の場合は画像のエッジに対応するような局所的なエネルギー極小値において最小になる.
        /// </summary>
        /// <param name="image">元画像あるいは，外部エネルギー場</param>
        /// <param name="points">輪郭点. ここに格納されている点をもとに計算をし、結果もここに入る</param>
        /// <param name="alpha">連続エネルギーの重み．pointsと同じ長さを持つ浮動小数点型配列（各輪郭点に配列の各要素が対応）．</param>
        /// <param name="beta">曲率エネルギーの重み．alpha と同様．</param>
        /// <param name="gamma">画像エネルギーの重み．alpha と同様．</param>
        /// <param name="win">最小値を探索する各点の近傍のサイズ． Width と Height は奇数でなければならない．</param>
        /// <param name="criteria">終了条件</param>
#else
        /// <summary>
        /// Changes contour position to minimize its energy
        /// </summary>
        /// <param name="image">The source image or external energy field. </param>
        /// <param name="points">Contour points (snake). </param>
        /// <param name="alpha">Weight of continuity energy, single float or array of length floats, one per each contour point. </param>
        /// <param name="beta">Weight of curvature energy, similar to alpha. </param>
        /// <param name="gamma">Weight of image energy, similar to alpha. </param>
        /// <param name="win">Size of neighborhood of every point used to search the minimum, both win.width and win.height must be odd. </param>
        /// <param name="criteria">Termination criteria. </param>
#endif
        public static void SnakeImage(IplImage image, CvPoint[] points, float alpha, float beta, float gamma, CvSize win, CvTermCriteria criteria)
        {
            SnakeImage(image, points, alpha, beta, gamma, win, criteria, true);
        }
#if LANG_JP
        /// <summary>
        /// 内部エネルギーと外部エネルギーの総和が最小になるように snake を更新する． 
        /// 内部エネルギーは輪郭形状に依存する（滑らかな輪郭ほど内部エネルギーが小さい）．
        /// 外部エネルギーはエネルギー場に依存し，画像勾配の場合は画像のエッジに対応するような局所的なエネルギー極小値において最小になる.
        /// </summary>
        /// <param name="image">元画像あるいは，外部エネルギー場</param>
        /// <param name="points">輪郭点. ここに格納されている点をもとに計算をし、結果もここに入る</param>
        /// <param name="alpha">連続エネルギーの重み．pointsと同じ長さを持つ浮動小数点型配列（各輪郭点に配列の各要素が対応）．</param>
        /// <param name="beta">曲率エネルギーの重み．alpha と同様．</param>
        /// <param name="gamma">画像エネルギーの重み．alpha と同様．</param>
        /// <param name="win">最小値を探索する各点の近傍のサイズ． Width と Height は奇数でなければならない．</param>
        /// <param name="criteria">終了条件</param>
        /// <param name="calcGradient">勾配フラグ．trueの場合，この関数は全ての画像ピクセルに対する勾配の強さを計算し，これをエネルギー場と見なす． falseの場合は，入力画像自体がエネルギー場と見なされる．</param>
#else
        /// <summary>
        /// Changes contour position to minimize its energy
        /// </summary>
        /// <param name="image">The source image or external energy field. </param>
        /// <param name="points">Contour points (snake). </param>
        /// <param name="alpha">Weight of continuity energy, single float or array of length floats, one per each contour point. </param>
        /// <param name="beta">Weight of curvature energy, similar to alpha. </param>
        /// <param name="gamma">Weight of image energy, similar to alpha. </param>
        /// <param name="win">Size of neighborhood of every point used to search the minimum, both win.width and win.height must be odd. </param>
        /// <param name="criteria">Termination criteria. </param>
        /// <param name="calcGradient">Gradient flag. If true, the function calculates gradient magnitude for every image pixel and consideres it as the energy field, otherwise the input image itself is considered. </param>
#endif
        public static void SnakeImage(IplImage image, CvPoint[] points, float alpha, float beta, float gamma, CvSize win, CvTermCriteria criteria, bool calcGradient)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (points == null)
                throw new ArgumentNullException("points");

            using (var pointsPtr = new ArrayAddress1<CvPoint>(points))
            {
                CvInvoke.cvSnakeImage(image.CvPtr, pointsPtr, points.Length, ref alpha, ref beta, ref gamma, CvConst.CV_VALUE, win, criteria, calcGradient);
            }
        }
#if LANG_JP
        /// <summary>
        /// 内部エネルギーと外部エネルギーの総和が最小になるように snake を更新する． 
        /// 内部エネルギーは輪郭形状に依存する（滑らかな輪郭ほど内部エネルギーが小さい）．
        /// 外部エネルギーはエネルギー場に依存し，画像勾配の場合は画像のエッジに対応するような局所的なエネルギー極小値において最小になる.
        /// </summary>
        /// <param name="image">元画像あるいは，外部エネルギー場</param>
        /// <param name="points">輪郭点. ここに格納されている点をもとに計算をし、結果もここに入る</param>
        /// <param name="alpha">連続エネルギーの重み．pointsと同じ長さを持つ浮動小数点型配列（各輪郭点に配列の各要素が対応）．</param>
        /// <param name="beta">曲率エネルギーの重み．alpha と同様．</param>
        /// <param name="gamma">画像エネルギーの重み．alpha と同様．</param>
        /// <param name="win">最小値を探索する各点の近傍のサイズ． Width と Height は奇数でなければならない．</param>
        /// <param name="criteria">終了条件</param>
#else
        /// <summary>
        /// Changes contour position to minimize its energy
        /// </summary>
        /// <param name="image">The source image or external energy field. </param>
        /// <param name="points">Contour points (snake). </param>
        /// <param name="alpha">Weights of continuity energy, single float or array of length floats, one per each contour point. </param>
        /// <param name="beta">Weights of curvature energy, similar to alpha. </param>
        /// <param name="gamma">Weights of image energy, similar to alpha. </param>
        /// <param name="win">Size of neighborhood of every point used to search the minimum, both win.width and win.height must be odd. </param>
        /// <param name="criteria">Termination criteria. </param>
#endif
        public static void SnakeImage(IplImage image, CvPoint[] points, float[] alpha, float[] beta, float[] gamma, CvSize win, CvTermCriteria criteria)
        {
            SnakeImage(image, points, alpha, beta, gamma, win, criteria, true);
        }
#if LANG_JP
        /// <summary>
        /// 内部エネルギーと外部エネルギーの総和が最小になるように snake を更新する． 
        /// 内部エネルギーは輪郭形状に依存する（滑らかな輪郭ほど内部エネルギーが小さい）．
        /// 外部エネルギーはエネルギー場に依存し，画像勾配の場合は画像のエッジに対応するような局所的なエネルギー極小値において最小になる.
        /// </summary>
        /// <param name="image">元画像あるいは，外部エネルギー場</param>
        /// <param name="points">輪郭点. ここに格納されている点をもとに計算をし、結果もここに入る</param>
        /// <param name="alpha">連続エネルギーの重み．pointsと同じ長さを持つ浮動小数点型配列（各輪郭点に配列の各要素が対応）．</param>
        /// <param name="beta">曲率エネルギーの重み．alpha と同様．</param>
        /// <param name="gamma">画像エネルギーの重み．alpha と同様．</param>
        /// <param name="win">最小値を探索する各点の近傍のサイズ． Width と Height は奇数でなければならない．</param>
        /// <param name="criteria">終了条件</param>
        /// <param name="calcGradient">勾配フラグ．trueの場合，この関数は全ての画像ピクセルに対する勾配の強さを計算し，これをエネルギー場と見なす． falseの場合は，入力画像自体がエネルギー場と見なされる．</param>
#else
        /// <summary>
        /// Changes contour position to minimize its energy
        /// </summary>
        /// <param name="image">The source image or external energy field. </param>
        /// <param name="points">Contour points (snake). </param>
        /// <param name="alpha">Weights of continuity energy, single float or array of length floats, one per each contour point. </param>
        /// <param name="beta">Weights of curvature energy, similar to alpha. </param>
        /// <param name="gamma">Weights of image energy, similar to alpha. </param>
        /// <param name="win">Size of neighborhood of every point used to search the minimum, both win.width and win.height must be odd. </param>
        /// <param name="criteria">Termination criteria. </param>
        /// <param name="calcGradient">Gradient flag. If true, the function calculates gradient magnitude for every image pixel and consideres it as the energy field, otherwise the input image itself is considered. </param>
#endif
        public static void SnakeImage(IplImage image, CvPoint[] points, float[] alpha, float[] beta, float[] gamma, CvSize win, CvTermCriteria criteria, bool calcGradient)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (points == null)
                throw new ArgumentNullException("points");
            if (alpha == null)
                throw new ArgumentNullException("alpha");
            if (beta == null)
                throw new ArgumentNullException("beta");
            if (gamma == null)
                throw new ArgumentNullException("gamma");

            using (var pointsPtr = new ArrayAddress1<CvPoint>(points))
            {
                CvInvoke.cvSnakeImage(image.CvPtr, pointsPtr, points.Length, alpha, beta, gamma, CvConst.CV_ARRAY, win, criteria, calcGradient);
            }
        }
        #endregion
        #region Sobel
#if LANG_JP
        /// <summary>
        /// 拡張Sobel演算子を用いて1次，2次，3次または混合次数の微分画像を計算する [aperture_size=3]
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="xorder">x-導関数の次数</param>
        /// <param name="yorder">y-導関数の次数</param>
#else
        /// <summary>
        /// Calculates first, second, third or mixed image derivatives using _extended Sobel operator
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="xorder">Order of the derivative x.</param>
        /// <param name="yorder">Order of the derivative y.</param>
#endif
        public static void Sobel(CvArr src, CvArr dst, int xorder, int yorder)
        {
            Sobel(src, dst, xorder, yorder, ApertureSize.Size3);
        }
#if LANG_JP
        /// <summary>
        /// 拡張Sobel演算子を用いて1次，2次，3次または混合次数の微分画像を計算する
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="xorder">x-導関数の次数</param>
        /// <param name="yorder">y-導関数の次数</param>
        /// <param name="apertureSize">拡張Sobelカーネルのサイズ</param>
#else
        /// <summary>
        /// Calculates first, second, third or mixed image derivatives using extended Sobel operator
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="xorder">Order of the derivative x.</param>
        /// <param name="yorder">Order of the derivative y.</param>
        /// <param name="apertureSize">Size of the extended Sobel kernel.</param>
#endif
        public static void Sobel(CvArr src, CvArr dst, int xorder, int yorder, ApertureSize apertureSize)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvSobel(src.CvPtr, dst.CvPtr, xorder, yorder, apertureSize);
        }
        #endregion
        #region Solve
#if LANG_JP
        /// <summary>
        /// 線形問題または最小二乗法問題を解く. dst = arg min_x||A*X-B||
        /// </summary>
        /// <param name="src1">入力行列</param>
        /// <param name="src2">線形システムの右辺</param>
        /// <param name="dst">出力解</param>
        /// <returns>methodにLUを指定した場合，Aが正則行列であればtrueを返し，そうでなければfalseを返す．</returns>
#else
        /// <summary>
        /// Solves linear system or least-squares problem
        /// </summary>
        /// <param name="src1">The source matrix. </param>
        /// <param name="src2">The right-hand part of the linear system. </param>
        /// <param name="dst">The output solution. </param>
        /// <returns>If CV_LU method is used, the function returns true if src1 is non-singular and false otherwise, in the latter case dst is not valid</returns>
#endif
        public static bool Solve(CvArr src1, CvArr src2, CvArr dst)
        {
            return Solve(src1, src2, dst, InvertMethod.LU);
        }
#if LANG_JP
        /// <summary>
        /// 線形問題または最小二乗法問題を解く. dst = arg min_x||A*X-B||
        /// </summary>
        /// <param name="src1">入力行列</param>
        /// <param name="src2">線形システムの右辺</param>
        /// <param name="dst">出力解</param>
        /// <param name="method">逆行列の解法</param>
        /// <returns>methodにLUを指定した場合，Aが正則行列であればtrueを返し，そうでなければfalseを返す．</returns>
#else
        /// <summary>
        /// Solves linear system or least-squares problem
        /// </summary>
        /// <param name="src1">The source matrix. </param>
        /// <param name="src2">The right-hand part of the linear system. </param>
        /// <param name="dst">The output solution. </param>
        /// <param name="method">The solution (matrix inversion) method</param>
        /// <returns>If CV_LU method is used, the function returns true if src1 is non-singular and false otherwise, in the latter case dst is not valid</returns>
#endif
        public static bool Solve(CvArr src1, CvArr src2, CvArr dst, InvertMethod method)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            return CvInvoke.cvSolve(src1.CvPtr, src2.CvPtr, dst.CvPtr, method) != 0;
        }
        #endregion
        #region SolveCubic
#if LANG_JP
        /// <summary>
        /// 3次方程式の実根を求める
        /// </summary>
        /// <param name="coeffs">式の係数で，3個または4個の要素を持つ配列．</param>
        /// <param name="roots">実根の出力配列．三つの要素を持つ．</param>
        /// <returns>求めた実根の数</returns>
#else
        /// <summary>
        /// Finds real roots of a cubic equation
        /// </summary>
        /// <param name="coeffs">The equation coefficients, array of 3 or 4 elements. </param>
        /// <param name="roots">The output array of real roots. Should have 3 elements. </param>
        /// <returns>the number of real roots found.</returns>
#endif
        public static int SolveCubic(CvMat coeffs, CvMat roots)
        {
            if (coeffs == null)
                throw new ArgumentNullException("coeffs");
            if (roots == null)
                throw new ArgumentNullException("roots");
            return CvInvoke.cvSolveCubic(coeffs.CvPtr, roots.CvPtr);
        }
        #endregion
        #region SolvePoly
#if LANG_JP
        /// <summary>
        /// 実係数多項式の実根および複素根を求める
        /// </summary>
        /// <param name="coeffs">(degree + 1) の長さの，方程式の係数配列（CV_32FC1 or CV_64FC1）</param>
        /// <param name="roots">degree の長さのね実根と複素根の出力配列（CV_32FC2 or CV_64FC2）</param>
#else
        /// <summary>
        /// Finds real and complex roots of a polynomial equation with real coefficients
        /// </summary>
        /// <param name="coeffs">The (degree + 1)-length array of equation coefficients (CV_32FC1 or CV_64FC1). </param>
        /// <param name="roots">The degree-length output array of real or complex roots (CV_32FC2 or CV_64FC2). </param>
#endif
        public static void SolvePoly(CvMat coeffs, CvMat roots)
        {
            SolvePoly(coeffs, roots, 10, 10);
        }
#if LANG_JP
        /// <summary>
        /// 実係数多項式の実根および複素根を求める
        /// </summary>
        /// <param name="coeffs">(degree + 1) の長さの，方程式の係数配列（CV_32FC1 or CV_64FC1）</param>
        /// <param name="roots">degree の長さのね実根と複素根の出力配列（CV_32FC2 or CV_64FC2）</param>
        /// <param name="maxiter">反復計算の最大繰り返し数</param>
#else
        /// <summary>
        /// Finds real and complex roots of a polynomial equation with real coefficients
        /// </summary>
        /// <param name="coeffs">The (degree + 1)-length array of equation coefficients (CV_32FC1 or CV_64FC1). </param>
        /// <param name="roots">The degree-length output array of real or complex roots (CV_32FC2 or CV_64FC2). </param>
        /// <param name="maxiter">The maximum number of iterations. </param>
#endif
        public static void SolvePoly(CvMat coeffs, CvMat roots, int maxiter)
        {
            SolvePoly(coeffs, roots, maxiter, 10);
        }
#if LANG_JP
        /// <summary>
        /// 実係数多項式の実根および複素根を求める
        /// </summary>
        /// <param name="coeffs">(degree + 1) の長さの，方程式の係数配列（CV_32FC1 or CV_64FC1）</param>
        /// <param name="roots">degree の長さのね実根と複素根の出力配列（CV_32FC2 or CV_64FC2）</param>
        /// <param name="maxiter">反復計算の最大繰り返し数</param>
        /// <param name="fig">要求精度の桁数</param>
#else
        /// <summary>
        /// Finds real and complex roots of a polynomial equation with real coefficients
        /// </summary>
        /// <param name="coeffs">The (degree + 1)-length array of equation coefficients (CV_32FC1 or CV_64FC1). </param>
        /// <param name="roots">The degree-length output array of real or complex roots (CV_32FC2 or CV_64FC2). </param>
        /// <param name="maxiter">The maximum number of iterations. </param>
        /// <param name="fig">The required figures of precision required. </param>
#endif
        public static void SolvePoly(CvMat coeffs, CvMat roots, int maxiter, int fig)
        {
            if (coeffs == null)
                throw new ArgumentNullException("coeffs");
            if (roots == null)
                throw new ArgumentNullException("roots");
            CvInvoke.cvSolvePoly(coeffs.CvPtr, roots.CvPtr, maxiter, fig);
        }
        #endregion
        #region Sort
#if LANG_JP
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="src">Source array to sort</param>
#else
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="src">Source array to sort</param>
#endif
        public static void Sort(CvArr src)
        {
            Sort(src, null);
        }
#if LANG_JP
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="src">Source array to sort</param>
        /// <param name="dst">Optional destination array</param>
#else
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="src">Source array to sort</param>
        /// <param name="dst">Optional destination array</param>
#endif
        public static void Sort(CvArr src, CvArr dst)
        {
            Sort(src, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="src">Source array to sort</param>
        /// <param name="dst">Optional destination array</param>
        /// <param name="idxmat">Index matrix</param>
#else
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="src">Source array to sort</param>
        /// <param name="dst">Optional destination array</param>
        /// <param name="idxmat">Index matrix</param>
#endif
        public static void Sort(CvArr src, CvArr dst, CvArr idxmat)
        {
            Sort(src, dst, idxmat, 0);
        }
#if LANG_JP
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="src">Source array to sort</param>
        /// <param name="dst">Optional destination array</param>
        /// <param name="idxmat">Index matrix</param>
        /// <param name="flags">Sorting parameter</param>
#else
        /// <summary>
        /// Sorts the rows/cols of an array ascending/descending
        /// </summary>
        /// <param name="src">Source array to sort</param>
        /// <param name="dst">Optional destination array</param>
        /// <param name="idxmat">Index matrix</param>
        /// <param name="flags">Sorting parameter</param>
#endif
        public static void Sort(CvArr src, CvArr dst, CvArr idxmat, SortFlag flags)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            IntPtr dstPtr = (dst == null) ? IntPtr.Zero : dst.CvPtr;
            IntPtr idxmatPtr = (dst == null) ? IntPtr.Zero : idxmat.CvPtr;
            CvInvoke.cvSort(src.CvPtr, dstPtr, idxmatPtr, flags);
        }
        #endregion
        #region Split
#if LANG_JP
        /// <summary>
        /// マルチチャンネルの配列を，複数のシングルチャンネルの配列に分割する．または，配列から一つのチャンネルを取り出す．
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst0">出力チャンネル1</param>
        /// <param name="dst1">出力チャンネル2</param>
        /// <param name="dst2">出力チャンネル3</param>
        /// <param name="dst3">出力チャンネル4</param>
#else
        /// <summary>
        /// Divides multi-channel array into several single-channel arrays or extracts a single channel from the array
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst0">Destination channel 0</param>
        /// <param name="dst1">Destination channel 1</param>
        /// <param name="dst2">Destination channel 2</param>
        /// <param name="dst3">Destination channel 3</param>
#endif
        public static void Split(CvArr src, CvArr dst0, CvArr dst1, CvArr dst2, CvArr dst3)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            IntPtr p0 = (dst0 == null) ? IntPtr.Zero : dst0.CvPtr;
            IntPtr p1 = (dst1 == null) ? IntPtr.Zero : dst1.CvPtr;
            IntPtr p2 = (dst2 == null) ? IntPtr.Zero : dst2.CvPtr;
            IntPtr p3 = (dst3 == null) ? IntPtr.Zero : dst3.CvPtr;
            CvInvoke.cvSplit(src.CvPtr, p0, p1, p2, p3);
        }
#if LANG_JP
        /// <summary>
        /// マルチチャンネルの配列を，複数のシングルチャンネルの配列に分割する．または，配列から一つのチャンネルを取り出す．
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst0">出力チャンネル1</param>
        /// <param name="dst1">出力チャンネル2</param>
        /// <param name="dst2">出力チャンネル3</param>
        /// <param name="dst3">出力チャンネル4</param>
#else
        /// <summary>
        /// Divides multi-channel array into several single-channel arrays or extracts a single channel from the array
        /// </summary>
        /// <param name="src">Source array. </param>
        /// <param name="dst0">Destination channel 0</param>
        /// <param name="dst1">Destination channel 1</param>
        /// <param name="dst2">Destination channel 2</param>
        /// <param name="dst3">Destination channel 3</param>
#endif
        public static void CvtPixToPlane(CvArr src, CvArr dst0, CvArr dst1, CvArr dst2, CvArr dst3)
        {
            Split(src, dst0, dst1, dst2, dst3);
        }
        #endregion
        #region Sqrt
#if LANG_JP
        /// <summary>
        /// 引数の平方根を計算する． 
        /// 引数が負の値の場合，結果は求まらない． 
        /// </summary>
        /// <param name="value">浮動小数点型の入力値</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates square root
        /// </summary>
        /// <param name="value">The input floating-point value </param>
        /// <returns></returns>
#endif
        public static float Sqrt(float value)
        {
            return (float)Math.Sqrt(value);
        }
        #endregion
        #region SquareAcc
#if LANG_JP
        /// <summary>
        /// アキュムレータに入力画像の二乗を加算する
        /// </summary>
        /// <param name="image">入力画像，1- あるいは 3-チャンネル，8 ビットあるいは 32 ビット浮動小数点型．（マルチチャンネル画像の各チャンネルは，個別に処理される）.</param>
        /// <param name="sqsum">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型． </param>
#else
        /// <summary>
        /// Adds the square of source image to accumulator
        /// </summary>
        /// <param name="image">Input image, 1- or 3-channel, 8-bit or 32-bit floating point (each channel of multi-channel image is processed independently). </param>
        /// <param name="sqsum">Accumulator of the same number of channels as input image, 32-bit or 64-bit floating-point. </param>
#endif
        public static void SquareAcc(CvArr image, CvArr sqsum)
        {
            SquareAcc(image, sqsum, null);
        }
#if LANG_JP
        /// <summary>
        /// アキュムレータに入力画像の二乗を加算する
        /// </summary>
        /// <param name="image">入力画像，1- あるいは 3-チャンネル，8 ビットあるいは 32 ビット浮動小数点型．（マルチチャンネル画像の各チャンネルは，個別に処理される）.</param>
        /// <param name="sqsum">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型． </param>
        /// <param name="mask">オプションの処理マスク</param>        
#else
        /// <summary>
        /// Adds the square of source image to accumulator
        /// </summary>
        /// <param name="image">Input image, 1- or 3-channel, 8-bit or 32-bit floating point (each channel of multi-channel image is processed independently). </param>
        /// <param name="sqsum">Accumulator of the same number of channels as input image, 32-bit or 64-bit floating-point. </param>
        /// <param name="mask">Optional operation mask. </param>
#endif
        public static void SquareAcc(CvArr image, CvArr sqsum, CvArr mask)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (sqsum == null)
                throw new ArgumentNullException("sqsum");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvSquareAcc(image.CvPtr, sqsum.CvPtr, maskPtr);
        }
        #endregion
        #region StarDetectorParams
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
        /// Constructor
        /// </summary>
#endif
        public static CvStarDetectorParams StarDetectorParams()
        {
            return new CvStarDetectorParams();
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="maxSize"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize"></param>
#endif
        public static CvStarDetectorParams StarDetectorParams(int maxSize)
        {
            return new CvStarDetectorParams(maxSize);
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
#endif
        public static CvStarDetectorParams StarDetectorParams(int maxSize, int responseThreshold)
        {
            return new CvStarDetectorParams(maxSize, responseThreshold);
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
#endif
        public static CvStarDetectorParams StarDetectorParams(int maxSize, int responseThreshold, int lineThresholdProjected)
        {
            return new CvStarDetectorParams(maxSize, responseThreshold, lineThresholdProjected);
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
        /// <param name="lineThresholdBinarized"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
        /// <param name="lineThresholdBinarized"></param>
#endif
        public static CvStarDetectorParams StarDetectorParams(int maxSize, int responseThreshold, int lineThresholdProjected, int lineThresholdBinarized)
        {
            return new CvStarDetectorParams(maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized);
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
        /// <param name="lineThresholdBinarized"></param>
        /// <param name="suppressNonmaxSize"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="responseThreshold"></param>
        /// <param name="lineThresholdProjected"></param>
        /// <param name="lineThresholdBinarized"></param>
        /// <param name="suppressNonmaxSize"></param>
#endif
        public static CvStarDetectorParams StarDetectorParams(int maxSize, int responseThreshold, int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize)
        {
            return new CvStarDetectorParams(maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized, suppressNonmaxSize);
        }
        #endregion
        #region StarKeypoint
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="size"></param>
        /// <param name="response"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="size"></param>
        /// <param name="response"></param>
#endif
        public static CvStarKeypoint StarKeypoint(CvPoint pt, int size, float response)
        {
            return new CvStarKeypoint(pt, size, response);
        }
        #endregion
        #region StartAppendToSeq
#if LANG_JP
        /// <summary>
        /// シーケンスへのデータ書き込み処理を初期化する
        /// </summary>
        /// <param name="seq">シーケンスへのポインタ．</param>
        /// <param name="writer">ライタ（Writer）の状態．この関数で初期化される．</param>
#else
        /// <summary>
        /// Initializes process of writing data to sequence
        /// </summary>
        /// <param name="seq">Pointer to the sequence. </param>
        /// <param name="writer">Writer state; initialized by the function. </param>
#endif
        public static void StartAppendToSeq(CvSeq seq, out CvSeqWriter writer)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            writer = new CvSeqWriter();
            CvInvoke.cvStartAppendToSeq(seq.CvPtr, writer.CvPtr);
        }
        #endregion
        #region StartFindContours
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <returns>CvContourScanner</returns>
#endif
        public static CvContourScanner StartFindContours(CvArr image, CvMemStorage storage)
        {
            return StartFindContours(image, storage, CvContour.SizeOf, ContourRetrieval.List, ContourChain.ApproxSimple, new CvPoint());
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="headerSize"></param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public static CvContourScanner StartFindContours(CvArr image, CvMemStorage storage, int headerSize)
        {
            return StartFindContours(image, storage, headerSize, ContourRetrieval.List, ContourChain.ApproxSimple, new CvPoint());
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="headerSize">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public static CvContourScanner StartFindContours(CvArr image, CvMemStorage storage, int headerSize, ContourRetrieval mode)
        {
            return StartFindContours(image, storage, headerSize, mode, ContourChain.ApproxSimple, new CvPoint());
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="headerSize">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
        /// <param name="method">近似手法．cvFindContoursと同様，但し CV_LINK_RUNS は使用不可． </param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <param name="method">Approximation method. It has the same meaning as in cvFindContours, but CV_LINK_RUNS can not be used here. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public static CvContourScanner StartFindContours(CvArr image, CvMemStorage storage, int headerSize, ContourRetrieval mode, ContourChain method)
        {
            return StartFindContours(image, storage, headerSize, mode, method, new CvPoint());
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="headerSize">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
        /// <param name="method">近似手法．cvFindContoursと同様，但し CV_LINK_RUNS は使用不可． </param>
        /// <param name="offset">ROIのオフセット．cvFindContoursを参照． </param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="headerSize">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <param name="method">Approximation method. It has the same meaning as in cvFindContours, but CV_LINK_RUNS can not be used here. </param>
        /// <param name="offset">ROI offset; see cvFindContours. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public static CvContourScanner StartFindContours(CvArr image, CvMemStorage storage, int headerSize, ContourRetrieval mode, ContourChain method, CvPoint offset)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (storage == null)
                throw new ArgumentNullException("storage");

            return new CvContourScanner(image, storage, headerSize, mode, method, offset);
        }
        #endregion
        #region StartNextStream
#if LANG_JP
        /// <summary>
        /// ファイルストレージ内の次のストリームを開始する． 
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
#else
        /// <summary>
        /// Starts the next stream
        /// </summary>
        /// <param name="fs">File storage. </param>
#endif
        public static void StartNextStream(CvFileStorage fs)
        {
            if (fs == null)
            {
                throw new ArgumentNullException("fs");
            }
            CvInvoke.cvStartNextStream(fs.CvPtr);
        }
        #endregion
        #region StartReadChainPoints
#if LANG_JP
        /// <summary>
        /// チェーンリーダを初期化する
        /// </summary>
        /// <param name="chain">チェーンへのポインタ</param>
        /// <param name="reader">チェーンリーダの状態</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chain">Pointer to chain.</param>
        /// <param name="reader">Chain reader state.</param>
#endif
        public static void StartReadChainPoints(CvChain chain, CvChainPtReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");
            if (chain == null)
                throw new ArgumentNullException("chain");
            reader.StartReadChainPoints(chain);
        }
        #endregion
        #region StartReadRawData
#if LANG_JP
        /// <summary>
        /// ファイルノードのシーケンスリーダの初期化
        /// </summary>
        /// <param name="fs">ファイルストレージ．</param>
        /// <param name="src">読み込むファイルノード(シーケンス)．</param>
        /// <param name="reader">シーケンスリーダへのポインタ．</param>
#else
        /// <summary>
        /// Initializes file node sequence reader
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="src">The file node (a sequence) to read numbers from. </param>
        /// <param name="reader">Output reference to the sequence reader. </param>
#endif
        public static void StartReadRawData(CvFileStorage fs, CvFileNode src, out CvSeqReader reader)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (src == null)
                throw new ArgumentNullException("src");
            reader = new CvSeqReader();
            CvInvoke.cvStartReadRawData(fs.CvPtr, src.CvPtr, reader.CvPtr);
        }
        #endregion
        #region StartReadSeq
#if LANG_JP
        /// <summary>
        /// シーケンスからの連続読み出し処理を初期化する
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="reader">リーダ（reader）の状態．この関数で初期化される．</param>
#else
        /// <summary>
        /// Initializes process of sequential reading from sequence
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <param name="reader">Reader state; initialized by the function. </param>
#endif
        public static void StartReadSeq(CvSeq seq, CvSeqReader reader)
        {
            StartReadSeq(seq, reader, false);
        }
#if LANG_JP
        /// <summary>
        /// シーケンスからの連続読み出し処理を初期化する
        /// </summary>
        /// <param name="seq">シーケンス</param>
        /// <param name="reader">リーダ（reader）の状態．この関数で初期化される．</param>
        /// <param name="reverse">シーケンス走査方向の指定．reverse が false の場合，リーダは先頭のシーケンス要素に位置する．それ以外は最後の要素に位置する．</param>
#else
        /// <summary>
        /// Initializes process of sequential reading from sequence
        /// </summary>
        /// <param name="seq">Sequence. </param>
        /// <param name="reader">Reader state; initialized by the function. </param>
        /// <param name="reverse">Determines the direction of the sequence traversal. If reverse is false, the reader is positioned at the first sequence element, otherwise it is positioned at the last element. </param>
#endif
        public static void StartReadSeq(CvSeq seq, CvSeqReader reader, bool reverse)
        {
            if (seq == null)
                throw new ArgumentNullException("seq");
            if (reader == null)
                throw new ArgumentNullException("reader");
            CvInvoke.cvStartReadSeq(seq.CvPtr, reader.CvPtr, reverse);
        }
        #endregion
        #region StartWindowThread
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// For MacOS or Linux, tries to start  thread to hande a window automatically (resizing, updating). Returns 0 if not supported
        /// </summary>
        /// <returns></returns>
#endif
        public static int StartWindowThread()
        {
            return CvInvoke.cvStartWindowThread();
        }
        #endregion
        #region StartWriteSeq
#if LANG_JP
        /// <summary>
        /// 新しいシーケンスを作成し，ライタ（writer）を初期化する
        /// </summary>
        /// <param name="seqFlags">作成されたシーケンスのフラグ． 生成されたシーケンスが，特定のシーケンスタイプを引数にとるような関数に一切渡されない場合は，この値に0を指定してもかまわない． そうでない場合は，定義済みのシーケンスタイプのリストから適切なタイプが選択されなければならない． </param>
        /// <param name="headerSize">シーケンスヘッダのサイズ．sizeof(CvSeq)以上でなければならない． また，特別なタイプか拡張が指示されている場合，そのタイプは基本タイプのヘッダサイズと合致しなければならない． </param>
        /// <param name="elemSize">シーケンスの要素サイズ（バイト単位）．サイズはシーケンスタイプと合致しなければならない． 例えば，点群のシーケンス（要素タイプは CV_SEQ_ELTYPE_POINT）を作成する場合， パラメータ elem_size は sizeof(CvPoint) と等しくなければならない． </param>
        /// <param name="storage">シーケンスの位置． </param>
        /// <param name="writer">ライタの状態．この関数で初期化される． </param>
#else
        /// <summary>
        /// Creates new sequence and initializes writer for it
        /// </summary>
        /// <param name="seqFlags">Flags of the created sequence. If the sequence is not passed to any function working with a specific type of sequences, the sequence value may be equal to 0, otherwise the appropriate type must be selected from the list of predefined sequence types. </param>
        /// <param name="headerSize">Size of the sequence header. The parameter value may not be less than sizeof(CvSeq). If a certain type or extension is specified, it must fit the base type header. </param>
        /// <param name="elemSize">Size of the sequence elements in bytes; must be consistent with the sequence type. For example, if the sequence of points is created (element type CV_SEQ_ELTYPE_POINT ), then the parameter elem_size must be equal to sizeof(CvPoint). </param>
        /// <param name="storage">Sequence location. </param>
        /// <param name="writer">Writer state; initialized by the function. </param>
#endif
        public static void StartWriteSeq(SeqType seqFlags, int headerSize, int elemSize, CvMemStorage storage, out CvSeqWriter writer)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            writer = new CvSeqWriter();
            CvInvoke.cvStartWriteSeq(seqFlags, headerSize, elemSize, storage.CvPtr, writer.CvPtr);
        }
        #endregion
        #region StartWriteStruct
#if LANG_JP
        /// <summary>
        /// 新しい構造体の書き込みを開始する
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="name">書き込む構造体の名前．読み込む場合は，この名前で構造体にアクセスできる．</param>
        /// <param name="structFlags">Seq, Map, Flowのフラグの組み合わせ. SeqとMapはどちらか1つを指定しなければならない.</param>
#else
        /// <summary>
        /// Starts writing a new structure
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="name">Name of the written structure. The structure can be accessed by this name when the storage is read. </param>
        /// <param name="structFlags">A combination one of the NodeType flags</param>
#endif
        public static void StartWriteStruct(CvFileStorage fs, string name, NodeType structFlags)
        {
            StartWriteStruct(fs, name, structFlags, null);
        }
#if LANG_JP
        /// <summary>
        /// 新しい構造体の書き込みを開始する
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="name">書き込む構造体の名前．読み込む場合は，この名前で構造体にアクセスできる．</param>
        /// <param name="structFlags">Seq, Map, Flowのフラグの組み合わせ. SeqとMapはどちらか1つを指定しなければならない.</param>
        /// <param name="typeName">オプションパラメータ - オブジェクトの型の名前． 
        /// XMLの場合，構造体開始タグのtype_id属性として書かれる． YAMLの場合，構造体名に続くコロンの後に書かれる． 
        /// 主にユーザオブジェクトと共に使われる．ストレージが読まれたとき，エンコードされた型名がオブジェクトの型を決定する.</param>
#else
        /// <summary>
        /// Starts writing a new structure
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="name">Name of the written structure. The structure can be accessed by this name when the storage is read. </param>
        /// <param name="structFlags">A combination one of the NodeType flags</param>
        /// <param name="typeName">Optional parameter - the object type name. 
        /// In case of XML it is written as type_id attribute of the structure opening tag. 
        /// In case of YAML it is written after a colon following the structure name. Mainly it comes with user objects. 
        /// When the storage is read, the encoded type name is used to determine the object type. </param>
#endif
        public static void StartWriteStruct(CvFileStorage fs, string name, NodeType structFlags, string typeName)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            CvInvoke.cvStartWriteStruct(fs.CvPtr, name, structFlags, typeName);
        }
        #endregion
        #region StereoCalibrate
#if LANG_JP
        /// <summary>
        /// ステレオカメラのキャリブレーションを行う
        /// </summary>
        /// <param name="objectPoints">オブジェクト点の結合行列，3xN あるいは Nx3．ここで， N は全てのビューにおける点数の合計． </param>
        /// <param name="imagePoints1">1 番目のカメラのビューにおける画像間対応点の結合行列， 2xN あるいは Nx2．ここで，N は全てのビューにおける点数の合計． </param>
        /// <param name="imagePoints2">2 番目のカメラのビューにおける画像間対応点の結合行列， 2xN あるいは Nx2．ここで，N は全てのビューにおける点数の合計． </param>
        /// <param name="npoints">各ビューに含まれる点数のベクトル，1xM あるいは Mx1． ここで，M はビューの数． </param>
        /// <param name="cameraMatrix1">入出力カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]． CV_CALIB_USE_INTRINSIC_GUESS か CV_CALIB_FIX_ASPECT_RATIO が指定された場 合は，これらの行列のいくつか（または全て）の要素が初期化されているはずである． </param>
        /// <param name="distCoeffs1">カメラ1の歪み係数を表す入出力ベクトル， 4x1，1x4，5x1，1x5．</param>
        /// <param name="cameraMatrix2">入出力カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]． CV_CALIB_USE_INTRINSIC_GUESS か CV_CALIB_FIX_ASPECT_RATIO が指定された場 合は，これらの行列のいくつか（または全て）の要素が初期化されているはずである． </param>
        /// <param name="distCoeffs2">カメラ2の歪み係数を表す入出力ベクトル， 4x1，1x4，5x1，1x5．</param>
        /// <param name="imageSize">画像サイズ．カメラの内部パラメータ行列を初期化する際にのみ用いられる． </param>
        /// <param name="R">1 番目と2 番目のカメラの座標系間の回転行列． </param>
        /// <param name="T">カメラ座標系間の並進ベクトル． </param>
#else
        /// <summary>
        /// Calibrates stereo camera
        /// </summary>
        /// <param name="objectPoints">The joint matrix of object points, 3xN or Nx3, where N is the total number of points in all views. </param>
        /// <param name="imagePoints1">The joint matrix of corresponding image points in the views from the 1st camera, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="imagePoints2">The joint matrix of corresponding image points in the views from the 2nd camera, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="npoints">Vector containing numbers of points in each view, 1xM or Mx1, where M is the number of views. </param>
        /// <param name="cameraMatrix1">The input/output camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of the elements of the matrices must be initialized. </param>
        /// <param name="distCoeffs1">The input/output vector of distortion coefficients for each camera, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="cameraMatrix2">The input/output camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of the elements of the matrices must be initialized. </param>
        /// <param name="distCoeffs2">The input/output vector of distortion coefficients for each camera, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="imageSize">Size of the image, used only to initialize intrinsic camera matrix. </param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras' coordinate systems </param>
        /// <param name="T">The translation vector between the cameras' coordinate systems. </param>
#endif
        public static void StereoCalibrate(CvMat objectPoints, CvMat imagePoints1, CvMat imagePoints2, CvMat npoints,
                       CvMat cameraMatrix1, CvMat distCoeffs1, CvMat cameraMatrix2, CvMat distCoeffs2,
                       CvSize imageSize, CvMat R, CvMat T)
        {
            StereoCalibrate(objectPoints, imagePoints1, imagePoints2, npoints,
                cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2,
                imageSize, R, T, null, null, new CvTermCriteria(30, 1e-6), CalibrationFlag.FixIntrinsic);
        }
#if LANG_JP
        /// <summary>
        /// ステレオカメラのキャリブレーションを行う
        /// </summary>
        /// <param name="objectPoints">オブジェクト点の結合行列，3xN あるいは Nx3．ここで， N は全てのビューにおける点数の合計． </param>
        /// <param name="imagePoints1">1 番目のカメラのビューにおける画像間対応点の結合行列， 2xN あるいは Nx2．ここで，N は全てのビューにおける点数の合計． </param>
        /// <param name="imagePoints2">2 番目のカメラのビューにおける画像間対応点の結合行列， 2xN あるいは Nx2．ここで，N は全てのビューにおける点数の合計． </param>
        /// <param name="npoints">各ビューに含まれる点数のベクトル，1xM あるいは Mx1． ここで，M はビューの数． </param>
        /// <param name="cameraMatrix1">入出力カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]． CV_CALIB_USE_INTRINSIC_GUESS か CV_CALIB_FIX_ASPECT_RATIO が指定された場 合は，これらの行列のいくつか（または全て）の要素が初期化されているはずである． </param>
        /// <param name="distCoeffs1">カメラ1の歪み係数を表す入出力ベクトル， 4x1，1x4，5x1，1x5．</param>
        /// <param name="cameraMatrix2">入出力カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]． CV_CALIB_USE_INTRINSIC_GUESS か CV_CALIB_FIX_ASPECT_RATIO が指定された場 合は，これらの行列のいくつか（または全て）の要素が初期化されているはずである． </param>
        /// <param name="distCoeffs2">カメラ2の歪み係数を表す入出力ベクトル， 4x1，1x4，5x1，1x5．</param>
        /// <param name="imageSize">画像サイズ．カメラの内部パラメータ行列を初期化する際にのみ用いられる． </param>
        /// <param name="R">1 番目と2 番目のカメラの座標系間の回転行列． </param>
        /// <param name="T">カメラ座標系間の並進ベクトル． </param>
        /// <param name="E">出力オプション：E行列．</param>
#else
        /// <summary>
        /// Calibrates stereo camera
        /// </summary>
        /// <param name="objectPoints">The joint matrix of object points, 3xN or Nx3, where N is the total number of points in all views. </param>
        /// <param name="imagePoints1">The joint matrix of corresponding image points in the views from the 1st camera, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="imagePoints2">The joint matrix of corresponding image points in the views from the 2nd camera, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="npoints">Vector containing numbers of points in each view, 1xM or Mx1, where M is the number of views. </param>
        /// <param name="cameraMatrix1">The input/output camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of the elements of the matrices must be initialized. </param>
        /// <param name="distCoeffs1">The input/output vector of distortion coefficients for each camera, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="cameraMatrix2">The input/output camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of the elements of the matrices must be initialized. </param>
        /// <param name="distCoeffs2">The input/output vector of distortion coefficients for each camera, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="imageSize">Size of the image, used only to initialize intrinsic camera matrix. </param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras' coordinate systems </param>
        /// <param name="T">The translation vector between the cameras' coordinate systems. </param>
        /// <param name="E">The optional output essential matrix </param>
#endif
        public static void StereoCalibrate(CvMat objectPoints, CvMat imagePoints1, CvMat imagePoints2, CvMat npoints,
                       CvMat cameraMatrix1, CvMat distCoeffs1, CvMat cameraMatrix2, CvMat distCoeffs2,
                       CvSize imageSize, CvMat R, CvMat T,
                       CvMat E)
        {
            StereoCalibrate(objectPoints, imagePoints1, imagePoints2, npoints,
                cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2,
                imageSize, R, T, E, null, new CvTermCriteria(30, 1e-6), CalibrationFlag.FixIntrinsic);
        }
#if LANG_JP
        /// <summary>
        /// ステレオカメラのキャリブレーションを行う
        /// </summary>
        /// <param name="objectPoints">オブジェクト点の結合行列，3xN あるいは Nx3．ここで， N は全てのビューにおける点数の合計． </param>
        /// <param name="imagePoints1">1 番目のカメラのビューにおける画像間対応点の結合行列， 2xN あるいは Nx2．ここで，N は全てのビューにおける点数の合計． </param>
        /// <param name="imagePoints2">2 番目のカメラのビューにおける画像間対応点の結合行列， 2xN あるいは Nx2．ここで，N は全てのビューにおける点数の合計． </param>
        /// <param name="npoints">各ビューに含まれる点数のベクトル，1xM あるいは Mx1． ここで，M はビューの数． </param>
        /// <param name="cameraMatrix1">入出力カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]． CV_CALIB_USE_INTRINSIC_GUESS か CV_CALIB_FIX_ASPECT_RATIO が指定された場 合は，これらの行列のいくつか（または全て）の要素が初期化されているはずである． </param>
        /// <param name="distCoeffs1">カメラ1の歪み係数を表す入出力ベクトル， 4x1，1x4，5x1，1x5．</param>
        /// <param name="cameraMatrix2">入出力カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]． CV_CALIB_USE_INTRINSIC_GUESS か CV_CALIB_FIX_ASPECT_RATIO が指定された場 合は，これらの行列のいくつか（または全て）の要素が初期化されているはずである． </param>
        /// <param name="distCoeffs2">カメラ2の歪み係数を表す入出力ベクトル， 4x1，1x4，5x1，1x5．</param>
        /// <param name="imageSize">画像サイズ．カメラの内部パラメータ行列を初期化する際にのみ用いられる． </param>
        /// <param name="R">1 番目と2 番目のカメラの座標系間の回転行列． </param>
        /// <param name="T">カメラ座標系間の並進ベクトル． </param>
        /// <param name="E">出力オプション：E行列．</param>
        /// <param name="F">出力オプション：F行列（基礎行列）．</param>
#else
        /// <summary>
        /// Calibrates stereo camera
        /// </summary>
        /// <param name="objectPoints">The joint matrix of object points, 3xN or Nx3, where N is the total number of points in all views. </param>
        /// <param name="imagePoints1">The joint matrix of corresponding image points in the views from the 1st camera, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="imagePoints2">The joint matrix of corresponding image points in the views from the 2nd camera, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="npoints">Vector containing numbers of points in each view, 1xM or Mx1, where M is the number of views. </param>
        /// <param name="cameraMatrix1">The input/output camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of the elements of the matrices must be initialized. </param>
        /// <param name="distCoeffs1">The input/output vector of distortion coefficients for each camera, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="cameraMatrix2">The input/output camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of the elements of the matrices must be initialized. </param>
        /// <param name="distCoeffs2">The input/output vector of distortion coefficients for each camera, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="imageSize">Size of the image, used only to initialize intrinsic camera matrix. </param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras' coordinate systems </param>
        /// <param name="T">The translation vector between the cameras' coordinate systems. </param>
        /// <param name="E">The optional output essential matrix </param>
        /// <param name="F">The optional output fundamental matrix </param>
#endif
        public static void StereoCalibrate(CvMat objectPoints, CvMat imagePoints1, CvMat imagePoints2, CvMat npoints,
                       CvMat cameraMatrix1, CvMat distCoeffs1, CvMat cameraMatrix2, CvMat distCoeffs2,
                       CvSize imageSize, CvMat R, CvMat T,
                       CvMat E, CvMat F)
        {
            StereoCalibrate(objectPoints, imagePoints1, imagePoints2, npoints,
                cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2,
                imageSize, R, T, E, F, new CvTermCriteria(30, 1e-6), CalibrationFlag.FixIntrinsic);
        }
#if LANG_JP
        /// <summary>
        /// ステレオカメラのキャリブレーションを行う
        /// </summary>
        /// <param name="objectPoints">オブジェクト点の結合行列，3xN あるいは Nx3．ここで， N は全てのビューにおける点数の合計． </param>
        /// <param name="imagePoints1">1 番目のカメラのビューにおける画像間対応点の結合行列， 2xN あるいは Nx2．ここで，N は全てのビューにおける点数の合計． </param>
        /// <param name="imagePoints2">2 番目のカメラのビューにおける画像間対応点の結合行列， 2xN あるいは Nx2．ここで，N は全てのビューにおける点数の合計． </param>
        /// <param name="npoints">各ビューに含まれる点数のベクトル，1xM あるいは Mx1． ここで，M はビューの数． </param>
        /// <param name="cameraMatrix1">入出力カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]． CV_CALIB_USE_INTRINSIC_GUESS か CV_CALIB_FIX_ASPECT_RATIO が指定された場 合は，これらの行列のいくつか（または全て）の要素が初期化されているはずである． </param>
        /// <param name="distCoeffs1">カメラ1の歪み係数を表す入出力ベクトル， 4x1，1x4，5x1，1x5．</param>
        /// <param name="cameraMatrix2">入出力カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]． CV_CALIB_USE_INTRINSIC_GUESS か CV_CALIB_FIX_ASPECT_RATIO が指定された場 合は，これらの行列のいくつか（または全て）の要素が初期化されているはずである． </param>
        /// <param name="distCoeffs2">カメラ2の歪み係数を表す入出力ベクトル， 4x1，1x4，5x1，1x5．</param>
        /// <param name="imageSize">画像サイズ．カメラの内部パラメータ行列を初期化する際にのみ用いられる． </param>
        /// <param name="R">1 番目と2 番目のカメラの座標系間の回転行列． </param>
        /// <param name="T">カメラ座標系間の並進ベクトル． </param>
        /// <param name="E">出力オプション：E行列．</param>
        /// <param name="F">出力オプション：F行列（基礎行列）．</param>
        /// <param name="termCrit">繰り返し最適化アルゴリズムのための終了条件．</param>
#else
        /// <summary>
        /// Calibrates stereo camera
        /// </summary>
        /// <param name="objectPoints">The joint matrix of object points, 3xN or Nx3, where N is the total number of points in all views. </param>
        /// <param name="imagePoints1">The joint matrix of corresponding image points in the views from the 1st camera, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="imagePoints2">The joint matrix of corresponding image points in the views from the 2nd camera, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="npoints">Vector containing numbers of points in each view, 1xM or Mx1, where M is the number of views. </param>
        /// <param name="cameraMatrix1">The input/output camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of the elements of the matrices must be initialized. </param>
        /// <param name="distCoeffs1">The input/output vector of distortion coefficients for each camera, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="cameraMatrix2">The input/output camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of the elements of the matrices must be initialized. </param>
        /// <param name="distCoeffs2">The input/output vector of distortion coefficients for each camera, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="imageSize">Size of the image, used only to initialize intrinsic camera matrix. </param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras' coordinate systems </param>
        /// <param name="T">The translation vector between the cameras' coordinate systems. </param>
        /// <param name="E">The optional output essential matrix </param>
        /// <param name="F">The optional output fundamental matrix </param>
        /// <param name="termCrit">Termination criteria for the iterative optimiziation algorithm. </param>
#endif
        public static void StereoCalibrate(CvMat objectPoints, CvMat imagePoints1, CvMat imagePoints2, CvMat npoints,
                       CvMat cameraMatrix1, CvMat distCoeffs1, CvMat cameraMatrix2, CvMat distCoeffs2,
                       CvSize imageSize, CvMat R, CvMat T,
                       CvMat E, CvMat F, CvTermCriteria termCrit)
        {
            StereoCalibrate(objectPoints, imagePoints1, imagePoints2, npoints,
                cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2,
                imageSize, R, T, E, F, termCrit, CalibrationFlag.FixIntrinsic);
        }
#if LANG_JP
        /// <summary>
        /// ステレオカメラのキャリブレーションを行う
        /// </summary>
        /// <param name="objectPoints">オブジェクト点の結合行列，3xN あるいは Nx3．ここで， N は全てのビューにおける点数の合計． </param>
        /// <param name="imagePoints1">1 番目のカメラのビューにおける画像間対応点の結合行列， 2xN あるいは Nx2．ここで，N は全てのビューにおける点数の合計． </param>
        /// <param name="imagePoints2">2 番目のカメラのビューにおける画像間対応点の結合行列， 2xN あるいは Nx2．ここで，N は全てのビューにおける点数の合計． </param>
        /// <param name="npoints">各ビューに含まれる点数のベクトル，1xM あるいは Mx1． ここで，M はビューの数． </param>
        /// <param name="cameraMatrix1">入出力カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]． CV_CALIB_USE_INTRINSIC_GUESS か CV_CALIB_FIX_ASPECT_RATIO が指定された場 合は，これらの行列のいくつか（または全て）の要素が初期化されているはずである． </param>
        /// <param name="distCoeffs1">カメラ1の歪み係数を表す入出力ベクトル， 4x1，1x4，5x1，1x5．</param>
        /// <param name="cameraMatrix2">入出力カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]． CV_CALIB_USE_INTRINSIC_GUESS か CV_CALIB_FIX_ASPECT_RATIO が指定された場 合は，これらの行列のいくつか（または全て）の要素が初期化されているはずである． </param>
        /// <param name="distCoeffs2">カメラ2の歪み係数を表す入出力ベクトル， 4x1，1x4，5x1，1x5．</param>
        /// <param name="imageSize">画像サイズ．カメラの内部パラメータ行列を初期化する際にのみ用いられる． </param>
        /// <param name="R">1 番目と2 番目のカメラの座標系間の回転行列． </param>
        /// <param name="T">カメラ座標系間の並進ベクトル． </param>
        /// <param name="E">出力オプション：E行列．</param>
        /// <param name="F">出力オプション：F行列（基礎行列）．</param>
        /// <param name="termCrit">繰り返し最適化アルゴリズムのための終了条件．</param>
        /// <param name="flags">様々なフラグ</param>
#else
        /// <summary>
        /// Calibrates stereo camera
        /// </summary>
        /// <param name="objectPoints">The joint matrix of object points, 3xN or Nx3, where N is the total number of points in all views. </param>
        /// <param name="imagePoints1">The joint matrix of corresponding image points in the views from the 1st camera, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="imagePoints2">The joint matrix of corresponding image points in the views from the 2nd camera, 2xN or Nx2, where N is the total number of points in all views. </param>
        /// <param name="npoints">Vector containing numbers of points in each view, 1xM or Mx1, where M is the number of views. </param>
        /// <param name="cameraMatrix1">The input/output camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of the elements of the matrices must be initialized. </param>
        /// <param name="distCoeffs1">The input/output vector of distortion coefficients for each camera, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="cameraMatrix2">The input/output camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. If CV_CALIB_USE_INTRINSIC_GUESS or CV_CALIB_FIX_ASPECT_RATIO are specified, some or all of the elements of the matrices must be initialized. </param>
        /// <param name="distCoeffs2">The input/output vector of distortion coefficients for each camera, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="imageSize">Size of the image, used only to initialize intrinsic camera matrix. </param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras' coordinate systems </param>
        /// <param name="T">The translation vector between the cameras' coordinate systems. </param>
        /// <param name="E">The optional output essential matrix </param>
        /// <param name="F">The optional output fundamental matrix </param>
        /// <param name="termCrit">Termination criteria for the iterative optimiziation algorithm. </param>
        /// <param name="flags">Different flags</param>
#endif
        public static void StereoCalibrate(CvMat objectPoints, CvMat imagePoints1, CvMat imagePoints2, CvMat npoints,
                       CvMat cameraMatrix1, CvMat distCoeffs1, CvMat cameraMatrix2, CvMat distCoeffs2,
                       CvSize imageSize, CvMat R, CvMat T,
                       CvMat E, CvMat F, CvTermCriteria termCrit, CalibrationFlag flags)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (imagePoints1 == null)
                throw new ArgumentNullException("imagePoints1");
            if (imagePoints2 == null)
                throw new ArgumentNullException("imagePoints2");
            if (npoints == null)
                throw new ArgumentNullException("npoints");
            if (cameraMatrix1 == null)
                throw new ArgumentNullException("cameraMatrix1");
            if (distCoeffs1 == null)
                throw new ArgumentNullException("distCoeffs1");
            if (cameraMatrix2 == null)
                throw new ArgumentNullException("cameraMatrix2");
            if (distCoeffs2 == null)
                throw new ArgumentNullException("distCoeffs2");

            IntPtr Eptr = (E == null) ? IntPtr.Zero : E.CvPtr;
            IntPtr Fptr = (F == null) ? IntPtr.Zero : F.CvPtr;

            CvInvoke.cvStereoCalibrate(objectPoints.CvPtr, imagePoints1.CvPtr, imagePoints2.CvPtr, npoints.CvPtr,
                cameraMatrix1.CvPtr, distCoeffs1.CvPtr, cameraMatrix2.CvPtr, distCoeffs2.CvPtr,
                imageSize, R.CvPtr, T.CvPtr, Eptr, Fptr, termCrit, flags);
        }
        #endregion
        #region StereoRectify
#if LANG_JP
        /// <summary>
        /// ステレオカメラの平行化変換を求める
        /// </summary>
        /// <param name="cameraMatrix1">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="cameraMatrix2">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="distCoeffs1">カメラ1の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="distCoeffs2">カメラ2の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="imageSize">ステレオカメラのキャリブレーションに用いられる画像サイズ． </param>
        /// <param name="R">1 番目と2 番目のカメラの座標系間の回転行列． </param>
        /// <param name="T">カメラ座標系間の並進ベクトル． </param>
        /// <param name="R1">1 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="R2">2 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="P1">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
        /// <param name="P2">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
#else
        /// <summary>
        /// Computes rectification transform for stereo camera
        /// </summary>
        /// <param name="cameraMatrix1">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="cameraMatrix2">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="distCoeffs1">The vector of distortion coefficients for camera1, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="distCoeffs2">The vector of distortion coefficients for camera2, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="imageSize">Size of the image used for stereo calibration. </param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras' coordinate systems </param>
        /// <param name="T">The translation vector between the cameras' coordinate systems. </param>
        /// <param name="R1">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="R2">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="P1">3x4 Projection matrices in the new (rectified) coordinate systems </param>
        /// <param name="P2">3x4 Projection matrices in the new (rectified) coordinate systems </param>
#endif
        public static void StereoRectify(CvMat cameraMatrix1, CvMat cameraMatrix2, CvMat distCoeffs1, CvMat distCoeffs2,
                             CvSize imageSize, CvMat R, CvMat T, CvMat R1, CvMat R2, CvMat P1, CvMat P2)
        {
            StereoRectify(cameraMatrix1, cameraMatrix2, distCoeffs1, distCoeffs2,
                imageSize, R, T, R1, R2, P1, P2, null, StereoRectificationFlag.ZeroDisparity);
        }
#if LANG_JP
        /// <summary>
        /// ステレオカメラの平行化変換を求める
        /// </summary>
        /// <param name="cameraMatrix1">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="cameraMatrix2">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="distCoeffs1">カメラ1の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="distCoeffs2">カメラ2の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="imageSize">ステレオカメラのキャリブレーションに用いられる画像サイズ． </param>
        /// <param name="R">1 番目と2 番目のカメラの座標系間の回転行列． </param>
        /// <param name="T">カメラ座標系間の並進ベクトル． </param>
        /// <param name="R1">1 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="R2">2 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="P1">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
        /// <param name="P2">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
        /// <param name="Q">視差と奥行きのマッピング行列，4x4．</param>
#else
        /// <summary>
        /// Computes rectification transform for stereo camera
        /// </summary>
        /// <param name="cameraMatrix1">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="cameraMatrix2">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="distCoeffs1">The vector of distortion coefficients for camera1, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="distCoeffs2">The vector of distortion coefficients for camera2, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="imageSize">Size of the image used for stereo calibration. </param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras' coordinate systems </param>
        /// <param name="T">The translation vector between the cameras' coordinate systems. </param>
        /// <param name="R1">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="R2">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="P1">3x4 Projection matrices in the new (rectified) coordinate systems </param>
        /// <param name="P2">3x4 Projection matrices in the new (rectified) coordinate systems </param>
        /// <param name="Q">The optional output disparity-to-depth mapping matrix, 4x4</param>
#endif
        public static void StereoRectify(CvMat cameraMatrix1, CvMat cameraMatrix2, CvMat distCoeffs1, CvMat distCoeffs2,
                             CvSize imageSize, CvMat R, CvMat T, CvMat R1, CvMat R2, CvMat P1, CvMat P2,
                             CvMat Q)
        {
            StereoRectify(cameraMatrix1, cameraMatrix2, distCoeffs1, distCoeffs2,
                imageSize, R, T, R1, R2, P1, P2, Q, StereoRectificationFlag.ZeroDisparity);
        }
#if LANG_JP
        /// <summary>
        /// ステレオカメラの平行化変換を求める
        /// </summary>
        /// <param name="cameraMatrix1">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="cameraMatrix2">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="distCoeffs1">カメラ1の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="distCoeffs2">カメラ2の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="imageSize">ステレオカメラのキャリブレーションに用いられる画像サイズ． </param>
        /// <param name="R">1 番目と2 番目のカメラの座標系間の回転行列． </param>
        /// <param name="T">カメラ座標系間の並進ベクトル． </param>
        /// <param name="R1">1 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="R2">2 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="P1">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
        /// <param name="P2">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
        /// <param name="Q">視差と奥行きのマッピング行列，4x4．</param>
        /// <param name="flags">オプションフラグ</param>
#else
        /// <summary>
        /// Computes rectification transform for stereo camera
        /// </summary>
        /// <param name="cameraMatrix1">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="cameraMatrix2">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="distCoeffs1">The vector of distortion coefficients for camera1, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="distCoeffs2">The vector of distortion coefficients for camera2, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="imageSize">Size of the image used for stereo calibration. </param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras' coordinate systems </param>
        /// <param name="T">The translation vector between the cameras' coordinate systems. </param>
        /// <param name="R1">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="R2">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="P1">3x4 Projection matrices in the new (rectified) coordinate systems </param>
        /// <param name="P2">3x4 Projection matrices in the new (rectified) coordinate systems </param>
        /// <param name="Q">The optional output disparity-to-depth mapping matrix, 4x4</param>
        /// <param name="flags">The operation flags</param>
#endif
        public static void StereoRectify(CvMat cameraMatrix1, CvMat cameraMatrix2, CvMat distCoeffs1, CvMat distCoeffs2,
                             CvSize imageSize, CvMat R, CvMat T, CvMat R1, CvMat R2, CvMat P1, CvMat P2,
                             CvMat Q, StereoRectificationFlag flags)
        {
            CvRect validPixROI1, validPixROI2;
            StereoRectify(cameraMatrix1, cameraMatrix2, distCoeffs1, distCoeffs2,
                imageSize, R, T, R1, R2, P1, P2, Q, flags, 
                -1, new CvSize(0, 0), out validPixROI1, out validPixROI2);
        }
#if LANG_JP
        /// <summary>
        /// ステレオカメラの平行化変換を求める
        /// </summary>
        /// <param name="cameraMatrix1">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="cameraMatrix2">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="distCoeffs1">カメラ1の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="distCoeffs2">カメラ2の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="imageSize">ステレオカメラのキャリブレーションに用いられる画像サイズ． </param>
        /// <param name="R">1 番目と2 番目のカメラの座標系間の回転行列． </param>
        /// <param name="T">カメラ座標系間の並進ベクトル． </param>
        /// <param name="R1">1 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="R2">2 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="P1">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
        /// <param name="P2">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
        /// <param name="Q">視差と奥行きのマッピング行列，4x4．</param>
        /// <param name="flags">オプションフラグ</param>
        /// <param name="alpha"></param>
#else
        /// <summary>
        /// Computes rectification transform for stereo camera
        /// </summary>
        /// <param name="cameraMatrix1">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="cameraMatrix2">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="distCoeffs1">The vector of distortion coefficients for camera1, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="distCoeffs2">The vector of distortion coefficients for camera2, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="imageSize">Size of the image used for stereo calibration. </param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras' coordinate systems </param>
        /// <param name="T">The translation vector between the cameras' coordinate systems. </param>
        /// <param name="R1">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="R2">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="P1">3x4 Projection matrices in the new (rectified) coordinate systems </param>
        /// <param name="P2">3x4 Projection matrices in the new (rectified) coordinate systems </param>
        /// <param name="Q">The optional output disparity-to-depth mapping matrix, 4x4</param>
        /// <param name="flags">The operation flags</param>
        /// <param name="alpha"></param>
#endif
        public static void StereoRectify(CvMat cameraMatrix1, CvMat cameraMatrix2, CvMat distCoeffs1, CvMat distCoeffs2,
                             CvSize imageSize, CvMat R, CvMat T, CvMat R1, CvMat R2, CvMat P1, CvMat P2,
                             CvMat Q, StereoRectificationFlag flags,
                             double alpha)
        {
            CvRect validPixROI1, validPixROI2;
            StereoRectify(cameraMatrix1, cameraMatrix2, distCoeffs1, distCoeffs2,
                imageSize, R, T, R1, R2, P1, P2, Q, flags,
                alpha, new CvSize(0,0), out validPixROI1, out validPixROI2);
        }
#if LANG_JP
        /// <summary>
        /// ステレオカメラの平行化変換を求める
        /// </summary>
        /// <param name="cameraMatrix1">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="cameraMatrix2">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="distCoeffs1">カメラ1の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="distCoeffs2">カメラ2の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="imageSize">ステレオカメラのキャリブレーションに用いられる画像サイズ． </param>
        /// <param name="R">1 番目と2 番目のカメラの座標系間の回転行列． </param>
        /// <param name="T">カメラ座標系間の並進ベクトル． </param>
        /// <param name="R1">1 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="R2">2 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="P1">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
        /// <param name="P2">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
        /// <param name="Q">視差と奥行きのマッピング行列，4x4．</param>
        /// <param name="flags">オプションフラグ</param>
        /// <param name="alpha"></param>
        /// <param name="newImageSize"></param>
#else
        /// <summary>
        /// Computes rectification transform for stereo camera
        /// </summary>
        /// <param name="cameraMatrix1">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="cameraMatrix2">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="distCoeffs1">The vector of distortion coefficients for camera1, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="distCoeffs2">The vector of distortion coefficients for camera2, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="imageSize">Size of the image used for stereo calibration. </param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras' coordinate systems </param>
        /// <param name="T">The translation vector between the cameras' coordinate systems. </param>
        /// <param name="R1">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="R2">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="P1">3x4 Projection matrices in the new (rectified) coordinate systems </param>
        /// <param name="P2">3x4 Projection matrices in the new (rectified) coordinate systems </param>
        /// <param name="Q">The optional output disparity-to-depth mapping matrix, 4x4</param>
        /// <param name="flags">The operation flags</param>
        /// <param name="alpha"></param>
        /// <param name="newImageSize"></param>
#endif
        public static void StereoRectify(CvMat cameraMatrix1, CvMat cameraMatrix2, CvMat distCoeffs1, CvMat distCoeffs2,
                             CvSize imageSize, CvMat R, CvMat T, CvMat R1, CvMat R2, CvMat P1, CvMat P2,
                             CvMat Q, StereoRectificationFlag flags, 
                             double alpha, CvSize newImageSize)
        {
            CvRect validPixROI1, validPixROI2;
            StereoRectify(cameraMatrix1, cameraMatrix2, distCoeffs1, distCoeffs2,
                imageSize, R, T, R1, R2, P1, P2, Q, flags, 
                alpha, newImageSize, out validPixROI1, out validPixROI2);
        }

#if LANG_JP
        /// <summary>
        /// ステレオカメラの平行化変換を求める
        /// </summary>
        /// <param name="cameraMatrix1">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="cameraMatrix2">カメラ行列 [fxk 0 cxk; 0 fyk  cyk; 0 0 1]．</param>
        /// <param name="distCoeffs1">カメラ1の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="distCoeffs2">カメラ2の歪み係数ベクトル．4x1，1x4，5x1，1x5．</param>
        /// <param name="imageSize">ステレオカメラのキャリブレーションに用いられる画像サイズ． </param>
        /// <param name="R">1 番目と2 番目のカメラの座標系間の回転行列． </param>
        /// <param name="T">カメラ座標系間の並進ベクトル． </param>
        /// <param name="R1">1 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="R2">2 番目のカメラに対する 3x3 平行化変換（回転行列）．</param>
        /// <param name="P1">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
        /// <param name="P2">新しい（平行化された）座標系に対する 3x4 の投影行列． </param>
        /// <param name="Q">視差と奥行きのマッピング行列，4x4．</param>
        /// <param name="flags">オプションフラグ</param>
        /// <param name="alpha"></param>
        /// <param name="newImageSize"></param>
        /// <param name="validPixROI1"></param>
        /// <param name="validPixROI2"></param>
#else
        /// <summary>
        /// Computes rectification transform for stereo camera
        /// </summary>
        /// <param name="cameraMatrix1">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="cameraMatrix2">The camera matrix [fxk 0 cxk; 0 fyk cyk; 0 0 1]. </param>
        /// <param name="distCoeffs1">The vector of distortion coefficients for camera1, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="distCoeffs2">The vector of distortion coefficients for camera2, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="imageSize">Size of the image used for stereo calibration. </param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras' coordinate systems </param>
        /// <param name="T">The translation vector between the cameras' coordinate systems. </param>
        /// <param name="R1">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="R2">3x3 Rectification transforms (rotation matrices) for the first and the second cameras, respectively </param>
        /// <param name="P1">3x4 Projection matrices in the new (rectified) coordinate systems </param>
        /// <param name="P2">3x4 Projection matrices in the new (rectified) coordinate systems </param>
        /// <param name="Q">The optional output disparity-to-depth mapping matrix, 4x4</param>
        /// <param name="flags">The operation flags</param>
        /// <param name="alpha"></param>
        /// <param name="newImageSize"></param>
        /// <param name="validPixROI1"></param>
        /// <param name="validPixROI2"></param>
#endif
        public static void StereoRectify(CvMat cameraMatrix1, CvMat cameraMatrix2, CvMat distCoeffs1, CvMat distCoeffs2,
                             CvSize imageSize, CvMat R, CvMat T, CvMat R1, CvMat R2, CvMat P1, CvMat P2,
                             CvMat Q, StereoRectificationFlag flags, 
                             double alpha, CvSize newImageSize, out CvRect validPixROI1, out CvRect validPixROI2)
        {
            if (cameraMatrix1 == null)
                throw new ArgumentNullException("cameraMatrix1");
            if (cameraMatrix2 == null)
                throw new ArgumentNullException("cameraMatrix2");
            if (distCoeffs1 == null)
                throw new ArgumentNullException("distCoeffs1");
            if (distCoeffs2 == null)
                throw new ArgumentNullException("distCoeffs2");
            if (R == null)
                throw new ArgumentNullException("R");
            if (T == null)
                throw new ArgumentNullException("T");
            if (R1 == null)
                throw new ArgumentNullException("R1");
            if (R2 == null)
                throw new ArgumentNullException("R2");
            if (P1 == null)
                throw new ArgumentNullException("P1");
            if (P2 == null)
                throw new ArgumentNullException("P2");

            IntPtr Qptr = (Q == null) ? IntPtr.Zero : Q.CvPtr;
            CvInvoke.cvStereoRectify(cameraMatrix1.CvPtr, cameraMatrix2.CvPtr, distCoeffs1.CvPtr, distCoeffs2.CvPtr,
                imageSize, R.CvPtr, T.CvPtr, R1.CvPtr, R2.CvPtr, P1.CvPtr, P2.CvPtr, Qptr, flags, 
                alpha, newImageSize, out validPixROI1, out validPixROI2);
        }
        #endregion
        #region StereoRectifyUncalibrated
#if LANG_JP
        /// <summary>
        /// キャリブレーションされていないステレオカメラの平行化変換を求める
        /// </summary>
        /// <param name="points1">互いに対応する 2 次元点の二つの配列</param>
        /// <param name="points2">互いに対応する 2 次元点の二つの配列</param>
        /// <param name="F">基礎行列． points1 と points2 の点ペアを用いて， 関数 cvFindFundamentalMat  によって計算される．</param>
        /// <param name="imgSize">画像サイズ．</param>
        /// <param name="H1">1 番目の画像と 2 番目の画像に対する平行化ホモグラフィ行列．</param>
        /// <param name="H2">1 番目の画像と 2 番目の画像に対する平行化ホモグラフィ行列．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Computes rectification transform for uncalibrated stereo camera
        /// </summary>
        /// <param name="points1">The 2 arrays of corresponding 2D points. </param>
        /// <param name="points2">The 2 arrays of corresponding 2D points. </param>
        /// <param name="F">Fundamental matrix. It can be computed using the same set of point pairs points1 and points2  using cvFindFundamentalMat</param>
        /// <param name="imgSize">Size of the image. </param>
        /// <param name="H1">The rectification homography matrices for the first and for the second images. </param>
        /// <param name="H2">The rectification homography matrices for the first and for the second images. </param>
        /// <returns></returns>
#endif
        public static int StereoRectifyUncalibrated(CvMat points1, CvMat points2, CvMat F, CvSize imgSize, CvMat H1, CvMat H2)
        {
            return StereoRectifyUncalibrated(points1, points2, F, imgSize, H1, H2, 5);
        }
#if LANG_JP
        /// <summary>
        /// キャリブレーションされていないステレオカメラの平行化変換を求める
        /// </summary>
        /// <param name="points1">互いに対応する 2 次元点の二つの配列</param>
        /// <param name="points2">互いに対応する 2 次元点の二つの配列</param>
        /// <param name="F">基礎行列． points1 と points2 の点ペアを用いて， 関数 cvFindFundamentalMat  によって計算される．</param>
        /// <param name="imgSize">画像サイズ．</param>
        /// <param name="H1">1 番目の画像と 2 番目の画像に対する平行化ホモグラフィ行列．</param>
        /// <param name="H2">1 番目の画像と 2 番目の画像に対する平行化ホモグラフィ行列．</param>
        /// <param name="threshold">オプション：外れ値を排除するための閾値． このパラメータが 0 よりも大きい場合， エピポーラ幾何に充分に従わないすべての点ペア （つまり，fabs(points2[i]T*F*points1[i])&gt;threshold  となる点）が，ホモグラフィ行列を計算する前に棄却される． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Computes rectification transform for uncalibrated stereo camera
        /// </summary>
        /// <param name="points1">The 2 arrays of corresponding 2D points. </param>
        /// <param name="points2">The 2 arrays of corresponding 2D points. </param>
        /// <param name="F">Fundamental matrix. It can be computed using the same set of point pairs points1 and points2  using cvFindFundamentalMat</param>
        /// <param name="imgSize">Size of the image. </param>
        /// <param name="H1">The rectification homography matrices for the first and for the second images. </param>
        /// <param name="H2">The rectification homography matrices for the first and for the second images. </param>
        /// <param name="threshold">Optional threshold used to filter out the outliers. If the parameter is greater than zero, then all the point pairs that do not comply the epipolar geometry well enough (that is, the points for which fabs(points2[i]T*F*points1[i])&gt;threshold) are rejected prior to computing the homographies. </param>
        /// <returns></returns>
#endif
        public static int StereoRectifyUncalibrated(CvMat points1, CvMat points2, CvMat F, CvSize imgSize, CvMat H1, CvMat H2, double threshold)
        {
            if (points1 == null)
                throw new ArgumentNullException("points1");
            if (points2 == null)
                throw new ArgumentNullException("points2");
            if (F == null)
                throw new ArgumentNullException("F");
            if (H1 == null)
                throw new ArgumentNullException("H1");
            if (H2 == null)
                throw new ArgumentNullException("H2");
            return CvInvoke.cvStereoRectifyUncalibrated(points1.CvPtr, points2.CvPtr, F.CvPtr, imgSize, H1.CvPtr, H2.CvPtr, threshold);
        }
        #endregion
        #region Sub
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの減算を行う. 
        /// dst(I)=src1(I)-src2(I) 
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes per-element difference between two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void Sub(CvArr src1, CvArr src2, CvArr dst)
        {
            Sub(src1, src2, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの減算を行う.
        /// dst(I)=src1(I)-src2(I) [mask(I)!=0 の場合]
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）． </param>
#else
        /// <summary>
        /// Computes per-element difference between two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void Sub(CvArr src1, CvArr src2, CvArr dst, CvArr mask)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvSub(src1.CvPtr, src2.CvPtr, dst.CvPtr, maskPtr);
        }
        #endregion
        #region SubS
#if LANG_JP
        /// <summary>
        /// 配列要素からスカラーを減算する.
        /// dst(I) = src(I)-value 
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes difference between array and scalar
        /// </summary>
        /// <param name="src">The source array. </param>
        /// <param name="value">Subtracted scalar. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void SubS(CvArr src, CvScalar value, CvArr dst)
        {
            SubS(src, value, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列要素からスカラーを減算する.
        /// dst(I) = src(I)-value [mask(I)!=0]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Computes difference between array and scalar
        /// </summary>
        /// <param name="src">The source array. </param>
        /// <param name="value">Subtracted scalar. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void SubS(CvArr src, CvScalar value, CvArr dst, CvArr mask)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvAddS(src.CvPtr, new CvScalar(-value.Val0, -value.Val1, -value.Val2, -value.Val3), dst.CvPtr, maskPtr);
        }
        #endregion
        #region SubRS
#if LANG_JP
        /// <summary>
        /// スカラーから配列要素を減算する.
        /// dst(I)=value-src(I)
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes difference between scalar and array
        /// </summary>
        /// <param name="src">The first source array. </param>
        /// <param name="value">Scalar to subtract from. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void SubRS(CvArr src, CvScalar value, CvArr dst)
        {
            SubRS(src, value, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// スカラーから配列要素を減算する.
        /// dst(I)=value-src(I) [mask(I)!=0 の場合]
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Computes difference between scalar and array
        /// </summary>
        /// <param name="src">The first source array. </param>
        /// <param name="value">Scalar to subtract from. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void SubRS(CvArr src, CvScalar value, CvArr dst, CvArr mask)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvSubRS(src.CvPtr, value, dst.CvPtr, maskPtr);
        }
        #endregion
        #region Sum
#if LANG_JP
        /// <summary>
        /// 配列要素の総和を計算する.
        /// 配列のタイプが IplImage で COI がセットされている場合，指定されたチャンネルのみを処理し，総和を１番目のスカラー値（S0）として保存する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Summarizes array elements
        /// </summary>
        /// <param name="arr">The array. </param>
        /// <returns>sum S of array elements, independently for each channel</returns>
#endif
        public static CvScalar Sum(CvArr arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            return CvInvoke.cvSum(arr.CvPtr);
        }
        #endregion
        #region Subdiv2DEdgeDst
#if LANG_JP
        /// <summary>
        /// 辺の終点を返す． 
        /// 仮想点は関数 cvCalcSubdivVoronoi2D を用いて計算される.
        /// </summary>
        /// <param name="edge">細分割平面の辺の一つ（quad-edge表現ではない）</param>
        /// <returns>辺の終点. 辺が双対細分割のものであり，仮想点の座標がまだ計算されていない場合は，nullを返す．</returns>
#else
        /// <summary>
        /// Returns edge destination.
        /// </summary>
        /// <param name="edge">Subdivision edge (not a quad-edge) </param>
        /// <returns>The edge destination. If the edge is from dual subdivision and the virtual point coordinates are not calculated yet, the returned pointer may be null.</returns>
#endif
        public static CvSubdiv2DPoint Subdiv2DEdgeDst(CvSubdiv2DEdge edge)
        {
            unsafe
            {
                ulong edgeValue = (ulong)edge;
                WCvQuadEdge2D* e = (WCvQuadEdge2D*)((long)edgeValue & ~3L);
                long value = (long)((edgeValue + 2) & 3);
                IntPtr p = e->pt(value);
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvSubdiv2DPoint(p);
            }
        }
        #endregion
        #region Subdiv2DEdgeOrg
#if LANG_JP
        /// <summary>
        /// 辺の始点を返す． 
        /// 仮想点は関数 cvCalcSubdivVoronoi2D を用いて計算される.
        /// </summary>
        /// <param name="edge">細分割平面の辺の一つ（quad-edge表現ではない）</param>
        /// <returns>辺の始点. 辺が双対細分割のものであり，仮想点の座標がまだ計算されていない場合は，nullを返す．</returns>
#else
        /// <summary>
        /// Returns edge origin.
        /// </summary>
        /// <param name="edge">Subdivision edge (not a quad-edge) </param>
        /// <returns>The edge origin. If the edge is from dual subdivision and the virtual point coordinates are not calculated yet, the returned pointer may be null.</returns>
#endif
        public static CvSubdiv2DPoint Subdiv2DEdgeOrg(CvSubdiv2DEdge edge)
        {
            unsafe
            {
                ulong edgeValue = (ulong)edge;
                WCvQuadEdge2D* e = (WCvQuadEdge2D*)((long)edgeValue & ~3L);
                long value = (long)(edgeValue & 3);
                IntPtr p = e->pt(value);
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvSubdiv2DPoint(p);
            }
        }
        #endregion
        #region Subdiv2DGetEdge
#if LANG_JP
        /// <summary>
        /// 入力された辺に関連する辺の一つを返す
        /// </summary>
        /// <param name="edge">細分割平面の辺の一つ（quad-edge表現ではない）</param>
        /// <param name="type">戻り値とする辺の条件</param>
        /// <returns>与えられた辺に関連する辺の一つ</returns>
#else
        /// <summary>
        /// Returns one of edges related to given.
        /// </summary>
        /// <param name="edge">Subdivision edge (not a quad-edge) </param>
        /// <param name="type">Specifies, which of related edges to return</param>
        /// <returns>one the edges related to the input edge</returns>
#endif
        public static CvSubdiv2DEdge Subdiv2DGetEdge(CvSubdiv2DEdge edge, CvNextEdgeType type)
        {
            unsafe
            {
                ulong edgeVal = (ulong)edge;
                WCvQuadEdge2D* e = (WCvQuadEdge2D*)((long)edgeVal & ~3L);
                edgeVal = (ulong)e->next(
                    ((long)edgeVal + (long)type) & 3
                ).ToInt64();
                return new CvSubdiv2DEdge(
                    (ulong)(((long)edgeVal & ~3L) + (((long)edgeVal + ((long)type >> 4)) & 3))
                );
            }
        }
        #endregion
        #region Subdiv2DLocate
#if LANG_JP
        /// <summary>
        /// ドロネー三角形に点を追加する
        /// </summary>
        /// <param name="subdiv">ドロネー，またはその他の細分割</param>
        /// <param name="pt">配置する点</param>
        /// <param name="edge">出力される辺．配置した点は，その辺上または端に存在する.</param>
        /// <returns>配置する点</returns>
#else
        /// <summary>
        /// Inserts a single point to Delaunay triangulation
        /// </summary>
        /// <param name="subdiv">Delaunay or another subdivision. </param>
        /// <param name="pt">The point to locate. </param>
        /// <param name="edge">The output edge the point falls onto or right to. </param>
        /// <returns></returns>
#endif
        public static CvSubdiv2DPointLocation Subdiv2DLocate(CvSubdiv2D subdiv, CvPoint2D32f pt, out CvSubdiv2DEdge edge)
        {
            if (subdiv == null)
            {
                throw new ArgumentNullException("subdiv");
            }
            CvSubdiv2DEdge e;
            IntPtr p = IntPtr.Zero;
            CvSubdiv2DPointLocation result = CvInvoke.cvSubdiv2DLocate(subdiv.CvPtr, pt, out e, ref p);            
            edge = e;
            return result;
        }
#if LANG_JP
        /// <summary>
        /// ドロネー三角形に点を追加する
        /// </summary>
        /// <param name="subdiv">ドロネー，またはその他の細分割</param>
        /// <param name="pt">配置する点</param>
        /// <param name="edge">出力される辺．配置した点は，その辺上または端に存在する.</param>
        /// <param name="vertex">オプション出力．入力点と一致する細分割の頂点へのポインタのポインタ</param>
        /// <returns>配置する点</returns>
#else
        /// <summary>
        /// Inserts a single point to Delaunay triangulation
        /// </summary>
        /// <param name="subdiv">Delaunay or another subdivision. </param>
        /// <param name="pt">The point to locate. </param>
        /// <param name="edge">The output edge the point falls onto or right to. </param>
        /// <param name="vertex">Optional output vertex double pointer the input point coinsides with. </param>
        /// <returns></returns>
#endif
        public static CvSubdiv2DPointLocation Subdiv2DLocate(CvSubdiv2D subdiv, CvPoint2D32f pt, out CvSubdiv2DEdge edge, ref CvSubdiv2DPoint vertex)
        {
            if (subdiv == null)
            {
                throw new ArgumentNullException("subdiv");
            }
            CvSubdiv2DEdge e;
            IntPtr p = vertex.CvPtr;
            CvSubdiv2DPointLocation result = CvInvoke.cvSubdiv2DLocate(subdiv.CvPtr, pt, out e, ref p);
            edge = e;
            if (p == IntPtr.Zero)
                vertex = null;
            else
                vertex = new CvSubdiv2DPoint(p);
            
            return result;
        }
        #endregion
        #region Subdiv2DNextEdge
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
#endif
        public static CvSubdiv2DEdge Subdiv2DNextEdge(CvSubdiv2DEdge edge)
        {
            return SUBDIV2D_NEXT_EDGE(edge);
        }
        #endregion
        #region Subdiv2DRotateEdge
#if LANG_JP
        /// <summary>
        /// 入力された辺を含むquad-edge中の辺の一つを返す．
        /// </summary>
        /// <param name="edge">細分割の辺（quad-edge表現ではない）</param>
        /// <param name="rotate">関係の指定（入力された辺と同じquad-edgeのどの辺を返すかを指定）</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns another edge of the same quad-edge
        /// </summary>
        /// <param name="edge">Subdivision edge (not a quad-edge) </param>
        /// <param name="rotate">Specifies, which of edges of the same quad-edge as the input one to return</param>
        /// <returns>one the edges of the same quad-edge as the input edge. </returns>
#endif
        public static CvSubdiv2DEdge Subdiv2DRotateEdge(CvSubdiv2DEdge edge, RotateEdgeFlag rotate)
        {
            long edgeVal = (long)(ulong)edge;
            return new CvSubdiv2DEdge(
                (ulong)((edgeVal & ~3L) + ((edgeVal + (long)rotate) & 3))
                );
        }
        #endregion
        #region Subdiv2DSymEdge
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
#endif
        public static CvSubdiv2DEdge Subdiv2DSymEdge(CvSubdiv2DEdge edge)
        {
            return new CvSubdiv2DEdge((ulong)edge ^ 2);
        }
        #endregion
        #region SubdivDelaunay2DInsert
#if LANG_JP
        /// <summary>
        /// ドロネー三角形に点を追加する
        /// </summary>
        /// <param name="subdiv">関数cvCreateSubdivDelaunay2D で作成されたドロネー細分割</param>
        /// <param name="pt">追加する点</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Inserts a single point to Delaunay triangulation
        /// </summary>
        /// <param name="subdiv">Delaunay subdivision created by function cvCreateSubdivDelaunay2D. </param>
        /// <param name="pt">Inserted point. </param>
        /// <returns></returns>
#endif
        public static CvSubdiv2DPoint SubdivDelaunay2DInsert(CvSubdiv2D subdiv, CvPoint2D32f pt)
        {
            if (subdiv == null)
            {
                throw new ArgumentNullException("subdiv");
            }
            IntPtr ptr = CvInvoke.cvSubdivDelaunay2DInsert(subdiv.CvPtr, pt);
            return new CvSubdiv2DPoint(ptr);
        }
        #endregion
        #region SubstituteContour
#if LANG_JP
        /// <summary>
        /// 抽出された輪郭を置き換える
        /// </summary>
        /// <param name="scanner">関数cvStartFindContoursで初期化された輪郭スキャナ</param>
        /// <param name="newContour">新しく置き換える輪郭</param>
#else
        /// <summary>
        /// Replaces retrieved contour
        /// </summary>
        /// <param name="scanner">Contour scanner initialized by the function cvStartFindContours . </param>
        /// <param name="newContour">Substituting contour. </param>
#endif
        public static void SubstituteContour(CvContourScanner scanner, CvSeq<CvPoint> newContour)
        {
            if (scanner == null)
                throw new ArgumentNullException("scanner");
            if (newContour == null)
                throw new ArgumentNullException("newContour");
            CvInvoke.cvSubstituteContour(scanner.CvPtr, newContour.CvPtr);
        }
        #endregion
        #region SURFParams
#if LANG_JP
        /// <summary>
        /// SURFのデフォルトパラメータを生成する
        /// </summary>
        /// <param name="hessianThreshold">keypoint.hessian の値がこの閾値よりも大きい特徴だけが検出される</param>
        /// <param name="extended">false：基本的なディスクリプタ（64要素）, true：拡張されたディスクリプタ（128要素）</param>
        /// <returns>デフォルトパラメータ</returns>
#else
        /// <summary>
        /// Creates SURF default parameters
        /// </summary>
        /// <param name="hessianThreshold">Only features with keypoint.hessian larger than that are extracted. </param>
        /// <param name="extended">false means basic descriptors (64 elements each), true means _extended descriptors (128 elements each) </param>
        /// <returns>default parameters</returns>
#endif
        public static CvSURFParams SURFParams(double hessianThreshold, bool extended)
        {
            return new CvSURFParams(hessianThreshold, extended);
        }
        #endregion
        #region SVBkSb
#if LANG_JP
        /// <summary>
        /// 特異値の後退代入を行う
        /// </summary>
        /// <param name="W">特異値の行列またはベクトル</param>
        /// <param name="U">左直交行列（転置されているかもしれない）</param>
        /// <param name="V">右直交行列（転置されているかもしれない）</param>
        /// <param name="B">行列Aの擬似逆行列に乗ずるための行列</param>
        /// <param name="X">出力行列．後退代入の結果．</param>
        /// <param name="flags">操作フラグ．cvSVDでのflagsと一致していなければならない．</param>
#else
        /// <summary>
        /// Performs singular value back substitution
        /// </summary>
        /// <param name="W">Matrix or vector of singular values. </param>
        /// <param name="U">Left orthogonal matrix (transposed, perhaps) </param>
        /// <param name="V">Right orthogonal matrix (transposed, perhaps) </param>
        /// <param name="B">The matrix to multiply the pseudo-inverse of the original matrix A by. This is the optional parameter. If it is omitted then it is assumed to be an identity matrix of an appropriate size (So X will be the reconstructed pseudo-inverse of A). </param>
        /// <param name="X">The destination matrix: result of back substitution. </param>
        /// <param name="flags">Operation flags, should match exactly to the flags passed to cvSVD. </param>
#endif
        public static void SVBkSb(CvArr W, CvArr U, CvArr V, CvArr B, CvArr X, SVDFlag flags)
        {
            if (W == null)
                throw new ArgumentNullException("W");
            if (U == null)
                throw new ArgumentNullException("U");
            if (V == null)
                throw new ArgumentNullException("V");
            if (B == null)
                throw new ArgumentNullException("B");
            if (X == null)
                throw new ArgumentNullException("X");
            CvInvoke.cvSVBkSb(W.CvPtr, U.CvPtr, V.CvPtr, B.CvPtr, X.CvPtr, flags);
        }
        #endregion
        #region SVD
#if LANG_JP
        /// <summary>
        /// 浮動小数点型の実数行列の特異値分解を行う.
        /// 行列Aを二つの直交行列と一つの対角行列の積に分解する．A=U*W*VT
        /// </summary>
        /// <param name="A">入力M×N行列</param>
        /// <param name="W">特異値行列の結果 (M×N または N×N)またはベクトル（N×1）．</param>
#else
        /// <summary>
        /// Performs singular value decomposition of real floating-point matrix
        /// </summary>
        /// <param name="A">Source M×N matrix. </param>
        /// <param name="W">Resulting singular value matrix (M×N or N×N) or vector (N×1). </param>
#endif
        public static void SVD(CvArr A, CvArr W)
        {
            SVD(A, W, null, null, SVDFlag.Zero);
        }
#if LANG_JP
        /// <summary>
        /// 浮動小数点型の実数行列の特異値分解を行う.
        /// 行列Aを二つの直交行列と一つの対角行列の積に分解する．A=U*W*VT
        /// </summary>
        /// <param name="A">入力M×N行列</param>
        /// <param name="W">特異値行列の結果 (M×N または N×N)またはベクトル（N×1）．</param>
        /// <param name="U">任意の左直交行列 (M×M または M×N)．もしCV_SVD_U_Tが指定された場合，上で述べた，行と列の数は入れ替わる．</param>
#else
        /// <summary>
        /// Performs singular value decomposition of real floating-point matrix
        /// </summary>
        /// <param name="A">Source M×N matrix. </param>
        /// <param name="W">Resulting singular value matrix (M×N or N×N) or vector (N×1). </param>
        /// <param name="U">Optional left orthogonal matrix (M×M or M×N). If CV_SVD_U_T is specified, the number of rows and columns in the sentence above should be swapped. </param>
#endif
        public static void SVD(CvArr A, CvArr W, CvArr U)
        {
            SVD(A, W, U, null, SVDFlag.Zero);
        }
#if LANG_JP
        /// <summary>
        /// 浮動小数点型の実数行列の特異値分解を行う.
        /// 行列Aを二つの直交行列と一つの対角行列の積に分解する．A=U*W*VT
        /// </summary>
        /// <param name="A">入力M×N行列</param>
        /// <param name="W">特異値行列の結果 (M×N または N×N)またはベクトル（N×1）．</param>
        /// <param name="U">任意の左直交行列 (M×M または M×N)．もしCV_SVD_U_Tが指定された場合，上で述べた，行と列の数は入れ替わる．</param>
        /// <param name="V">任意の右直交行列（N×N)．</param>
#else
        /// <summary>
        /// Performs singular value decomposition of real floating-point matrix
        /// </summary>
        /// <param name="A">Source M×N matrix. </param>
        /// <param name="W">Resulting singular value matrix (M×N or N×N) or vector (N×1). </param>
        /// <param name="U">Optional left orthogonal matrix (M×M or M×N). If CV_SVD_U_T is specified, the number of rows and columns in the sentence above should be swapped. </param>
        /// <param name="V">Optional right orthogonal matrix (N×N) </param>
#endif
        public static void SVD(CvArr A, CvArr W, CvArr U, CvArr V)
        {
            SVD(A, W, U, V, SVDFlag.Zero);
        }
#if LANG_JP
        /// <summary>
        /// 浮動小数点型の実数行列の特異値分解を行う.
        /// 行列Aを二つの直交行列と一つの対角行列の積に分解する．A=U*W*VT
        /// </summary>
        /// <param name="A">入力M×N行列</param>
        /// <param name="W">特異値行列の結果 (M×N または N×N)またはベクトル（N×1）．</param>
        /// <param name="U">任意の左直交行列 (M×M または M×N)．もしCV_SVD_U_Tが指定された場合，上で述べた，行と列の数は入れ替わる．</param>
        /// <param name="V">任意の右直交行列（N×N)．</param>
        /// <param name="flags">操作フラグ</param>
#else
        /// <summary>
        /// Performs singular value decomposition of real floating-point matrix
        /// </summary>
        /// <param name="A">Source M×N matrix. </param>
        /// <param name="W">Resulting singular value matrix (M×N or N×N) or vector (N×1). </param>
        /// <param name="U">Optional left orthogonal matrix (M×M or M×N). If CV_SVD_U_T is specified, the number of rows and columns in the sentence above should be swapped. </param>
        /// <param name="V">Optional right orthogonal matrix (N×N) </param>
        /// <param name="flags">Operation flags</param>
#endif
        public static void SVD(CvArr A, CvArr W, CvArr U, CvArr V, SVDFlag flags)
        {
            if (A == null)
                throw new ArgumentNullException("A");
            if (W == null)
                throw new ArgumentNullException("W");
            IntPtr UPtr = (U == null) ? IntPtr.Zero : U.CvPtr;
            IntPtr VPtr = (V == null) ? IntPtr.Zero : V.CvPtr;
            CvInvoke.cvSVD(A.CvPtr, W.CvPtr, UPtr, VPtr, flags);
        }
        #endregion
    }
}