using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Flann
{
#if LANG_JP
    /// <summary>
    /// ディスクにあらかじめ保存されたデータを読み出すために利用されます．
    /// </summary>
#else
    /// <summary>
    /// This object type is used for loading a previously saved index from the disk.
    /// </summary>
#endif
    public class SavedIndexParams : IndexParams
    {
        #region Properties
        /*
#if LANG_JP
        /// <summary>
        /// インデックスが保存されたファイル名
        /// </summary>
#else
        /// <summary>
        /// The filename in which the index was saved.
        /// </summary>
#endif
        public string FileName
        {
            get
            {
                unsafe
                {
                    return FlannInvoke.flann_SavedIndexParams_filename_get(ptr);
                }
            }
            set
            {
                unsafe
                {
                    FlannInvoke.flann_SavedIndexParams_filename_set(ptr, value);
                }
            }
        }
        //*/
        #endregion

        #region Init & Disposal
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename">インデックスが保存されたファイル名</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename">インデックスが保存されたファイル名</param>
#endif
        public SavedIndexParams(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException(nameof(filename));
            ptr = NativeMethods.flann_SavedIndexParams_new(filename);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create SavedIndexParams");
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.flann_SavedIndexParams_delete(ptr);
            base.DisposeUnmanaged();
        }

        #endregion
    }
}
