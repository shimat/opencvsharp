using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Base class for high-level OpenCV algorithms
    /// </summary>
    public class Algorithm : DisposableCvObject
    {
        /// <summary>
        /// cv::Ptr&lt;FeatureDetector&gt;
        /// </summary>
        private PtrOfAlgorithm objectPtr;
        /// <summary>
        /// 
        /// </summary>
        private bool disposed = false;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        internal Algorithm()
        {
            ptr = NativeMethods.core_Algorithm_new();
            objectPtr = PtrOfAlgorithm.FromRawPtr(ptr);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// 
        /// </summary>
        internal Algorithm(IntPtr ptr)
        {
            base.ptr = ptr;
            IsEnabledDispose = false;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static Algorithm FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FeatureDetector pointer");
            
            var ptrObj = new PtrOfAlgorithm(ptr);
            var obj = new Algorithm
                {
                    objectPtr = ptrObj, 
                    ptr = ptrObj.Obj
                };
            return obj;
        }
        /// <summary>
        /// Creates instance from raw T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static Algorithm FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FeatureDetector pointer");
            return new Algorithm(ptr);
        }
        
#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
#endif
        public void Release()
        {
            Dispose(true);
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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        if (objectPtr != null)
                        {
                            objectPtr.Dispose();
                        }
                        else
                        {
                            if (ptr != IntPtr.Zero)
                                NativeMethods.core_Algorithm_delete(ptr);
                        }
                        objectPtr = null;
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        /// <summary>
        /// Returns the algorithm name
        /// </summary>
        public string Name
        {
            get
            {
                StringBuilder buf = new StringBuilder(1024);
                NativeMethods.core_Algorithm_name(ptr, buf, buf.Capacity);
                return buf.ToString();
            }
        }

        #region Get
        /// <summary>
        /// Returns the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <returns></returns>
        public int GetInt(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            return NativeMethods.core_Algorithm_getInt(ptr, name);            
        }
        /// <summary>
        /// Returns the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <returns></returns>
        public double GetDouble(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            return NativeMethods.core_Algorithm_getDouble(ptr, name);
        }
        /// <summary>
        /// Returns the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <returns></returns>
        public bool GetBool(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            return NativeMethods.core_Algorithm_getBool(ptr, name) != 0;
        }
        /// <summary>
        /// Returns the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <returns></returns>
        public string GetString(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            StringBuilder buf = new StringBuilder(1024);
            NativeMethods.core_Algorithm_getString(ptr, name, buf, buf.Capacity);
            return buf.ToString();
        }
        /// <summary>
        /// Returns the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <returns></returns>
        public Mat GetMat(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            IntPtr mat = NativeMethods.core_Algorithm_getMat(ptr, name);
            return new Mat(mat);
        }
        /// <summary>
        /// Returns the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <returns></returns>
        public Mat[] GetMatVector(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            using (var vec = new VectorOfMat())
            {
                NativeMethods.core_Algorithm_getMatVector(ptr, name, vec.CvPtr);
                return vec.ToArray();
            }
        }
        /// <summary>
        /// Returns the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <returns></returns>
        public Algorithm GetAlgorithm(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            IntPtr ptrObj = NativeMethods.core_Algorithm_getAlgorithm(ptr, name);
            return FromPtr(ptrObj);
        }
        #endregion

        #region Set
        /// <summary>
        /// Sets the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        public void SetInt(string name, int value)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            NativeMethods.core_Algorithm_setInt(ptr, name, value);
        }
        /// <summary>
        /// Sets the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        public void SetDouble(string name, double value)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            NativeMethods.core_Algorithm_setDouble(ptr, name, value);
        }
        /// <summary>
        /// Sets the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        public void SetBool(string name, bool value)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            NativeMethods.core_Algorithm_setBool(ptr, name, value);
        }
        /// <summary>
        /// Sets the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        public void SetString(string name, string value)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            NativeMethods.core_Algorithm_setString(ptr, name, value);
        }
        /// <summary>
        /// Sets the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        public void SetMat(string name, Mat value)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            if (value == null)
                throw new ArgumentNullException("value");
            value.ThrowIfDisposed();
            NativeMethods.core_Algorithm_setMat(ptr, name, value.CvPtr);
        }
        /// <summary>
        /// Sets the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        public void SetMatVector(string name, IEnumerable<Mat> value)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            if (value == null)
                throw new ArgumentNullException("value");
            IntPtr[] valueArray = EnumerableEx.SelectPtrs(value);
            NativeMethods.core_Algorithm_setMatVector(ptr, name, valueArray, valueArray.Length);
        }
        /// <summary>
        /// Sets the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        public void SetAlgorithm(string name, Algorithm value)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            NativeMethods.core_Algorithm_setAlgorithm(ptr, name, value.CvPtr);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string ParamHelp(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            var buf = new StringBuilder(4096);
            NativeMethods.core_Algorithm_paramHelp(ptr, name, buf, buf.Capacity);
            return buf.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int ParamType(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            return NativeMethods.core_Algorithm_paramType(ptr, name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetParams()
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            using (var namesVec = new VectorOfString())
            {
                NativeMethods.core_Algorithm_getParams(ptr, namesVec.CvPtr);
                return namesVec.ToArray();
            }
        }

        /// <summary>
        /// Returns the list of registered algorithms
        /// </summary>
        /// <returns>The output array of algorithm names.</returns>
        public static string[] GetList()
        {
            using (var vec = new VectorOfString())
            {
                NativeMethods.core_Algorithm_getList(vec.CvPtr);
                return vec.ToArray();
            }
        }

        /// <summary>
        /// Creates algorithm instance by name
        /// </summary>
        /// <param name="name">The algorithm name, one of the names returned by GetList()</param>
        /// <returns></returns>
        public static Algorithm Create(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            // cv::Ptr<T> を作成
            IntPtr p = NativeMethods.core_Algorithm_create(name);
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException("Algorithm name [" + name + "] not found");
            return FromPtr(p);
        }
        /// <summary>
        /// Creates algorithm instance by name
        /// </summary>
        /// <param name="name">The algorithm name, one of the names returned by GetList()</param>
        /// <returns></returns>
        public static T Create<T>(string name)
            where T : Algorithm
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            // cv::Ptr<T> でAlgorithmを受け取る
            IntPtr p = NativeMethods.core_Algorithm_create(name);
            if(p == IntPtr.Zero)
                throw new OpenCvSharpException("Algorithm name [" + name + "] not found");

            // リフレクションでオブジェクト生成
            Type t = typeof(T);
            MethodInfo mi = t.GetMethod("FromPtr", BindingFlags.NonPublic | BindingFlags.Static);
            if (mi == null)
                throw new NotSupportedException("Algorithm type [" + t.Name + "] not supported");
            return (T)mi.Invoke(null, new object[] {p});
        }

        /// <summary>
        /// Algorithm information
        /// </summary>
        /// <returns></returns>
        public virtual AlgorithmInfo Info
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("Algorithm");
                IntPtr p = NativeMethods.core_Algorithm_info(ptr);
                return new AlgorithmInfo(p);
            }
        }
    }
}
