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
        #region WaitKey
#if JANG_JP
        /// <summary>
        /// 何かキーが押されるまで待機する．
        /// </summary>
        /// <returns>押されたキーのキーコード</returns>
#else
        /// <summary>
        /// Waits for key event infinitely (delay&lt;=0) or for "delay" milliseconds. 
        /// Returns the code of the pressed key or -1 if no key were pressed until the specified timeout has elapsed. 
        /// </summary>
        /// <returns>key code</returns>
#endif
        public static int WaitKey()
        {
            return CvInvoke.cvWaitKey(0);
        }
#if JANG_JP
        /// <summary>
        /// 何かキーが押されるか、若しくはdelayで指定した時間(ミリ秒)待機する。
        /// </summary>
        /// <param name="delay">遅延時間（ミリ秒）</param>
        /// <returns>キーが押された場合はそのキーコードを，キーが押されないまま指定されたタイムアウト時間が過ぎてしまった場合は -1</returns>
#else
        /// <summary>
        /// Waits for key event infinitely (delay&lt;=0) or for "delay" milliseconds. 
        /// Returns the code of the pressed key or -1 if no key were pressed until the specified timeout has elapsed. 
        /// </summary>
        /// <param name="delay">Delay in milliseconds. </param>
        /// <returns>key code</returns>
#endif
        public static int WaitKey(int delay)
        {
            return CvInvoke.cvWaitKey(delay);
        }
        #endregion
        #region WarpAffine
#if LANG_JP
        /// <summary>
        /// 画像のアフィン変換を行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="mapMatrix">2×3 変換行列</param>
#else
        /// <summary>
        /// Applies affine transformation to the image.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapMatrix">2x3 transformation matrix. </param>
#endif
        public static void WarpAffine(CvArr src, CvArr dst, CvMat mapMatrix)
        {
            WarpAffine(src, dst, mapMatrix, Interpolation.Linear | Interpolation.FillOutliers, CvScalar.ScalarAll(0));
        }
#if LANG_JP
        /// <summary>
        /// 画像のアフィン変換を行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="mapMatrix">2×3 変換行列</param>
        /// <param name="flags">補間方法</param>
#else
        /// <summary>
        /// Applies affine transformation to the image.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapMatrix">2x3 transformation matrix. </param>
        /// <param name="flags">A combination of interpolation method and the optional flags.</param>
#endif
        public static void WarpAffine(CvArr src, CvArr dst, CvMat mapMatrix, Interpolation flags)
        {
            WarpAffine(src, dst, mapMatrix, flags, CvScalar.ScalarAll(0));
        }
#if LANG_JP
        /// <summary>
        /// 画像のアフィン変換を行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="mapMatrix">2×3 変換行列</param>
        /// <param name="flags">補間方法</param>
        /// <param name="fillval">対応の取れない点に対して与える値</param>
#else
        /// <summary>
        /// Applies affine transformation to the image.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapMatrix">2x3 transformation matrix. </param>
        /// <param name="flags">A combination of interpolation method and the optional flags.</param>
        /// <param name="fillval">A value used to fill outliers. </param>
#endif
        public static void WarpAffine(CvArr src, CvArr dst, CvMat mapMatrix, Interpolation flags, CvScalar fillval)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (mapMatrix == null)
                throw new ArgumentNullException("mapMatrix");
            CvInvoke.cvWarpAffine(src.CvPtr, dst.CvPtr, mapMatrix.CvPtr, flags, fillval);
        }
        #endregion
        #region WarpPerspective
#if LANG_JP
        /// <summary>
        /// 画像の透視変換を行う.
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="mapMatrix">3×3 の変換行列</param>
#else
        /// <summary>
        /// Applies perspective transformation to the image.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapMatrix">3x3 transformation matrix. </param>
#endif
        public static void WarpPerspective(CvArr src, CvArr dst, CvMat mapMatrix)
        {
            WarpPerspective(src, dst, mapMatrix, Interpolation.Linear | Interpolation.FillOutliers);
        }
