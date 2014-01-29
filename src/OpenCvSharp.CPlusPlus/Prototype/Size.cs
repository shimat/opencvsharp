using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    public struct Size
    {
        public int Width;
        public int Height;

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public Size(double width, double height)
        {
            Width = (int)width;
            Height = (int)height;
        }
    }
}
