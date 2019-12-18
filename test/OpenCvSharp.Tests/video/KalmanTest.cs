using Xunit;

namespace OpenCvSharp.Tests.Video
{
    public class KalmanTest : TestBase
    {
        [Fact]
        public void StatePre()
        {
            using var kalman = new KalmanFilter();
            using var propValue = kalman.StatePre;
            Assert.NotNull(propValue);
            Assert.True(propValue.Empty());

            using var mat = new Mat(2, 2, MatType.CV_8U, new byte[,]
            {
                { 1, 1 },
                { 0, 1 }
            });
            kalman.StatePre = mat;
            IsDataEqual(mat, kalman.StatePre);
        }

        [Fact]
        public void StatePost()
        {
            using var kalman = new KalmanFilter();
            using var propValue = kalman.StatePost;
            Assert.NotNull(propValue);
            Assert.True(propValue.Empty());

            using var mat = new Mat(2, 2, MatType.CV_8U, new byte[,]
            {
                { 1, 1 },
                { 0, 1 }
            });
            kalman.StatePost = mat;
            IsDataEqual(mat, kalman.StatePost);
        }

        [Fact]
        public void TransitionMatrix()
        {
            using var kalman = new KalmanFilter();
            using var propValue = kalman.TransitionMatrix;
            Assert.NotNull(propValue);
            Assert.True(propValue.Empty());

            using var mat = new Mat(2, 2, MatType.CV_8U, new byte[,]
            {
                { 1, 1 },
                { 0, 1 }
            });
            kalman.TransitionMatrix = mat;
            IsDataEqual(mat, kalman.TransitionMatrix);
        }

        [Fact]
        public void ControlMatrix()
        {
            using var kalman = new KalmanFilter();
            using var propValue = kalman.ControlMatrix;
            Assert.NotNull(propValue);
            Assert.True(propValue.Empty());

            using var mat = new Mat(2, 2, MatType.CV_8U, new byte[,]
            {
                { 1, 1 },
                { 0, 1 }
            });
            kalman.ControlMatrix = mat;
            IsDataEqual(mat, kalman.ControlMatrix);
        }

        [Fact]
        public void MeasurementMatrix()
        {
            using var kalman = new KalmanFilter();
            using var propValue = kalman.MeasurementMatrix;
            Assert.NotNull(propValue);
            Assert.True(propValue.Empty());

            using var mat = new Mat(2, 2, MatType.CV_8U, new byte[,]
            {
                { 1, 1 },
                { 0, 1 }
            });
            kalman.MeasurementMatrix = mat;
            IsDataEqual(mat, kalman.MeasurementMatrix);
        }

        [Fact]
        public void ProcessNoiseCov()
        {
            using var kalman = new KalmanFilter();
            using var propValue = kalman.ProcessNoiseCov;
            Assert.NotNull(propValue);
            Assert.True(propValue.Empty());

            using var mat = new Mat(2, 2, MatType.CV_8U, new byte[,]
            {
                { 1, 1 },
                { 0, 1 }
            });
            kalman.ProcessNoiseCov = mat;
            IsDataEqual(mat, kalman.ProcessNoiseCov);
        }

        [Fact]
        public void MeasurementNoiseCov()
        {
            using var kalman = new KalmanFilter();
            using var propValue = kalman.MeasurementNoiseCov;
            Assert.NotNull(propValue);
            Assert.True(propValue.Empty());

            using var mat = new Mat(2, 2, MatType.CV_8U, new byte[,]
            {
                { 1, 1 },
                { 0, 1 }
            });
            kalman.MeasurementNoiseCov = mat;
            IsDataEqual(mat, kalman.MeasurementNoiseCov);
        }

        [Fact]
        public void ErrorCovPre()
        {
            using var kalman = new KalmanFilter();
            using var propValue = kalman.ErrorCovPre;
            Assert.NotNull(propValue);
            Assert.True(propValue.Empty());

            using var mat = new Mat(2, 2, MatType.CV_8U, new byte[,]
            {
                { 1, 1 },
                { 0, 1 }
            });
            kalman.ErrorCovPre = mat;
            IsDataEqual(mat, kalman.ErrorCovPre);
        }

        [Fact]
        public void Gain()
        {
            using var kalman = new KalmanFilter();
            using var propValue = kalman.Gain;
            Assert.NotNull(propValue);
            Assert.True(propValue.Empty());

            using var mat = new Mat(2, 2, MatType.CV_8U, new byte[,]
            {
                { 1, 1 },
                { 0, 1 }
            });
            kalman.Gain = mat;
            IsDataEqual(mat, kalman.Gain);
        }

        [Fact]
        public void ErrorCovPost()
        {
            using var kalman = new KalmanFilter();
            using var propValue = kalman.ErrorCovPost;
            Assert.NotNull(propValue);
            Assert.True(propValue.Empty());

            using var mat = new Mat(2, 2, MatType.CV_8U, new byte[,]
            {
                { 1, 1 },
                { 0, 1 }
            });
            kalman.ErrorCovPost = mat;
            IsDataEqual(mat, kalman.ErrorCovPost);
        }

        private static void IsDataEqual(Mat lhs, Mat rhs)
        {
            Assert.Equal(lhs.Size(), rhs.Size());
            Assert.Equal(lhs.Type(), rhs.Type());
            Assert.Equal(lhs.Sum(), rhs.Sum());

            using var diff = lhs - rhs;
            Assert.Equal(Scalar.Black, Cv2.Sum(diff));
        }
    }
}
