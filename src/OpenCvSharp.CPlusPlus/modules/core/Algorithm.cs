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

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
                base.Dispose(disposing);
            }
        }

        #endregion

        /*
        /// <summary>
        /// Creates algorithm instance by name
        /// </summary>
        /// <param name="name">The algorithm name, one of the names returned by GetList()</param>
        /// <typeparam name="T">Algorithm type (SIFT, FAST, etc.)</typeparam>
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
        */
    }
}
