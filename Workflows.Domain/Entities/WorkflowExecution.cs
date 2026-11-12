namespace Workflows.Domain.Entities;

using Workflows.Domain.Common;
using Workflows.Domain.Enums;

/// <summary>
/// Representa una instancia en ejecución o finalizada de un flujo de trabajo.
/// Registra el bloque actual, el estado del proceso, los datos de contexto y el historial operatico.
/// </summary>
public class WorkflowExecution : BaseEntity
{
    public Guid WorkflowVersionId { get; private set; }
    public WorkflowVersion? WorkflowVersion { get; private set; }
    public Guid CurrentBlockId { get; private set; }
    public WorkflowBlock? CurrentBlock { get; private set; }
    public ExecutionStatus Status { get; private set; } = ExecutionStatus.Pending;
    public DateTime StartedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; private set; }
    public string TriggeredByUserId { get; private set; } = string.Empty;
    public string ExecutionContextJson { get; private set; } = "{}";

    private readonly List<WorkflowTask> _tasks = [];
    public IReadOnlyCollection<WorkflowTask> Tasks => _tasks.AsReadOnly();

    private readonly List<WorkflowApproval> _approvals = [];
    public IReadOnlyCollection<WorkflowApproval> Approvals => _approvals.AsReadOnly();

    private WorkflowExecution() { }

    public WorkflowExecution(
        Guid workflowVersionId,
        Guid startBlockId,
        string triggeredByUserId,
        string executionContextJson = "{}")
    {
        WorkflowVersionId = workflowVersionId;
        CurrentBlockId = startBlockId;
        TriggeredByUserId = triggeredByUserId;
        Status = ExecutionStatus.Pending;
        ExecutionContextJson = string.IsNullOrWhiteSpace(executionContextJson) ? "{}" : executionContextJson;
    }

    public void StarExecution()
    {
        Status = ExecutionStatus.Running;
        StartedAt = DateTime.UtcNow;
    }

    public void MoveToBlock(Guid nextBlockId, string updateContextJson)
    {
        CurrentBlockId = nextBlockId;
        ExecutionContextJson = updateContextJson;
    }

    public void PausedExecution()
    {
        Status = ExecutionStatus.Paused;
    }

    public void CompleteExecution()
    {
        Status = ExecutionStatus.Completed;
        CompletedAt = DateTime.UtcNow;
    }

    public void FailExecution()
    {
        Status = ExecutionStatus.Failed;
        CompletedAt = DateTime.UtcNow;
    }

    public void CancelExecution()
    {
        Status = ExecutionStatus.Canceled;
        CompletedAt = DateTime.UtcNow;
    }
}