#if LANG_JP
        /// <summary>
        /// 画像の透視変換を行う.
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="mapMatrix">3×3 の変換行列</param>
        /// <param name="flags">補間方法</param>
#else
        /// <summary>
        /// Applies perspective transformation to the image.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapMatrix">3x3 transformation matrix. </param>
        /// <param name="flags">A combination of interpolation method and the optional flags.</param>
#endif
        public static void WarpPerspective(CvArr src, CvArr dst, CvMat mapMatrix, Interpolation flags)
        {
            WarpPerspective(src, dst, mapMatrix, flags, CvScalar.ScalarAll(0));
        }
#if LANG_JP
        /// <summary>
        /// 画像の透視変換を行う.
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="mapMatrix">3×3 の変換行列</param>
        /// <param name="flags">補間方法</param>
        /// <param name="fillval">対応の取れない点に対して与える値</param>
#else
        /// <summary>
        /// Applies perspective transformation to the image.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapMatrix">3x3 transformation matrix. </param>
        /// <param name="flags">A combination of interpolation method and the optional flags.</param>
        /// <param name="fillval">A value used to fill outliers. </param>
#endif
        public static void WarpPerspective(CvArr src, CvArr dst, CvMat mapMatrix, Interpolation flags, CvScalar fillval)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (mapMatrix == null)
                throw new ArgumentNullException("mapMatrix");
            CvInvoke.cvWarpPerspective(src.CvPtr, dst.CvPtr, mapMatrix.CvPtr, flags, fillval);
        }
        #endregion
        #region Watershed
#if LANG_JP
        /// <summary>
        /// watershedアルゴリズムによる画像のセグメント化を行う.
        /// 画像をこの関数に渡す前に，ユーザーは大まかに画像markers中の処理対象領域を，正（>0）のインデックスを用いて区切っておかなければならない．
        /// </summary>
        /// <param name="image">入力画像．8ビット，3チャンネル画像.</param>
        /// <param name="markers">入出力画像．32ビットシングルチャンネルのマーカー画像（マップ）.</param>
#else
        /// <summary>
        /// Does watershed segmentation.
        /// </summary>
        /// <param name="image">The input 8-bit 3-channel image. </param>
        /// <param name="markers">The input/output 32-bit single-channel image (map) of markers. </param>
#endif
        public static void Watershed(CvArr image, CvArr markers)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (markers == null)
                throw new ArgumentNullException("markers");
            CvInvoke.cvWatershed(image.CvPtr, markers.CvPtr);
        }
        #endregion
        #region Write
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルストレージに書き込む.
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="name">書き込まれるオブジェクトの名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="ptr">オブジェクトへの参照</param>
#else
        /// <summary>
        /// Writes user object
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="name">Name, of the written object. Should be null if and only if the parent structure is a sequence. </param>
        /// <param name="ptr">Pointer to the object. </param>
#endif
        public static void Write(CvFileStorage fs, string name, CvArr ptr)
        {
            Write(fs, name, ptr, new CvAttrList());
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルストレージに書き込む.
        /// </summary>
        /// <param name="fs">ファイルストレージ.</param>
        /// <param name="name">書き込まれるオブジェクトの名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="ptr">オブジェクトへの参照.</param>
        /// <param name="attributes">オブジェクトの属性．これは特定の型に対して固有である.</param>
#else
        /// <summary>
        /// Writes user object
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="name">Name, of the written object. Should be null if and only if the parent structure is a sequence. </param>
        /// <param name="ptr">Pointer to the object. </param>
        /// <param name="attributes">The attributes of the object. They are specific for each particular type.</param>
#endif
        public static void Write(CvFileStorage fs, string name, CvArr ptr, CvAttrList attributes)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (ptr == null)
                throw new ArgumentNullException("ptr");
            CvInvoke.cvWrite(fs.CvPtr, name, ptr.CvPtr, attributes);
        }
        #endregion
        #region WriteComment
