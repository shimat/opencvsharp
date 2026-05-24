using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using OpenCvSharp.Analyzers;
using Xunit;

namespace OpenCvSharp.Analyzers.Tests;

public class MatPropertyInLoopConditionAnalyzerTests
{
    private const string MatStub = """
        namespace OpenCvSharp
        {
            public class Mat
            {
                public int Rows { get; }
                public int Cols { get; }
                public int Dims { get; }
                public int Width { get; }
                public int Height { get; }
            }
        }
        """;

    private static Task Verify(string source, params DiagnosticResult[] expected)
    {
        var test = new CSharpAnalyzerTest<MatPropertyInLoopConditionAnalyzer, XUnitVerifier>
        {
            TestCode = MatStub + source,
        };
        test.ExpectedDiagnostics.AddRange(expected);
        return test.RunAsync();
    }

    [Fact]
    public Task ForLoop_Rows_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                for (int i = 0; i < {|#0:mat.Rows|}; i++) { }
            }
        }
        """,
        DiagnosticResult.CompilerWarning(MatPropertyInLoopConditionAnalyzer.DiagnosticId)
            .WithLocation(0).WithArguments("Rows", "rows"));

    [Fact]
    public Task ForLoop_Cols_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                for (int j = 0; j < {|#0:mat.Cols|}; j++) { }
            }
        }
        """,
        DiagnosticResult.CompilerWarning(MatPropertyInLoopConditionAnalyzer.DiagnosticId)
            .WithLocation(0).WithArguments("Cols", "cols"));

    [Fact]
    public Task WhileLoop_Rows_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat, int i)
            {
                while (i < {|#0:mat.Rows|}) { i++; }
            }
        }
        """,
        DiagnosticResult.CompilerWarning(MatPropertyInLoopConditionAnalyzer.DiagnosticId)
            .WithLocation(0).WithArguments("Rows", "rows"));

    [Fact]
    public Task CachedLocal_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                int rows = mat.Rows;
                for (int i = 0; i < rows; i++) { }
            }
        }
        """);

    [Fact]
    public Task RowsUsedOutsideLoop_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                int n = mat.Rows;
            }
        }
        """);
}
