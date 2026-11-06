namespace Workflows.Domain.Enums;

/// <summary>
/// Representa el estado de una solicitud de aprobación generada por un bloque dentro de un flujo de trabajo
/// </summary>
public enum ApprovalStatus
{
    Pending = 1,
    Approved = 2,
    Rejected = 3,
    Canceled = 4
}
