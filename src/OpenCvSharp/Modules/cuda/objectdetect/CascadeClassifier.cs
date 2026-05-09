using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Cascade classifier class for object detection.
    /// </summary>
    public class CascadeClassifier : Algorithm
    {
        protected CascadeClassifier(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_delete(p)))
        {
        }

        public static CascadeClassifier Create(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException(nameof(filename));

            NativeMethods.HandleException(
                NativeMethods.cuda_createCascadeClassifier(filename, out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_CascadeClassifier_get(smartPtr, out var rawPtr));

            return new CascadeClassifier(smartPtr, rawPtr);
        }

        /// <summary>
        /// Detects objects of different sizes in the input image. The detected objects are returned as a GpuMat buffer.
        /// </summary>
        public virtual void DetectMultiScale(OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.OutputArray objects, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (image is null) throw new ArgumentNullException(nameof(image));
            if (objects is null) throw new ArgumentNullException(nameof(objects));

            image.ThrowIfDisposed();
            objects.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_CascadeClassifier_detectMultiScale(RawPtr, image.CvPtr, objects.CvPtr, stream?.CvPtr??IntPtr.Zero));

            objects.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(image);
        }

        /// <summary>
        /// Converts the GpuMat buffer returned by DetectMultiScale into a C# Rect array.
        /// </summary>
        public virtual Rect[] Convert(OpenCvSharp.Cuda.OutputArray gpuObjects)
        {
            if (gpuObjects is null) throw new ArgumentNullException(nameof(gpuObjects));
            gpuObjects.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_CascadeClassifier_convert(RawPtr, gpuObjects.CvPtr, out IntPtr outRects, out int outCount));

            GC.KeepAlive(this);
            GC.KeepAlive(gpuObjects);

            if (outCount == 0 || outRects == IntPtr.Zero)
                return Array.Empty<Rect>();

            // Marshal C++ array into C# Rect[]
            Rect[] result = new Rect[outCount];
            int structSize = Marshal.SizeOf<Rect>();
            for (int i = 0; i < outCount; i++)
            {
                IntPtr currentPtr = new IntPtr(outRects.ToInt64() + (i * structSize));
                result[i] = Marshal.PtrToStructure<Rect>(currentPtr);
            }

            // Clean up C++ array
            NativeMethods.HandleException(NativeMethods.cuda_FreeRectArray(outRects));

            return result;
        }

        /// <summary>
        /// Convenience method: Automatically detects and converts to Rect[] array.
        /// </summary>
        public Rect[] DetectMultiScale(GpuMat image)
        {
            using var gpuObjects = new GpuMat();
            DetectMultiScale(image, gpuObjects);
            return Convert(gpuObjects);
        }
        public Size ClassifierSize
        {
            get { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_getClassifierSize(RawPtr, out Size val)); 
                GC.KeepAlive(this); 
                return val; 
            }
        }

        public bool FindLargestObject
        {
            get { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_getFindLargestObject(RawPtr, out int val)); 
                GC.KeepAlive(this); 
                return val != 0; 
            }
            set { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_setFindLargestObject(RawPtr, value ? 1 : 0));
                GC.KeepAlive(this); 
            }
        }

        public int MaxNumObjects
        {
            get { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_getMaxNumObjects(RawPtr, out int val)); 
                GC.KeepAlive(this);
                return val; 
            }
            set { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_setMaxNumObjects(RawPtr, value)); 
                GC.KeepAlive(this); 
            }
        }

        public Size MaxObjectSize
        {
            get { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_getMaxObjectSize(RawPtr, out Size val)); 
                GC.KeepAlive(this);
                return val; 
            }
            set { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_setMaxObjectSize(RawPtr, value)); 
                GC.KeepAlive(this); 
            }
        }

        public int MinNeighbors
        {
            get { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_getMinNeighbors(RawPtr, out int val)); 
                GC.KeepAlive(this);
                return val; 
            }
            set { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_setMinNeighbors(RawPtr, value)); 
                GC.KeepAlive(this);
            }
        }

        public Size MinObjectSize
        {
            get { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_getMinObjectSize(RawPtr, out Size val)); 
                GC.KeepAlive(this);
                return val;
            }
            set { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_setMinObjectSize(RawPtr, value)); 
                GC.KeepAlive(this);
            }
        }

        public double ScaleFactor
        {
            get { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_getScaleFactor(RawPtr, out double val)); 
                GC.KeepAlive(this);
                return val; 
            }
            set { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_CascadeClassifier_setScaleFactor(RawPtr, value)); 
                GC.KeepAlive(this); 
            }
        }
    }
}
