namespace Workflows.Domain.Interfaces;

using System.Security.Cryptography;
using Workflows.Domain.Common;

/// <summary>
/// Define el contrato de unidad de Trabajo para coordinar transacciones atómicas 
/// y persistir cambios consolidados entre múltiples repositorios del dominio.
/// </summary>
public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    IRepository<T> Repository<T>() where T : BaseEntity;

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    void BeginTransaction();
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    void CommitTransaction();
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    void RollbackTransaction();
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
