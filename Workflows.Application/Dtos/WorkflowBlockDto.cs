namespace Workflows.Application.Dtos;

using Workflows.Domain.Enums;

/// <summary>
/// Objeto de transferencia de datos que representa un bloque visual y funcional
/// dentro del diseñador de flujos de trabajo.
/// </summary>
public sealed record WorkflowBlockDto(
    Guid Id,
    Guid WorkflowVersionId,
    string Name,
    BlockType Type,
    double PositionX,
    double PositionY,
    string ConfigurationJson);

/// <summary>
/// Objeto de transferencia de datos para la creación o actualización de un bloque
/// desde el lienzo del diseñador visual.
/// </summary>
public sealed record SaveWorkflowBlockDto(
    Guid? Id,
    string Name,
    BlockType Type,
    double PositionX,
    double PositionY,
    string ConfigurationJson);
