namespace Workflows.Domain.Entities;

using Workflows.Domain.Common;
using Workflows.Domain.Enums;

/// <summary>
/// Representa una solicitud de aprobación emitida durante la ejecución de un flujo de trabajo.
/// registrando el responsable designado, la resolución tomada y las observaciones correspondientes.
/// </summary>
public class WorkflowApproval : BaseEntity
{
    public Guid WorkflowExecutionId { get; private set; }
    public WorkflowExecution? WorkflowExecution { get; private set; }
    public Guid WorkflowBlockId { get; private set; }
    public WorkflowBlock? WorkflowBlock { get; private set; }
    public Guid ApproverUserId { get; private set; }
    public User? ApproverUser { get; private set; }
    public ApprovalStatus Status { get; private set; } = ApprovalStatus.Pending;
    public string? Comments { get; private set; }
    public DateTime RequestedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? RespondedAt { get; private set; }

    private WorkflowApproval() { }

    public WorkflowApproval(
        Guid workflowExecutionId,
        Guid workflowBlockId,
        Guid approverUserId)
    {
        WorkflowExecutionId = workflowExecutionId;
        WorkflowBlockId = workflowBlockId;
        ApproverUserId = approverUserId;
        Status = ApprovalStatus.Pending;
        RequestedAt = DateTime.UtcNow;
    }

    public void Approve(string? comments = null)
    {
        Status = ApprovalStatus.Approved;
        Comments = comments;
        RespondedAt = DateTime.UtcNow;
    }

    public void Reject(string? comments = null)
    {
        Status = ApprovalStatus.Rejected;
        Comments = comments;
        RespondedAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
        Status = ApprovalStatus.Canceled;
        RespondedAt = DateTime.UtcNow;
    }
}
