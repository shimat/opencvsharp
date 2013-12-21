using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 属性のリスト
    /// </summary>
#else
    /// <summary>
    /// List of attributes
    /// </summary>
#endif
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CvAttrList : IDisposable
    {
        #region Fields
        /// <summary>
        /// const char** attr;
        /// </summary>
        private sbyte** _attr;
        /// <summary>
        /// struct CvAttrList* next;
        /// </summary>
        private IntPtr _next;
        #endregion

        #region Properties
#if LANG_JP
        /// <summary>
        /// (attribute_name,attribute_value)のペアからなるNULLで終わる配列
        /// </summary>
#else
        /// <summary>
        /// NULL-terminated array of (attribute_name,attribute_value) pairs
        /// </summary>
#endif
        public string[] Attr
        {
            get 
            {
                if (_attr == null)
                {
                    return null;
                }
                else
                {
                    List<string> result = new List<string>();
                    for (int i = 0; _attr[i] != null; i++)
                    {
                        result.Add(new string(_attr[i]));
                    }
                    return result.ToArray();
                }
            }
            set
            {
                Dispose();

                if (value == null)
                {
                    _attr = null;
                }
                else
                {
                    unsafe
                    {
                        _attr = (sbyte**)Marshal.AllocHGlobal(sizeof(sbyte*) * value.Length + 1);
                        int i;
                        for (i = 0; i < value.Length; i++)
                        {
                            if (value[i] == null)
                            {
                                throw new ArgumentException();
                            }
                            _attr[i] = (sbyte*)Marshal.StringToHGlobalAnsi(value[i]);
                        }
                        // null-terminated array
                        _attr[i] = null;
                    }
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 属性リストの次の塊へのポインタ
        /// </summary>
#else
        /// <summary>
        /// pointer to next chunk of the attributes list
        /// </summary>
#endif
        public Pointer<CvAttrList> Next
        {
            get { return new Pointer<CvAttrList>(_next); }
            set { _next = value.Address; }
        }

        /// <summary>
        /// sizeof(CvAttrList)
        /// </summary>
        public static readonly int SizeOf = IntPtr.Size * 2;
        #endregion

        #region Constructors
#if LANG_JP
        /// <summary>
        /// 構造体CvAttrListの初期化
        /// </summary>
        /// <param name="attr">(attribute_name,attribute_value)のペアからなる配列</param>
#else
        /// <summary>
        /// initializes CvAttrList structure
        /// </summary>
        /// <param name="attr">array of (attribute_name,attribute_value) pairs</param>
#endif
        public CvAttrList(string[] attr)
            : this(attr, Pointer<CvAttrList>.Zero)
        {
        }
#if LANG_JP
        /// <summary>
        /// 構造体CvAttrListの初期化
        /// </summary>
        /// <param name="attr">(attribute_name,attribute_value)のペアからなる配列</param>
        /// <param name="next">属性リストの次の塊へのポインタ</param>
#else
        /// <summary>
        /// initializes CvAttrList structure
        /// </summary>
        /// <param name="attr">array of (attribute_name,attribute_value) pairs</param>
        /// <param name="next">pointer to next chunk of the attributes list</param>
#endif
        public CvAttrList(string[] attr, Pointer<CvAttrList> next)
            : this()
        {
            this.Attr = attr;
            this.Next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            unsafe
            {
                if (_attr != null)
                {
                    for (int i = 0; _attr[i] != null; i++)
                    {
                        Marshal.FreeHGlobal(new IntPtr(_attr[i]));
                    }
                    Marshal.FreeHGlobal(new IntPtr(_attr));
                    _attr = null;
                }
            }
        }
        #endregion
    }
}
