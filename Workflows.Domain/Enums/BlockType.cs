namespace Workflows.Domain.Enums;

/// <summary>
/// Define la tipología de bloques disponibles para la construcción y ejecución
/// de flujos de trabajo en el diseñador visual.
/// </summary>
public enum BlockType
{
    Start = 1,
    End = 2,
    Task = 3,
    Assignee = 4,
    Approval = 5,
    Notification = 6,
    Condition = 7
}