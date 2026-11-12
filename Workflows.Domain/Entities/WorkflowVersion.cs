namespace Workflows.Domain.Entities;

using Workflows.Domain.Common;

/// <summary>
/// Representa una versión especifica e inmutable de la estructura de un flujo de trabajo, 
/// conteniendo el conjunto de bloques y conexiones que definen su ejecución.
/// </summary>
public class WorkflowVersion : BaseEntity
{
    public Guid WorkflowDefinitionId { get; private set; }
    public WorkflowDefinition? WorkflowDefinition { get; private set; }
    public int VersionNumber { get; private set; }
    public bool IsPublished { get; private set; }
    public DateTime? PublishedAt { get; private set; }

    private readonly List<WorkflowBlock> _block = [];
    public IReadOnlyCollection<WorkflowBlock> Blocks => _block.AsReadOnly();

    private readonly List<WorkflowConnection> _connections = [];
    public IReadOnlyCollection<WorkflowConnection> Connections => _connections.AsReadOnly();

    private readonly List<WorkflowExecution> _executions = [];
    public IReadOnlyCollection<WorkflowExecution> Executions => _executions.AsReadOnly();

    private WorkflowVersion() { }

    public WorkflowVersion(Guid workflowDefinitionId, int versionNumber)
    {
        WorkflowDefinitionId = workflowDefinitionId;
        VersionNumber = versionNumber;
        IsPublished = false;
    }

    public void Publish()
    {
        IsPublished = true;
        PublishedAt = DateTime.UtcNow;
    }
}
