using System;

namespace OpenCvSharp.Face
{
    /// <summary>
    /// Abstract base class for all facemark models.
    /// 
    /// All facemark models in OpenCV are derived from the abstract base class Facemark, which 
    /// provides a unified access to all facemark algorithms in OpenCV.
    /// To utilize this API in your program, please take a look at the @ref tutorial_table_of_content_facemark
    /// </summary>
    public abstract class Facemark : Algorithm
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="fn"></param>
        public override void Read(FileNode fn)
        {
            ThrowIfDisposed();
            if (fn == null)
                throw new ArgumentNullException(nameof(fn));
           
            NativeMethods.face_Facemark_read(ptr, fn.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(fn);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="fs"></param>
        public override void Write(FileStorage fs)
        {
            ThrowIfDisposed();
            if (fs == null)
                throw new ArgumentNullException(nameof(fs));

            NativeMethods.face_Facemark_write(ptr, fs.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(fs);
        }

        /*
        /// <summary>
        /// Add one training sample to the trainer.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="landmarks">The ground-truth of facial landmarks points corresponds to the image.</param>
        /// <returns></returns>
        public virtual bool AddTrainingSample(InputArray image, InputArray landmarks)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (landmarks == null)
                throw new ArgumentNullException(nameof(landmarks));
            image.ThrowIfDisposed();
            landmarks.ThrowIfDisposed();

            int ret = NativeMethods.face_Facemark_addTrainingSample(ptr, image.CvPtr, landmarks.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(landmarks);

            return ret != 0;
        }

        /// <summary>
        /// Trains a Facemark algorithm using the given dataset.
        /// Before the training process, training samples should be added to the trainer 
        /// using face::addTrainingSample function.
        /// </summary>
        /// <param name="parameters">Optional extra parameters (algorithm dependent).</param>
        public virtual void Training(IntPtr parameters = default)
        {
            ThrowIfDisposed();
            NativeMethods.face_Facemark_training(ptr, parameters);
            GC.KeepAlive(this);
        }
        */

        /// <summary>
        ///  A function to load the trained model before the fitting process.
        /// </summary>
        /// <param name="model">A string represent the filename of a trained model.</param>
        public virtual void LoadModel(string model)
        {
            ThrowIfDisposed();
            NativeMethods.face_Facemark_loadModel(ptr, model);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Trains a Facemark algorithm using the given dataset.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="faces">Output of the function which represent region of interest of the detected faces. Each face is stored in cv::Rect container.</param>
        /// <param name="landmarks">The detected landmark points for each faces.</param>
        /// <returns></returns>
        public virtual bool Fit(
            InputArray image,
            InputArray faces,
            InputOutputArray landmarks)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (faces == null)
                throw new ArgumentNullException(nameof(faces));
            if (landmarks == null)
                throw new ArgumentNullException(nameof(landmarks));
            image.ThrowIfDisposed();
            faces.ThrowIfDisposed();
            landmarks.ThrowIfNotReady();

            int ret = NativeMethods.face_Facemark_fit(ptr, image.CvPtr, faces.CvPtr, landmarks.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(image);
            landmarks.Fix();

            return ret != 0;
        }

        /*
        /// <summary>
        /// Set a user defined face detector for the Facemark algorithm.
        /// </summary>
        /// <param name="detector">The user defined face detector function</param>
        /// <param name="userData">Detector parameters</param>
        /// <returns></returns>
        public virtual bool SetFaceDetector(IntPtr detector, IntPtr userData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Detect faces from a given image using default or user defined face detector.
        /// Some Algorithm might not provide a default face detector.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="faces">Output of the function which represent region of interest of the detected faces. Each face is stored in cv::Rect container.</param>
        /// <returns></returns>
        public virtual bool GetFaces(InputArray image, OutputArray faces)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (faces == null)
                throw new ArgumentNullException(nameof(faces));
            image.ThrowIfDisposed();
            faces.ThrowIfDisposed();

            int ret = NativeMethods.face_Facemark_getFaces_OutputArray(ptr, image.CvPtr, faces.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(image);
            faces.Fix();

            return ret != 0;
        }
        
        /// <summary>
        /// Detect faces from a given image using default or user defined face detector.
        /// Some Algorithm might not provide a default face detector.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="faces">Output of the function which represent region of interest of the detected faces. Each face is stored in cv::Rect container.</param>
        /// <returns></returns>
        public virtual bool GetFaces(InputArray image, out Rect[] faces)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            int ret;
            using (var facesVec = new VectorOfRect())
            {
                ret = NativeMethods.face_Facemark_getFaces_vectorOfRect(ptr, image.CvPtr, facesVec.CvPtr);
                faces = facesVec.ToArray();
            }

            GC.KeepAlive(this);
            GC.KeepAlive(image);

            return ret != 0;
        }
        */

        /// <summary>
        /// Get data from an algorithm
        /// </summary>
        /// <param name="items"> The obtained data, algorithm dependent.</param>
        /// <returns></returns>
        public virtual bool GetData(IntPtr items)
        {
            throw new NotImplementedException();
        }
    }
}