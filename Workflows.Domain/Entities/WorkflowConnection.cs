namespace Workflows.Domain.Entities;

using Workflows.Domain.Common;

/// <summary>
/// Representa la conexión orientada entre dos bloques dentro de una versión de flujo de trabajo.
/// Define la estructura del grafo de ejecución, permitiendo bifurcaciones y caminos condicionales.
/// </summary>
public class WorkflowConnection : BaseEntity
{
    public Guid WorkflowVersionId { get; private set; }
    public WorkflowVersion? WorkflowVersion { get; private set; }
    public Guid SourceBlockId { get; private set; }
    public WorkflowBlock? SourceBlock { get; private set; }
    public Guid TargetBlockId { get; private set; }
    public WorkflowBlock? TargetBlock { get; private set; }

    public string SourcePort { get; private set; } = "output";
    public string TargetPort { get; private set; } = "input";
    public string? ConditionExpression { get; private set; }

    private WorkflowConnection() { }

    public WorkflowConnection(
        Guid workflowVersionId,
        Guid sourceBlockId,
        Guid targetBlockId,
        string sourcePort = "output",
        string targetPort = "input",
        string? conditionExpression = null)
    {
        WorkflowVersionId = workflowVersionId;
        SourceBlockId = sourceBlockId;
        TargetBlockId = targetBlockId;
        SourcePort = sourcePort;
        TargetPort = targetPort;
        ConditionExpression = conditionExpression;
    }

    public void UpdateCondition(string? conditionExpression)
    {
        ConditionExpression = conditionExpression;
    }
}
