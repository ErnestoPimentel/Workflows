namespace Workflows.Application.Dtos;

/// <summary>
/// Objeto de transferencia de datos que representa una conexión orientada
/// entre dos bloques dentro de una versión de flujo de trabajo
/// </summary>
public sealed record WorkflowConnectionDto(
    Guid Id,
    Guid WorkflowVersionId,
    Guid SourceBlockId,
    Guid TargetBlockId,
    string SourcePort,
    string TargetPort,
    string? ConditionExpression);

/// <summary>
/// Objeto de transferencia de datos para registrar o modificar conexiones
/// y reglas de bifurcación entre bloques en el diseñador
/// </summary>
public sealed record SaveWorkflowConnectionDto(
    Guid? Id,
    Guid SourceBlockId,
    Guid TargetBlockId,
    string SourcePort,
    string TargetPort,
    string? ConditionExpression);
