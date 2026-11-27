namespace Workflows.Domain.Entities;

using System.Net.Http.Headers;
using Workflows.Domain.Common;

public class AuditLog : BaseEntity
{
    public string EntityName { get; private set; } = string.Empty;
    public Guid EntityId { get; private set; }
    public string Action { get; private set; } = string.Empty;
    public string? OldValuesJson { get; private set; }
    public string? NewValuesJson { get; private set; }
    public string? AffectedColumnJson { get; private set; }
    public string UserId { get; private set; } = string.Empty;
    public DateTime Timestamp { get; private set; } = DateTime.UtcNow;

    private AuditLog() { }

    public AuditLog(
        string entityName,
        Guid entityId,
        string action,
        string userId,
        string? oldvaluesJson = null,
        string? newValuesJson = null,
        string? affectedColumnsJson = null)
    {
        EntityName = entityName;
        EntityId = entityId;
        Action = action;
        UserId = userId;
        OldValuesJson = oldvaluesJson;
        NewValuesJson = newValuesJson;
        AffectedColumnJson = affectedColumnsJson;
        Timestamp = DateTime.UtcNow;
    }
}
