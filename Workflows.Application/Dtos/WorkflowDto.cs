namespace Workflows.Application.Dtos;

/// <summary>
/// Objeto de transferencia de datos que representa la definición principal
/// de un flujo de trabajo y su estado de versionamiento.
/// </summary>
public sealed record WorkflowDto(
    Guid Id,
    string Name,
    string Description,
    bool IsActive,
    int CurrentVersionNumber,
    DateTime CreatedAt,
    string CreatedBy,
    DateTime? LastModifiedAt);

/// <summary>
/// Objeto de transferencia de datos detallado de una versión especifica de flujo,
/// incluyendo su topología completa de bloques y conexiones.
/// </summary>
public sealed record WorkflowVersionDto(
    Guid Id,
    Guid WorkflowDefinitionId,
    string WorkflowName,
    int VersionNumber,
    bool IsPublished,
    DateTime? PublishedAt,
    IReadOnlyList<WorkflowBlockDto> Blocks,
    IReadOnlyList<WorkflowConnectionDto> Connections);

/// <summary>
/// Objeto de transferencia de datos para crear una nueva definición de flujo de trabajo.
/// </summary>
public sealed record CreateWorkflowDto(
    string Name,
    string Description);

/// <summary>
/// Objeto de transferencia de datos para actualizar los metadatos de un flujo existente.
/// </summary>
public sealed record UpdateWorkflowDto(
    Guid Id,
    string Name,
    string Description,
    bool IsActive);
