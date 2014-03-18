using System;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    class MatOperations : ISample
    {
        public void Run()
        {
            SubMat();
            RowColRangeOperation();
            RowColOperation();
        }

        /// <summary>
        /// Submatrix operations
        /// </summary>
        private void SubMat()
        {
            Mat src = Cv2.ImRead(FilePath.Lenna);

            // Get partial mat (similar to cvSetImageROI)
            Mat part = src[200, 400, 200, 400];
            // Invert partial pixel values
            Cv2.BitwiseNot(part, part);

            // Fill the region (50..100, 100..150) with color (128, 0, 0)
            part = src.SubMat(50, 100, 100, 150);
            part.SetTo(128);

            using (new Window("SubMat", src))
            {
                Cv2.WaitKey();
            }
        }

        /// <summary>
        /// Submatrix operations
        /// </summary>
        private void RowColRangeOperation()
        {
            Mat src = Cv2.ImRead(FilePath.Lenna);

            Cv2.GaussianBlur(
                src.RowRange(100, 200),
                src.RowRange(200, 300),
                new Size(7, 7), 20);

            Cv2.GaussianBlur(
                src.ColRange(200, 300),
                src.ColRange(100, 200),
                new Size(7, 7), 20);

            using (new Window("RowColRangeOperation", src))
            {
                Cv2.WaitKey();
            }
        }

        /// <summary>
        /// Submatrix expression operations
        /// </summary>
        private void RowColOperation()
        {
            Mat src = Cv2.ImRead(FilePath.Lenna);

            src.Expr[new Rect(100, 100, 200, 200)] = 
                src.Expr[new Rect(100, 100, 200, 200)].T();
           
            src.ColExpr[100] = ~src.ColExpr[200] * 2 / 3;

            src.RowExpr[100] += src.RowExpr[102];

            // set constant value...
            src.RowExpr[450,460] = src.RowExpr[450,460] * 0 + new Scalar(0,0,255);


            using (new Window("RowColOperation", src))
            {
                Cv2.WaitKey();
            }
        }

    }
}