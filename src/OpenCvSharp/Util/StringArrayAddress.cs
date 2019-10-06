using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Util
{
    /// <inheritdoc />
    /// <summary>
    /// Class to get address of string array
    /// </summary>
    public class StringArrayAddress : ArrayAddress2<byte>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="stringEnumerable"></param>
        public StringArrayAddress(IEnumerable<string> stringEnumerable)
            : base(ToJaggedByteArray(stringEnumerable))
        {
        }

        private static byte[][] ToJaggedByteArray(IEnumerable<string> stringEnumerable)
        {
            if (stringEnumerable == null)
                throw new ArgumentNullException(nameof(stringEnumerable));

            var byteList = new List<byte[]>();
            foreach (var s in stringEnumerable)
            {
                byteList.Add(Encoding.ASCII.GetBytes(s));
            }
            return byteList.ToArray();
        }
    }
}