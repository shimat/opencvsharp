using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Util
{
#if !uap10
#if LANG_JP
    /// <summary>
    /// 動的にアンマネージのアセンブリにある関数を呼び出すためのクラス
    /// </summary>
    /// <typeparam name="T">実行させたい関数の定義に合わせたデリゲート</typeparam>
#else
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
#endif
    public class DynamicInvoker<T> : DisposableObject 
    {
#if LANG_JP
        /// <summary>
        /// 読み込むライブラリの名前
        /// </summary>
#else
        /// <summary>
        /// Name of library to be loaded
        /// </summary>
#endif
        public string DllName { get; private set; }

#if LANG_JP
        /// <summary>
        /// 呼び出す関数の名前
        /// </summary>
#else
        /// <summary>
        /// Name of function to be called
        /// </summary>
#endif
        public string FunctionName { get; private set; }

#if LANG_JP
        /// <summary>
        /// LoadLibraryで得られたポインタ
        /// </summary>
#else
        /// <summary>
        /// Pointer which retrieved by LoadLibrary
        /// </summary>
#endif
        public IntPtr PtrLib { get; }

#if LANG_JP
        /// <summary>
        /// GetProcAddressで得られたポインタ
        /// </summary>
#else
        /// <summary>
        /// Pointer which retrieved by GetProcAddress
        /// </summary>
#endif
        public IntPtr PtrProc { get; }

#if LANG_JP
        /// <summary>
        /// 呼び出す関数ポインタをデリゲートに変換したものを取得する
        /// </summary>
#else
        /// <summary>
        /// Delegate which is converted from function pointer
        /// </summary>
#endif
        public T Call { get; private set; }

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="dllName">ライブラリの名前</param>
        /// <param name="functionName">関数の名前</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dllName">Name of library</param>
        /// <param name="functionName">Name of function</param>
#endif
        public DynamicInvoker(string dllName, string functionName)
        {
            if (Platform.OS == OS.Unix)
            {
                throw new PlatformNotSupportedException("This method is for only Windows");
            }

#if NET20 || NET40
            if (!typeof(T).IsSubclassOf(typeof(Delegate)))
#else
            if (!typeof(T).GetTypeInfo().IsSubclassOf(typeof(Delegate)))
#endif
                throw new OpenCvSharpException("The type argument must be Delegate.");
            if (string.IsNullOrEmpty(dllName))
                throw new ArgumentNullException(nameof(dllName));
            if (string.IsNullOrEmpty(functionName))
                throw new ArgumentNullException(nameof(functionName));

            PtrLib = Win32Api.LoadLibrary(dllName);
            if (PtrLib == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to load \"{0}\".", dllName);
            PtrProc = Win32Api.GetProcAddress(PtrLib, functionName);
            if (PtrProc == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to get address of function \"{0}\".", functionName);

            DllName = dllName;
            FunctionName = functionName;
            IsDisposed = false;

#if NET20 || NET40
            Call = (T)(object)Marshal.GetDelegateForFunctionPointer(PtrProc, typeof(T));
#else
            Call = Marshal.GetDelegateForFunctionPointer<T>(PtrProc);
#endif
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            Win32Api.FreeLibrary(PtrLib);
            base.DisposeUnmanaged();
        }
    }
#endif
}
