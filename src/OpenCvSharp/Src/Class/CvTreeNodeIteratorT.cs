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
    /// <typeparam name="T"></typeparam>
#else
    /// <summary>
    /// Class that is used to traverse trees
    /// </summary>
    /// <typeparam name="T"></typeparam>
#endif
    [StructLayout(LayoutKind.Sequential)]
    public class CvTreeNodeIterator<T> : CvTreeNodeIterator, IEnumerable<T>
        where T : CvArr
    {
        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CvTreeNodeIterator()
             : base()
        {
        }
        /// <summary>
        /// Construct by cvInitTreeNodeIterator
        /// </summary>
        /// <param name="first"></param>
        /// <param name="max_level"></param>
        public CvTreeNodeIterator(IntPtr first, int max_level)
            : base(first, max_level)
        {
        }
        /// <summary>
        /// Construct by cvInitTreeNodeIterator
        /// </summary>
        /// <param name="first"></param>
        /// <param name="max_level"></param>
        public CvTreeNodeIterator(CvArr first, int max_level)
            : base(first, max_level)
        {
        }
        /// <summary>
        /// Convert to generic class
        /// </summary>
        /// <param name="it"></param>
        public CvTreeNodeIterator(CvTreeNodeIterator it)
        {
            node = it.Node;
            level = it.Level;
            max_level = it.MaxLevel;
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
        public new T NextTreeNode() 
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
        public new T PrevTreeNode() 
        {
            return Cv.PrevTreeNode<T>(this);
        }
        #endregion
        #endregion

        #region IEnumerable<t> メンバ
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            T elem;
            while ((elem = Cv.NextTreeNode<T>(this)) != null)
            {
                yield return elem;
            }
        }
        #endregion

        #region IEnumerable メンバ
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
