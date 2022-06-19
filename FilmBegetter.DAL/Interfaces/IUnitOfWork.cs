using Microsoft.EntityFrameworkCore.Storage;

namespace FilmBegetter.DAL.Interfaces; 

public interface IUnitOfWork {
    
    TRepository GetRepository<TRepository, TEntity>()
        where TRepository : IRepository<TEntity> where TEntity : class;

    Task<int> SaveChangesAsync();

    IDbContextTransaction BeginTransaction();
}