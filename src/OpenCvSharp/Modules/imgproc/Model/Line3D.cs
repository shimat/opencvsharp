namespace OpenCvSharp;

/// <summary>
/// A 3-dimensional line object
/// </summary>
public class Line3D
{
    /// <summary>
    /// The X component of the normalized vector collinear to the line
    /// </summary>
    public double Vx { get; }

    /// <summary>
    /// The Y component of the normalized vector collinear to the line
    /// </summary>
    public double Vy { get; }

    /// <summary>
    /// The Z component of the normalized vector collinear to the line
    /// </summary>
    public double Vz { get; }

    /// <summary>
    /// X-coordinate of some point on the line
    /// </summary>
    public double X1 { get; }

    /// <summary>
    /// Y-coordinate of some point on the line
    /// </summary>
    public double Y1 { get; }

    /// <summary>
    /// Z-coordinate of some point on the line
    /// </summary>
    public double Z1 { get; }
        
    /// <summary>
    /// Initializes this object
    /// </summary>
    /// <param name="vx">The X component of the normalized vector collinear to the line</param>
    /// <param name="vy">The Y component of the normalized vector collinear to the line</param>
    /// <param name="vz">The Z component of the normalized vector collinear to the line</param>
    /// <param name="x1">Z-coordinate of some point on the line</param>
    /// <param name="y1">Z-coordinate of some point on the line</param>
    /// <param name="z1">Z-coordinate of some point on the line</param>
    public Line3D(double vx, double vy, double vz, double x1, double y1, double z1)
    {
        Vx = vx;
        Vy = vy;
        Vz = vz;
        X1 = x1;
        Y1 = y1;
        Z1 = z1;
    }

    /// <summary>
    /// Initializes by cvFitLine output 
    /// </summary>
    /// <param name="line">The returned value from cvFitLine</param>param>
    public Line3D(float[] line)
    {
        if (line is null)
            throw new ArgumentNullException(nameof(line));
        if (line.Length != 6)
            throw new ArgumentException("array.Length != 6", nameof(line));

        Vx = line[0];
        Vy = line[1];
        Vz = line[2];
        X1 = line[3];
        Y1 = line[4];
        Z1 = line[5];
    }

    /// <summary>
    /// Perpendicular foot
    /// </summary>
    /// <param name="point"></param>
    public Point3d PerpendicularFoot(Point3f point)
    {
        return PerpendicularFoot(point.X, point.Y, point.Z);
    }

    /// <summary>
    /// Perpendicular foot
    /// </summary>
    /// <param name="point"></param>
    public Point3d PerpendicularFoot(Point3d point)
    {
        return PerpendicularFoot(point.X, point.Y, point.Z);
    }

    /// <summary>
    /// Perpendicular foot
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public Point3d PerpendicularFoot(double x, double y, double z)
    {
        var xa = X1;
        var ya = Y1;
        var za = Z1;
        var xb = X1 + Vx;
        var yb = Y1 + Vy;
        var zb = Z1 + Vz;

        var k = ((x - xa)*(xb - xa) + (y - ya)*(yb - ya) + (z - za)*(zb - za))/
                (Math.Pow(xb - xa, 2) + Math.Pow(yb - ya, 2) + Math.Pow(zb - za, 2));

        var hx = k*xb+(1-k)*xa;
        var hy = k*yb+(1-k)*ya;
        var hz = k*zb+(1-k)*za;
        return new Point3d(hx, hy, hz);
    }

    /// <summary>
    /// Returns the distance between this line and the specified point
    /// </summary>
    /// <param name="point"></param>
    public double Distance(Point3f point)
    {
        return Distance(point.X, point.Y, point.Z);
    }

    /// <summary>
    /// Returns the distance between this line and the specified point
    /// </summary>
    /// <param name="point"></param>
    public double Distance(Point3d point)
    {
        return Distance(point.X, point.Y, point.Z);
    }

    /// <summary>
    /// Returns the distance between this line and the specified point
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public double Distance(double x, double y, double z)
    {
        var p = new Point3d(x, y, z);
        var a = new Point3d(X1, Y1, Z1);
        var b = new Point3d(X1 + Vx, Y1 + Vy, Z1 + Vz);
        var ab = new Point3d { X = b.X - a.X, Y = b.Y - a.Y, Z = b.Z - a.Z };
        var ap = new Point3d { X = p.X - a.X, Y = p.Y - a.Y, Z = p.Z - a.Z };

        // AB, APを外積 -> 平行四辺形Dの面積
        var d = VectorLength(CrossProduct(ab, ap));
        // AB間の距離
        var l = VertexDistance(a, b);
        // 平行四辺形の高さ(垂線)
        var h = d / l;
        return h;
    }

    /// <summary>
    /// ベクトルの外積
    /// </summary>
    /// <param name="vl"></param>
    /// <param name="vr"></param>
    /// <returns></returns>
    private static Point3d CrossProduct(Point3d vl, Point3d vr)
    {
        var ret = new Point3d
        {
            X = (vl.Y*vr.Z) - (vl.Z*vr.Y), 
            Y = (vl.Z*vr.X) - (vl.X*vr.Z), 
            Z = (vl.X*vr.Y) - (vl.Y*vr.X)
        };
        return ret;
    }

    /// <summary>
    /// ベクトルの長さ(原点からの距離)
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private static double VectorLength(Point3d v)
    {
        return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
    }

    /// <summary>
    /// 2点間(2ベクトル)の距離
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    private static double VertexDistance(Point3d p1, Point3d p2)
    {
        return Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + 
                         (p2.Y - p1.Y) * (p2.Y - p1.Y) + 
                         (p2.Z - p1.Z) * (p2.Z - p1.Z));
    }
}
