Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports OpenCvSharp

Namespace OpenCvSharpSamples
	''' <summary>
	''' カルマンフィルタ
	''' </summary>
	''' <remarks>http://opencv.jp/opencv-1.1.0/document/opencvref_cv_estimators.html#decl_CvKalman</remarks>
	Friend Class Kalman
'INSTANT VB TODO TASK: There is no equivalent to the 'unsafe' modifier in VB:
'ORIGINAL LINE: public unsafe Kalman()
		Public Sub New()
			' cvKalmanPredict, cvKalmanCorrect
			' カルマンフィルタを用いて回転する点を追跡する

			' A matrix data
			Dim A() As Single = { 1, 1, 0, 1 }

			Using img As New IplImage(500, 500, BitDepth.U8, 3)
			Using kalman As New CvKalman(2, 1, 0)
			Using window As New CvWindow("Kalman", WindowMode.AutoSize)
				' state is (phi, delta_phi) - angle and angle increment
				Dim state As New CvMat(2, 1, MatrixType.F32C1)
				Dim process_noise As New CvMat(2, 1, MatrixType.F32C1)
				' only phi (angle) is measured
				Dim measurement As New CvMat(1, 1, MatrixType.F32C1)

				measurement.SetZero()
				Dim rng As New CvRandState(0, 1, -1, DistributionType.Uniform)
				Dim code As Integer = -1

				Do
					Cv.RandSetRange(rng, 0, 0.1, 0)
					rng.DistType = DistributionType.Normal

					Marshal.Copy(A, 0, kalman.TransitionMatrix.Data, A.Length)
					kalman.MeasurementMatrix.SetIdentity(1)
					kalman.ProcessNoiseCov.SetIdentity(1e-5)
					kalman.MeasurementNoiseCov.SetIdentity(1e-1)
					kalman.ErrorCovPost.SetIdentity(1)
					' choose random initial state
					Cv.Rand(rng, kalman.StatePost)
					rng.DistType = DistributionType.Normal

					Do
						Dim state_angle As Single = state.DataSingle(0)
						Dim state_pt As CvPoint = CalcPoint(img, state_angle)

						' predict point position
						Dim prediction As CvMat = kalman.Predict(Nothing)
						Dim predict_angle As Single = prediction.DataSingle(0)
						Dim predict_pt As CvPoint = CalcPoint(img, predict_angle)

						Cv.RandSetRange(rng, 0, Math.Sqrt(kalman.MeasurementNoiseCov.DataSingle(0)), 0)
						Cv.Rand(rng, measurement)

						' generate measurement
						Cv.MatMulAdd(kalman.MeasurementMatrix, state, measurement, measurement)

						Dim measurement_angle As Single = measurement.DataArraySingle(0)
						Dim measurement_pt As CvPoint = CalcPoint(img, measurement_angle)

						img.SetZero()
						DrawCross(img, state_pt, CvColor.White, 3)
						DrawCross(img, measurement_pt, CvColor.Red, 3)
						DrawCross(img, predict_pt, CvColor.Green, 3)
						img.Line(state_pt, measurement_pt, New CvColor(255, 0, 0), 3, LineType.AntiAlias, 0)
						img.Line(state_pt, predict_pt, New CvColor(255, 255, 0), 3, LineType.AntiAlias, 0)

						' adjust Kalman filter state
						kalman.Correct(measurement)

						Cv.RandSetRange(rng, 0, Math.Sqrt(kalman.ProcessNoiseCov.DataSingle(0)), 0)
						Cv.Rand(rng, process_noise)
						Cv.MatMulAdd(kalman.TransitionMatrix, state, process_noise, state)

						window.ShowImage(img)
						' break current simulation by pressing a key
						code = CvWindow.WaitKey(100)
						If code > 0 Then
							Exit Do
						End If
					Loop
					' exit by ESCAPE
					If code = 27 Then
						Exit Do
					End If
				Loop
			End Using
			End Using
			End Using
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="img"></param>
		''' <param name="angle"></param>
		''' <returns></returns>
		Private Function CalcPoint(ByVal img As IplImage, ByVal angle As Single) As CvPoint
			Return New CvPoint With {.X = CInt(Math.Truncate(Math.Round(img.Width / 2.0 + img.Width / 3.0 * Math.Cos(angle)))), .Y = CInt(Math.Truncate(Math.Round(img.Height / 2.0 - img.Width / 3.0 * Math.Sin(angle))))}
		End Function
		''' <summary>
		''' 点をプロット
		''' </summary>
		''' <param name="img"></param>
		''' <param name="center"></param>
		''' <param name="color"></param>
		''' <param name="d"></param>
		Private Sub DrawCross(ByVal img As IplImage, ByVal center As CvPoint, ByVal color As CvColor, ByVal d As Integer)
			img.Line(center.X - d, center.Y - d, center.X + d, center.Y + d, color, 1, 0)
			img.Line(center.X + d, center.Y - d, center.X - d, center.Y + d, color, 1, 0)
		End Sub

	End Class
End Namespace
