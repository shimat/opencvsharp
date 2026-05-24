using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace OpenCvSharp.Analyzers;

/// <summary>
/// Detects <c>Mat.Row()</c>, <c>Mat.Col()</c>, <c>Mat.RowRange()</c>, or <c>Mat.ColRange()</c>
/// whose return value is not wrapped in a <c>using</c> statement or declaration.
/// </summary>
/// <remarks>
/// These methods allocate a native submatrix object. Unlike <c>new Mat()</c> (which CA2000 flags),
/// these look like simple accessors and are easy to overlook. The recommended alternative for
/// iteration is <c>AsRows&lt;T&gt;()</c> which avoids allocation entirely.
/// </remarks>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class RowColNotDisposedAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "OCVS004";

    private static readonly DiagnosticDescriptor Rule = new(
        id: DiagnosticId,
        title: "Mat submatrix not disposed",
        messageFormat: "Mat.{0}() returns a Mat submatrix that must be disposed. " +
                       "Wrap in 'using', or use AsRows<T>() / AsCols<T>() to avoid allocation entirely.",
        category: "Reliability",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Mat.Row(), Mat.Col(), Mat.RowRange(), and Mat.ColRange() each allocate a " +
                     "native Mat header. If not disposed, the native object lives until the GC " +
                     "finalizer runs, causing uncontrolled native memory pressure.",
        helpLinkUri: "https://github.com/shimat/opencvsharp/issues/1775");

    private static readonly ImmutableHashSet<string> SubmatrixMethods =
        ImmutableHashSet.Create(StringComparer.Ordinal, "Row", "Col", "RowRange", "ColRange");

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
        var invocation = (InvocationExpressionSyntax)context.Node;

        if (invocation.Expression is not MemberAccessExpressionSyntax ma)
            return;

        var methodName = ma.Name.Identifier.ValueText;
        if (!SubmatrixMethods.Contains(methodName))
            return;

        var symbol = context.SemanticModel.GetSymbolInfo(invocation).Symbol as IMethodSymbol;
        if (symbol?.ContainingType?.ToDisplayString() != "OpenCvSharp.Mat")
            return;

        if (!IsDisposed(invocation))
            context.ReportDiagnostic(Diagnostic.Create(Rule, invocation.GetLocation(), methodName));
    }

    private static bool IsDisposed(InvocationExpressionSyntax invocation)
    {
        var parent = invocation.Parent;

        // using var row = mat.Row(i);
        if (parent is EqualsValueClauseSyntax { Parent: VariableDeclaratorSyntax { Parent: VariableDeclarationSyntax { Parent: LocalDeclarationStatementSyntax localDecl } } }
            && localDecl.UsingKeyword.IsKind(SyntaxKind.UsingKeyword))
            return true;

        // using (var row = mat.Row(i)) { ... }
        if (parent is EqualsValueClauseSyntax { Parent: VariableDeclaratorSyntax { Parent: VariableDeclarationSyntax { Parent: UsingStatementSyntax } } })
            return true;

        // using (mat.Row(i)) { ... }  — expression form
        if (parent is UsingStatementSyntax)
            return true;

        // mat.Row(i).At<T>(col) — OCVS001 already flags this exact pattern; skip here
        // to avoid a double warning. Only At<T> is exempted; other chains like .Clone()
        // still leak the submatrix and should be reported.
        if (parent is MemberAccessExpressionSyntax chainedMa
            && chainedMa.Parent is InvocationExpressionSyntax
            && chainedMa.Name.Identifier.Text == "At")
            return true;

        // Passed as argument — caller is responsible
        if (parent is ArgumentSyntax)
            return true;

        // Return statement — caller is responsible
        if (parent is ReturnStatementSyntax)
            return true;

        return false;
    }
}
