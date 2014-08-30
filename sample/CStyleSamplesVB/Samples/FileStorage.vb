Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' データのファイルストレージへの書き込み・読み込み
''' </summary>
Friend Module FileStorage
    Public Sub Start()
        Const fileNameImage As String = "images.xml"
        Const fileNameSeq As String = "sequence.yml"

        ' image.xmlへ画像データを書き込む
        SampleFileStorageWriteImage(fileNameImage)
        ' 書き込んだ画像データを読み込んで表示
        SampleFileStorageReadImage(fileNameImage)

        ' マップのシーケンスの保存とその読み込み
        SampleFileStorageWriteSeq(fileNameSeq)
        SampleFileStorageReadSeq(fileNameSeq)
    End Sub

    ''' <summary>
    ''' 画像データのファイルストレージへの書き込み
    ''' </summary>
    ''' <param name="fileName">書きこむXML or YAMLファイル</param>
    Private Sub SampleFileStorageWriteImage(ByVal fileName As String)
        ' cvWrite, cvWriteComment
        ' IplImage構造体の情報をファイルに保存する

        ' (1)画像を読み込む
        Using colorImg As New IplImage(FilePath.Image.Lenna, LoadMode.Color)
            Using grayImg As New IplImage(colorImg.Size, BitDepth.U8, 1)
                ' (2)ROIの設定と二値化処理
                colorImg.CvtColor(grayImg, ColorConversion.BgrToGray)
                Dim roi As New CvRect(0, 0, colorImg.Width \ 2, colorImg.Height \ 2)
                grayImg.SetROI(roi)
                colorImg.SetROI(roi)
                grayImg.Threshold(grayImg, 90, 255, ThresholdType.Binary)
                ' (3)xmlファイルへの書き出し 
                Using fs As New CvFileStorage(fileName, Nothing, FileStorageMode.Write)
                    fs.WriteComment("This is a comment line.", False)
                    fs.Write("color_img", colorImg)
                    fs.StartNextStream()
                    fs.Write("gray_img", grayImg)
                End Using
                ' (4)書きこんだxmlファイルを開く
                'using (Process p = Process.Start(fileName)) {
                '    p.WaitForExit();
                '}                
            End Using
        End Using
    End Sub
    ''' <summary>
    ''' 画像データのファイルストレージからの読み込み        
    ''' <param name="fileName">読み込むXML or YAMLファイル</param>
    Private Sub SampleFileStorageReadImage(ByVal fileName As String)
        Dim colorImg, grayImg As IplImage
        ' (1)ファイルを読み込む
        Using fs As New CvFileStorage(fileName, Nothing, FileStorageMode.Read)
            Dim node As CvFileNode
            node = fs.GetFileNodeByName(Nothing, "color_img")
            colorImg = fs.Read(Of IplImage)(node)
            node = fs.GetFileNodeByName(Nothing, "gray_img")
            grayImg = fs.Read(Of IplImage)(node)
        End Using
        ' (2)ROI情報を取得し矩形を描いた後，解放
        Dim roiColor As CvRect = colorImg.GetROI()
        Dim roiGray As CvRect = grayImg.GetROI()
        colorImg.ResetROI()
        grayImg.ResetROI()
        colorImg.Rectangle(New CvPoint(roiColor.X, roiColor.Y), New CvPoint(roiColor.X + roiColor.Width, roiColor.Y + roiColor.Height), CvColor.Red)
        grayImg.Rectangle(New CvPoint(roiGray.X, roiGray.Y), New CvPoint(roiGray.X + roiGray.Width, roiGray.Y + roiGray.Height), CvColor.Black)
        ' (3)画像を描画 
        Using TempCvWindow As CvWindow = New CvWindow("Color Image", WindowMode.AutoSize, colorImg)
            Using TempCvWindowGray As CvWindow = New CvWindow("Grayscale Image", WindowMode.AutoSize, grayImg)
                Cv.WaitKey(0)
            End Using
        End Using
        colorImg.Dispose()
        grayImg.Dispose()
    End Sub

    ''' <summary>
    ''' マップのシーケンスのファイルストレージへの書き込み
    ''' </summary>
    ''' <param name="fileName">書きこむXML or YAMLファイル</param>
    Private Sub SampleFileStorageWriteSeq(ByVal fileName As String)
        ' cvStartWriteStruct, cvEndWriteStruct
        ' 二つのエントリを持つマップのシーケンスをファイルに保存する

        Const size As Integer = 20
        Dim rng As New CvRNG(CULng(Date.Now.Ticks))
        Dim pt(size - 1) As CvPoint
        ' (1)点列の作成
        For i As Integer = 0 To pt.Length - 1
            pt(i).X = CInt(Math.Truncate(rng.RandInt(100)))
            pt(i).Y = CInt(Math.Truncate(rng.RandInt(100)))
        Next i
        ' (2)マップのシーケンスとして点列を保存
        Using fs As New CvFileStorage(fileName, Nothing, FileStorageMode.Write)
            fs.StartWriteStruct("points", NodeType.Seq)
            For i As Integer = 0 To pt.Length - 1
                fs.StartWriteStruct(Nothing, NodeType.Map Or NodeType.Flow)
                fs.WriteInt("x", pt(i).X)
                fs.WriteInt("y", pt(i).Y)
                fs.EndWriteStruct()
            Next i
            fs.EndWriteStruct()
        End Using
        ' (3)書きこんだyamlファイルを開く
        'using (Process p = Process.Start(fileName)) {
        '    p.WaitForExit();
        '} 
    End Sub

    ''' <summary>
    ''' マップのシーケンスのファイルストレージからの読み込み
    ''' </summary>
    ''' <param name="fileName">書きこむXML or YAMLファイル</param>
    Private Sub SampleFileStorageReadSeq(ByVal fileName As String)
        ' cvGetHashedKey, cvGetFileNode
        ' 二つのエントリを持つマップのシーケンスをファイルから読み込む

        ' (1)ファイルストレージのオープン，ハッシュドキーの計算，シーケンスノードの取得
        Using fs As New CvFileStorage("sequence.yml", Nothing, FileStorageMode.Read)
            Dim xKey As CvStringHashNode = fs.GetHashedKey("x", True)
            Dim yKey As CvStringHashNode = fs.GetHashedKey("y", True)
            Dim points As CvFileNode = fs.GetFileNodeByName(Nothing, "points")
            ' (2)シーケンスリーダを初期化，各ノードを順次取得
            If (points.Tag And NodeType.Seq) <> 0 Then
                Dim seq As CvSeq = points.DataSeq
                Dim total As Integer = seq.Total
                Dim reader As New CvSeqReader()
                seq.StartRead(reader, False)
                For i As Integer = 0 To total - 1
                    Dim pt As CvFileNode = CvFileNode.FromPtr(reader.Ptr)
                    ' (3)高速バージョン
                    '                        
                    '                        CvFileNode xnode = fs.GetFileNode(pt, x_key, false);
                    '                        CvFileNode ynode = fs.GetFileNode(pt, y_key, false);
                    '                        Debug.Assert(
                    '                            xnode != null && 
                    '                            (xnode.Tag & NodeType.Integer) != 0 &&
                    '                            ynode != null && 
                    '                            (ynode.Tag & NodeType.Integer) != 0
                    '                        );
                    '                        int x = xnode.DataI;
                    '                        int i = ynode.DataI;
                    '                        //
                    ' (4)低速バージョン．x_keyとy_keyを使わない 
                    '                        
                    '                        CvFileNode xnode = fs.GetFileNodeByName(pt, "x");   
                    '                        CvFileNode ynode = fs.GetFileNodeByName(pt, "i");
                    '                        Debug.Assert(
                    '                            xnode != null &&
                    '                            (xnode.Tag & NodeType.Integer) != 0 &&
                    '                            ynode != null &&
                    '                            (ynode.Tag & NodeType.Integer) != 0
                    '                        ); 
                    '                        int x = xnode.DataI;   
                    '                        int i = ynode.DataI;
                    '                        //
                    ' (5)さらに低速だが，使いやすいバージョン
                    '''*
                    Dim x As Integer = fs.ReadIntByName(pt, "x", 0)
                    Dim y As Integer = fs.ReadIntByName(pt, "y", 0)
                    '*/
                    ' (6)データを表示し，次のシーケンスノードを取得
                    Cv.NEXT_SEQ_ELEM(seq.ElemSize, reader)
                    Form1.TextBox1.AppendText(Environment.NewLine & String.Format("{0}: ({1}, {2})", i, x, y))
                Next i
            End If
        End Using
        'Console.ReadKey()
    End Sub
End Module
' End Namespace
