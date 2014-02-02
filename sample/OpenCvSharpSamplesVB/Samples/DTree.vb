Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.MachineLearning

Namespace OpenCvSharpSamples
	''' <summary>
	''' samples/c/mushroom.c
	''' </summary>
	''' <remarks>
	''' The sample demonstrates how to build a decision tree for classifying mushrooms.
	''' It uses the sample base agaricus-lepiota.data from UCI Repository, here is the link:
	'''
	''' Newman, D.J. & Hettich, S. & Blake, C.L. & Merz, C.J. (1998).
	''' UCI Repository of machine learning databases
	''' [http://www.ics.uci.edu/~mlearn/MLRepository.html].
	''' Irvine, CA: University of California, Department of Information and Computer Science.
	''' </remarks>
	Friend Class DTree
		Private ReadOnly VarDesc() As String = { "cap shape (bell=b,conical=c,convex=x,flat=f)", "cap surface (fibrous=f,grooves=g,scaly=y,smooth=s)", "cap color (brown=n,buff=b,cinnamon=c,gray=g,green=r," & vbLf & vbTab & "pink=p,purple=u,red=e,white=w,yellow=y)", "bruises? (bruises=t,no=f)", "odor (almond=a,anise=l,creosote=c,fishy=y,foul=f," & vbLf & vbTab & "musty=m,none=n,pungent=p,spicy=s)", "gill attachment (attached=a,descending=d,free=f,notched=n)", "gill spacing (close=c,crowded=w,distant=d)", "gill size (broad=b,narrow=n)", "gill color (black=k,brown=n,buff=b,chocolate=h,gray=g," & vbLf & vbTab & "green=r,orange=o,pink=p,purple=u,red=e,white=w,yellow=y)", "stalk shape (enlarging=e,tapering=t)", "stalk root (bulbous=b,club=c,cup=u,equal=e,rhizomorphs=z,rooted=r)", "stalk surface above ring (ibrous=f,scaly=y,silky=k,smooth=s)", "stalk surface below ring (ibrous=f,scaly=y,silky=k,smooth=s)", "stalk color above ring (brown=n,buff=b,cinnamon=c,gray=g,orange=o," & vbLf & vbTab & "pink=p,red=e,white=w,yellow=y)", "stalk color below ring (brown=n,buff=b,cinnamon=c,gray=g,orange=o," & vbLf & vbTab & "pink=p,red=e,white=w,yellow=y)", "veil type (partial=p,universal=u)", "veil color (brown=n,orange=o,white=w,yellow=y)", "ring number (none=n,one=o,two=t)", "ring type (cobwebby=c,evanescent=e,flaring=f,large=l," & vbLf & vbTab & "none=n,pendant=p,sheathing=s,zone=z)", "spore print color (black=k,brown=n,buff=b,chocolate=h,green=r," & vbLf & vbTab & "orange=o,purple=u,white=w,yellow=y)", "population (abundant=a,clustered=c,numerous=n," & vbLf & vbTab & "scattered=s,several=v,solitary=y)", "habitat (grasses=g,leaves=l,meadows=m,paths=p" & vbLf & vbTab & "urban=u,waste=w,woods=d)"}

		''' <summary>
		''' main
		''' </summary>
		Public Sub New()
			Dim data As CvMat
			Dim missing As CvMat
			Dim responses As CvMat
			Dim dtree As CvDTree

			If Not MushroomReadDatabase([Const].DataMushroom, data, missing, responses) Then
				Console.WriteLine("Unable to load the training database" & vbLf & "Pass it as a parameter: dtree <path to agaricus-lepiota.data>" & vbLf)
				Return
			End If

			dtree = MushroomCreateDTree(data, missing, responses, 10) ' poisonous mushrooms will have 10x higher weight in the decision tree

			PrintVariableImportance(dtree)
			InteractiveClassification(dtree)

			data.Dispose()
			missing.Dispose()
			responses.Dispose()
			dtree.Dispose()

			Console.Read()
		End Sub


		''' <summary>
		''' loads the mushroom database, which is a text file, containing
		''' one training sample per row, all the input variables and the output variable are categorical,
		''' the values are encoded by characters.
		''' </summary>
		''' <param name="filename"></param>
		''' <param name="data"></param>
		''' <param name="missing"></param>
		''' <param name="responses"></param>
		''' <returns></returns>
		Private Function MushroomReadDatabase(ByVal filename As String, ByRef data As CvMat, ByRef missing As CvMat, ByRef responses As CvMat) As Boolean
			data = Nothing
			missing = Nothing
			responses = Nothing

			Dim varCount As Integer = 0
			Dim seq As New List(Of Single())()

			Try
				Using sr As New StreamReader(filename)
					Dim buf As String

					' read the first line and determine the number of variables
					buf = sr.ReadLine()
					For Each c As Char In buf
						varCount += If(c = ","c, 1, 0)
					Next c

					Do
						' create temporary memory storage to store the whole database
						Dim elPtr(varCount) As Single

						Dim i As Integer
						For i = 0 To varCount
							Dim c As Char = buf.Chars(i * 2)
							elPtr(i) = If(c = "?"c, -1.0F, CSng(c))
						Next i
						If i <> varCount + 1 Then
							Exit Do
						End If
						seq.Add(elPtr)
						buf = sr.ReadLine()
						If buf Is Nothing OrElse buf.IndexOf(","c) = -1 Then
							Exit Do
						End If
					Loop
				End Using
			Catch
				Return False
			End Try

			' allocate the output matrices and copy the base there
			data = New CvMat(seq.Count, varCount, MatrixType.F32C1)
			missing = New CvMat(seq.Count, varCount, MatrixType.U8C1)
			responses = New CvMat(seq.Count, 1, MatrixType.F32C1)

			For i As Integer = 0 To seq.Count - 1
'INSTANT VB TODO TASK: There is no equivalent to an 'unsafe' block in VB:
'				unsafe
'INSTANT VB TODO TASK: There is no equivalent to a 'fixed' block in VB:
'					fixed (float* _sdata = seq[i])
						Single* sdata = _sdata + 1
						Single* ddata = data.DataSingle + (varCount * i)
						Single* dr = responses.DataSingle + i
						Byte* dm = missing.DataByte + (varCount * i)

						For j As Integer = 0 To varCount - 1
							ddata(j) = sdata(j)
							dm(j) = If(sdata(j) < 0, CByte(1), CByte(0))
						Next j
						*dr = sdata(-1)
'INSTANT VB NOTE: End of the original C# 'fixed' block.
'INSTANT VB NOTE: End of the original C# 'unsafe' block.
			Next i

			Return True
		End Function


		''' <summary>
		''' 
		''' </summary>
		''' <param name="data"></param>
		''' <param name="missing"></param>
		''' <param name="responses"></param>
		''' <param name="pWeight"></param>
		''' <returns></returns>
		Private Function MushroomCreateDTree(ByVal data As CvMat, ByVal missing As CvMat, ByVal responses As CvMat, ByVal pWeight As Single) As CvDTree
			Dim priors() As Single = { 1, pWeight }

			Dim varType As New CvMat(data.Cols + 1, 1, MatrixType.U8C1)
			Cv.Set(varType, CvScalar.ScalarAll(CvStatModel.CV_VAR_CATEGORICAL)) ' all the variables are categorical

			Dim dtree As New CvDTree()

			Dim p As New CvDTreeParams(8, 10, 0, True, 15, 10, True, True, priors) ' the array of priors, the bigger p_weight, the more attention -  throw away the pruned tree branches -  use 1SE rule => smaller tree -  the number of cross-validation folds -  max number of categories (use sub-optimal algorithm for larger numbers) -  compute surrogate split, as we have missing data -  regression accuracy: N/A here -  min sample count -  max depth
				' to the poisonous mushrooms
				' (a mushroom will be judjed to be poisonous with bigger chance)

			dtree.Train(data, DTreeDataLayout.RowSample, responses, Nothing, Nothing, varType, missing, p)

			' compute hit-rate on the training database, demonstrates predict usage.
			Dim hr1 As Integer = 0, hr2 As Integer = 0, pTotal As Integer = 0
			For i As Integer = 0 To data.Rows - 1
				Dim sample, mask As CvMat
				Cv.GetRow(data, sample, i)
				Cv.GetRow(missing, mask, i)
				Dim r As Double = dtree.Predict(sample, mask).Value
				Dim d As Boolean = Math.Abs(r - responses.DataArraySingle(i)) >= Single.Epsilon
				If d Then
					If r <> "p"c Then
						hr1 += 1
					Else
						hr2 += 1
					End If
				End If
				'Console.WriteLine(responses.DataArraySingle[i]);
				pTotal += If(responses.DataArraySingle(i) = CSng("p"c), 1, 0)
			Next i

			Console.WriteLine("Results on the training database")
			Console.WriteLine(vbTab & "Poisonous mushrooms mis-predicted: {0} ({1}%)", hr1, CDbl(hr1) * 100 \ pTotal)
			Console.WriteLine(vbTab & "False-alarms: {0} ({1}%)", hr2, CDbl(hr2) * 100 / (data.Rows - pTotal))

			varType.Dispose()

			Return dtree
		End Function


		''' <summary>
		''' 
		''' </summary>
		''' <param name="dtree"></param>
		''' <param name="varDesc"></param>
		Private Sub PrintVariableImportance(ByVal dtree As CvDTree)
			Dim varImportance As CvMat = dtree.GetVarImportance()

			If varImportance Is Nothing Then
				Console.WriteLine("Error: Variable importance can not be retrieved")
				Return
			End If

			Console.Write("Print variable importance information? (y/n) ")
			Dim input As String = Console.ReadLine()
			If input.Chars(0) <> "y"c AndAlso input.Chars(0) <> "Y"c Then
				Return
			End If

			For i As Integer = 0 To (varImportance.Cols * varImportance.Rows) - 1
				Dim val As Double = varImportance.DataArrayDouble(i)
				Dim len As Integer = VarDesc(i).IndexOf("("c)
				Console.Write("{0}", VarDesc(i).Substring(0, len))
				Console.WriteLine(": {0}%", val * 100.0)
			Next i
		End Sub


		''' <summary>
		''' 
		''' </summary>
		''' <param name="dtree"></param>
		Private Sub InteractiveClassification(ByVal dtree As CvDTree)
			If dtree Is Nothing Then
				Return
			End If

			Dim root As CvDTreeNode = dtree.GetRoot()
			Dim data As CvDTreeTrainData = dtree.GetData()
			Dim input As String

			Do
				Dim node As CvDTreeNode

				Console.Write("Start/Proceed with interactive mushroom classification (y/n): ")
				input = Console.ReadLine()
				If input.Chars(0) <> "y"c AndAlso input.Chars(0) <> "Y"c Then
					Exit Do
				End If
				Console.WriteLine("Enter 1-letter answers, '?' for missing/unknown value...")

				' custom version of predict
				node = root
				Do
					Dim split As CvDTreeSplit = node.Split
					Dim dir As Integer = 0

					If node.Left Is Nothing OrElse node.Tn <= dtree.GetPrunedTreeIdx() OrElse node.Split Is Nothing Then
						Exit Do
					End If

					Do While split IsNot Nothing
						Dim j As Integer
						Dim vi As Integer = split.VarIdx
						Dim count As Integer = data.CatCount.DataArrayInt32(vi)


						Console.Write("{0}: ", VarDesc(vi))
						input = Console.ReadLine()


						If input.Chars(0) = "?"c Then
							split = split.Next
							Continue Do
						End If

						' convert the input character to the normalized value of the variable
'INSTANT VB TODO TASK: There is no equivalent to an 'unsafe' block in VB:
'						unsafe
							Integer* map = data.CatMap.DataInt32 + data.CatOfs.DataInt32(vi)
							For j = 0 To count - 1
								If map(j) = input.Chars(0) Then
									Exit For
								End If
							Next j
'INSTANT VB NOTE: End of the original C# 'unsafe' block.

						If j < count Then
							dir = If((split.Subset(j >> 5) And (1 << (j And 31))) <> 0, -1, 1)
							If split.Inversed Then
								dir = -dir
							End If
							Exit Do
						Else
							Console.WriteLine("Error: unrecognized value")
						End If
					Loop

					If dir = 0 Then
						Console.WriteLine("Impossible to classify the sample")
						node = Nothing
						Exit Do
					End If
					node = If(dir < 0, node.Left, node.Right)
				Loop

				If node IsNot Nothing Then
					Console.Write("Prediction result: the mushroom is {0}" & vbLf,If(node.ClassIdx = 0, "EDIBLE", "POISONOUS"))
				End If
				Console.Write(vbLf & "-----------------------------" & vbLf)
			Loop
		End Sub
	End Class
End Namespace