#if LANG_JP
        /// <summary>
        /// ファイルストレージにコメントを書き込む (eol_comment = false)．
        /// このコメントはデバッグや説明を記述するために使われるもので，読み込み時には読み飛ばされる．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="comment">一行または複数行の，書き込まれるコメ文字列</param>
#else
        /// <summary>
        /// Writes comment
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="comment">The written comment, single-line or multi-line. </param>
#endif
        public static void WriteComment(CvFileStorage fs, string comment)
        {
            WriteComment(fs, comment, false);
        }
#if LANG_JP
        /// <summary>
        /// ファイルストレージにコメントを書き込む．
        /// このコメントはデバッグや説明を記述するために使われるもので，読み込み時には読み飛ばされる．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="comment">一行または複数行の，書き込まれるコメ文字列</param>
        /// <param name="eolComment">trueの場合，この関数は現在の行の最後にコメントを入れようと試みる．
        /// falseで，コメントが複数，または現在の行の最後に納まらない場合は，コメントは新しい行から始められる．</param>
#else
        /// <summary>
        /// Writes comment
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="comment">The written comment, single-line or multi-line. </param>
        /// <param name="eolComment">If true, the function tries to put the comment in the end of current line. 
        /// If the flag is false, if the comment is multi-line, or if it does not fit in the end of the current line, the comment starts from a new line. </param>
#endif
        public static void WriteComment(CvFileStorage fs, string comment, bool eolComment)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (comment == null)
                throw new ArgumentNullException("comment");
            CvInvoke.cvWriteComment(fs.CvPtr, comment, eolComment);
        }
        #endregion
        #region WriteFileNode
#if LANG_JP
        /// <summary>
        /// ファイルノードを他のファイルストレージに書き込む
        /// </summary>
        /// <param name="fs">書き込み先のファイルストレージ．</param>
        /// <param name="newNodeName">書き込み先ファイルストレージ内のファイルノードの新しい名前．元の名前を維持するためには，cvGetFileNodeName(node)を用いる．</param>
        /// <param name="node">書き込まれるノード．</param>
        /// <param name="embed">書き込まれるノードがコレクションで，このパラメータがtrueの場合，階層の余分なレベルは生成されない．
        /// その代わりに，nodeの全ての要素は現在書き込まれている構造体に書き込まれる．
        /// 当然，マップ要素はマップにのみ書き込まれ，シーケンス要素はシーケンスにのみ書き込まれる．</param>
#else
        /// <summary>
        /// Writes file node to another file storage
        /// </summary>
        /// <param name="fs">Destination file storage. </param>
        /// <param name="newNodeName">New name of the file node in the destination file storage. To keep the existing name, use cvGetFileNodeName(node). </param>
        /// <param name="node">The written node </param>
        /// <param name="embed">If the written node is a collection and this parameter is true, no extra level of hierarchy is created. 
        /// Instead, all the elements of node are written into the currently written structure. 
        /// Of course, map elements may be written only to map, and sequence elements may be written only to sequence. </param>
#endif
        public static void WriteFileNode(CvFileStorage fs, string newNodeName, CvFileNode node, bool embed)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (string.IsNullOrEmpty(newNodeName))
                throw new ArgumentNullException("newNodeName");
            if (node == null)
                throw new ArgumentNullException("node");

            CvInvoke.cvWriteFileNode(fs.CvPtr, newNodeName, node.CvPtr, embed);
        }
        #endregion
        #region WriteFrame
#if LANG_JP
        /// <summary>
        /// 一つのフレームをビデオファイルに書き込む/追加する
        /// </summary>
        /// <param name="writer">ビデオライタクラス</param>
        /// <param name="image">書き込まれるフレーム</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Writes/appends one frame to video file. 
        /// </summary>
        /// <param name="writer">video writer structure. </param>
        /// <param name="image">the written frame.</param>
        /// <returns></returns>
#endif
        public static int WriteFrame(CvVideoWriter writer, IplImage image)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            if (image == null)
                throw new ArgumentNullException("image");
            return CvInvoke.cvWriteFrame(writer.CvPtr, image.CvPtr);
        }
        #endregion
        #region WriteInt
