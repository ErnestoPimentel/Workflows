namespace Workflows.Domain.Entities;

using Workflows.Domain.Common;

/// <summary>
/// Representa un rol de usuario dentro del sistema Workflows para el control 
/// de acceso y asignación de permisos sobre la plataforma.
/// </summary>
public class Role : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool IsSystemRole { get; private set; }

    private readonly List<User> _users = [];
    public IReadOnlyCollection<User> Users => _users.AsReadOnly();

    private Role() { }

    public Role(string name, string description, bool isSystemRole = false)
    {
        Name = name;
        Description = description;
        IsSystemRole = isSystemRole;
    }

    public void UpdateDetails(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
