using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using OpenCvSharp.Analyzers;
using Xunit;

namespace OpenCvSharp.Analyzers.Tests;

public class RowColInLoopBodyAnalyzerTests
{
    private const string MatStub = """
        namespace OpenCvSharp
        {
            public class Mat
            {
                public int Rows { get; }
                public Mat Row(int y) => this;
                public Mat Col(int x) => this;
            }
        }
        """;

    private static Task Verify(string source, params DiagnosticResult[] expected)
    {
        var test = new CSharpAnalyzerTest<RowColInLoopBodyAnalyzer, XUnitVerifier>
        {
            TestCode = MatStub + source,
        };
        test.ExpectedDiagnostics.AddRange(expected);
        return test.RunAsync();
    }

    [Fact]
    public Task RowInForLoop_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                int rows = mat.Rows;
                for (int i = 0; i < rows; i++)
                {
                    var row = {|#0:mat.Row(i)|};
                }
            }
        }
        """,
        DiagnosticResult.CompilerWarning(RowColInLoopBodyAnalyzer.DiagnosticId)
            .WithLocation(0).WithArguments("Row"));

    [Fact]
    public Task ColInWhileLoop_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat, int i)
            {
                while (i < 10)
                {
                    var col = {|#0:mat.Col(i)|};
                    i++;
                }
            }
        }
        """,
        DiagnosticResult.CompilerWarning(RowColInLoopBodyAnalyzer.DiagnosticId)
            .WithLocation(0).WithArguments("Col"));

    [Fact]
    public Task RowOutsideLoop_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                var row = mat.Row(0);
            }
        }
        """);

    [Fact]
    public Task RowInForLoopCondition_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                for (int i = 0; i < mat.Row(0).Rows; i++) { }
            }
        }
        """);

    [Fact]
    public Task RowInForLoopInitializer_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                for (var r = mat.Row(0); ; ) { }
            }
        }
        """);

    [Fact]
    public Task RowInNestedLambda_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Action a = () => mat.Row(0);  // lambda boundary — not flagged
                }
            }
        }
        """);
}
