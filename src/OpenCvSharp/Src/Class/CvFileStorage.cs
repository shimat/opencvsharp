/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// ファイルストレージ.
    /// CXCoreは，XML(http://www.w3c.org/XML)や YAML (http://www.yaml.org)形式のデータの読み書きが可能である．
    /// </summary>
#else
    /// <summary>
    /// File Storage
    /// </summary>
#endif
    public class CvFileStorage : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// データの読み書きのためのファイルを開く．
        /// 書き込みの場合は，新しいファイルが作成されるか，ファイルが存在する場合には上書きされる．
        /// また，読み書きされるファイルの種類は拡張子で判別される． XMLの場合は.xml，YAMLの場合は.ymlまたは.yamlである．
        /// </summary>
        /// <param name="filename">ストレージに関連づけられたファイルの名前</param>
        /// <param name="memstorage">一時的なデータや，CvSeqや CvGraphなどの動的構造体の保存に使われるメモリストレージ．nullの場合，一時的なメモリが確保されて使用される．</param>
        /// <param name="flags">ファイルを開く方法または作成する方法</param>
#else
        /// <summary>
        /// Opens file storage for reading or writing data
        /// </summary>
        /// <param name="filename">Name of the file associated with the storage. </param>
        /// <param name="memstorage">Memory storage used for temporary data and for storing dynamic structures, such as CvSeq or CvGraph. If it is null, a temporary memory storage is created and used. </param>
        /// <param name="flags"></param>
#endif
        public CvFileStorage(string filename, CvMemStorage memstorage, FileStorageMode flags)
            : this(filename, memstorage, flags, null)
        {
        }
#if LANG_JP
        /// <summary>
        /// データの読み書きのためのファイルを開く．
        /// 書き込みの場合は，新しいファイルが作成されるか，ファイルが存在する場合には上書きされる．
        /// また，読み書きされるファイルの種類は拡張子で判別される． XMLの場合は.xml，YAMLの場合は.ymlまたは.yamlである．
        /// </summary>
        /// <param name="filename">ストレージに関連づけられたファイルの名前</param>
        /// <param name="memstorage">一時的なデータや，CvSeqや CvGraphなどの動的構造体の保存に使われるメモリストレージ．nullの場合，一時的なメモリが確保されて使用される．</param>
        /// <param name="flags">ファイルを開く方法または作成する方法</param>
        /// <param name="encoding"></param>
#else
        /// <summary>
        /// Opens file storage for reading or writing data
        /// </summary>
        /// <param name="filename">Name of the file associated with the storage. </param>
        /// <param name="memstorage">Memory storage used for temporary data and for storing dynamic structures, such as CvSeq or CvGraph. If it is null, a temporary memory storage is created and used. </param>
        /// <param name="flags"></param>
        /// <param name="encoding"></param>
#endif
        public CvFileStorage(string filename, CvMemStorage memstorage, FileStorageMode flags, string encoding)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");

            IntPtr memstoragePtr = (memstorage == null) ? IntPtr.Zero : memstorage.CvPtr;

            ptr = CvInvoke.cvOpenFileStorage(filename, memstoragePtr, flags, encoding);
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvFileStorage");
            }
        }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvFileStorage*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvFileStorage*</param>
