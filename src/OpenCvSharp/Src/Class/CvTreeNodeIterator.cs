/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// ツリーノードのイテレータのためのクラス
    /// </summary>

#else
    /// <summary>
    /// Class that is used to traverse trees
    /// </summary>
#endif
    [StructLayout(LayoutKind.Sequential)]
    public class CvTreeNodeIterator
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        protected IntPtr node;
        /// <summary>
        /// 
        /// </summary>
        protected int level;
        /// <summary>
        /// 
        /// </summary>
        protected int max_level;

        /// <summary>
        /// 
        /// </summary>
        public IntPtr Node
        {
            get { return node; }
            protected set { node = value; }
        }       
        /// <summary>
        /// 
        /// </summary>
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MaxLevel
        {
            get { return max_level; }
            set { max_level = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CvTreeNodeIterator()
        {
            node = default(IntPtr);
            level = default(int);
            max_level = default(int);
        }
        /// <summary>
        /// Construct by cvInitTreeNodeIterator
        /// </summary>
        /// <param name="first"></param>
        /// <param name="max_level"></param>
        public CvTreeNodeIterator(IntPtr first, int max_level)
        {
            if (first == IntPtr.Zero)
            {
                throw new ArgumentNullException("first");
            }
            CvInvoke.cvInitTreeNodeIterator(this, first, max_level);
        }
        /// <summary>
        /// Construct by cvInitTreeNodeIterator
        /// </summary>
        /// <param name="first"></param>
        /// <param name="max_level"></param>
        public CvTreeNodeIterator(CvArr first, int max_level)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            CvInvoke.cvInitTreeNodeIterator(this, first.CvPtr, max_level);
        }
        #endregion

        #region Methods 
        #region NextTreeNode
#if LANG_JP
        /// <summary>
        /// 現在のノードを返し，イテレータを次のノードに移動させる．
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns the currently observed node and moves iterator toward the next node
        /// </summary>
        /// <returns></returns>
#endif
        public IntPtr NextTreeNode()
        {
            return Cv.NextTreeNode(this);
        }
#if LANG_JP
        /// <summary>
        /// 現在のノードを返し，イテレータを次のノードに移動させる．
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns the currently observed node and moves iterator toward the next node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
#endif
        public T NextTreeNode<T>() where T : CvArr
        {
            return Cv.NextTreeNode<T>(this);
        }
        #endregion
        #region PrevTreeNode
#if LANG_JP
        /// <summary>
        /// 現在のノードを返し，イテレータを前のノードに移動させる．
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns the currently observed node and moves iterator toward the previous node
        /// </summary>
        /// <returns></returns>
#endif
        public IntPtr PrevTreeNode()
        {
            return Cv.PrevTreeNode(this);
        }
#if LANG_JP
        /// <summary>
        /// 現在のノードを返し，イテレータを前のノードに移動させる．
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns the currently observed node and moves iterator toward the previous node
        /// </summary>
        /// <returns></returns>
#endif
        public T PrevTreeNode<T>() where T : CvArr
        {
            return Cv.PrevTreeNode<T>(this);
        }
        #endregion
        #endregion
    }
}
