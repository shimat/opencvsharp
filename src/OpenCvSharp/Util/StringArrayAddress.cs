using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Util
{
    /// <summary>
    /// Class to get address of string array
    /// </summary>
    public class StringArrayAddress : ArrayAddress2<byte>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringArray"></param>
        public StringArrayAddress(string[] stringArray)
        {
            var byteList = new List<byte[]>();
            for (int i = 0; i < stringArray.Length; i++)
            {
                byteList.Add(Encoding.ASCII.GetBytes(stringArray[i]));
            }
            Initialize(byteList.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        public StringArrayAddress(IEnumerable<string> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
        }
    }
}