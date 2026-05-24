using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace OpenCvSharp.Analyzers;

/// <summary>
/// Detects <c>mat.Rows</c>, <c>mat.Cols</c>, <c>mat.Dims</c>, <c>mat.Width</c>, or <c>mat.Height</c>
/// used in loop conditions, where each access is a P/Invoke call evaluated on every iteration.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class MatPropertyInLoopConditionAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "OCVS002";

    private static readonly DiagnosticDescriptor Rule = new(
        id: DiagnosticId,
        title: "Mat property accessed in loop condition",
        messageFormat: "'{0}' is a P/Invoke call on every iteration; cache it before the loop as 'int {1} = mat.{0};'",
        category: "Performance",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Mat.Rows, Mat.Cols, Mat.Dims, Mat.Width, and Mat.Height each invoke a native " +
                     "P/Invoke call. Placing them in a loop condition causes one P/Invoke call per " +
                     "iteration. Cache the value in a local variable before the loop.",
        helpLinkUri: "https://github.com/shimat/opencvsharp/issues/1775");

    // Properties on OpenCvSharp.Mat that are P/Invoke calls
    private static readonly ImmutableHashSet<string> ExpensiveProperties =
        ImmutableHashSet.Create(StringComparer.Ordinal, "Rows", "Cols", "Dims", "Width", "Height");

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(AnalyzeFor,     SyntaxKind.ForStatement);
        context.RegisterSyntaxNodeAction(AnalyzeWhile,   SyntaxKind.WhileStatement);
        context.RegisterSyntaxNodeAction(AnalyzeDo,      SyntaxKind.DoStatement);
    }

    private static void AnalyzeFor(SyntaxNodeAnalysisContext context)
    {
        var forLoop = (ForStatementSyntax)context.Node;
        if (forLoop.Condition is not null)
            CheckExpression(forLoop.Condition, context);
    }

    private static void AnalyzeWhile(SyntaxNodeAnalysisContext context)
    {
        var whileLoop = (WhileStatementSyntax)context.Node;
        CheckExpression(whileLoop.Condition, context);
    }

    private static void AnalyzeDo(SyntaxNodeAnalysisContext context)
    {
        var doLoop = (DoStatementSyntax)context.Node;
        CheckExpression(doLoop.Condition, context);
    }

    private static void CheckExpression(ExpressionSyntax condition, SyntaxNodeAnalysisContext context)
    {
        foreach (var node in condition.DescendantNodesAndSelf())
        {
            if (node is not MemberAccessExpressionSyntax ma)
                continue;

            var propName = ma.Name.Identifier.ValueText;
            if (!ExpensiveProperties.Contains(propName))
                continue;

            var symbol = context.SemanticModel.GetSymbolInfo(ma).Symbol as IPropertySymbol;
            if (symbol?.ContainingType?.ToDisplayString() != "OpenCvSharp.Mat")
                continue;

            var suggestedName = char.ToLowerInvariant(propName[0]) + propName.Substring(1);
            context.ReportDiagnostic(Diagnostic.Create(Rule, ma.GetLocation(), propName, suggestedName));
        }
    }
}
