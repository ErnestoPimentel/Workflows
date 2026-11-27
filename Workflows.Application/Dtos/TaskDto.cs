namespace Workflows.Application.Dtos;

using Workflows.Domain.Enums;
using TaskStatus = Domain.Enums.TaskStatus;

/// <summary>
/// Objeto de transferencia de datos que representa una tarea operativa asignada
/// dentro de una instancia de ejecución de flujo de trabajo.
/// </summary>
public sealed record TaskDto(
    Guid Id,
    Guid WorkflowExecutionId,
    Guid WorkflowBlockId,
    string Title,
    string Description,
    Guid? AssignedToUserId,
    string? AssignedToUserName,
    TaskStatus Status,
    DateTime? DueDate,
    DateTime? CompletedAt,
    string ResultDataJson,
    DateTime CreatedAt);

/// <summary>
/// Objeto de transferencia de datos para registrar la finalización de una tarea
/// y los datos de salida generados por el responsable.
/// </summary>
public sealed record CompleteTaskDto(
    Guid TaskId,
    string ResultDataJson);

/// <summary>
/// Objeto de transferencia de datos que representa una solicitud de aprobación
/// generada durante la ejecución de un flujo de trabajo.
/// </summary>
public sealed record ApprovalDto(
    Guid Id,
    Guid WorkflowExecutionId,
    Guid WorkflowBlockId,
    Guid ApproverUserId,
    string ApproverUserName,
    ApprovalStatus Status,
    string? Comments,
    DateTime RequestedAt,
    DateTime? ResponseAt);

/// <summary>
/// Objeto de transferencia de datos para emitir una resolución de aprobación o rechazo.
/// </summary>
public sealed record RespondApprovalDto(
    Guid ApprovalId,
    bool IsApproved,
    string? Comments);

/// <summary>
/// Objeto de transferencia de datos que representa una notificación personal o global
/// presentada en el centro de alertas del usuario.
/// </summary>
public sealed record NotificationDto(
    Guid Id,
    Guid? UserId,
    string Title,
    string Message,
    bool IsGlobal,
    bool IsRead,
    DateTime? ReadAt,
    string? ReferenceUrl,
    DateTime CreatedAt);