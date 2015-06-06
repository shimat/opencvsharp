using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Flann
{
    /// <summary>
    /// 
    /// </summary>
    public class IndexParams : DisposableCvObject
    {
        private bool disposed = false;

        #region Properties

        #endregion

        #region Init & Disposal
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IndexParams()
        {
            ptr = NativeMethods.flann_IndexParams_new();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create IndexParams");
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
                        if (ptr != IntPtr.Zero)
                        {
                            NativeMethods.flann_IndexParams_delete(ptr);
                        }
                        ptr = IntPtr.Zero;
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

        #region Methods
        #region Get**
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public string GetString(string key, string defaultVal)
        {
            StringBuilder sb = new StringBuilder(1024);
            NativeMethods.flann_IndexParams_getString(ptr, key, defaultVal, sb);
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetString(string key)
        {
            return GetString(key, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public int GetInt(string key, int defaultVal)
        {
            return NativeMethods.flann_IndexParams_getInt(ptr, key, defaultVal);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetInt(string key)
        {
            return GetInt(key, -1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public double GetDouble(string key, double defaultVal)
        {
            return NativeMethods.flann_IndexParams_getDouble(ptr, key, defaultVal);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public double GetDouble(string key)
        {
            return GetDouble(key, -1);
        }
        #endregion
        #region Set**
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetString(string key, string value)
        {
            NativeMethods.flann_IndexParams_setString(ptr, key, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetInt(string key, int value)
        {
            NativeMethods.flann_IndexParams_setInt(ptr, key, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetDouble(string key, double value)
        {
            NativeMethods.flann_IndexParams_setDouble(ptr, key, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetFloat(string key, float value)
        {
            NativeMethods.flann_IndexParams_setFloat(ptr, key, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetBool(string key, bool value)
        {
            NativeMethods.flann_IndexParams_setBool(ptr, key, value ? 1 : 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetAlgorithm(int value)
        {
            NativeMethods.flann_IndexParams_setAlgorithm(ptr, value);
        }
        #endregion
        #endregion
    }
}
