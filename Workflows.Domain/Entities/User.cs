namespace Workflows.Domain.Entities;

using Workflows.Domain.Common;

/// <summary>
/// Representa a un usuario del sistema, encapsulando credenciales, perfil personal, 
/// configuración global de entorno y preferencias de internacionalización.
/// </summary>
public class User : BaseEntity
{
    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string FullName { get; private set; } = string.Empty;
    public string? AvatarUrl { get; private set; }
    public string PreferredLanguage { get; private set; } = "es-MX";
    public string PreferredTheme { get; private set; } = "light";
    public bool EnableNotifications { get; private set; } = true;
    public Guid RoleId { get; private set; }
    public Role? Role { get; private set; }

    private User() { }

    public User(string username, string email, string fullName, Guid roleId, string? avatarUrl = null)
    {
        Username = username;
        Email = email;
        FullName = fullName;
        RoleId = roleId;
        AvatarUrl = avatarUrl;
    }

    public void UpdateProfile(string fullName, string? avatarUrl)
    {
        FullName = fullName;
        AvatarUrl = avatarUrl;
    }

    public void UpdateEnvironmentPreferences(string preferredLanguage, string preferredTheme, bool enableNotifications)
    {
        PreferredLanguage = preferredLanguage;
        PreferredTheme = preferredTheme;
        EnableNotifications = enableNotifications;
    }

    public void AssignRole(Guid newRoleId) => RoleId = newRoleId;
}
