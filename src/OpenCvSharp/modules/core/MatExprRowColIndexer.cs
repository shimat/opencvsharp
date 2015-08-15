using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MatExprRowColIndexer
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly MatExpr parent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        protected internal MatExprRowColIndexer(MatExpr parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public abstract MatExpr this[int pos] { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual MatExpr Get(int pos)
        {
            return this[pos];
        }
    }
}