#endif
        public CvFileStorage(IntPtr ptr)
        {
            this.ptr = ptr;
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
                        CvInvoke.cvReleaseFileStorage(ref ptr);
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

        #region Methods
        #region EndWriteStruct
#if LANG_JP
        /// <summary>
        /// ファイルストレージへの構造体の書き込みを終了する．
        /// </summary>
#else
        /// <summary>
        /// Ends writing a structure
        /// </summary>
#endif
        public void EndWriteStruct()
        {
            Cv.EndWriteStruct(this);
        }
        #endregion
        #region GetFileNode
#if LANG_JP
        /// <summary>
        /// マップまたはファイルストレージ内のノードを見つける
        /// </summary>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探す．もしmapとkeyの両方がnullの場合には， この関数はトップレベルノードを持つマップであるルートファイルノードを返す．</param>
        /// <param name="key">cvGetHashedKeyで取得されるノード名ヘの唯一のポインタ</param>
        /// <returns>与えたmap,keyに対するファイルノード</returns>
#else
        /// <summary>
        /// Finds node in the map or file storage
        /// </summary>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. If both map and key are nulls, the function returns the root file node - a map that contains top-level nodes. </param>
        /// <param name="key">Unique pointer to the node name, retrieved with cvGetHashedKey. </param>
        /// <returns></returns>
#endif
        public CvFileNode GetFileNode(CvFileNode map, CvStringHashNode key)
        {
            return Cv.GetFileNode(this, map, key);
        }
#if LANG_JP
        /// <summary>
        /// マップまたはファイルストレージ内のノードを見つける
        /// </summary>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探す．もしmapとkeyの両方がnullの場合には， この関数はトップレベルノードを持つマップであるルートファイルノードを返す．</param>
        /// <param name="key">cvGetHashedKeyで取得されるノード名ヘの唯一のポインタ</param>
        /// <param name="create_missing">absent keyをハッシュテーブルに追加するかどうかを指定するフラグ</param>
        /// <returns>与えたmap,keyに対するファイルノード</returns>
#else
        /// <summary>
        /// Finds node in the map or file storage
        /// </summary>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. If both map and key are nulls, the function returns the root file node - a map that contains top-level nodes. </param>
        /// <param name="key">Unique pointer to the node name, retrieved with cvGetHashedKey. </param>
        /// <param name="createMissing">Flag that specifies, whether an absent node should be added to the map, or not. </param>
        /// <returns></returns>
#endif
        public CvFileNode GetFileNode(CvFileNode map, CvStringHashNode key, bool createMissing)
        {
            return Cv.GetFileNode(this, map, key, createMissing);
        }
        #endregion
        #region GetFileNodeByName
#if LANG_JP
        /// <summary>
        /// マップ内またはファイルストレージ内からノードを探索する
        /// </summary>
        /// <param name="map">親マップ．nullの場合，この関数は一番最初のものから開始して，全てのトップレベルノード(ストリーム)内を探索する．</param>
        /// <param name="name">ファイルノード名</param>
        /// <returns>名前がnameのファイルノード</returns>
#else
        /// <summary>
        /// Finds node in the map or file storage
        /// </summary>
        /// <param name="map">The parent map. If it is null, the function searches in all the top-level nodes (streams), starting from the first one. </param>
        /// <param name="name">The file node name. </param>
        /// <returns></returns>
#endif
        public CvFileNode GetFileNodeByName(CvFileNode map, string name)
        {
            return Cv.GetFileNodeByName(this, map, name);
        }
        #endregion
        #region GetRootFileNode
#if LANG_JP
        /// <summary>
        /// トップレベルファイルノードの一つを返す．
        /// </summary>
        /// <returns>トップレベルファイルノードの一つ</returns>
#else
        /// <summary>
        /// Retrieves one of top-level nodes of the file storage
        /// </summary>
        /// <returns>One of top-level file nodes</returns>
#endif
        public CvFileNode GetRootFileNode()
        {
            return Cv.GetRootFileNode(this);
        }
#if LANG_JP
        /// <summary>
        /// トップレベルファイルノードの一つを返す．
        /// </summary>
        /// <param name="stream_index">0から始まるストリームのインデックス．多くの場合，ファイル中に存在するのは一つのストームであるが，複数にもなり得る．</param>
        /// <returns>トップレベルファイルノードの一つ</returns>
#else
        /// <summary>
        /// Retrieves one of top-level nodes of the file storage
        /// </summary>
        /// <param name="streamIndex">Zero-based index of the stream. In most cases, there is only one stream in the file, however there can be several. </param>
        /// <returns>One of top-level file nodes</returns>
#endif
        public CvFileNode GetRootFileNode(int streamIndex)
        {
            return Cv.GetRootFileNode(this, streamIndex);
        }
        #endregion
        #region GetHashedKey
#if LANG_JP
        /// <summary>
        /// 与えた名前に対するユニークなポインタを返す 
        /// </summary>
        /// <param name="name">ファイルノード名</param>
        /// <returns>与えた名前に対するユニークなポインタ</returns>
#else
        /// <summary>
        /// Returns a unique pointer for given name
        /// </summary>
        /// <param name="name">Literal node name. </param>
        /// <returns>The unique pointer for each particular file node name.</returns>
#endif
        public CvStringHashNode GetHashedKey(string name)
        {
            return Cv.GetHashedKey(this, name);
        }
#if LANG_JP
        /// <summary>
        /// 与えた名前に対するユニークなポインタを返す 
        /// </summary>
        /// <param name="name">ファイルノード名</param>
        /// <param name="create_missing">absent keyをハッシュテーブルに追加するかどうかを指定するフラグ</param>
        /// <returns>与えた名前に対するユニークなポインタ</returns>
#else
        /// <summary>
        /// Returns a unique pointer for given name
        /// </summary>
        /// <param name="name">Literal node name. </param>
        /// <param name="createMissing">Length of the name (if it is known a priori), or -1 if it needs to be calculated. </param>
        /// <returns>The unique pointer for each particular file node name.</returns>
#endif
        public CvStringHashNode GetHashedKey(string name, bool createMissing)
        {
            return Cv.GetHashedKey(this, name, createMissing);
        }
        #endregion
        #region Read
#if LANG_JP
        /// <summary>
        /// オブジェクトをデコードし，その参照を返す.
        /// </summary>
        /// <typeparam name="T">返却値の型(CvArr派生型)</typeparam>
        /// <param name="node">ルートオブジェクトノード</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Decodes object and returns pointer to it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node">The root object node. </param>
        /// <returns></returns>
#endif
        public T Read<T>(CvFileNode node) where T : CvArr
        {
            return Cv.Read<T>(this, node);
        }
        #endregion
        #region ReadByName
#if LANG_JP
        /// <summary>
        /// オブジェクトをデコードし，デコードする.
        /// cvGetFileNodeByName とcvReadの単純な合成である．
        /// </summary>
        /// <typeparam name="T">返却値の型(CvArr派生型)</typeparam>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する．</param>
        /// <param name="name">ノード名</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds object and decodes it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <returns></returns>
#endif
        public T ReadByName<T>(CvFileNode map, string name) where T : CvArr
        {
            return Cv.ReadByName<T>(this, map, name);
        }
        #endregion
        #region ReadIntByName
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadIntの単純な合成である．
        /// </summary>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <returns>ファイルノードで表現された整数値</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <returns></returns>
#endif
        public int ReadIntByName(CvFileNode map, string name)
        {
            return Cv.ReadIntByName(this, map, name);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadIntの単純な合成である．
        /// </summary>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <param name="default_value">ファイルノードが見つからない場合の戻り値</param>
        /// <returns>ファイルノードで表現された整数値</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <param name="defaultValue">The value that is returned if the file node is not found. </param>
        /// <returns></returns>
#endif
        public int ReadIntByName(CvFileNode map, string name, int defaultValue)
        {
            return Cv.ReadIntByName(this, map, name, defaultValue);
        }
        #endregion
        #region ReadRawData
#if LANG_JP
        /// <summary>
        /// 複数の数値を読み込む
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src">数値を読み込むファイルノード(シーケンス)</param>
        /// <param name="dst">書き込み先の配列へのポインタ．</param>
        /// <param name="dt">配列の個々の要素の仕様．</param>
#else
        /// <summary>
        /// Reads multiple numbers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src">The file node (a sequence) to read numbers from. </param>
        /// <param name="dst">Reference to the destination array. </param>
        /// <param name="dt">Specification of each array element. It has the same format as in cvWriteRawData. </param>
#endif
        public void ReadRawData<T>(CvFileNode src, ref T[] dst, string dt)
            where T : struct
        {
            Cv.ReadRawData<T>(this, src, ref dst, dt);
        }
        #endregion
        #region ReadRawDataSlice
#if LANG_JP
        /// <summary>
        /// 複数の数値のシーケンスを読み込む
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">シーケンスリーダ</param>
        /// <param name="count">読み込む要素数</param>
        /// <param name="dst">出力配列</param>
        /// <param name="dt">各配列要素の仕様</param>
#else
        /// <summary>
        /// Initializes file node sequence reader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">The sequence reader. Initialize it with cvStartReadRawData. </param>
        /// <param name="count">The number of elements to read. </param>
        /// <param name="dst">Destination array. </param>
        /// <param name="dt">Specification of each array element. It has the same format as in cvWriteRawData. </param>
#endif
        public void ReadRawDataSlice<T>(CvSeqReader reader, int count, out T[] dst, string dt)
            where T : struct
        {
            Cv.ReadRawDataSlice(this, reader, count, out dst, dt);
        }
        #endregion
        #region ReadRealByName
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadRealの単純な合成である．
        /// </summary>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <returns>ファイルノードで表現された浮動小数点型の値</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <returns></returns>
#endif
        public double ReadRealByName(CvFileNode map, string name)
        {
            return Cv.ReadRealByName(this, map, name);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadRealの単純な合成である．
        /// </summary>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <param name="default_value">ファイルノードが見つからない場合の戻り値</param>
        /// <returns>ファイルノードで表現された浮動小数点型の値</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <param name="defaultValue">The value that is returned if the file node is not found. </param>
        /// <returns></returns>
#endif
        public double ReadRealByName(CvFileNode map, string name, double defaultValue)
        {
            return Cv.ReadRealByName(this, map, name, defaultValue);
        }
        #endregion
        #region ReadStringByName
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadStringの単純な合成である．
        /// </summary>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <returns>ファイルノードで表現された文字列</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <returns></returns>
#endif
        public string ReadStringByName(CvFileNode map, string name)
        {
            return Cv.ReadStringByName(this, map, name);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadStringの単純な合成である．
        /// </summary>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <param name="default_value">ファイルノードが見つからない場合の戻り値</param>
        /// <returns>ファイルノードで表現された文字列</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <param name="defaultValue">The value that is returned if the file node is not found. </param>
        /// <returns></returns>
#endif
        public string ReadStringByName(CvFileNode map, string name, string defaultValue)
        {
            return Cv.ReadStringByName(this, map, name, defaultValue);
        }
        #endregion
        #region StartNextStream
#if LANG_JP
        /// <summary>
        /// ファイルストレージ内の次のストリームを開始する． 
        /// </summary>
#else
        /// <summary>
        /// Starts the next stream
        /// </summary>
#endif
        public void StartNextStream()
        {
            Cv.StartNextStream(this);
        }
        #endregion
        #region StartReadRawData
#if LANG_JP
        /// <summary>
        /// ファイルノードのシーケンスリーダの初期化
        /// </summary>
        /// <param name="src">読み込むファイルノード(シーケンス)．</param>
        /// <param name="reader">シーケンスリーダへのポインタ．</param>
#else
        /// <summary>
        /// Initializes file node sequence reader
        /// </summary>
        /// <param name="src">The file node (a sequence) to read numbers from. </param>
        /// <param name="reader">Output reference to the sequence reader. </param>
#endif
        public void StartReadRawData(CvFileNode src, out CvSeqReader reader)
        {
            Cv.StartReadRawData(this, src, out reader);
        }
        #endregion
        #region StartWriteStruct
#if LANG_JP
        /// <summary>
        /// 新しい構造体の書き込みを開始する
        /// </summary>
        /// <param name="name">書き込む構造体の名前．読み込む場合は，この名前で構造体にアクセスできる．</param>
        /// <param name="struct_flags">Seq, Map, Flowのフラグの組み合わせ. SeqとMapはどちらか1つを指定しなければならない.</param>
#else
        /// <summary>
        /// Starts writing a new structure
        /// </summary>
        /// <param name="name">Name of the written structure. The structure can be accessed by this name when the storage is read. </param>
        /// <param name="structFlags">A combination one of the NodeType flags</param>
#endif
        public void StartWriteStruct(string name, NodeType structFlags)
        {
            Cv.StartWriteStruct(this, name, structFlags);
        }
#if LANG_JP
        /// <summary>
        /// 新しい構造体の書き込みを開始する
        /// </summary>
        /// <param name="name">書き込む構造体の名前．読み込む場合は，この名前で構造体にアクセスできる．</param>
        /// <param name="struct_flags">Seq, Map, Flowのフラグの組み合わせ. SeqとMapはどちらか1つを指定しなければならない.</param>
        /// <param name="type_name">オプションパラメータ - オブジェクトの型の名前． 
        /// XMLの場合，構造体開始タグのtype_id属性として書かれる． YAMLの場合，構造体名に続くコロンの後に書かれる． 
        /// 主にユーザオブジェクトと共に使われる．ストレージが読まれたとき，エンコードされた型名がオブジェクトの型を決定する.</param>
#else
        /// <summary>
        /// Starts writing a new structure
        /// </summary>
        /// <param name="name">Name of the written structure. The structure can be accessed by this name when the storage is read. </param>
        /// <param name="structFlags">A combination one of the NodeType flags</param>
        /// <param name="typeName">Optional parameter - the object type name. 
        /// In case of XML it is written as type_id attribute of the structure opening tag. 
        /// In case of YAML it is written after a colon following the structure name. Mainly it comes with user objects. 
        /// When the storage is read, the encoded type name is used to determine the object type. </param>
#endif
        public void StartWriteStruct(string name, NodeType structFlags, string typeName)
        {
            Cv.StartWriteStruct(this, name, structFlags, typeName);
        }
        #endregion
        #region Write
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルストレージに書き込む.
        /// </summary>
        /// <param name="name">書き込まれるオブジェクトの名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="ptr">オブジェクトへの参照</param>
#else
        /// <summary>
        /// Writes user object
        /// </summary>
        /// <param name="name">Name, of the written object. Should be null if and only if the parent structure is a sequence. </param>
        /// <param name="arr">Pointer to the object. </param>
#endif
        public void Write(string name, CvArr arr)
        {
            Cv.Write(this, name, arr);
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトをファイルストレージに書き込む.
        /// </summary>
        /// <param name="name">書き込まれるオブジェクトの名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="ptr">オブジェクトへの参照.</param>
        /// <param name="attributes">オブジェクトの属性．これは特定の型に対して固有である.</param>
#else
        /// <summary>
        /// Writes user object
        /// </summary>
        /// <param name="name">Name, of the written object. Should be null if and only if the parent structure is a sequence. </param>
        /// <param name="arr">Pointer to the object. </param>
        /// <param name="attributes">The attributes of the object. They are specific for each particular type.</param>
#endif
        public void Write(string name, CvArr arr, CvAttrList attributes)
        {
            Cv.Write(this, name, arr, attributes);
        }
        #endregion
        #region WriteComment
#if LANG_JP
        /// <summary>
        /// ファイルストレージにコメントを書き込む (eol_comment = false)．
        /// このコメントはデバッグや説明を記述するために使われるもので，読み込み時には読み飛ばされる．
        /// </summary>
        /// <param name="comment">一行または複数行の，書き込まれるコメ文字列</param>
#else
        /// <summary>
        /// Writes comment
        /// </summary>
        /// <param name="comment">The written comment, single-line or multi-line. </param>
#endif
        public void WriteComment(string comment)
        {
            Cv.WriteComment(this, comment);
        }
#if LANG_JP
        /// <summary>
        /// ファイルストレージにコメントを書き込む．
        /// このコメントはデバッグや説明を記述するために使われるもので，読み込み時には読み飛ばされる．
        /// </summary>
        /// <param name="comment">一行または複数行の，書き込まれるコメ文字列</param>
        /// <param name="eol_comment">trueの場合，この関数は現在の行の最後にコメントを入れようと試みる．
        /// falseで，コメントが複数，または現在の行の最後に納まらない場合は，コメントは新しい行から始められる．</param>
#else
        /// <summary>
        /// Writes comment
        /// </summary>
        /// <param name="comment">The written comment, single-line or multi-line. </param>
        /// <param name="eolComment">If true, the function tries to put the comment in the end of current line. 
        /// If the flag is false, if the comment is multi-line, or if it does not fit in the end of the current line, the comment starts from a new line. </param>
#endif
        public void WriteComment(string comment, bool eolComment)
        {
            Cv.WriteComment(this, comment, eolComment);
        }
        #endregion
        #region WriteFileNode
#if LANG_JP
        /// <summary>
        /// ファイルノードを他のファイルストレージに書き込む
        /// </summary>
        /// <param name="new_node_name">書き込み先ファイルストレージ内のファイルノードの新しい名前．元の名前を維持するためには，cvGetFileNodeName(node)を用いる．</param>
        /// <param name="node">書き込まれるノード．</param>
        /// <param name="embed">書き込まれるノードがコレクションで，このパラメータがtrueの場合，階層の余分なレベルは生成されない．
        /// その代わりに，nodeの全ての要素は現在書き込まれている構造体に書き込まれる．
        /// 当然，マップ要素はマップにのみ書き込まれ，シーケンス要素はシーケンスにのみ書き込まれる．</param>
#else
        /// <summary>
        /// Writes file node to another file storage
        /// </summary>
        /// <param name="newNodeName">New name of the file node in the destination file storage. To keep the existing name, use cvGetFileNodeName(node). </param>
        /// <param name="node">The written node </param>
        /// <param name="embed">If the written node is a collection and this parameter is true, no extra level of hierarchy is created. 
        /// Instead, all the elements of node are written into the currently written structure. 
        /// Of course, map elements may be written only to map, and sequence elements may be written only to sequence. </param>
#endif
        public void WriteFileNode(string newNodeName, CvFileNode node, bool embed)
        {
            Cv.WriteFileNode(this, newNodeName, node, embed);
        }
        #endregion
        #region WriteInt
#if LANG_JP
        /// <summary>
        /// 1つの整数値（名前あり，または無し）をファイルに書き込む.
        /// </summary>
        /// <param name="name">書き込まれる文字列の名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="value">書き込まれる値</param>
#else
        /// <summary>
        /// Writes an integer value
        /// </summary>
        /// <param name="name">Name of the written value. Should be NULL if and only if the parent structure is a sequence. </param>
        /// <param name="value">The written value. </param>
#endif
        public void WriteInt(string name, int value)
        {
            Cv.WriteInt(this, name, value);
        }
        #endregion
        #region WriteRawData
#if LANG_JP
        /// <summary>
        /// 複数の数値を書き込む
        /// </summary>
        /// <typeparam name="T">srcの要素の型</typeparam>
        /// <param name="src">書き込む配列</param>
        /// <param name="dt">フォーマット</param>
#else
        /// <summary>
        /// Writes multiple numbers
        /// </summary>
        /// <typeparam name="T">Type of the elements in src</typeparam>
        /// <param name="src">Written array </param>
        /// <param name="dt">Format</param>
#endif
        public void WriteRawData<T>(T[] src, string dt) where T : struct
        {
            Cv.WriteRawData(this, src, dt);
        }
        #endregion
        #region WriteReal
#if LANG_JP
        /// <summary>
        /// 単精度浮動小数点型の値（名前あり，または無し）をファイルに書き込む．
        /// 特別な値はエンコードされる：Not A NumberはNaN に，±Infinityは +.Inf (-.Inf) になる．
        /// </summary>
        /// <param name="name">書き込まれる文字列の名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="value">書き込まれる値</param>
#else
        /// <summary>
        /// Writes a floating-point value
        /// </summary>
        /// <param name="name">Name of the written value. Should be null if and only if the parent structure is a sequence. </param>
        /// <param name="value">The written value. </param>
#endif
        public void WriteReal(string name, double value)
        {
            Cv.WriteReal(this, name, value);
        }
        #endregion
        #region WriteString
#if LANG_JP
        /// <summary>
        /// 文字列をファイルストレージに書き込む.
        /// </summary>
        /// <param name="name">書き込まれる文字列の名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="str">書き込まれる文字列</param>
#else
        /// <summary>
        /// Writes a text string
        /// </summary>
        /// <param name="name">Name of the written string. Should be null if and only if the parent structure is a sequence. </param>
        /// <param name="str">The written text string. </param>
#endif
        public void WriteString(string name, string str)
        {
            Cv.WriteString(this, name, str);
        }
#if LANG_JP
        /// <summary>
        /// 文字列をファイルストレージに書き込む.
        /// </summary>
        /// <param name="name">書き込まれる文字列の名前．親の構造体がシーケンスの場合は，nullにしなければならない．</param>
        /// <param name="str">書き込まれる文字列</param>
        /// <param name="quote">trueの場合，書き込まれる文字列は必要かどうかに関わらず引用符で挟まれる．
        /// falseの場合，必要な場合にのみ引用符が使われる（例えば，文字列が数字で始まっていたり，スペースを含む場合）．</param>
#else
        /// <summary>
        /// Writes a text string
        /// </summary>
        /// <param name="name">Name of the written string. Should be null if and only if the parent structure is a sequence. </param>
        /// <param name="str">The written text string. </param>
        /// <param name="quote">If true, the written string is put in quotes, regardless of whether they are required or not. 
        /// Otherwise, if the flag is false, quotes are used only when they are required (e.g. when the string starts with a digit or contains spaces). </param>
#endif
        public void WriteString(string name, string str, bool quote)
        {
            Cv.WriteString(this, name, str, quote);
        }
        #endregion
        #endregion
    }
}
