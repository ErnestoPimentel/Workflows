namespace Workflows.Domain.Common;

/// <summary>
/// Clase base para todas las entidades de dominio.
/// Proporciona atributos fundamentales de identidad, auditoría y control de estado de registros.
/// </summary>
public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public string CreatedBy { get; protected set; } = string.Empty;
    public DateTime? LastModifiedAt { get; protected set; }
    public string? LastModifiedBy { get; protected set; }
    public bool IsDeleted { get; protected set; } = false;

    public void SetCreatedInfo(string userId)
    {
        CreatedBy = userId;
        CreatedAt = DateTime.UtcNow;
    }

    public void SetModifiedInfo(string userId)
    {
        LastModifiedBy = userId;
        LastModifiedAt = DateTime.UtcNow;
    }

    public void SoftDelete(string userId)
    {
        IsDeleted = true;
        SetModifiedInfo(userId);
    }
}