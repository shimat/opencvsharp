using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 行列演算のテスト
    /// </summary>  
    class MatTest
    {
        public MatTest()
        {
            // 行列aとbを初期化
            // aはオーソドックスに1次元配列で元データを指定
            double[] _a = new double[]{  1, 2, 3, 
                                        4, 5, 6,  
                                        7, 8, 9,  };
            // bは二次元配列で指定してみる. 1チャンネルの行列ならこちらの方が楽.
            double[,] _b = new double[,]{ {1, 4, 7},
                                          {2, 5, 8},
                                          {3, 6, 9} };
            // 色(RGB3チャンネル)の配列
            CvColor[,] _c = new CvColor[,]{ {CvColor.Red, CvColor.Green, CvColor.Blue},
                                          {CvColor.Brown, CvColor.Cyan, CvColor.Pink},
                                          {CvColor.Magenta, CvColor.Navy, CvColor.Violet} };

            using (CvMat a = new CvMat(3, 3, MatrixType.F64C1, _a))     // 元データが1次元配列の場合
            using (CvMat b = CvMat.FromArray(_b))                       // 元データが2次元配列の場合
            using (CvMat c = CvMat.FromArray(_c, MatrixType.U8C3))      // 多チャンネル配列の場合
            {
                // aとbの値を表示
                Console.WriteLine("a : \n{0}", a); 
                Console.WriteLine("b : \n{0}", b);

                // 行列の掛け算
                 Console.WriteLine("A * B : \n{0}", a * b);

                // 加算、減算
                Console.WriteLine("a + b : \n{0}", a + b);
                Console.WriteLine("a - b : \n{0}", a - b);

                // 論理演算
                Console.WriteLine("a & b : \n{0}", a & b);
                Console.WriteLine("a | b : \n{0}", a | b);
                Console.WriteLine("~a : \n{0}", ~a);
            }
            // CvMatは大してメモリを食うことはないと思われるので、
            // いちいちusingせずGCにまかせてもいいかも。

            Console.WriteLine("press any key to quit");
            Console.Read();
        }
    }
}
