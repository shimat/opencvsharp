using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace OpenCvSharp.Analyzers;

/// <summary>
/// Detects the misuse pattern <c>mat.Row(i).At&lt;T&gt;(col)</c> where the column index is
/// silently interpreted as a row index, causing out-of-bounds memory access.
/// </summary>
/// <remarks>
/// <para>
/// <c>Mat.Row(i)</c> returns a 1×N submatrix. <c>At&lt;T&gt;(int i0)</c> on a 2D matrix
/// treats <c>i0</c> as the row index (dimension 0), not a column index. The resulting
/// address is <c>data + step * col</c> — jumping entire rows past the end of the submatrix.
/// </para>
/// <para>
/// Use <c>mat.At&lt;T&gt;(row, col)</c> or <c>mat.AsRows&lt;T&gt;()</c> instead.
/// See https://github.com/shimat/opencvsharp/issues/1775
/// </para>
/// </remarks>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class RowAtAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "OCVS001";

    private static readonly DiagnosticDescriptor Rule = new(
        id: DiagnosticId,
        title: "At<T>(int) called on a Mat row submatrix",
        messageFormat: "At<T>(int) on the 1-row Mat returned by Row() treats the argument as a row index, " +
                       "not a column index, silently producing wrong results or out-of-bounds access. " +
                       "Use mat.At<T>(row, col) or mat.AsRows<T>() instead.",
        category: "Correctness",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Mat.Row(i) returns a 2D 1×N submatrix. At<T>(int i0) interprets i0 as a row " +
                     "index (dimension 0), not a column index. Access the parent matrix directly: " +
                     "mat.At<T>(row, col), or use mat.AsRows<T>() for high-performance loops.",
        helpLinkUri: "https://github.com/shimat/opencvsharp/issues/1775");

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(AnalyzeInvocation, SyntaxKind.InvocationExpression);
    }

    private static void AnalyzeInvocation(SyntaxNodeAnalysisContext context)
    {
        var atInvocation = (InvocationExpressionSyntax)context.Node;

        if (!IsMatAtIntCall(atInvocation, context.SemanticModel))
            return;

        if (atInvocation.Expression is not MemberAccessExpressionSyntax memberAccess)
            return;

        var receiver = memberAccess.Expression;

        // Case 1: direct chain — mat.Row(i).At<T>(c)
        if (IsMatRowCall(receiver, context.SemanticModel))
        {
            context.ReportDiagnostic(Diagnostic.Create(Rule, atInvocation.GetLocation()));
            return;
        }

        // Case 2: local variable — var row = mat.Row(i); row.At<T>(c)
        if (receiver is IdentifierNameSyntax identifier &&
            context.SemanticModel.GetSymbolInfo(identifier).Symbol is ILocalSymbol local &&
            IsLocalDeclaredFromRowCall(local, context.SemanticModel))
        {
            context.ReportDiagnostic(Diagnostic.Create(Rule, atInvocation.GetLocation()));
        }
    }

    /// <summary>
    /// Returns true when <paramref name="expr"/> is a call to <c>OpenCvSharp.Mat.At&lt;T&gt;(int)</c>.
    /// </summary>
    private static bool IsMatAtIntCall(InvocationExpressionSyntax expr, SemanticModel model)
    {
        if (expr.Expression is not MemberAccessExpressionSyntax ma)
            return false;
        if (ma.Name.Identifier.ValueText != "At")
            return false;
        if (expr.ArgumentList.Arguments.Count != 1)
            return false;

        var sym = model.GetSymbolInfo(expr).Symbol as IMethodSymbol;
        return sym is { Parameters.Length: 1 } &&
               sym.ContainingType?.ToDisplayString() == "OpenCvSharp.Mat" &&
               sym.Parameters[0].Type.SpecialType == SpecialType.System_Int32;
    }

    /// <summary>
    /// Returns true when <paramref name="expr"/> is a call to <c>OpenCvSharp.Mat.Row(int)</c>.
    /// </summary>
    private static bool IsMatRowCall(ExpressionSyntax expr, SemanticModel model)
    {
        if (expr is not InvocationExpressionSyntax inv)
            return false;
        if (inv.Expression is not MemberAccessExpressionSyntax ma)
            return false;
        if (ma.Name.Identifier.ValueText != "Row")
            return false;

        var sym = model.GetSymbolInfo(inv).Symbol as IMethodSymbol;
        return sym?.ContainingType?.ToDisplayString() == "OpenCvSharp.Mat";
    }

    /// <summary>
    /// Returns true when the local variable's declaration initializer is a call to <c>Mat.Row(int)</c>.
    /// Covers: <c>var row = mat.Row(i);</c>
    /// </summary>
    private static bool IsLocalDeclaredFromRowCall(ILocalSymbol local, SemanticModel model)
    {
        var syntaxRef = local.DeclaringSyntaxReferences.FirstOrDefault();
        if (syntaxRef?.GetSyntax() is not VariableDeclaratorSyntax { Initializer.Value: { } initializer })
            return false;

        return IsMatRowCall(initializer, model);
    }
}
