using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Base class for high-level OpenCV algorithms
    /// </summary>
    public abstract class Algorithm : DisposableCvObject
    {
        /// <summary>
        /// cv::Ptr&lt;Algorithm&gt;
        /// </summary>
        private Ptr<Algorithm> objectPtr;
        /// <summary>
        /// 
        /// </summary>
        private bool disposed;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        internal Algorithm()
        {
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
        
        #region Get
        // Get/Set は、cv::Algorithm のメソッドを単純に呼ぶとクラッシュする。
        // レシーバのポインタ型が常に cv::Algorithm* になってしまうため。
        // なので、内部実装を参考に AlgorithmInfoを直接叩く。
        // Algorithm::info() はabstractで、各子クラス固有の AlgorithmInfo*が取れる。

        /// <summary>
        /// Returns the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <returns></returns>
        public int GetInt(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            IntPtr info = InfoPtr;
            int value = 0;
            NativeMethods.core_AlgorithmInfo_getInt(
                info, ptr, name, (int)AlgorithmParamType.Int, ref value);
            return value;
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
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            IntPtr info = InfoPtr;
            double value = 0;
            NativeMethods.core_AlgorithmInfo_getDouble(
                info, ptr, name, (int)AlgorithmParamType.Real, ref value);
            return value;
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
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            IntPtr info = InfoPtr;
            int valueInt = 0;
            NativeMethods.core_AlgorithmInfo_getBool(
                info, ptr, name, (int)AlgorithmParamType.Boolean, ref valueInt);
            return valueInt != 0;
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
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            IntPtr info = InfoPtr;
            StringBuilder buf = new StringBuilder(1 << 16);
            NativeMethods.core_AlgorithmInfo_getString(
                info, ptr, name, (int)AlgorithmParamType.String, buf, buf.Capacity);
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
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            IntPtr info = InfoPtr;
            Mat value = new Mat();
            NativeMethods.core_AlgorithmInfo_getMat(
                info, ptr, name, (int)AlgorithmParamType.Mat, value.CvPtr);
            return value;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            IntPtr info = InfoPtr;
            NativeMethods.core_AlgorithmInfo_setInt(
                info, ptr, name, (int)AlgorithmParamType.Int, value, 0);
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
            IntPtr info = InfoPtr;
            NativeMethods.core_AlgorithmInfo_setDouble(
                info, ptr, name, (int)AlgorithmParamType.Real, value, 0);
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
            IntPtr info = InfoPtr;
            int valueInt = value ? 1 : 0;
            NativeMethods.core_AlgorithmInfo_setBool(
                info, ptr, name, (int)AlgorithmParamType.Boolean, valueInt, 0);
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
            IntPtr info = InfoPtr;
            NativeMethods.core_AlgorithmInfo_setString(
                info, ptr, name, (int)AlgorithmParamType.String, value, 0);
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

            IntPtr info = InfoPtr;
            NativeMethods.core_AlgorithmInfo_setMat(
                info, ptr, name, (int)AlgorithmParamType.Mat, value.CvPtr, 0);
        }

        /// <summary>
        /// Sets the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        public void SetMatVector(string name, IEnumerable<Mat> value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets the algorithm parameter
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        public void SetAlgorithm(string name, Algorithm value)
        {
            throw new NotImplementedException();
        }
        #endregion

        /// <summary>
        /// Returns the algorithm name
        /// </summary>
        public string Name
        {
            get { return Info.Name; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string ParamHelp(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            return Info.ParamHelp(name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AlgorithmParamType ParamType(string name)
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            return Info.ParamType(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetParams()
        {
            if (disposed)
                throw new ObjectDisposedException("Algorithm");
            return Info.GetParams();
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
        public static T Create<T>(string name)
            where T : Algorithm
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            
            // リフレクションでオブジェクト生成
            Type t = typeof(T);
            MethodInfo mi = t.GetMethod("CreateAlgorithm", BindingFlags.Public | BindingFlags.Static);
            if (mi == null)
                throw new OpenCvSharpException("Algorithm type [" + t.Name + "] not supported");
            return (T)mi.Invoke(null, new object[] {name});
        }

        /// <summary>
        /// Algorithm information
        /// </summary>
        /// <returns></returns>
        public AlgorithmInfo Info
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("Algorithm");
                return infoObj ?? (infoObj = new AlgorithmInfo(InfoPtr));
            }
        }
        private AlgorithmInfo infoObj;
        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public abstract IntPtr InfoPtr { get; }

        /// <summary>
        /// Returns a string that represents this Algorithm.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var str = new StringBuilder();
            str.AppendFormat("Algorithm [{0}]\n", Name);

            string[] names = GetParams();
            foreach (string name in names)
            {
                AlgorithmParamType type = ParamType(name);
                string typeName = Enum.GetName(typeof(AlgorithmParamType), type);
                str.AppendFormat(" * {0} {1} = ", typeName, name);

                switch (type)
                {
                    case AlgorithmParamType.Int:
                    case AlgorithmParamType.Short:
                    case AlgorithmParamType.UChar:
                        str.AppendFormat("{0}\n", GetInt(name));
                        break;
                    case AlgorithmParamType.Boolean:
                        str.AppendFormat("{0}\n", GetBool(name));
                        break;
                    case AlgorithmParamType.Real:
                    case AlgorithmParamType.Float:
                    case AlgorithmParamType.UInt64:
                        str.AppendFormat("{0}\n", GetDouble(name));
                        break;
                    case AlgorithmParamType.Mat:
                        str.AppendFormat("{0}\n", GetMat(name).ToString());
                        break;
                    case AlgorithmParamType.MatVector:
                        str.AppendFormat("Mat[{0}]\n", GetMatVector(name).Length);
                        break;
                    case AlgorithmParamType.String:
                        str.AppendFormat("{0}\n", GetString(name));
                        break;
                    case AlgorithmParamType.Algorithm:
                        str.AppendFormat("{0}\n", GetAlgorithm(name).Name);
                        break;
                }
            }

            return str.ToString();
        }
    }
}
