using Xunit;

namespace OpenCvSharp.Tests.ImgProc;

public class Subdiv2DTest
{
    [Fact]
    public void Create()
    {
        using var subdiv = new Subdiv2D();
    }

    [Fact]
    public void CreateWithRect()
    {
        using var subdiv = new Subdiv2D(new Rect(0, 0, 500, 500));
    }

    [Fact]
    public void InitDelaunay()
    {
        using var subdiv = new Subdiv2D();
        subdiv.InitDelaunay(new Rect(0, 0, 800, 600));
    }
        
    [Fact]
    public void GetTriangleList()
    {
        using var subdiv = new Subdiv2D(new Rect(0, 0, 500, 500));

        var points = new[] {new Point2f(300, 100), new Point2f(200, 300), new Point2f(400, 300)};
        subdiv.Insert(points[0]);
        subdiv.Insert(points[1]);
        subdiv.Insert(points[2]);

        var triangles = subdiv.GetTriangleList();
        Assert.Single(triangles);

        var triangleVertices = new[]
        {
            triangles[0].Item0, triangles[0].Item1, triangles[0].Item2, triangles[0].Item3, triangles[0].Item4, triangles[0].Item5,
        };
        foreach (var point in points)
        {
            Assert.Contains(point.X, triangleVertices);
            Assert.Contains(point.Y, triangleVertices);
        }
    }
        
    [Fact]
    public void GetVoronoiFacetList()
    {
        using var subdiv = new Subdiv2D(new Rect(0, 0, 500, 500));

        var points = new[] {new Point2f(300, 100), new Point2f(200, 300), new Point2f(400, 300)};
        subdiv.Insert(points);

        subdiv.GetVoronoiFacetList(null, out var facetList, out var facetCenters);
        Assert.Equal(3, facetList.Length);
        Assert.Equal(3, facetCenters.Length);
        Assert.Equal(4, facetList[0].Length);
    }
}
