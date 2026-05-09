#if ENABLED_CUDA
using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    public sealed class ORB : Feature2DAsync
    {
        // GpuMat layout constants for keypoints row indices
        public const int XRow = 0;
        public const int YRow = 1;
        public const int ResponseRow = 2;
        public const int AngleRow = 3;
        public const int OctaveRow = 4;
        public const int SizeRow = 5;
        public const int RowsCount = 6;

        private ORB(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_ORB_delete(p)))
        {
        }

        public static ORB Create(
            int nfeatures = 500, float scaleFactor = 1.2f, int nlevels = 8, int edgeThreshold = 31,
            int firstLevel = 0, int wtaK = 2, ORBScoreType scoreType = ORBScoreType.Harris,
            int patchSize = 31, int fastThreshold = 20, bool blurForDescriptor = false)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_ORB_create(
                    nfeatures, scaleFactor, nlevels, edgeThreshold, firstLevel,
                    wtaK, (int)scoreType, patchSize, fastThreshold, blurForDescriptor ? 1 : 0, out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_ORB_get(smartPtr, out var rawPtr));

            return new ORB(smartPtr, rawPtr);
        }


        public bool BlurForDescriptor
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_getBlurForDescriptor(RawPtr, out int val)); 
                GC.KeepAlive(this);
                return val != 0;
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_setBlurForDescriptor(RawPtr, value ? 1 : 0)); 
                GC.KeepAlive(this); 
            }
        }

        public int EdgeThreshold
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_getEdgeThreshold(RawPtr, out int val)); 
                GC.KeepAlive(this);
                return val; 
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_setEdgeThreshold(RawPtr, value)); 
                GC.KeepAlive(this);
            }
        }

        public int FastThreshold
        {
            get 
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_ORB_getFastThreshold(RawPtr, out int val));
                GC.KeepAlive(this);
                return val;
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_setFastThreshold(RawPtr, value)); 
                GC.KeepAlive(this); 
            }
        }

        public int FirstLevel
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_getFirstLevel(RawPtr, out int val)); 
                GC.KeepAlive(this);
                return val; 
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_setFirstLevel(RawPtr, value));
                GC.KeepAlive(this);
            }
        }

        public int MaxFeatures
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_getMaxFeatures(RawPtr, out int val)); 
                GC.KeepAlive(this); 
                return val;
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_setMaxFeatures(RawPtr, value)); 
                GC.KeepAlive(this); 
            }
        }

        public int NLevels
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_getNLevels(RawPtr, out int val));
                GC.KeepAlive(this); 
                return val; 
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_setNLevels(RawPtr, value));
                GC.KeepAlive(this);
            }
        }

        public int PatchSize
        {
            get
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_getPatchSize(RawPtr, out int val)); 
                GC.KeepAlive(this); 
                return val;
            }
            set
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_setPatchSize(RawPtr, value)); 
                GC.KeepAlive(this);
            }
        }

        public double ScaleFactor
        {
            get
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_ORB_getScaleFactor(RawPtr, out double val)); 
                GC.KeepAlive(this); 
                return val; }
            set
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_ORB_setScaleFactor(RawPtr, value));
                GC.KeepAlive(this);
            }
        }

        public ORBScoreType ScoreType
        {
            get 
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_ORB_getScoreType(RawPtr, out int val));
                GC.KeepAlive(this); return (ORBScoreType)val; }
            set
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_ORB_setScoreType(RawPtr, (int)value)); 
                GC.KeepAlive(this); 
            }
        }

        public int WtaK
        {
            get
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_ORB_getWTA_K(RawPtr, out int val)); 
                GC.KeepAlive(this); 
                return val; 
            }
            set
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_ORB_setWTA_K(RawPtr, value));
                GC.KeepAlive(this);
            }
        }
    }
}
#endif
