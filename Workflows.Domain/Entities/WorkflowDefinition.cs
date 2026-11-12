namespace Workflows.Domain.Entities;

using Workflows.Domain.Common;

/// <summary>
/// Representa la definición de un flujo de trabajo dentro del sistema. 
/// Actúa como la cabecera lógica que agrupa sus distintas versiones publicadas y borradores.
/// </summary>
public class WorkflowDefinition : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; private set; }
    public int CurrentVersionNumber { get; private set; }

    private readonly List<WorkflowVersion> _versions = [];
    public IReadOnlyCollection<WorkflowVersion> Versions => _versions.AsReadOnly();

    private WorkflowDefinition() { }

    public WorkflowDefinition(string name, string description)
    {
        Name = name;
        Description = description;
        IsActive = true;
        CurrentVersionNumber = 1;
    }

    public void UpdateDetails(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Activate() => IsActive = true;

    public void Desactivate() => IsActive = false;

    public void IncrementVersion() => CurrentVersionNumber++;
}
