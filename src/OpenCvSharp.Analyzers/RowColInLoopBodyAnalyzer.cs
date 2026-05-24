using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace OpenCvSharp.Analyzers;

/// <summary>
/// Detects <c>mat.Row()</c> or <c>mat.Col()</c> called inside a loop body,
/// suggesting <c>AsRows&lt;T&gt;()</c> or <c>AsCols&lt;T&gt;()</c> as a zero-allocation alternative.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class RowColInLoopBodyAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "OCVS003";

    private static readonly DiagnosticDescriptor Rule = new(
        id: DiagnosticId,
        title: "Mat.Row() / Mat.Col() called inside a loop",
        messageFormat: "Mat.{0}() allocates a new submatrix object on every iteration. " +
                       "Use mat.AsRows<T>() (or AsCols<T>()) outside the loop for zero-allocation row access.",
        category: "Performance",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Calling Mat.Row() or Mat.Col() inside a loop allocates a native Mat " +
                     "submatrix object on every iteration, creating GC pressure. " +
                     "Obtain a MatRowAccessor<T> via AsRows<T>() before the loop; " +
                     "each row is then a Span<T> with no allocation.",
        helpLinkUri: "https://github.com/shimat/opencvsharp/issues/1775");

    private static readonly ImmutableHashSet<string> RowColMethods =
        ImmutableHashSet.Create(StringComparer.Ordinal, "Row", "Col");

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
        if (!RowColMethods.Contains(methodName))
            return;

        var symbol = context.SemanticModel.GetSymbolInfo(invocation).Symbol as IMethodSymbol;
        if (symbol?.ContainingType?.ToDisplayString() != "OpenCvSharp.Mat")
            return;

        if (IsInsideLoopBody(invocation))
            context.ReportDiagnostic(Diagnostic.Create(Rule, invocation.GetLocation(), methodName));
    }

    private static bool IsInsideLoopBody(SyntaxNode node)
    {
        for (var current = node.Parent; current is not null; current = current.Parent)
        {
            // Function boundaries: stop searching upward
            if (current is MethodDeclarationSyntax
                         or LocalFunctionStatementSyntax
                         or LambdaExpressionSyntax
                         or AnonymousMethodExpressionSyntax)
                return false;

            // Loop constructs: only flag when node is inside the loop body (Statement),
            // not in the initializer, condition, or iterator of a for/foreach.
            StatementSyntax? loopBody = current switch
            {
                ForStatementSyntax f       => f.Statement,
                WhileStatementSyntax w     => w.Statement,
                DoStatementSyntax d        => d.Statement,
                ForEachStatementSyntax fe  => fe.Statement,
                _                          => null,
            };
            if (loopBody is not null)
                return loopBody.FullSpan.Contains(node.FullSpan);
        }
        return false;
    }
}
