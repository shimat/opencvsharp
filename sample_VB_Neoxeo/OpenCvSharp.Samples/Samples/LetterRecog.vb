Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.MachineLearning

Namespace OpenCvSharpSamples
	''' <summary>
	''' samples/c/letter_recog.cpp
	''' </summary>
	''' <remarks>
	''' The sample demonstrates how to train Random Trees classifier
	''' (or Boosting classifier, or MLP - see main()) using the provided dataset.
	''' 
	''' We use the sample database letter-recognition.data
	''' from UCI Repository, here is the link:
	''' 
	''' Newman, D.J. & Hettich, S. & Blake, C.L. & Merz, C.J. (1998).
	''' UCI Repository of machine learning databases
	''' [http://www.ics.uci.edu/~mlearn/MLRepository.html].
	''' Irvine, CA: University of California, Department of Information and Computer Science.
	'''
	''' The dataset consists of 20000 feature vectors along with the
	''' responses - capital latin letters A..Z.
	''' The first 16000 (10000 for boosting)) samples are used for training
	''' and the remaining 4000 (10000 for boosting) - to test the classifier.
	''' </remarks>
	Friend Class LetterRecog
		''' <summary>
		''' !! Choose a classifier you want to use !!
		''' </summary>
		Private ReadOnly Classifier As ClassifierType = ClassifierType.SVM



		''' <summary>
		''' Entry point
		''' </summary>
		Public Sub New()
			Dim method As ClassifierBuilder

			Select Case Classifier
				Case ClassifierType.RTrees
					method = AddressOf BuildRtreesClassifier
				Case ClassifierType.Boost
					method = AddressOf BuildBoostClassifier
				Case ClassifierType.MLP
					method = AddressOf BuildMlpClassifier
				Case ClassifierType.SVM
					method = AddressOf BuildSvmClassifier
				Case Else
					Throw New NotImplementedException()
			End Select

			method([Const].DataLetterRecog, Nothing, Nothing)
		End Sub
		''' <summary>
		''' 
		''' </summary>
		Private Enum ClassifierType
			RTrees
			Boost
			MLP
			SVM
		End Enum
		''' <summary>
		''' 
		''' </summary>
		Private Delegate Sub ClassifierBuilder(ByVal dataFilename As String, ByVal filenameToSave As String, ByVal filenameToLoad As String)





		''' <summary>
		''' 
		''' </summary>
		''' <param name="filename"></param>
		''' <param name="varCount"></param>
		''' <param name="data"></param>
		''' <param name="responses"></param>
		Private Sub ReadNumClassData(ByVal filename As String, ByVal varCount As Integer, ByRef data As CvMat, ByRef responses As CvMat)
			Dim seq As New List(Of Single())()

			Using sr As New StreamReader(filename)
				Dim buf As String
				Do
					Dim elPtr(varCount) As Single
					buf = sr.ReadLine()
					If buf Is Nothing OrElse buf.IndexOf(","c) < 0 Then
						Exit Do
					End If

					Dim vals() As String = buf.Split(","c)
					elPtr(0) = vals(0).Chars(0)
					Dim i As Integer
					For i = 1 To varCount
						elPtr(i) = Convert.ToSingle(vals(i))
					Next i
					If i <= varCount Then
						Exit Do
					End If
					seq.Add(elPtr)
				Loop
			End Using

			data = New CvMat(seq.Count, varCount, MatrixType.F32C1)
			responses = New CvMat(seq.Count, 1, MatrixType.F32C1)

			For i As Integer = 0 To seq.Count - 1
'INSTANT VB TODO TASK: There is no equivalent to an 'unsafe' block in VB:
'				unsafe
'INSTANT VB TODO TASK: There is no equivalent to a 'fixed' block in VB:
'					fixed (float* _sdata = seq[i])
						Single* sdata = _sdata + 1
						Single* ddata = data.DataSingle + (varCount * i)
						Single* dr = responses.DataSingle + i
						For j As Integer = 0 To varCount - 1
							ddata(j) = sdata(j)
						Next j
						*dr = sdata(-1)
'INSTANT VB NOTE: End of the original C# 'fixed' block.
'INSTANT VB NOTE: End of the original C# 'unsafe' block.
			Next i

		End Sub


		''' <summary>
		''' RTrees
		''' </summary>
		''' <param name="dataFilename"></param>
		''' <param name="filenameToSave"></param>
		''' <param name="filenameToLoad"></param>
		Private Sub BuildRtreesClassifier(ByVal dataFilename As String, ByVal filenameToSave As String, ByVal filenameToLoad As String)
			Dim data As CvMat = Nothing
			Dim responses As CvMat = Nothing
			Dim varType As CvMat = Nothing
			Dim sampleIdx As CvMat = Nothing


			Dim nsamplesAll As Integer = 0, ntrainSamples As Integer = 0
			Dim trainHr As Double = 0, testHr As Double = 0
			Dim forest As New CvRTrees()
			Dim varImportance As CvMat = Nothing

			Try
				ReadNumClassData(dataFilename, 16, data, responses)
			Catch
				Console.WriteLine("Could not read the database {0}", dataFilename)
				Return
			End Try
			Console.WriteLine("The database {0} is loaded.", dataFilename)

			nsamplesAll = data.Rows
			ntrainSamples = CInt(Math.Truncate(nsamplesAll * 0.8))

			' Create or load Random Trees classifier
			If filenameToLoad IsNot Nothing Then
				' load classifier from the specified file
				forest.Load(filenameToLoad)
				ntrainSamples = 0
				If forest.GetTreeCount() = 0 Then
					Console.WriteLine("Could not read the classifier {0}", filenameToLoad)
					Return
				End If
				Console.WriteLine("The classifier {0} is loaded.", filenameToLoad)
			Else
				' create classifier by using <data> and <responses>
				Console.Write("Training the classifier ...")

				' 1. create type mask
				varType = New CvMat(data.Cols + 1, 1, MatrixType.U8C1)
				varType.Set(CvScalar.ScalarAll(CvStatModel.CV_VAR_ORDERED))
				varType.SetReal1D(data.Cols, CvStatModel.CV_VAR_CATEGORICAL)

				' 2. create sample_idx
				sampleIdx = New CvMat(1, nsamplesAll, MatrixType.U8C1)
					Dim mat As CvMat
					Cv.GetCols(sampleIdx, mat, 0, ntrainSamples)
					mat.Set(CvScalar.RealScalar(1))

					Cv.GetCols(sampleIdx, mat, ntrainSamples, nsamplesAll)
					mat.SetZero()

				' 3. train classifier
				forest.Train(data, DTreeDataLayout.RowSample, responses, Nothing, sampleIdx, varType, Nothing, New CvRTParams(10, 10, 0, False, 15, Nothing, True, 4, New CvTermCriteria(100, 0.01F)))
				Console.WriteLine()
			End If

			' compute prediction error on train and test data
			For i As Integer = 0 To nsamplesAll - 1
				Dim r As Double
				Dim sample As CvMat
				Cv.GetRow(data, sample, i)

				r = forest.Predict(sample)
				r = If(Math.Abs(CDbl(r) - responses.DataArraySingle(i)) <= Single.Epsilon, 1, 0)

				If i < ntrainSamples Then
					trainHr += r
				Else
					testHr += r
				End If
			Next i

			testHr /= CDbl(nsamplesAll - ntrainSamples)
			trainHr /= CDbl(ntrainSamples)
			Console.WriteLine("Recognition rate: train = {0:F1}%, test = {1:F1}%", trainHr * 100.0, testHr * 100.0)

			Console.WriteLine("Number of trees: {0}", forest.GetTreeCount())

			' Print variable importance
			varImportance = forest.GetVarImportance()
			If varImportance IsNot Nothing Then
				Dim rtImpSum As Double = Cv.Sum(varImportance).Val0
				Console.WriteLine("var#" & vbTab & "importance (in %):")
				For i As Integer = 0 To varImportance.Cols - 1
					Console.WriteLine("{0}" & vbTab & "{1:F1}", i, 100.0F * varImportance.DataArraySingle(i) / rtImpSum)
				Next i
			End If

			' Print some proximitites
			Console.WriteLine("Proximities between some samples corresponding to the letter 'T':")
				Dim sample1, sample2 As CvMat
				Dim pairs(,) As Integer = { { 0, 103 }, { 0, 106 }, { 106, 103 }, { -1, -1 } }

				Dim i As Integer = 0
				Do While pairs(i, 0) >= 0
					Cv.GetRow(data, sample1, pairs(i, 0))
					Cv.GetRow(data, sample2, pairs(i, 1))
					Console.WriteLine("proximity({0},{1}) = {2:F1}%", pairs(i, 0), pairs(i, 1), forest.GetProximity(sample1, sample2) * 100.0)
					i += 1
				Loop

			' Save Random Trees classifier to file if needed
			If filenameToSave IsNot Nothing Then
				forest.Save(filenameToSave)
			End If


			Console.Read()


			If sampleIdx IsNot Nothing Then
				sampleIdx.Dispose()
			End If
			If varType IsNot Nothing Then
				varType.Dispose()
			End If
			data.Dispose()
			responses.Dispose()
			forest.Dispose()
		End Sub


		''' <summary>
		''' 
		''' </summary>
		''' <param name="dataFilename"></param>
		''' <param name="filenameToSave"></param>
		''' <param name="filenameToLoad"></param>
		Private Sub BuildBoostClassifier(ByVal dataFilename As String, ByVal filenameToSave As String, ByVal filenameToLoad As String)
			Const ClassCount As Integer = 26

			Dim data As CvMat = Nothing
			Dim responses As CvMat = Nothing
			Dim varType As CvMat = Nothing
			Dim tempSample As CvMat = Nothing
			Dim weakResponses As CvMat = Nothing

			Dim nsamplesAall As Integer = 0, ntrainSamples As Integer = 0
			Dim varCount As Integer
			Dim trainHr As Double = 0, testHr As Double = 0
			Dim boost As New CvBoost()

			Try
				ReadNumClassData(dataFilename, 16, data, responses)
			Catch
				Console.WriteLine("Could not read the database {0}", dataFilename)
				Return
			End Try
			Console.WriteLine("The database {0} is loaded.", dataFilename)

			nsamplesAall = data.Rows
			ntrainSamples = CInt(Math.Truncate(nsamplesAall * 0.5))
			varCount = data.Cols

			' Create or load Boosted Tree classifier
			If filenameToLoad IsNot Nothing Then
				' load classifier from the specified file
				boost.Load(filenameToLoad)
				ntrainSamples = 0
				If boost.GetWeakPredictors() Is Nothing Then
					Console.WriteLine("Could not read the classifier {0}", filenameToLoad)
					Return
				End If
				Console.WriteLine("The classifier {0} is loaded.", filenameToLoad)
			Else
				' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
				'
				' As currently boosted tree classifier in MLL can only be trained
				' for 2-class problems, we transform the training database by
				' "unrolling" each training sample as many times as the number of
				' classes (26) that we have.
				'
				' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

				Using newData As New CvMat(ntrainSamples * ClassCount, varCount + 1, MatrixType.F32C1)
				Using newResponses As New CvMat(ntrainSamples * ClassCount, 1, MatrixType.S32C1)

					' 1. unroll the database type mask
					Console.WriteLine("Unrolling the database...")
					For i As Integer = 0 To ntrainSamples - 1
'INSTANT VB TODO TASK: There is no equivalent to an 'unsafe' block in VB:
'						unsafe
							Single* dataRow = CSng(data.DataByte + data.Step * i)
							For j As Integer = 0 To ClassCount - 1
								Single* newDataRow = CSng(newData.DataByte + newData.Step * (i * ClassCount + j))
								For k As Integer = 0 To varCount - 1
									newDataRow(k) = dataRow(k)
								Next k
								newDataRow(varCount) = CSng(j)
								newResponses.DataInt32(i * ClassCount + j) = If(responses.DataSingle(i) = j + AscW("A"c), 1, 0)
							Next j
'INSTANT VB NOTE: End of the original C# 'unsafe' block.
					Next i

					' 2. create type mask
					varType = New CvMat(varCount + 2, 1, MatrixType.U8C1)
					varType.Set(CvScalar.ScalarAll(CvStatModel.CV_VAR_ORDERED))
					' the last indicator variable, as well
					' as the new (binary) response are categorical
					varType.SetReal1D(varCount, CvStatModel.CV_VAR_CATEGORICAL)
					varType.SetReal1D(varCount + 1, CvStatModel.CV_VAR_CATEGORICAL)

					' 3. train classifier
					Console.Write("Training the classifier (may take a few minutes)...")
					boost.Train(newData, DTreeDataLayout.RowSample, newResponses, Nothing, Nothing, varType, Nothing, New CvBoostParams(CvBoost.REAL, 100, 0.95, 5, False, Nothing))
				End Using
				End Using
				Console.WriteLine()
			End If

			tempSample = New CvMat(1, varCount + 1, MatrixType.F32C1)
			weakResponses = New CvMat(1, boost.GetWeakPredictors().Total, MatrixType.F32C1)

			' compute prediction error on train and test data
			For i As Integer = 0 To nsamplesAall - 1
				Dim bestClass As Integer = 0
				Dim maxSum As Double = Double.MinValue
				Dim r As Double
				Dim sample As CvMat

				Cv.GetRow(data, sample, i)
				For k As Integer = 0 To varCount - 1
					tempSample.DataArraySingle(k) = sample.DataArraySingle(k)
				Next k

				For j As Integer = 0 To ClassCount - 1
					tempSample.DataArraySingle(varCount) = CSng(j)
					boost.Predict(tempSample, Nothing, weakResponses)
					Dim sum As Double = weakResponses.Sum().Val0
					If maxSum < sum Then
						maxSum = sum
						bestClass = j + AscW("A"c)
					End If
				Next j

				r = If(Math.Abs(bestClass - responses.DataArraySingle(i)) < Single.Epsilon, 1, 0)

				If i < ntrainSamples Then
					trainHr += r
				Else
					testHr += r
				End If
			Next i

			testHr /= CDbl(nsamplesAall - ntrainSamples)
			trainHr /= CDbl(ntrainSamples)
			Console.WriteLine("Recognition rate: train = {0:F1}%, test = {1:F1}%", trainHr * 100.0, testHr * 100.0)
			Console.WriteLine("Number of trees: {0}", boost.GetWeakPredictors().Total)

			' Save classifier to file if needed
			If filenameToSave IsNot Nothing Then
				boost.Save(filenameToSave)
			End If


			Console.Read()


			tempSample.Dispose()
			weakResponses.Dispose()
			If varType IsNot Nothing Then
				varType.Dispose()
			End If
			data.Dispose()
			responses.Dispose()
			boost.Dispose()
		End Sub


		''' <summary>
		''' 
		''' </summary>
		''' <param name="dataFilename"></param>
		''' <param name="filenameToSave"></param>
		''' <param name="filenameToLoad"></param>
		Private Sub BuildMlpClassifier(ByVal dataFilename As String, ByVal filenameToSave As String, ByVal filenameToLoad As String)
			Const ClassCount As Integer = 26

			Dim data As CvMat = Nothing
			Dim trainData As CvMat = Nothing
			Dim responses As CvMat = Nothing
			Dim mlpResponse As CvMat = Nothing
			Dim layerSizes As CvMat = Nothing

			Dim nsamplesAll As Integer = 0, ntrainSamples As Integer = 0
			Dim trainHr As Double = 0, testHr As Double = 0
			Dim mlp As New CvANN_MLP()

			Try
				ReadNumClassData(dataFilename, 16, data, responses)
			Catch
				Console.WriteLine("Could not read the database {0}", dataFilename)
				Return
			End Try
			Console.WriteLine("The database {0} is loaded.", dataFilename)

			nsamplesAll = data.Rows
			ntrainSamples = CInt(Math.Truncate(nsamplesAll * 0.8))

			' Create or load MLP classifier
			If filenameToLoad IsNot Nothing Then
				' load classifier from the specified file
				mlp.Load(filenameToLoad)
				ntrainSamples = 0
				If mlp.GetLayerCount() = 0 Then
					Console.WriteLine("Could not read the classifier {0}", filenameToLoad)
					Return
				End If
				Console.WriteLine("The classifier {0} is loaded.", filenameToLoad)
			Else
				' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
				'
				' MLP does not support categorical variables by explicitly.
				' So, instead of the output class label, we will use
				' a binary vector of <class_count> components for training and,
				' therefore, MLP will give us a vector of "probabilities" at the
				' prediction stage
				'
				' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

				Using newResponses As New CvMat(ntrainSamples, ClassCount, MatrixType.F32C1)
					' 1. unroll the responses
					Console.WriteLine("Unrolling the responses...")
'INSTANT VB TODO TASK: There is no equivalent to an 'unsafe' block in VB:
'					unsafe
						For i As Integer = 0 To ntrainSamples - 1
							Dim clsLabel As Integer = Cv.Round(responses.DataArraySingle(i)) - AscW("A"c)
							Single* bitVec = CSng(newResponses.DataByte + i * newResponses.Step)
							For j As Integer = 0 To ClassCount - 1
								bitVec(j) = 0.0F
							Next j
							bitVec(clsLabel) = 1.0F
						Next i
'INSTANT VB NOTE: End of the original C# 'unsafe' block.
					Cv.GetRows(data, trainData, 0, ntrainSamples)

					' 2. train classifier
					Dim layerSizesData() As Integer = { data.Cols, 100, 100, ClassCount }
					layerSizes = New CvMat(1, layerSizesData.Length, MatrixType.S32C1, layerSizesData)
					mlp.Create(layerSizes)
					Console.Write("Training the classifier (may take a few minutes)...")
					mlp.Train(trainData, newResponses, Nothing, Nothing, New CvANN_MLP_TrainParams(New CvTermCriteria(300, 0.01), MLPTrainingMethod.RPROP, 0.01))
				End Using
				Console.WriteLine()
			End If

			mlpResponse = New CvMat(1, ClassCount, MatrixType.F32C1)

			' compute prediction error on train and test data
			For i As Integer = 0 To nsamplesAll - 1
				Dim bestClass As Integer
				Dim sample As CvMat
				Dim minLoc, maxLoc As CvPoint

				Cv.GetRow(data, sample, i)
				mlp.Predict(sample, mlpResponse)
				mlpResponse.MinMaxLoc(minLoc, maxLoc, Nothing)
				bestClass = maxLoc.X + AscW("A"c)

				Dim r As Integer = If(Math.Abs(CDbl(bestClass) - responses.DataArraySingle(i)) < Single.Epsilon, 1, 0)

				If i < ntrainSamples Then
					trainHr += r
				Else
					testHr += r
				End If
			Next i

			testHr /= CDbl(nsamplesAll - ntrainSamples)
			trainHr /= CDbl(ntrainSamples)
			Console.WriteLine("Recognition rate: train = {0:F1}%, test = {1:F1}%", trainHr * 100.0, testHr * 100.0)

			' Save classifier to file if needed
			If filenameToSave IsNot Nothing Then
				mlp.Save(filenameToSave)
			End If


			Console.Read()


			mlpResponse.Dispose()
			data.Dispose()
			responses.Dispose()
			If layerSizes IsNot Nothing Then
				layerSizes.Dispose()
			End If
			mlp.Dispose()
		End Sub


		''' <summary>
		''' SVM
		''' </summary>
		''' <param name="dataFilename"></param>
		''' <param name="filenameToSave"></param>
		''' <param name="filenameToLoad"></param>
		Private Sub BuildSvmClassifier(ByVal dataFilename As String, ByVal filenameToSave As String, ByVal filenameToLoad As String)
			'C_SVCのパラメータ
			Const SvmC As Single = 1000
			'RBFカーネルのパラメータ
			Const SvmGamma As Single = 0.1F

			Dim data As CvMat = Nothing
			Dim responses As CvMat = Nothing
			Dim sampleIdx As CvMat = Nothing

			Dim nsamplesAll As Integer = 0, ntrainSamples As Integer = 0
			Dim trainHr As Double = 0, testHr As Double = 0

			Dim svm As New CvSVM()
			Dim criteria As New CvTermCriteria(100, 0.001)

			Try
				ReadNumClassData(dataFilename, 16, data, responses)
			Catch
				Console.WriteLine("Could not read the database {0}", dataFilename)
				Return
			End Try
			Console.WriteLine("The database {0} is loaded.", dataFilename)

			nsamplesAll = data.Rows
			ntrainSamples = CInt(Math.Truncate(nsamplesAll * 0.2))

			' Create or load Random Trees classifier
			If filenameToLoad IsNot Nothing Then
				' load classifier from the specified file
				svm.Load(filenameToLoad)
				ntrainSamples = 0
				If svm.GetSupportVectorCount() = 0 Then
					Console.WriteLine("Could not read the classifier {0}", filenameToLoad)
					Return
				End If
				Console.WriteLine("The classifier {0} is loaded.", filenameToLoad)
			Else
				' create classifier by using <data> and <responses>
				Console.Write("Training the classifier ...")

				' 2. create sample_idx
				sampleIdx = New CvMat(1, nsamplesAll, MatrixType.U8C1)
					Dim mat As CvMat
					Cv.GetCols(sampleIdx, mat, 0, ntrainSamples)
					mat.Set(CvScalar.RealScalar(1))

					Cv.GetCols(sampleIdx, mat, ntrainSamples, nsamplesAll)
					mat.SetZero()

				' 3. train classifier
				' 方法、カーネルにより使わないパラメータは0で良く、
				' 重みについてもNULLで良い
				svm.Train(data, responses, Nothing, sampleIdx, New CvSVMParams(CvSVM.C_SVC, CvSVM.RBF, 0, SvmGamma, 0, SvmC, 0, 0, Nothing, criteria))
				Console.WriteLine()
			End If


			' compute prediction error on train and test data            
			For i As Integer = 0 To nsamplesAll - 1
				Dim r As Double
				Dim sample As CvMat
				Cv.GetRow(data, sample, i)

				r = svm.Predict(sample)
				' compare results
				Console.WriteLine("predict: {0}, responses: {1}, {2}", CChar(r), CChar(responses.DataArraySingle(i)),If(Math.Abs(CDbl(r) - responses.DataArraySingle(i)) <= Single.Epsilon, "Good!", "Bad!"))
				r = If(Math.Abs(CDbl(r) - responses.DataArraySingle(i)) <= Single.Epsilon, 1, 0)

				If i < ntrainSamples Then
					trainHr += r
				Else
					testHr += r
				End If
			Next i

			testHr /= CDbl(nsamplesAll - ntrainSamples)
			trainHr /= CDbl(ntrainSamples)
			Console.WriteLine("Gamma={0:F5}, C={1:F5}", SvmGamma, SvmC)
			If filenameToLoad IsNot Nothing Then
				Console.WriteLine("Recognition rate: test = {0:F1}%", testHr * 100.0)
			Else
				Console.WriteLine("Recognition rate: train = {0:F1}%, test = {1:F1}%", trainHr * 100.0, testHr * 100.0)
			End If

			Console.WriteLine("Number of Support Vector: {0}", svm.GetSupportVectorCount())
			' Save SVM classifier to file if needed
			If filenameToSave IsNot Nothing Then
				svm.Save(filenameToSave)
			End If


			Console.Read()


			If sampleIdx IsNot Nothing Then
				sampleIdx.Dispose()
			End If
			data.Dispose()
			responses.Dispose()
			svm.Dispose()
		End Sub

	End Class
End Namespace
