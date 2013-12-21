using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 連立方程式を解く
    /// </summary>
    class Solve
    {
        public Solve()
        {
            //  x +  y +  z = 6
            // 2x - 3y + 4z = 8
            // 4x + 4y - 4z = 0

            double[] A = new double[]{
                1, 1, 1,
                2, -3, 4,
                4, 4, -4
            };
            double[] B = new double[]{
                6,
                8,
                0
            };

            CvMat matA = new CvMat(3, 3, MatrixType.F64C1, A);
            CvMat matB = new CvMat(3, 1, MatrixType.F64C1, B);

            // X = inv(A) * B
            CvMat matAInv = matA.Clone();
            matA.Inv(matAInv);

            CvMat matX = matAInv * matB;

            Console.WriteLine("X = {0}", matX[0].Val0);
            Console.WriteLine("Y = {0}", matX[1].Val0);
            Console.WriteLine("Z = {0}", matX[2].Val0);
            Console.Read();
        }
    }
}