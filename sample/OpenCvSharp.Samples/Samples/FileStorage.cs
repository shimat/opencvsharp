using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// データのファイルストレージへの書き込み・読み込み
    /// </summary>
    class FileStorage
    {        
        public FileStorage()
        {
            const string fileNameImage = "images.xml";
            const string fileNameSeq = "sequence.yml";

            // image.xmlへ画像データを書き込む
            SampleFileStorageWriteImage(fileNameImage);
            // 書き込んだ画像データを読み込んで表示
            SampleFileStorageReadImage(fileNameImage);

            // マップのシーケンスの保存とその読み込み
            SampleFileStorageWriteSeq(fileNameSeq);
            SampleFileStorageReadSeq(fileNameSeq);
        }

        /// <summary>
        /// 画像データのファイルストレージへの書き込み
        /// </summary>
        /// <param name="fileName">書きこむXML or YAMLファイル</param>
        private static void SampleFileStorageWriteImage(string fileName)
        {
            // cvWrite, cvWriteComment
            // IplImage構造体の情報をファイルに保存する

            // (1)画像を読み込む
            using (IplImage colorImg = new IplImage(Const.ImageLenna, LoadMode.Color))
            using (IplImage grayImg = new IplImage(colorImg.Size, BitDepth.U8, 1))
            {
                // (2)ROIの設定と二値化処理
                colorImg.CvtColor(grayImg, ColorConversion.BgrToGray);
                CvRect roi = new CvRect(0, 0, colorImg.Width / 2, colorImg.Height / 2);
                grayImg.SetROI(roi);
                colorImg.SetROI(roi);
                grayImg.Threshold(grayImg, 90, 255, ThresholdType.Binary);
                // (3)xmlファイルへの書き出し 
                using (CvFileStorage fs = new CvFileStorage(fileName, null, FileStorageMode.Write))
                {
                    fs.WriteComment("This is a comment line.", false);
                    fs.Write("color_img", colorImg);
                    fs.StartNextStream();
                    fs.Write("gray_img", grayImg);
                }
                // (4)書きこんだxmlファイルを開く
                //using (Process p = Process.Start(fileName)) {
                //    p.WaitForExit();
                //}                
            }
        }
        /// <summary>
        /// 画像データのファイルストレージからの読み込み        
        /// <param name="fileName">読み込むXML or YAMLファイル</param>
        private static void SampleFileStorageReadImage(string fileName)
        {
            IplImage colorImg, grayImg;
            // (1)ファイルを読み込む
            using (CvFileStorage fs = new CvFileStorage(fileName, null, FileStorageMode.Read))
            {
                CvFileNode node;
                node = fs.GetFileNodeByName(null, "color_img");
                colorImg = fs.Read<IplImage>(node);
                node = fs.GetFileNodeByName(null, "gray_img");
                grayImg = fs.Read<IplImage>(node);
            }
            // (2)ROI情報を取得し矩形を描いた後，解放
            CvRect roiColor = colorImg.GetROI();
            CvRect roiGray = grayImg.GetROI();
            colorImg.ResetROI();
            grayImg.ResetROI();
            colorImg.Rectangle(
                new CvPoint(roiColor.X, roiColor.Y),
                new CvPoint(roiColor.X + roiColor.Width, roiColor.Y + roiColor.Height),
                CvColor.Red
            );
            grayImg.Rectangle(
                new CvPoint(roiGray.X, roiGray.Y),
                new CvPoint(roiGray.X + roiGray.Width, roiGray.Y + roiGray.Height),
                CvColor.Black
            );
            // (3)画像を描画 
            using (new CvWindow("Color Image", WindowMode.AutoSize, colorImg)) 
            using (new CvWindow("Grayscale Image", WindowMode.AutoSize, grayImg))
            {
                Cv.WaitKey(0);
            }
            colorImg.Dispose();
            grayImg.Dispose();
        }

        /// <summary>
        /// マップのシーケンスのファイルストレージへの書き込み
        /// </summary>
        /// <param name="fileName">書きこむXML or YAMLファイル</param>
        private static void SampleFileStorageWriteSeq(string fileName)
        {
            // cvStartWriteStruct, cvEndWriteStruct
            // 二つのエントリを持つマップのシーケンスをファイルに保存する

            const int size = 20;
            CvRNG rng = new CvRNG((ulong)DateTime.Now.Ticks);
            CvPoint[] pt = new CvPoint[size];
            // (1)点列の作成
            for (int i = 0; i < pt.Length; i++)
            {
                pt[i].X = (int)rng.RandInt(100);
                pt[i].Y = (int)rng.RandInt(100);
            }
            // (2)マップのシーケンスとして点列を保存
            using (CvFileStorage fs = new CvFileStorage(fileName, null, FileStorageMode.Write))
            {
                fs.StartWriteStruct("points", NodeType.Seq);
                for (int i = 0; i < pt.Length; i++)
                {
                    fs.StartWriteStruct(null, NodeType.Map | NodeType.Flow);
                    fs.WriteInt("x", pt[i].X);
                    fs.WriteInt("y", pt[i].Y);
                    fs.EndWriteStruct();
                }
                fs.EndWriteStruct();
            }
            // (3)書きこんだyamlファイルを開く
            //using (Process p = Process.Start(fileName)) {
            //    p.WaitForExit();
            //} 
        }

        /// <summary>
        /// マップのシーケンスのファイルストレージからの読み込み
        /// </summary>
        /// <param name="fileName">書きこむXML or YAMLファイル</param>
        private static void SampleFileStorageReadSeq(string fileName)
        {
            // cvGetHashedKey, cvGetFileNode
            // 二つのエントリを持つマップのシーケンスをファイルから読み込む

            // (1)ファイルストレージのオープン，ハッシュドキーの計算，シーケンスノードの取得
            using (CvFileStorage fs = new CvFileStorage("sequence.yml", null, FileStorageMode.Read))
            {
                CvStringHashNode xKey = fs.GetHashedKey("x", true);
                CvStringHashNode yKey = fs.GetHashedKey("y", true);
                CvFileNode points = fs.GetFileNodeByName(null, "points");
                // (2)シーケンスリーダを初期化，各ノードを順次取得
                if ((points.Tag & NodeType.Seq) != 0)
                {
                    CvSeq seq = points.DataSeq;
                    int total = seq.Total;
                    CvSeqReader reader = new CvSeqReader();
                    seq.StartRead(reader, false);
                    for (int i = 0; i < total; i++)
                    {
                        CvFileNode pt = CvFileNode.FromPtr(reader.Ptr);
                        // (3)高速バージョン
                        /*
                        CvFileNode xnode = fs.GetFileNode(pt, x_key, false);
                        CvFileNode ynode = fs.GetFileNode(pt, y_key, false);
                        Debug.Assert(
                            xnode != null && 
                            (xnode.Tag & NodeType.Integer) != 0 &&
                            ynode != null && 
                            (ynode.Tag & NodeType.Integer) != 0
                        );
                        int x = xnode.DataI;
                        int i = ynode.DataI;
                        //*/
                        // (4)低速バージョン．x_keyとy_keyを使わない 
                        /*
                        CvFileNode xnode = fs.GetFileNodeByName(pt, "x");   
                        CvFileNode ynode = fs.GetFileNodeByName(pt, "i");
                        Debug.Assert(
                            xnode != null &&
                            (xnode.Tag & NodeType.Integer) != 0 &&
                            ynode != null &&
                            (ynode.Tag & NodeType.Integer) != 0
                        ); 
                        int x = xnode.DataI;   
                        int i = ynode.DataI;
                        //*/
                        // (5)さらに低速だが，使いやすいバージョン
                        ///*
                        int x = fs.ReadIntByName(pt, "x", 0);
                        int y = fs.ReadIntByName(pt, "y", 0);
                        //*/
                        // (6)データを表示し，次のシーケンスノードを取得
                        Cv.NEXT_SEQ_ELEM(seq.ElemSize, reader);
                        Console.WriteLine("{0}: ({1}, {2})", i, x, y);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
