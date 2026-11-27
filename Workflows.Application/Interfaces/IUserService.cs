namespace Workflows.Application.Interfaces;

using Workflows.Application.Dtos;

/// <summary>
/// Contrato de servicio de aplicación para la gestión de usuario, perfiles personales,
/// configuración global de entorno y administración de roles.
/// </summary>
public interface IUserService
{
    UserDto? GetUserById(Guid id);
    Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UserDto?> GetUserByUserNameAsync(string username, CancellationToken cancellationToken = default);

    IQueryable<UserDto> QueryUsers();

    Task<UserDto> CreateUserAsync(CreateUserDto dto, string performedByUserId, CancellationToken cancellationToken = default);
    Task<UserDto> UpdateUserProfileAsync(UpdateUserProfileDto dto, string performedByUserId, CancellationToken cancellationToken = default);
    Task<UserDto> UpdateUserEnvironmentAsync(UpdateUserEnvironmentDto dto, string performedByUserId, CancellationToken cancellationToken = default);
    Task AssignUserRoleAsync(Guid userId, Guid roleId, string performedByUserId, CancellationToken cancellationToken = default);
    Task DeleteUserAsync(Guid userId, string performedByUserId, CancellationToken cancellationToken = default);

    IReadOnlyList<RoleDto> GetAllRoles();
    Task<IReadOnlyList<RoleDto>> GetAllRolesAsync(CancellationToken cancellationToken = default);

    Task<RoleDto> CreateRoleAsync(CreateRoleDto dto, string performedByUserId, CancellationToken cancellationToken = default);
    Task<RoleDto> UpdateRoleAsync(UpdateRoleDto dto, string performedByUserId, CancellationToken cancellationToken = default);
    Task DeleteRoleAsync(Guid roleId, string performedByUserId, CancellationToken cancellationToken = default);

}
