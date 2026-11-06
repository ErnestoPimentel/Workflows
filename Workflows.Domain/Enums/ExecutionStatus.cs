namespace Workflows.Domain.Enums;

/// <summary>
/// Define los estados de ciclo de vida para las instancias de ejecución de un flujo de trabajo dentro del sistema
/// </summary>
public enum ExecutionStatus
{
    Pending = 1,
    Running = 2,
    Paused = 3,
    Completed = 4,
    Failed = 5,
    Canceled = 6
}
