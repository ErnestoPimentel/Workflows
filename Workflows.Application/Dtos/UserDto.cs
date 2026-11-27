namespace Workflows.Application.Dtos;

/// <summary>
/// Objeto de transferencia de datos que representa el perfil completo de un usuario,
/// su rol asignado y sus preferencias de entorno e internacionalización.
/// </summary>
public sealed record UserDto(
    Guid Id,
    string Username,
    string Email,
    string FullName,
    string? AvatarUrl,
    string PreferredLanguage,
    string PreferredTheme,
    bool EnableNotifications,
    Guid RoleId,
    string RoleName);

/// <summary>
/// Objeto de transferencia de datos para el registro de un nuevo usuario en el sistema.
/// </summary>
public sealed record CreateUserDto(
    string UserName,
    string Email,
    string FullName,
    Guid RoleId,
    string? AvatarUrl);

/// <summary>
/// Objeto de transferencia de datos para actualizar la información personal y avatar del usuario.
/// </summary>
public sealed record UpdateUserProfileDto(
    Guid UserId,
    string FullName,
    string? AvatarUrl);

/// <summary>
/// Objeto de transferencia de datos para persistir la configuración global de entorno
/// e idioma seleccionado por el usuario
/// </summary>
public sealed record UpdateUserEnvironmentDto(
    Guid UserId,
    string PreferredLanguage,
    string PreferredTheme,
    bool EnableNotifications);

/// <summary>
/// Objeto de transferencia de datos que representa un rol de acceso dentro de la plataforma.
/// </summary>
public sealed record RoleDto(
    Guid Id,
    string Name,
    string Description,
    bool IsSystemRole);

/// <summary>
/// Objeto de transferencia de datos para crear un nuevo rol personalizado.
/// </summary>
public sealed record CreateRoleDto(
    string Name,
    string Description);

/// <summary>
/// Objeto de transferencia de datos para editar un rol existente.
/// </summary>
public sealed record UpdateRoleDto(
    Guid Id,
    string Name,
    string Description);

