namespace Workflows.Domain.Interfaces;

using System.Linq.Expressions;
using Workflows.Domain.Common;

/// <summary>
/// Contrato genérico de acceso a datos para las entidades de dominio.
/// Abstrae las operaciones de lectura y escritura tanto síncronas como asincronas.
/// </summary>
/// <typeparam name="T">Tipo de entidad de dominio derivada de BaseEntity.</typeparam>
public interface IRepository<T> where T : BaseEntity
{
    T? GetById(Guid id);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    IReadOnlyList<T> GetAll();
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

    IReadOnlyList<T> Find(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    IQueryable<T> Query();

    void Add(T entity);
    Task AddAsync(T entity, CancellationToken cancellationToken);

    void Update(T entity);
    void Remove(T entity);

    bool Exists(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}
