﻿using System;
using System.Text;

namespace OpenCvSharp.Flann
{
    /// <summary>
    /// 
    /// </summary>
    public class IndexParams : DisposableCvObject
    {
        internal OpenCvSharp.Ptr? PtrObj { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IndexParams()
        {
            var p = NativeMethods.flann_Ptr_IndexParams_new();
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Failed to create {nameof(IndexParams)}");

            PtrObj = new Ptr(p);
            ptr = PtrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        protected IndexParams(OpenCvSharp.Ptr? ptrObj)
        {
            PtrObj = ptrObj;
            ptr = PtrObj?.Get() ?? IntPtr.Zero;
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            PtrObj?.Dispose();
            PtrObj = null;
            base.DisposeManaged();
        }

        #region Methods
        #region Get**
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public string GetString(string key, string? defaultVal)
        {
            var sb = new StringBuilder(1024);
            NativeMethods.flann_IndexParams_getString(ptr, key, defaultVal, sb);
            GC.KeepAlive(this);
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
            var ret = NativeMethods.flann_IndexParams_getInt(ptr, key, defaultVal);
            GC.KeepAlive(this);
            return ret;
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
            var ret = NativeMethods.flann_IndexParams_getDouble(ptr, key, defaultVal);
            GC.KeepAlive(this);
            return ret;
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
            GC.KeepAlive(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetInt(string key, int value)
        {
            NativeMethods.flann_IndexParams_setInt(ptr, key, value);
            GC.KeepAlive(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetDouble(string key, double value)
        {
            NativeMethods.flann_IndexParams_setDouble(ptr, key, value);
            GC.KeepAlive(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetFloat(string key, float value)
        {
            NativeMethods.flann_IndexParams_setFloat(ptr, key, value);
            GC.KeepAlive(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetBool(string key, bool value)
        {
            NativeMethods.flann_IndexParams_setBool(ptr, key, value ? 1 : 0);
            GC.KeepAlive(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetAlgorithm(int value)
        {
            NativeMethods.flann_IndexParams_setAlgorithm(ptr, value);
            GC.KeepAlive(this);
        }
        #endregion
        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.flann_Ptr_IndexParams_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.flann_Ptr_IndexParams_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