#if LANG_JP
        /// <summary>
        /// 1つの整数値（名前あり，または無し）をファイルに書き込む.
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="name">書き込まれる文字列の名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="value">書き込まれる値</param>
#else
        /// <summary>
        /// Writes an integer value
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="name">Name of the written value. Should be NULL if and only if the parent structure is a sequence. </param>
        /// <param name="value">The written value. </param>
#endif
        public static void WriteInt(CvFileStorage fs, string name, int value)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (name == null)
                throw new ArgumentNullException("name");
            CvInvoke.cvWriteInt(fs.CvPtr, name, value);
        }
        #endregion
        #region WriteRawData
#if LANG_JP
        /// <summary>
        /// 複数の数値を書き込む
        /// </summary>
        /// <typeparam name="T">srcの要素の型</typeparam>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="src">書き込む配列</param>
        /// <param name="dt">フォーマット</param>
#else
        /// <summary>
        /// Writes multiple numbers
        /// </summary>
        /// <typeparam name="T">Type of the elements in src</typeparam>
        /// <param name="fs">File storage. </param>
        /// <param name="src">Written array </param>
        /// <param name="dt">Format</param>
#endif
        public static void WriteRawData<T>(CvFileStorage fs, T[] src, string dt) where T : struct
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (src == null)
                throw new ArgumentNullException("src");
            if (string.IsNullOrEmpty(dt))
                throw new ArgumentNullException("dt");

            using (var srcPtr = new ArrayAddress1<T>(src))
            {
                CvInvoke.cvWriteRawData(fs.CvPtr, srcPtr.Pointer, src.Length, dt);
            }
        }
        #endregion
        #region WriteReal
#if LANG_JP
        /// <summary>
        /// 単精度浮動小数点型の値（名前あり，または無し）をファイルに書き込む．
        /// 特別な値はエンコードされる：Not A NumberはNaN に，±Infinityは +.Inf (-.Inf) になる．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="name">書き込まれる文字列の名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="value">書き込まれる値</param>
#else
        /// <summary>
        /// Writes a floating-point value
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="name">Name of the written value. Should be null if and only if the parent structure is a sequence. </param>
        /// <param name="value">The written value. </param>
#endif
        public static void WriteReal(CvFileStorage fs, string name, double value)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (name == null)
                throw new ArgumentNullException("name");
            CvInvoke.cvWriteReal(fs.CvPtr, name, value);
        }
        #endregion
        #region WriteString
#if LANG_JP
        /// <summary>
        /// 文字列をファイルストレージに書き込む.
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="name">書き込まれる文字列の名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="str">書き込まれる文字列</param>
#else
        /// <summary>
        /// Writes a text string
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="name">Name of the written string. Should be null if and only if the parent structure is a sequence. </param>
        /// <param name="str">The written text string. </param>
#endif
        public static void WriteString(CvFileStorage fs, string name, string str)
        {
            WriteString(fs, name, str, false);
        }
#if LANG_JP
        /// <summary>
        /// 文字列をファイルストレージに書き込む.
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="name">書き込まれる文字列の名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="str">書き込まれる文字列</param>
        /// <param name="quote">trueの場合，書き込まれる文字列は必要かどうかに関わらず引用符で挟まれる．
        /// falseの場合，必要な場合にのみ引用符が使われる（例えば，文字列が数字で始まっていたり，スペースを含む場合）．</param>
#else
        /// <summary>
        /// Writes a text string
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="name">Name of the written string. Should be null if and only if the parent structure is a sequence. </param>
        /// <param name="str">The written text string. </param>
        /// <param name="quote">If true, the written string is put in quotes, regardless of whether they are required or not. 
        /// Otherwise, if the flag is false, quotes are used only when they are required (e.g. when the string starts with a digit or contains spaces). </param>
#endif
        public static void WriteString(CvFileStorage fs, string name, string str, bool quote)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (str == null)
                throw new ArgumentNullException("str");
            CvInvoke.cvWriteString(fs.CvPtr, name, str, quote);
        }
        #endregion
    }
}