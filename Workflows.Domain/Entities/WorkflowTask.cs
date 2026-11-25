namespace Workflows.Domain.Entities;

using Workflows.Domain.Common;
using TaskStatus = Workflows.Domain.Enums.TaskStatus;

/// <summary>
/// Representa una tarea operativa generada durante la ejecución de un bloque de tarea
/// dentro de una instancia de flujo de trabajo, incluyendo su asignación y estado.
/// </summary>
public class WorkflowTask : BaseEntity
{
    public Guid WorkflowExecutionId { get; private set; }
    public WorkflowExecution? WorkflowExecution { get; private set; }
    public Guid WorkflowBlockId { get; private set; }
    public WorkflowBlock? WorkflowBlock { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Guid? AssignedToUserId { get; private set; }
    public User? AssignedToUser { get; private set; }
    public TaskStatus Status { get; private set; } = TaskStatus.Pending;
    public DateTime? DueDate { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public string ResutlDataJson { get; private set; } = "{}";

    private WorkflowTask() { }

    public WorkflowTask(
        Guid workflowExecutionId,
        Guid workflowBlockId,
        string title,
        string description,
        Guid? assignedToUserId = null,
        DateTime? dueDate = null)
    {
        WorkflowExecutionId = workflowExecutionId;
        WorkflowBlockId = workflowBlockId;
        Title = title;
        Description = description;
        AssignedToUserId = assignedToUserId;
        DueDate = dueDate;
        Status = TaskStatus.Pending;
    }

    public void AssignUser(Guid userId)
    {
        AssignedToUserId = userId;
    }

    public void StartTask()
    {
        Status = TaskStatus.InProgress;
    }

    public void CompleteTask(string resultDataJson = "{}")
    {
        Status = TaskStatus.Completed;
        CompletedAt = DateTime.UtcNow;
        ResutlDataJson = string.IsNullOrWhiteSpace(resultDataJson) ? "{}" : resultDataJson;
    }

    public void FailTask()
    {
        Status = TaskStatus.Failed;
        CompletedAt = DateTime.UtcNow;
    }

    public void CancelTask()
    {
        Status = TaskStatus.Canceled;
        CompletedAt = DateTime.UtcNow;
    }
}
