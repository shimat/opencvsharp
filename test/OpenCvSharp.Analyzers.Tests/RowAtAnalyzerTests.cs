using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using OpenCvSharp.Analyzers;
using Xunit;

namespace OpenCvSharp.Analyzers.Tests;

public class RowAtAnalyzerTests
{
    // Minimal stub of OpenCvSharp.Mat — lets the analyzer resolve types
    // without requiring the actual OpenCvSharp assembly.
    private const string MatStub = """
        namespace OpenCvSharp
        {
            public class Mat
            {
                public Mat Row(int y) => this;
                public ref T At<T>(int i0) where T : unmanaged => throw null!;
                public ref T At<T>(int i0, int i1) where T : unmanaged => throw null!;
            }
            public struct Vec3b { }
        }
        """;

    private static Task Verify(string source, params DiagnosticResult[] expected)
    {
        var test = new CSharpAnalyzerTest<RowAtAnalyzer, XUnitVerifier>
        {
            TestCode = MatStub + source,
        };
        test.ExpectedDiagnostics.AddRange(expected);
        return test.RunAsync();
    }

    [Fact]
    public Task DirectChain_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                var _ = {|#0:mat.Row(1).At<OpenCvSharp.Vec3b>(2)|};
            }
        }
        """,
        DiagnosticResult.CompilerWarning(RowAtAnalyzer.DiagnosticId).WithLocation(0));

    [Fact]
    public Task LocalVariable_ReportsWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                var row = mat.Row(1);
                var _ = {|#0:row.At<OpenCvSharp.Vec3b>(2)|};
            }
        }
        """,
        DiagnosticResult.CompilerWarning(RowAtAnalyzer.DiagnosticId).WithLocation(0));

    [Fact]
    public Task TwoArgAt_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                var _ = mat.At<OpenCvSharp.Vec3b>(1, 2);
            }
        }
        """);

    [Fact]
    public Task AtOnFullMatrix_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat)
            {
                var _ = mat.At<OpenCvSharp.Vec3b>(1);
            }
        }
        """);

    [Fact]
    public Task LocalAssignedFromNonRowMethod_NoWarning() => Verify(
        """
        class Test
        {
            void M(OpenCvSharp.Mat mat, OpenCvSharp.Mat other)
            {
                var row = other;
                var _ = row.At<OpenCvSharp.Vec3b>(2);
            }
        }
        """);
}
