using System;
using System.Collections.Generic;

namespace OpenCvSharp.Tests
{
    public class DoubleEqualityComparer : IEqualityComparer<double>
    {
        private readonly double epsilon;

        public DoubleEqualityComparer(double epsilon)
        {
            if (epsilon < 0)
                throw new ArgumentException("epsilon can't be negative", nameof(epsilon));
            this.epsilon = epsilon;
        }

        public bool Equals(double x, double y)
        {
            return Math.Abs(x - y) < epsilon;
        }

        public int GetHashCode(double obj)
        {
            return obj.GetHashCode();
        }
    }
}