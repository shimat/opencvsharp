using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using OpenCvSharp.Analyzers;
using Xunit;

namespace OpenCvSharp.Analyzers.Tests;

public class MatExprChainAnalyzerTests
{
    private const string MatStub = """
        namespace OpenCvSharp
        {
            public class Mat : System.IDisposable
            {
                public static MatExpr operator +(Mat a, Mat b) => new MatExpr();
                public static MatExpr operator -(Mat a, Mat b) => new MatExpr();
                public static MatExpr operator *(Mat a, double s) => new MatExpr();
                public void Dispose() { }
            }
            public class MatExpr : System.IDisposable
            {
                public static MatExpr operator +(MatExpr a, Mat b) => new MatExpr();
                public static implicit operator Mat(MatExpr e) => new Mat();
                public void Dispose() { }
            }
        }
        """;

    private static Task Verify(string source, params DiagnosticResult[] expected)
    {
        var test = new CSharpAnalyzerTest<MatExprChainAnalyzer, XUnitVerifier>
        {
            TestCode = MatStub + source,
        };
        test.ExpectedDiagnostics.AddRange(expected);
        return test.RunAsync();
    }

    [Fact]
    public Task TripleChain_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat a, OpenCvSharp.Mat b, OpenCvSharp.Mat c)
            {
                OpenCvSharp.Mat result = {|#0:a + b|} + c;
            }
        }
        """,
        DiagnosticResult.CompilerWarning(MatExprChainAnalyzer.DiagnosticId)
            .WithLocation(0).WithArguments("+"));

    [Fact]
    public Task SimpleAdd_AssignedToVar_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat a, OpenCvSharp.Mat b)
            {
                OpenCvSharp.Mat result = a + b;
            }
        }
        """);

    [Fact]
    public Task ParenthesizedChain_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat a, OpenCvSharp.Mat b, OpenCvSharp.Mat c)
            {
                OpenCvSharp.Mat result = ({|#0:a + b|}) + c;
            }
        }
        """,
        DiagnosticResult.CompilerWarning(MatExprChainAnalyzer.DiagnosticId)
            .WithLocation(0).WithArguments("+"));

    [Fact]
    public Task UsingMatExprVariable_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat a, OpenCvSharp.Mat b, OpenCvSharp.Mat c)
            {
                using var ab = a + b;
                OpenCvSharp.Mat result = ab + c;
            }
        }
        """);
}
