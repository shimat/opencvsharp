using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Multidimensional Scaling (多次元尺度構成法)
    /// </summary>
    class MDS
    {
        /// <summary>
        /// Distance among 10 American cities
        /// </summary>
        /// <example>
        /// * The linear distance between Atlanta and Chicago is 587km.
        /// </example>
        static readonly double[,] CityDistance = new double[,]
        {
            /*Atlanta*/         {0,      587,    1212,   701,    1936,   604,    748,    2139,   2182,   543},
            /*Chicago*/         {587,    0,      920,    940,    1745,   1188,   713,    1858,   1737,   597},
            /*Denver*/          {1212,   920,    0,      879,    831,    1726,   1631,   949,    1021,   1494},
            /*Houston*/         {701,    940,    879,    0,      1734,   968,    1420,   1645,   1891,   1220},
            /*Los Angeles*/     {1936,   1745,   831,    1734,   0,      2339,   2451,   347,    959,    2300},
            /*Miami*/           {604,    1188,   1726,   968,    2339,   0,      1092,   2594,   2734,   923},
            /*New York*/        {748,    713,    1631,   1420,   2451,   1092,   0,      2571,   2408,   205},
            /*San Francisco*/   {2139,   1858,   949,    1645,   347,    2594,   2571,   0,      678,    2442},
            /*Seattle*/         {2182,   1737,   1021,   1891,   959,    2734,   2408,   678,    0,      2329},
            /*Washington D.C.*/ {543,    597,    1494,   1220,   2300,   923,    205,    2442,   2329,   0}
        };
        /// <summary>
        /// City names
        /// </summary>
        static readonly string[] CityNames = new string[]
        {
                "Atlanta","Chicago","Denver","Houston","Los Angeles","Miami","New York","San Francisco","Seattle","Washington D.C."
        };


        /// <summary>
        /// Classical Multidimensional Scaling
        /// </summary>
        public MDS()
        {
            // creates distance matrix
            int size = CityDistance.GetLength(0);
            CvMat t = new CvMat(size, size, MatrixType.F64C1, CityDistance);
            // adds Torgerson's additive constant to t
            t += Torgerson(t);
            // squares all elements of t
            t.Mul(t, t);

            // centering matrix G
            CvMat g = CenteringMatrix(size);
            // calculates inner product matrix B
            CvMat b = g * t * g.T() * -0.5;
            // calculates eigenvalues and eigenvectors of B
            CvMat vectors = new CvMat(size, size, MatrixType.F64C1);
            CvMat values = new CvMat(size, 1, MatrixType.F64C1);
            Cv.EigenVV(b, vectors, values);
            
            for (int r = 0; r < values.Rows; r++)
            {
                if (values[r] < 0)                
                    values[r] = 0;                
            }

            // multiplies sqrt(eigenvalue) by eigenvector
            CvMat result = vectors.GetRows(0, 2);
            for (int r = 0; r < result.Rows; r++)
            {
                for (int c = 0; c < result.Cols; c++)
                {
                    result[r, c] *= Math.Sqrt(values[r]);
                }                
            }

            // scaling
            Cv.Normalize(result, result, 0, 800, NormType.MinMax);

            //Console.WriteLine(vectors);
            //Console.WriteLine(values);
            //Console.WriteLine(result);

            // opens a window
            using (IplImage img = new IplImage(800, 600, BitDepth.U8, 3))
            using (CvFont font = new CvFont(FontFace.HersheySimplex, 0.5f, 0.5f))
            using (CvWindow window = new CvWindow("City Location Estimation"))
            {
                img.Zero();
                for (int c = 0; c < size; c++)
                {
                    double x = result[0, c];
                    double y = result[1, c];
                    x = x * 0.7 + img.Width * 0.1;
                    y = y * 0.7 + img.Height * 0.1;
                    img.Circle((int)x, (int)y, 5, CvColor.Red, -1);
                    img.PutText(CityNames[c], new CvPoint((int)x+5, (int)y+10), font, CvColor.White);
                }
                window.Image = img;
                Cv.WaitKey();
            }
        }

        /// <summary>
        /// Returns Torgerson's additive constant
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        private double Torgerson(CvMat mat)
        {
            if (mat == null)
                throw new ArgumentNullException();
            else if (mat.Rows != mat.Cols)
                throw new ArgumentException();

            int n = mat.Rows;            
            // Additive constant in case of negative value
            double min, max; 
            (-mat).MinMaxLoc(out min, out max);
            double c2 = max;
            // Additive constant from triangular inequality
            double c1 = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        double v = mat[i, k] - mat[i, j] - mat[j, k];
                        if (v > c1)
                        {
                            c1 = v;
                        }
                    }
                }
            }
            return Math.Max(Math.Max(c1, c2), 0);
        }

        /// <summary>
        /// Returns centering matrix
        /// </summary>
        /// <param name="n">Size of matrix</param>
        /// <returns></returns>
        private CvMat CenteringMatrix(int n)
        {
            return (CvMat.Identity(n, n, MatrixType.F64C1) - new CvMat(n, n, MatrixType.F64C1, 1.0 / n));
        }
    }
}