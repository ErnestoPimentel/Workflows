namespace Workflows.Domain.Entities;

using Workflows.Domain.Common;
using Workflows.Domain.Enums;

/// <summary>
/// Representa un bloque visual y funcional dentro del diseñador de flujos de trabajo.
/// Define la posición gráfica en el lienzo, el tipo de operación y la configuración dinámica del bloque.
/// </summary>
public class WorkflowBlock : BaseEntity
{
    public Guid WorkflowVersionId { get; private set; }
    public WorkflowVersion? WorkflowVersion { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public BlockType Type { get; private set; }
    public double PositionX { get; private set; }
    public double PositionY { get; private set; }
    public string ConfigurationJson { get; private set; } = "{}";

    private WorkflowBlock() { }

    public WorkflowBlock (
        Guid workflowVersionId,
        string name,
        BlockType type,
        double positionX,
        double positionY,
        string configurationJson = "{}")
    {
        WorkflowVersionId = workflowVersionId;
        Name = name;
        Type = type;
        PositionX = positionX;
        PositionY = positionY;
        ConfigurationJson = string.IsNullOrWhiteSpace(configurationJson) ? "{}" : configurationJson;
    }

    public void UpdatePosition(double positionX, double positionY)
    {
        PositionX = positionX;
        PositionY = positionY;
    }

    public void UpdateConfiguration(string name, string configurationJson)
    {
        Name = name;
        ConfigurationJson = string.IsNullOrWhiteSpace(configurationJson) ? "{}" : configurationJson;
    }
}
