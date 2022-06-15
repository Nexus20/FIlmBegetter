using System.Linq.Expressions;

namespace FilmBegetter.DAL.Interfaces; 

public interface IRepository<TEntity> where TEntity : class {

    Task<List<TEntity>> FindAllAsync();
    
    Task CreateAsync(TEntity entity);
    
    Task Delete(Expression<Func<TEntity, bool>> filter);

    void Update(TEntity entity);

    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter);
    
    Task<TEntity> FirstOrDefaultWithDetailsAsync(Expression<Func<TEntity, bool>> filter);

    Task<List<TEntity>> FindAllWithDetailsAsync(Expressions<TEntity> expressions);
}