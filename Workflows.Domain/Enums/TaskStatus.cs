namespace Workflows.Domain.Enums;

/// <summary>
/// Representa el estado de procesamiento de una tarea individual dentro de la ejecución de un flujo de trabajo.
/// </summary>
public enum TaskStatus
{
    Pending = 1,
    InProgress = 2,
    Completed = 3,
    Failed = 4,
    Canceled = 5
}
