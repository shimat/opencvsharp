using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using OpenCvSharp.Analyzers;
using Xunit;

namespace OpenCvSharp.Analyzers.Tests;

public class RowColNotDisposedAnalyzerTests
{
    private const string MatStub = """
        namespace OpenCvSharp
        {
            public class Mat : System.IDisposable
            {
                public Mat Row(int y) => this;
                public Mat Col(int x) => this;
                public Mat RowRange(int start, int end) => this;
                public Mat ColRange(int start, int end) => this;
                public T At<T>(int i0) where T : struct => default;
                public Mat Clone() => new Mat();
                public void Dispose() { }
            }
        }
        """;

    private static Task Verify(string source, params DiagnosticResult[] expected)
    {
        var test = new CSharpAnalyzerTest<RowColNotDisposedAnalyzer, XUnitVerifier>
        {
            TestCode = MatStub + source,
        };
        test.ExpectedDiagnostics.AddRange(expected);
        return test.RunAsync();
    }

    [Fact]
    public Task VarWithoutUsing_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                var row = {|#0:mat.Row(0)|};
            }
        }
        """,
        DiagnosticResult.CompilerWarning(RowColNotDisposedAnalyzer.DiagnosticId)
            .WithLocation(0).WithArguments("Row"));

    [Fact]
    public Task UsingVar_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                using var row = mat.Row(0);
            }
        }
        """);

    [Fact]
    public Task UsingStatement_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                using (var row = mat.RowRange(0, 2)) { }
            }
        }
        """);

    [Fact]
    public Task PassedAsArgument_NoWarning() => Verify(
        """
        class Test
        {
            void Use(OpenCvSharp.Mat m) { }
            void M(OpenCvSharp.Mat mat)
            {
                Use(mat.Row(0));
            }
        }
        """);

    [Fact]
    public Task ChainedAtCall_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                int v = mat.Row(0).At<int>(3);
            }
        }
        """);

    [Fact]
    public Task ChainedCloneCall_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                var copy = {|#0:mat.Row(0)|}.Clone();
            }
        }
        """,
        DiagnosticResult.CompilerWarning(RowColNotDisposedAnalyzer.DiagnosticId)
            .WithLocation(0).WithArguments("Row"));

    [Fact]
    public Task ColRangeWithoutUsing_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                var c = {|#0:mat.ColRange(0, 3)|};
            }
        }
        """,
        DiagnosticResult.CompilerWarning(RowColNotDisposedAnalyzer.DiagnosticId)
            .WithLocation(0).WithArguments("ColRange"));
}
