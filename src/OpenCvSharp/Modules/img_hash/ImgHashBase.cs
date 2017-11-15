using System;

namespace OpenCvSharp.ImgHash
{
    /// <inheritdoc />
    /// <summary>
    /// The base class for image hash algorithms
    /// </summary>
    public abstract class ImgHashBase : Algorithm
    {
        /// <summary>
        /// Computes hash of the input image
        /// </summary>
        /// <param name="inputArr">input image want to compute hash value</param>
        /// <param name="outputArr">hash of the image</param>
        /// <returns></returns>
        public virtual void Compute(InputArray inputArr, OutputArray outputArr)
        {
            ThrowIfDisposed();

            if (inputArr == null)
                throw new ArgumentNullException(nameof(inputArr));
            if (outputArr == null)
                throw new ArgumentNullException(nameof(outputArr));

            inputArr.ThrowIfDisposed();
            outputArr.ThrowIfNotReady();

            NativeMethods.img_hash_ImgHashBase_compute(ptr, inputArr.CvPtr, outputArr.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(inputArr);
            outputArr.Fix();
        }

        /// <summary>
        /// Compare the hash value between inOne and inTwo
        /// </summary>
        /// <param name="hashOne">Hash value one</param>
        /// <param name="hashTwo">Hash value two</param>
        /// <returns>value indicate similarity between inOne and inTwo, the meaning of the value vary from algorithms to algorithms</returns>
        public virtual double Compare(InputArray hashOne, InputArray hashTwo)
        {
            ThrowIfDisposed();

            if (hashOne == null)
                throw new ArgumentNullException(nameof(hashOne));
            if (hashTwo == null)
                throw new ArgumentNullException(nameof(hashTwo));

            hashOne.ThrowIfDisposed();
            hashTwo.ThrowIfDisposed();

            var ret = NativeMethods.img_hash_ImgHashBase_compare(ptr, hashOne.CvPtr, hashTwo.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(hashOne);
            GC.KeepAlive(hashOne);
            return ret;
        }
    }
}
