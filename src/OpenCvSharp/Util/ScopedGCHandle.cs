using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Util
{
#if LANG_JP
    /// <summary>
    /// IDisposableを実装したGCHandle
    /// </summary>
#else
    /// <summary>
    /// Original GCHandle that implement IDisposable 
    /// </summary>
#endif
    public class ScopedGCHandle : IDisposable
    {
        private GCHandle handle;
        private bool disposed;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 指定したオブジェクトに System.Runtime.InteropServices.GCHandleType.Normal ハンドルを割り当てます
        /// </summary>
        /// <param name="value">GCの対象からはずすオブジェクト</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
#endif
        public ScopedGCHandle(object value)
        {
            if (value != null)
            {
                handle = GCHandle.Alloc(value);
            }
            disposed = false;
        }
#if LANG_JP
        /// <summary>
        /// 指定したオブジェクトに指定した型のハンドルを割り当てます
        /// </summary>
        /// <param name="value">GCの対象からはずすオブジェクト</param>
        /// <param name="type">作成する System.Runtime.InteropServices.GCHandle の型を示す、System.Runtime.InteropServices.GCHandleType 値の 1 つ</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
#endif
        public ScopedGCHandle(object value, GCHandleType type)
        {
            if (value != null)
            {
                handle = GCHandle.Alloc(value, type);
            }
            disposed = false;
        }
#if LANG_JP
        /// <summary>
        /// GCHandleから初期化
        /// </summary>
        /// <param name="handle"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
#endif
        private ScopedGCHandle(GCHandle handle)
        {
            this.handle = handle;
            disposed = false;
        }

#if LANG_JP
        /// <summary>
        /// 指定したオブジェクトに System.Runtime.InteropServices.GCHandleType.Normal ハンドルを割り当てます
        /// </summary>
        /// <param name="value">System.Runtime.InteropServices.GCHandle を使用するオブジェクト</param>
        /// <returns>オブジェクトをガベージ コレクションから保護する新しい System.Runtime.InteropServices.GCHandle。
        /// System.Runtime.InteropServices.GCHandle は、不要になったときに System.Runtime.InteropServices.GCHandle.Free() で解放する必要があります。</returns>
        /// <exception cref="System.ArgumentException">非プリミティブ (blittable でない) メンバを持つインスタンスは固定できません</exception>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
#endif
        public static ScopedGCHandle Alloc(object value)
        {
            return new ScopedGCHandle(value);
        }
#if LANG_JP
        /// <summary>
        /// 指定したオブジェクトに指定した型のハンドルを割り当てます
        /// </summary>
        /// <param name="value">System.Runtime.InteropServices.GCHandle を使用するオブジェクト</param>
        /// <param name="type">作成する System.Runtime.InteropServices.GCHandle の型を示す、System.Runtime.InteropServices.GCHandleType 値の 1 つ</param>
        /// <returns>オブジェクトをガベージ コレクションから保護する新しい System.Runtime.InteropServices.GCHandle。
        /// System.Runtime.InteropServices.GCHandle は、不要になったときに System.Runtime.InteropServices.GCHandle.Free() で解放する必要があります。</returns>
        /// <exception cref="System.ArgumentException">非プリミティブ (blittable でない) メンバを持つインスタンスは固定できません</exception>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#endif
        public static ScopedGCHandle Alloc(object value, GCHandleType type)
        {
            return new ScopedGCHandle(value, type);
        }

#if LANG_JP
        /// <summary>
        /// GCHandle.Freeによりリソースの解放を行う
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                // Release managed resources.
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
                disposed = true;
            }
        }
        /// <summary>
        /// Destructor
        /// </summary>
        ~ScopedGCHandle()
        {
            Dispose(false);
        }
        #endregion

        #region Static methods
#if LANG_JP
        /// <summary>
        /// マネージ オブジェクトを識別するハンドルから作成された新しい System.Runtime.InteropServices.GCHandle オブジェクトを返します
        /// </summary>
        /// <param name="value">System.Runtime.InteropServices.GCHandle オブジェクトの作成元のマネージ オブジェクトを識別する System.IntPtr ハンドル</param>
        /// <exception cref="System.InvalidOperationException">value パラメータの値が System.IntPtr.Zero です</exception>
        /// <returns>値パラメータに対応する新しい System.Runtime.InteropServices.GCHandle オブジェクト</returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
#endif
        public static ScopedGCHandle FromIntPtr(IntPtr value)
        {
            return new ScopedGCHandle(GCHandle.FromIntPtr(value));
        }
#if LANG_JP
        /// <summary>
        /// System.Runtime.InteropServices.GCHandle オブジェクトの内部整数表現を返します
        /// </summary>
        /// <param name="value">内部整数表現の取得元の System.Runtime.InteropServices.GCHandle オブジェクト</param>
        /// <returns>System.Runtime.InteropServices.GCHandle オブジェクトを表す System.IntPtr オブジェクト</returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
#endif
        public static IntPtr ToIntPtr(ScopedGCHandle value)
        {
            return GCHandle.ToIntPtr(value.Handle);
        }
        #endregion

        #region Properties
#if LANG_JP
        /// <summary>
        /// 内部で保持するGCHandle
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public GCHandle Handle
        {
            get { return handle; }
        }
#if LANG_JP
        /// <summary>
        /// ハンドルが割り当てられているかどうかを示す値を取得します
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public bool IsAllocated
        {
            get { return handle.IsAllocated; }
        }
#if LANG_JP
        /// <summary>
        /// ハンドルが表すオブジェクトを取得または設定します
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public object Target
        {
            get { return handle.Target; }
            set { handle.Target = value; }
        }
        #endregion

        #region Methods
#if LANG_JP
        /// <summary>
        /// System.Runtime.InteropServices.GCHandleType.Pinned ハンドル内のオブジェクトのアドレスを取得します
        /// </summary>
        /// <returns>System.IntPtr としての Pinned オブジェクトのアドレス</returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public IntPtr AddrOfPinnedObject()
        {
            return handle.AddrOfPinnedObject();
        }
#if LANG_JP
        /// <summary>
        /// 指定した System.Runtime.InteropServices.GCHandle オブジェクトが、現在の System.Runtime.InteropServices.GCHandle オブジェクトと等しいかどうかを判断します
        /// </summary>
        /// <param name="obj">現在の System.Runtime.InteropServices.GCHandle オブジェクトと比較する System.Runtime.InteropServices.GCHandle オブジェクト</param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
#endif
        public override bool Equals(object obj)
        {
            return handle.Equals(obj);
        }
#if LANG_JP
        /// <summary>
        /// System.Runtime.InteropServices.GCHandle を解放します
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public void Free()
        {
            handle.Free();
        }
#if LANG_JP
        /// <summary>
        /// 現在の System.Runtime.InteropServices.GCHandle オブジェクトの識別子を返します
        /// </summary>
        /// <returns>現在の System.Runtime.InteropServices.GCHandle オブジェクトの識別子</returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public override int GetHashCode()
        {
            return handle.GetHashCode();
        }
#if LANG_JP
        /// <summary>
        /// 文字列形式を返す
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public override string ToString()
        {
            return handle.ToString();
        }
        #endregion
    }
}
