using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 解放処理を行うクラスが継承するための基本クラス
    /// </summary>
#else
    /// <summary>
    /// Represents a class which manages its own memory. 
    /// </summary>
#endif
    public abstract class DisposableObject : IDisposable
    {
        /// <summary>
        /// Gets or sets a handle which allocates using cvSetData.
        /// </summary>
        protected GCHandle dataHandle;

        private volatile int disposeSignaled = 0;

        #region Properties
#if LANG_JP
        /// <summary>
        /// リソースが解放済みかどうかを取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a value indicating whether this instance has been disposed.
        /// </summary>
#endif
        public bool IsDisposed { get; protected set; }

#if LANG_JP
        /// <summary>
        /// 解放処理を許可するかどうかを取得・設定する. falseならばDisposeは何もしない.
        /// 通常はユーザはこのフラグを変更してはならない. CvCapture.QueryFrameで取得したIplImageのように, 
        /// 解放処理をするとエラーとなるオブジェクトの場合に自動的にこのフラグがfalseとなる。
        /// </summary>
#else
        /// <summary>
        /// Gets or sets a value indicating whether you permit disposing this instance.
        /// </summary>
#endif
        public bool IsEnabledDispose { get; set; }


#if LANG_JP
        /// <summary>
        /// cvCreateXXX といった関数がなく自前で構造体の分のメモリを確保する場合、
        /// そのアドレスを入れておく場所
        /// </summary>
#else
        /// <summary>
        /// Gets or sets a memory address allocated by AllocMemory.
        /// </summary>
#endif
        protected IntPtr AllocatedMemory { get; set; }

#if LANG_JP
        /// <summary>
        /// AllocatedMemoryに確保されているメモリのサイズ
        /// </summary>
#else
        /// <summary>
        /// Gets or sets the byte length of the allocated memory
        /// </summary>
#endif
        protected long AllocatedMemorySize { get; set; }

        #endregion

        #region Init and Dispossal
#if LANG_JP
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        protected DisposableObject()
            : this(true)
        {
        }

#if LANG_JP
        /// <summary>
        /// 解放の可否を指定して初期化
        /// </summary>
        /// <param name="isEnabledDispose">GCで解放するならtrue</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isEnabledDispose">true if you permit disposing this class by GC</param>
#endif
        protected DisposableObject(bool isEnabledDispose)
        {
            IsDisposed = false;
            IsEnabledDispose = isEnabledDispose;
            AllocatedMemory = IntPtr.Zero;
            AllocatedMemorySize = 0;
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
#else
        /// <summary>
        /// Releases the resources
        /// </summary>
#endif
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        private void Dispose(bool disposing)
        {
#pragma warning disable 420
            // http://stackoverflow.com/questions/425132/a-reference-to-a-volatile-field-will-not-be-treated-as-volatile-implications
            if (Interlocked.Exchange(ref disposeSignaled, 1) != 0)
            {
                return;
            }

            IsDisposed = true;

            if (IsEnabledDispose)
            {
                if (disposing)
                {
                    DisposeManaged();
                }
                DisposeUnmanaged();
            }
        }

#if LANG_JP
        /// <summary>
        /// デストラクタ
        /// </summary>
#else
        /// <summary>
        /// Destructor
        /// </summary>
#endif
        ~DisposableObject()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected virtual void DisposeManaged()
        {
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected virtual void DisposeUnmanaged()
        {
            if (dataHandle.IsAllocated)
            {
                dataHandle.Free();
            }
            if (AllocatedMemorySize > 0)
            {
                GC.RemoveMemoryPressure(AllocatedMemorySize);
                AllocatedMemorySize = 0;
            }
            if (AllocatedMemory != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(AllocatedMemory);
                AllocatedMemory = IntPtr.Zero;
            }
        }

        #endregion

        #region Methods

#if LANG_JP
        /// <summary>
        /// cvSetDataで割り当てる配列データをGCHandleでピン止めする
        /// </summary>
        /// <param name="obj"></param>
#else
        /// <summary>
        /// Pins the object to be allocated by cvSetData.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
#endif
        protected internal GCHandle AllocGCHandle(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            
            if (dataHandle.IsAllocated)
                dataHandle.Free();
            dataHandle = GCHandle.Alloc(obj, GCHandleType.Pinned);
            return dataHandle;
        }

#if LANG_JP
        /// <summary>
        /// 指定したサイズの量のメモリを割り当てる。
        /// Dispose時に解放する
        /// </summary>
        /// <param name="size">割り当てたメモリ</param>
#else
        /// <summary>
        /// Allocates the specified size of memory.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
#endif
        protected IntPtr AllocMemory(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            
            if (AllocatedMemory != IntPtr.Zero)
                Marshal.FreeHGlobal(AllocatedMemory);
            AllocatedMemory = Marshal.AllocHGlobal(size);
            NotifyMemoryPressure(size);
            return AllocatedMemory;
        }

#if LANG_JP
        /// <summary>
        /// アンマネージメモリを確保したメモリサイズを通知する。
        /// 
        /// 実際に確保するならAllocMemoryのほうを使う。
        /// 確保はcvCreateXXXがやってくれるという場合はこっちを使う
        /// </summary>
        /// <param name="size"></param>
#else
        /// <summary>
        /// Notifies the allocated size of memory.
        /// </summary>
        /// <param name="size"></param>
#endif
        protected void NotifyMemoryPressure(long size)
        {
            // マルチスレッド動作時にロックがかかるらしい。いったん廃止
            if (!IsEnabledDispose)
                return;
            if (size == 0)
                return;
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            
            if (AllocatedMemorySize > 0)
                GC.RemoveMemoryPressure(AllocatedMemorySize);
            
            AllocatedMemorySize = size;
            GC.AddMemoryPressure(size);
        }

#if LANG_JP
        /// <summary>
        /// このオブジェクトが解放済みの場合はObjectDisposedExceptionを投げる
        /// </summary>
#else
        /// <summary>
        /// If this object is disposed, then ObjectDisposedException is thrown.
        /// </summary>
#endif
        public void ThrowIfDisposed()
        {
            if (IsDisposed) 
                throw new ObjectDisposedException(GetType().FullName);
        }

        #endregion
    }
}
