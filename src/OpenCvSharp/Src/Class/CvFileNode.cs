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
#if LANG_JP
    /// <summary>
    /// ファイルストレージノード
    /// </summary>
#else
    /// <summary>
    /// Basic element of the file storage - scalar or collection
    /// </summary>
#endif
    public class CvFileNode : CvObject
    {
        #region Constructors
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvFileNode*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvFileNode*</param>
#endif
        public CvFileNode(IntPtr ptr)
        {
            this._ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvFileNode*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvFileNode*</param>
#endif
        public static CvFileNode FromPtr(IntPtr ptr)
        {
            return new CvFileNode(ptr);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvFileNode) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvFileNode));

#if LANG_JP
        /// <summary>
        /// ファイルノードの型
        /// </summary>
#else
        /// <summary>
        /// Type of file node
        /// </summary>
#endif
        public NodeType Tag
        {
            get
            {
                unsafe
                {
                    return (NodeType)((WCvFileNode*)_ptr)->tag;
                }
            }
        }

        /// <summary>
        /// Dataの先頭8バイトを返す
        /// </summary>
        internal long DataHead
        {
            get
            {
                unsafe
                {
                    CvString s = ((WCvFileNode*)_ptr)->data;
                    byte[] b1 = BitConverter.GetBytes(s.Len);
                    byte[] b2;
                    if (IntPtr.Size == 4)
                        b2 = BitConverter.GetBytes(s.Ptr.ToInt32());
                    else
                        b2 = BitConverter.GetBytes(s.Ptr.ToInt64());
                    byte[] b3 = new byte[8];
                    for (int i = 0; i < 4; i++)
                    {
                        b3[i] = b1[i];
                        b3[i + 4] = b2[i];
                    }
                    return BitConverter.ToInt64(b3, 0);
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 浮動小数点のスカラー値
        /// CvFileNode->data->f
        /// </summary>
#else
        /// <summary>
        /// scalar floating-point number
        /// </summary>
#endif
        public double DataF
        {
            get
            {
                unsafe
                {
                    // CvStringはx86で8バイト、x64で12バイト。
                    // doubleの分の8バイトを抽出する。                    
                    return BitConverter.Int64BitsToDouble(DataHead);
                    //return ((WCvFileNode*)_ptr)->data_f;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 整数のスカラー値
        /// CvFileNode->data->i
        /// </summary>
#else
        /// <summary>
        /// scalar integer number
        /// </summary>
#endif
        public int DataI
        {
            get
            {
                unsafe
                {
                    CvString s = ((WCvFileNode*)_ptr)->data;
                    return s.Len;
                    //return ((WCvFileNode*)_ptr)->data_i;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 文字列
        /// CvFileNode->data->str
        /// </summary>
#else
        /// <summary>
        /// text string
        /// </summary>
#endif
        public CvString DataStr
        {
            get
            {
                unsafe
                {
                    return ((WCvFileNode*)_ptr)->data;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// シーケンス（整列されたファイルノードのコレクション）
        /// CvFileNode->data->seq
        /// </summary>
#else
        /// <summary>
        /// sequence (ordered collection of file nodes)
        /// </summary>
#endif
        public CvSeq DataSeq
        {
            get
            {
                unsafe
                {
                    //seq = new IntPtr(((WCvFileNode*)_ptr)->data_seq);
                    IntPtr seq = new IntPtr(DataHead);
                    if (seq == IntPtr.Zero)
                        return null;
                    else
                        return new CvSeq(seq);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// マップ（名前付けされたファイルノードのコレクション）
        /// CvFileNode->data->map
        /// </summary>
#else
        /// <summary>
        /// map (collection of named file nodes)
        /// </summary>
#endif
        public IntPtr DataMap
        {
            get
            {
                unsafe
                {
                    IntPtr seq = new IntPtr(DataHead);
                    return new IntPtr(DataHead);
                    //return new IntPtr(((WCvFileNode*)_ptr)->data_map);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードの名前
        /// </summary>
#else
        /// <summary>
        /// File node name
        /// </summary>
#endif
        public string Name
        {
            get { return Cv.GetFileNodeName(this); }
        }
        #endregion

        #region Methods
        #region GetFileNodeName
#if LANG_JP
        /// <summary>
        /// ファイルノードの名前を返す．ファイルノードが名前を持たないか，nodeがnullの場合にはnullを返す．
        /// </summary>
        /// <returns>ファイルノードの名前</returns>
#else
        /// <summary>
        /// Returns name of file node
        /// </summary>
        /// <returns>name of the file node or null</returns>
#endif
        public string GetFileNodeName()
        {
            return Cv.GetFileNodeName(this);
        }
        #endregion
        #region ReadInt
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された整数値を返す．
        /// </summary>
        /// <returns>ファイルノードで表現された整数値</returns>
#else
        /// <summary>
        /// Retrieves integer value from file node
        /// </summary>
        /// <returns>integer that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public int ReadInt()
        {
            return Cv.ReadInt(this);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された整数値を返す．
        /// </summary>
        /// <param name="default_value">nodeがnullの場合の戻り値</param>
        /// <returns>ファイルノードで表現された整数値</returns>
#else
        /// <summary>
        /// Retrieves integer value from file node
        /// </summary>
        /// <param name="default_value">The value that is returned if node is null. </param>
        /// <returns>integer that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public int ReadInt(int default_value)
        {
            return Cv.ReadInt(this, default_value);
        }
        #endregion        
        
        #region ReadReal
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された浮動小数点型の値を返す．
        /// </summary>
        /// <returns>ファイルノードで表現された浮動小数点型の値</returns>
#else
        /// <summary>
        /// Retrieves floating-point value from file node
        /// </summary>
        /// <returns>returns floating-point value that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public double ReadReal()
        {
            return Cv.ReadReal(this);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された浮動小数点型の値を返す．
        /// </summary>
        /// <param name="default_value">nodeがnullの場合の戻り値</param>
        /// <returns>ファイルノードで表現された浮動小数点型の値</returns>
#else
        /// <summary>
        /// Retrieves floating-point value from file node
        /// </summary>
        /// <param name="default_value">The value that is returned if node is null. </param>
        /// <returns>returns floating-point value that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public double ReadReal(double default_value)
        {
            return Cv.ReadReal(this, default_value);
        }
        #endregion
        #region ReadString
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された文字列を返す．
        /// </summary>
        /// <returns>ファイルノードで表現された文字列</returns>
#else
        /// <summary>
        /// Retrieves text string from file node
        /// </summary>
        /// <returns>returns text string that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public string ReadString()
        {
            return Cv.ReadString(this);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された文字列を返す．
        /// </summary>
        /// <param name="default_value">nodeがnullの場合の戻り値</param>
        /// <returns>ファイルノードで表現された文字列</returns>
#else
        /// <summary>
        /// Retrieves text string from file node
        /// </summary>
        /// <param name="default_value">The value that is returned if node is null. </param>
        /// <returns>returns text string that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public string ReadString(string default_value)
        {
            return Cv.ReadString(this, default_value);
        }
        #endregion
        #endregion
    }
}
