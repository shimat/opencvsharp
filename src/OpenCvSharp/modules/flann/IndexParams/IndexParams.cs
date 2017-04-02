using System;
using System.Text;

namespace OpenCvSharp.Flann
{
    /// <summary>
    /// 
    /// </summary>
    public class IndexParams : DisposableCvObject
    {
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

        protected internal IndexParams(bool dummy)
        {
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.flann_IndexParams_delete(ptr);
            base.DisposeUnmanaged();
        }

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
