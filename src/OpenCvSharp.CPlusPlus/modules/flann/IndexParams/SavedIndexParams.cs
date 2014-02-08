using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Flann
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
        #region Field
        /// <summary>
        /// sizeof(cv::flann::SavedIndexParams)
        /// </summary>
        public static readonly new int SizeOf = FlannInvoke.flann_SavedIndexParams_sizeof();

        private bool disposed = false;
        #endregion

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
                    return FlannInvoke.flann_SavedIndexParams_filename_get(_ptr);
                }
            }
            set
            {
                unsafe
                {
                    FlannInvoke.flann_SavedIndexParams_filename_set(_ptr, value);
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
                throw new ArgumentNullException("filename");
            ptr = FlannInvoke.flann_SavedIndexParams_construct(filename);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create SavedIndexParams");
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        FlannInvoke.flann_SavedIndexParams_destruct(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion
    }
}
