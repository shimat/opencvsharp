using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
#else
    /// <summary>
    /// CvLineIterator
    /// </summary>
#endif
    public class CvLineIterator : DisposableCvObject, IEnumerable<CvScalar>
    {
        #region Fields
        private int _count;
        private CvArr _image;
        private CvPoint _pt1;
        private CvPoint _pt2;
        private PixelConnectivity _connectivity;
        private bool _left_to_right;
        #endregion

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 構造体の分のメモリを割り当てて初期化
        /// </summary>
#else
        /// <summary>
        /// Constructor
        /// </summary>
#endif
        public CvLineIterator()
        {
            this.ptr = base.AllocMemory(SizeOf);
            this._count = -1;
        }

#if LANG_JP
        /// <summary>
        /// ラインイテレータを初期化する
        /// </summary>
        /// <param name="image">対象画像</param>
        /// <param name="pt1">線分の一つ目の端点</param>
        /// <param name="pt2">線分のニつ目の端点</param>
        /// <returns></returns> 
#else
        /// <summary>
        /// Initializes line iterator
        /// </summary>
        /// <param name="image">Image to sample the line from.  </param>
        /// <param name="pt1">First ending point of the line segment. </param>
        /// <param name="pt2">Second ending point of the line segment. </param>
        /// <returns>The function cvInitLineIterator initializes the line iterator and returns the number of pixels between two end points. Both points must be inside the image. After the iterator has been initialized, all the points on the raster line that connects the two ending points may be retrieved by successive calls of NextLinePoint point. The points on the line are calculated one by one using 4-connected or 8-connected Bresenham algorithm.</returns> 
#endif
        public CvLineIterator(CvArr image, CvPoint pt1, CvPoint pt2)
            : this(image, pt1, pt2, PixelConnectivity.Connectivity_8, false)
        {
        }
#if LANG_JP
        /// <summary>
        /// ラインイテレータを初期化する
        /// </summary>
        /// <param name="image">対象画像</param>
        /// <param name="pt1">線分の一つ目の端点</param>
        /// <param name="pt2">線分のニつ目の端点</param>
        /// <param name="connectivity">走査した線分の接続性．4または8</param>
        /// <returns></returns> 
#else
        /// <summary>
        /// Initializes line iterator
        /// </summary>
        /// <param name="image">Image to sample the line from.  </param>
        /// <param name="pt1">First ending point of the line segment. </param>
        /// <param name="pt2">Second ending point of the line segment. </param>
        /// <param name="connectivity">The scanned line connectivity, 4 or 8. </param>
        /// <returns>The function cvInitLineIterator initializes the line iterator and returns the number of pixels between two end points. Both points must be inside the image. After the iterator has been initialized, all the points on the raster line that connects the two ending points may be retrieved by successive calls of NextLinePoint point. The points on the line are calculated one by one using 4-connected or 8-connected Bresenham algorithm.</returns> 
#endif
        public CvLineIterator(CvArr image, CvPoint pt1, CvPoint pt2, PixelConnectivity connectivity)
            : this(image, pt1, pt2, connectivity, false)
        {
        }
#if LANG_JP
        /// <summary>
        /// ラインイテレータを初期化する
        /// </summary>
        /// <param name="image">対象画像</param>
        /// <param name="pt1">線分の一つ目の端点</param>
        /// <param name="pt2">線分のニつ目の端点</param>
        /// <param name="connectivity">走査した線分の接続性．4または8</param>
        /// <param name="left_to_right">pt1とpt2とは無関係に線分をいつも左から右に走査する(true)か， pt1からpt2への決まった方向で走査するか(false)を指定するフラグ. </param>
        /// <returns></returns> 
#else
        /// <summary>
        /// Initializes line iterator
        /// </summary>
        /// <param name="image">Image to sample the line from.  </param>
        /// <param name="pt1">First ending point of the line segment. </param>
        /// <param name="pt2">Second ending point of the line segment. </param>
        /// <param name="connectivity">The scanned line connectivity, 4 or 8. </param>
        /// <param name="left_to_right">The flag, indicating whether the line should be always scanned from the left-most point to the right-most out of pt1 and pt2 (left_to_right=true), or it is scanned in the specified order, from pt1 to pt2 (left_to_right=false). </param>
        /// <returns>The function cvInitLineIterator initializes the line iterator and returns the number of pixels between two end points. Both points must be inside the image. After the iterator has been initialized, all the points on the raster line that connects the two ending points may be retrieved by successive calls of NextLinePoint point. The points on the line are calculated one by one using 4-connected or 8-connected Bresenham algorithm.</returns> 
#endif
        public CvLineIterator(CvArr image, CvPoint pt1, CvPoint pt2, PixelConnectivity connectivity, bool left_to_right)
            : this()
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            Initialize(image, pt1, pt2, connectivity, left_to_right);
        }

        /// <summary>
        /// Initializes line iterator
        /// </summary>
        /// <param name="image">Image to sample the line from.  </param>
        /// <param name="pt1">First ending point of the line segment. </param>
        /// <param name="pt2">Second ending point of the line segment. </param>
        /// <param name="connectivity">The scanned line connectivity, 4 or 8. </param>
        /// <param name="left_to_right">The flag, indicating whether the line should be always scanned from the left-most point to the right-most out of pt1 and pt2 (left_to_right=true), or it is scanned in the specified order, from pt1 to pt2 (left_to_right=false). </param>
        /// <returns>The function cvInitLineIterator initializes the line iterator and returns the number of pixels between two end points. Both points must be inside the image. After the iterator has been initialized, all the points on the raster line that connects the two ending points may be retrieved by successive calls of NextLinePoint point. The points on the line are calculated one by one using 4-connected or 8-connected Bresenham algorithm.</returns> 
        private void Initialize(CvArr image, CvPoint pt1, CvPoint pt2, PixelConnectivity connectivity, bool left_to_right)
        {
            this._image = image;
            this._pt1 = pt1;
            this._pt2 = pt2;
            this._connectivity = connectivity;
            this._left_to_right = left_to_right;
            this._count = NativeMethods.cvInitLineIterator(image.CvPtr, pt1, pt2, this.CvPtr, connectivity, left_to_right);
        }
        /// <summary>
        /// Initializes line iterator
        /// </summary>
        private void Initialize()
        {
            Initialize(_image, _pt1, _pt2, _connectivity, _left_to_right);
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
            // 親の解放処理
            base.Dispose(disposing);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvLineIterator) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvLineIterator));

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int Count
        {
            get { return _count; }
            private set { _count = value; }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IntPtr Ptr
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvLineIterator*)ptr)->ptr);
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLineIterator*)ptr)->ptr = (byte*)value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int Err
        {
            get
            {
                unsafe
                {
                    return ((WCvLineIterator*)ptr)->err;
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLineIterator*)ptr)->err = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int PlusDelta
        {
            get
            {
                unsafe
                {
                    return ((WCvLineIterator*)ptr)->plus_delta;
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLineIterator*)ptr)->plus_delta = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int MinusDelta
        {
            get
            {
                unsafe
                {
                    return ((WCvLineIterator*)ptr)->minus_delta;
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLineIterator*)ptr)->minus_delta = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int PlusStep
        {
            get
            {
                unsafe
                {
                    return ((WCvLineIterator*)ptr)->plus_step;
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLineIterator*)ptr)->plus_step = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int MinusStep
        {
            get
            {
                unsafe
                {
                    return ((WCvLineIterator*)ptr)->minus_step;
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLineIterator*)ptr)->minus_step = value;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// CV_NEXT_LINE_POINT
        /// </summary>
#else
        /// <summary>
        /// CV_NEXT_LINE_POINT
        /// </summary>
#endif
        public void NextLinePoint()
        {
            Cv.NEXT_LINE_POINT(this);
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// Gets the value of the current point
        /// </summary>
#endif
        public CvScalar CurrentPoint()//out CvPoint current_coordinates)
        {
            if (_image == null)
            {
                throw new NotSupportedException("Not initialized iterator");
            }

            /*int offset = Ptr.ToInt32() - _image.ImageData.ToInt32();
            int y = offset / _image.WidthStep;
            int x = (offset - y * _image.WidthStep) / (3 * _image.ElemDepth);
            current_coordinates = new CvPoint(x, y);*/
            int ch = _image.ElemChannels;
            CvScalar result = new CvScalar();
            
                IntPtr ptr = Ptr;
                for (int j = 0; j < ch; j++) unsafe
                {
                    switch (_image.ElemType) 
                    {
                        case MatrixType.U8C1:
                        case MatrixType.U8C2:
                        case MatrixType.U8C3:
                        case MatrixType.U8C4:
                            result[j] = ((byte*)ptr)[j]; break;
                        case MatrixType.S8C1:
                        case MatrixType.S8C2:
                        case MatrixType.S8C3:
                        case MatrixType.S8C4:
                            result[j] = ((sbyte*)ptr)[j]; break;
                        case MatrixType.U16C1:
                        case MatrixType.U16C2:
                        case MatrixType.U16C3:
                        case MatrixType.U16C4:
                            result[j] = ((ushort*)ptr)[j]; break;
                        case MatrixType.S16C1:
                        case MatrixType.S16C2:
                        case MatrixType.S16C3:
                        case MatrixType.S16C4:
                            result[j] = ((short*)ptr)[j]; break;
                        case MatrixType.F32C1:
                        case MatrixType.F32C2:
                        case MatrixType.F32C3:
                        case MatrixType.F32C4:
                            result[j] = ((float*)ptr)[j]; break;
                        case MatrixType.S32C1:
                        case MatrixType.S32C2:
                        case MatrixType.S32C3:
                        case MatrixType.S32C4:
                            result[j] = ((int*)ptr)[j]; break;
                        case MatrixType.F64C1:
                        case MatrixType.F64C2:
                        case MatrixType.F64C3:
                        case MatrixType.F64C4:
                            result[j] = ((double*)ptr)[j]; break;
                        default:
                            throw new OpenCvSharpException();
                    }
                    
                }

                return result;
        }
        #endregion

        #region IEnumerable<T> Members
        /// <summary>
        /// Supports a simple iteration over a generic collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<CvScalar> GetEnumerator()
        {
            if (_image == null)
            {
                throw new NotSupportedException("Not initialized iterator");
            }

            Initialize();

            for (int i = 0; i < _count; i++)
            {                         
                yield return CurrentPoint();
                Cv.NEXT_LINE_POINT(this);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
