using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MatExpr : DisposableCvObject
    {
        private bool disposed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal MatExpr(IntPtr ptr)
        {
            this.ptr = ptr;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                Console.WriteLine("MatExpr disposed");
                CppInvoke.core_MatExpr_delete(ptr);
                disposed = true;
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator Mat(MatExpr self)
        {
            try
            {
                IntPtr retPtr = CppInvoke.core_MatExpr_toMat(self.ptr);
                Mat retVal = new Mat(retPtr);
                return retVal;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mat ToMat()
        {
            return (Mat)this;
        }
    }
}
