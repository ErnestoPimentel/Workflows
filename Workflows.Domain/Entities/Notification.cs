namespace Workflows.Domain.Entities;

using Workflows.Domain.Common;

/// <summary>
/// Representa una notificación personal o global dentro de la plataforma Workflows,
/// generada por eventos del sistema o por bloques de notificación en los flujos de trabajo.
/// </summary>
public class Notification : BaseEntity
{
    public Guid? UserId { get; private set; }
    public User? User { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Message { get; private set; } = string.Empty;
    public bool IsGlobal { get; private set; }
    public bool IsRead { get; private set; }
    public DateTime? ReadAt { get; private set; }
    public string? ReferenceUrl { get; private set; }

    private Notification() { }

    public Notification(
        string title,
        string message,
        Guid? userId = null,
        bool isGlobal = false,
        string? referenceUrl = null)
    {
        Title = title;
        Message = message;
        UserId = userId;
        IsGlobal = isGlobal;
        ReferenceUrl = referenceUrl;
        IsRead = false;
    }

    public void MarkAsRead()
    {
        if (!IsRead)
        {
            IsRead = true;
            ReadAt = DateTime.UtcNow;
        }
    }
}
