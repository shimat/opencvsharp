using System;
using System.Collections.Generic;

namespace OpenCvSharp.Util
{
    /// <summary>
    /// Used for manage the resources of OpenCVSharp, like Mat, MatExpr, etc.
    /// </summary>
    public class ResourcesTracker : IDisposable
    {
        private ISet<DisposableObject> trackedObjects = new HashSet<DisposableObject>();
        private object asyncLock = new object();

        /// <summary>
        /// Trace the object obj, and return it
        /// </summary>
        /// <typeparam name="TCV"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TCV T<TCV>(TCV obj) where TCV : DisposableObject
        {
            if (obj == null)
            {
                return obj;
            }
            lock (asyncLock)
            {
                trackedObjects.Add(obj);
            }
            return obj;
        }

        /// <summary>
        /// Trace an array of objects , and return them
        /// </summary>
        /// <typeparam name="TCV"></typeparam>
        /// <param name="objs"></param>
        /// <returns></returns>

        public TCV[] T<TCV>(TCV[] objs) where TCV : DisposableObject
        {
            foreach (var obj in objs)
            {
                T(obj);
            }
            return objs;
        }

        /// <summary>
        /// Create a new Mat instance, and trace it
        /// </summary>
        /// <returns></returns>

        public Mat NewMat()
        {
            return T(new Mat());
        }

        /// <summary>
        ///  Create a new Mat instance, and trace it
        /// </summary>
        /// <param name="size">size</param>
        /// <param name="matType">matType</param>
        /// <param name="scalar">scalar</param>
        /// <returns></returns>

        public Mat NewMat(Size size, MatType matType, Scalar scalar)
        {
            return T(new Mat(size, matType, scalar));
        }

        /// <summary>
        /// Dispose all traced objects
        /// </summary>

        public void Dispose()
        {
            lock (asyncLock)
            {
                foreach (var obj in trackedObjects)
                {
                    if (obj.IsDisposed == false)
                    {
                        obj.Dispose();
                    }
                }
                trackedObjects.Clear();
            }
        }
    }
}
