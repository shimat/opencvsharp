using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace OpenCvSharp.Analyzers;

/// <summary>
/// Detects chained arithmetic on <c>Mat</c> (e.g. <c>a + b + c</c>) where intermediate
/// <c>MatExpr</c> objects are never disposed.
/// </summary>
/// <remarks>
/// <para>
/// <c>Mat</c> arithmetic operators return <c>MatExpr</c> (an <see cref="System.IDisposable"/> wrapper
/// around a native lazy-evaluation expression). In a chain such as <c>a + b + c</c>, the
/// <c>MatExpr</c> produced by <c>a + b</c> is consumed by the second <c>+</c> and never disposed,
/// leaving the native object to the GC finalizer.
/// </para>
/// <para>
/// Prefer <c>Cv2.Add</c> / <c>Cv2.Subtract</c> etc., or assign each step to a <c>using</c>
/// variable.
/// </para>
/// </remarks>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class MatExprChainAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "OCVS005";

    private static readonly DiagnosticDescriptor Rule = new(
        id: DiagnosticId,
        title: "Intermediate MatExpr not disposed in chained Mat arithmetic",
        messageFormat: "The intermediate MatExpr from '{0}' is never disposed. " +
                       "Use Cv2.Add/Subtract/Multiply/Divide, or assign each step to a 'using' variable.",
        category: "Reliability",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Mat arithmetic operators return MatExpr, an IDisposable wrapping a native " +
                     "lazy-evaluation object. In a chain like a + b + c, the MatExpr for a + b " +
                     "is consumed without being disposed, leaking the native resource until " +
                     "the GC finalizer runs.",
        helpLinkUri: "https://github.com/shimat/opencvsharp/issues/1775");

    private const string MatExprFullName = "OpenCvSharp.MatExpr";

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(AnalyzeBinaryExpression, SyntaxKind.AddExpression,
            SyntaxKind.SubtractExpression, SyntaxKind.MultiplyExpression, SyntaxKind.DivideExpression);
    }

    private static void AnalyzeBinaryExpression(SyntaxNodeAnalysisContext context)
    {
        var binary = (BinaryExpressionSyntax)context.Node;

        // The result of this expression must be MatExpr
        var resultType = context.SemanticModel.GetTypeInfo(binary).Type;
        if (resultType?.ToDisplayString() != MatExprFullName)
            return;

        // Flag only when this MatExpr is consumed immediately by another binary expression
        // without being assigned to a variable — that's the intermediate-temporary case.
        // Unwrap any parentheses: (a + b) + c has a ParenthesizedExpressionSyntax between the
        // inner binary and the outer one, but the semantics are identical.
        var parent = binary.Parent;
        while (parent is ParenthesizedExpressionSyntax)
            parent = parent.Parent;
        if (parent is BinaryExpressionSyntax or AssignmentExpressionSyntax { Left: not IdentifierNameSyntax })
        {
            var operatorToken = binary.OperatorToken.ToString();
            context.ReportDiagnostic(Diagnostic.Create(Rule, binary.GetLocation(), operatorToken));
        }
    }
}
