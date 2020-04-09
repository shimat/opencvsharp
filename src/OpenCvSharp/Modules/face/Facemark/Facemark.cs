using System;
// ReSharper disable UnusedMember.Global

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
        /// <summary>
        ///  A function to load the trained model before the fitting process.
        /// </summary>
        /// <param name="model">A string represent the filename of a trained model.</param>
        public virtual void LoadModel(string model)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.face_Facemark_loadModel(ptr, model));
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
            out Point2f[][] landmarks)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (faces == null)
                throw new ArgumentNullException(nameof(faces));
            image.ThrowIfDisposed();
            faces.ThrowIfDisposed();

            int ret;
            using (var landmarx = new VectorOfVectorPoint2f())
            {
                NativeMethods.HandleException(
                    NativeMethods.face_Facemark_fit(ptr, image.CvPtr, faces.CvPtr, landmarx.CvPtr, out ret));
                landmarks = landmarx.ToArray();
            }

            GC.KeepAlive(this);
            GC.KeepAlive(image);

            return ret != 0;
        }
    }
}