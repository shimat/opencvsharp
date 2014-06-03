using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 型情報
    /// </summary>
#else
    /// <summary>
    /// Type information
    /// </summary>
#endif
    public class CvTypeInfo : DisposableCvObject
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// メモリを確保して初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvTypeInfo()
        {
            this.ptr = base.AllocMemory(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// ネイティブのデータポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvTypeInfo*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvTypeInfo*</param>
#endif
        public CvTypeInfo(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvTypeInfo) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvTypeInfo));


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// not used
        /// </summary>
#endif
        public int Flags
        {
            get
            {
                unsafe
                {
                    return ((WCvTypeInfo*)ptr)->flags;
                }
            }
        }
		/* sizeof(CvTypeInfo) */
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// not used
        /// </summary>
#endif
		public int HeaderSize
		{
            get
            {
                unsafe
                {
                    return ((WCvTypeInfo*)ptr)->header_size;
                }
            }
		}	
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// previous registered type in the list
        /// </summary>
#endif
        public CvTypeInfo Prev
		{
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvTypeInfo*)ptr)->prev);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvTypeInfo(p);
            }
		}
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// next registered type in the list
        /// </summary>
#endif
        public CvTypeInfo Next
		{
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvTypeInfo*)ptr)->next);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvTypeInfo(p);
            }
		}	
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// type name, written to file storage
        /// </summary>
#endif
		public string TypeName
		{
            get
            {
                unsafe
                {
                    return new string(((WCvTypeInfo*)ptr)->type_name);
                }
            }
		}	


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// checks if the passed object belongs to the type
        /// </summary>
#endif
		public CvIsInstanceFunc IsInstance
		{
			get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvTypeInfo*)ptr)->is_instance);
                }
                return (CvIsInstanceFunc)Marshal.GetDelegateForFunctionPointer(p, typeof(CvIsInstanceFunc));
            }
		}	
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// releases object (memory etc.)
        /// </summary>
#endif
        public CvReleaseFunc Release
		{
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvTypeInfo*)ptr)->release);
                }
                return (CvReleaseFunc)Marshal.GetDelegateForFunctionPointer(p, typeof(CvReleaseFunc));
            }
		}	
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// reads object from file storage
        /// </summary>
#endif
		public CvReadFunc Read
		{
            get 
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvTypeInfo*)ptr)->read);
                }
                return (CvReadFunc)Marshal.GetDelegateForFunctionPointer(p, typeof(CvReadFunc)); 
            }
		}	
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// writes object to file storage
        /// </summary>
#endif
		public CvWriteFunc Write
		{
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvTypeInfo*)ptr)->write);
                }
                return (CvWriteFunc)Marshal.GetDelegateForFunctionPointer(p, typeof(CvWriteFunc));
            }
		}	
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// creates a copy of the object
        /// </summary>
#endif
		public CvCloneFunc Clone
		{
			get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvTypeInfo*)ptr)->clone);
                }
                return (CvCloneFunc)Marshal.GetDelegateForFunctionPointer(p, typeof(CvCloneFunc));
            }
		}
        #endregion

        #region Methods
        #region RegisterType
#if LANG_JP
        /// <summary>
        /// 新しい型を登録する
        /// </summary>
#else
        /// <summary>
        /// Registers new type
        /// </summary>
#endif
        public void RegisterType()
        {
            Cv.RegisterType(this);
        }
        #endregion
        #endregion
    }
}
