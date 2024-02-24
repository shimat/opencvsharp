namespace OpenCvSharp;

/// <summary>
/// 2-dimentional line vector
/// </summary>
public class Line2D
{
    #region Properties

    /// <summary>
    /// The X component of the normalized vector collinear to the line
    /// </summary>
    public double Vx { get; }

    /// <summary>
    /// The Y component of the normalized vector collinear to the line
    /// </summary>
    public double Vy { get; }

    /// <summary>
    /// X-coordinate of some point on the line
    /// </summary>
    public double X1 { get; }

    /// <summary>
    /// Y-coordinate of some point on the line
    /// </summary>
    public double Y1 { get; }

    #endregion

    #region Init

    /// <summary>
    /// Initializes this object
    /// </summary>
    /// <param name="vx">The X component of the normalized vector collinear to the line</param>
    /// <param name="vy">The Y component of the normalized vector collinear to the line</param>
    /// <param name="x1">Z-coordinate of some point on the line</param>
    /// <param name="y1">Z-coordinate of some point on the line</param>
    public Line2D(double vx, double vy, double x1, double y1)
    {
        Vx = vx;
        Vy = vy;
        X1 = x1;
        Y1 = y1;
    }

    /// <summary>
    /// Initializes by cvFitLine output 
    /// </summary>
    /// <param name="line">The returned value from cvFitLine</param>param>
    public Line2D(float[] line)
    {
        if (line is null)
            throw new ArgumentNullException(nameof(line));

        Vx = line[0];
        Vy = line[1];
        X1 = line[2];
        Y1 = line[3];
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public double GetVectorRadian()
    {
        return Math.Atan2(Vy, Vx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public double GetVectorAngle()
    {
        return GetVectorRadian() * 180 / Math.PI;
    }

    /// <summary>
    /// Returns the distance between this line and the specified point
    /// </summary>
    /// <param name="point"></param>
    public double Distance(Point point)
    {
        return Distance(point.X, point.Y);
    }

    /// <summary>
    /// Returns the distance between this line and the specified point
    /// </summary>
    /// <param name="point"></param>
    public double Distance(Point2f point)
    {
        return Distance(point.X, point.Y);
    }

    /// <summary>
    /// Returns the distance between this line and the specified point
    /// </summary>
    /// <param name="point"></param>
    public double Distance(Point2d point)
    {
        return Distance(point.X, point.Y);
    }

    /// <summary>
    /// Returns the distance between this line and the specified point
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public double Distance(double x, double y)
    {
        // 公式で
        var m = Vy / Vx;
        var n = Y1 - m * X1; 
        return Math.Abs(y - m * x - n) / Math.Sqrt(1 + m * m);
    }

    /// <summary>
    /// Fits this line to the specified size (for drawing)
    /// </summary>
    /// <param name="width">Width of fit size</param>
    /// <param name="height">Height of fit size</param>
    /// <param name="pt1">1st edge point of fitted line</param>
    /// <param name="pt2">2nd edge point of fitted line</param>
    public void FitSize(int width, int height, out Point pt1, out Point pt2)
    {
        double t = (width + height);
        pt1 = new Point
        {
            X = (int)Math.Round(X1 - Vx*t),
            Y = (int)Math.Round(Y1 - Vy * t)
        };
        pt2 = new Point
        {
            X = (int)Math.Round(X1 + Vx * t),
            Y = (int)Math.Round(Y1 + Vy * t)
        };
    }

    #endregion
}
