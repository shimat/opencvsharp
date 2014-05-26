using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Information about the image topology for cv::findContours
    /// </summary>
    public class HiearchyIndex
    {
        /// <summary>
        /// 
        /// </summary>
        public int Next { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Previous { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Child { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HiearchyIndex()
        {
            Next = 0;
            Previous = 0;
            Child = 0;
            Parent = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="previous"></param>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        public HiearchyIndex(int next, int previous, int child, int parent)
        {
            Next = next;
            Previous = previous;
            Child = child;
            Parent = parent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static HiearchyIndex FromVec4i(Vec4i vec)
        {
            return new HiearchyIndex
            {
                Next = vec.Item0,
                Previous = vec.Item1,
                Child = vec.Item2,
                Parent = vec.Item3
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec4i ToVec4i()
        {
            return new Vec4i(Next, Previous, Child, Parent);
        }
    }
}
