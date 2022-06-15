using System.Linq.Expressions;
using FilmBegetter.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmBegetter.DAL.Repositories; 

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
    
    protected readonly ApplicationDbContext Context;

    private readonly DbSet<TEntity> _dbSet;

    public Repository(ApplicationDbContext context) {
        Context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public Task<List<TEntity>> FindAllAsync() {
        return FindAllWithDetailsWithoutFilter().ToListAsync();
    }

    public Task CreateAsync(TEntity entity) {
        return _dbSet.AddAsync(entity).AsTask();
    }

    public async Task Delete(Expression<Func<TEntity, bool>> filter) {
        
        var entitiesToDelete = await FindAsync(filter);

        foreach (var entityToDelete in entitiesToDelete) {
            if (Context.Entry(entityToDelete).State == EntityState.Detached) {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
    }

    public void Update(TEntity entity) {
        
        if (Context.Entry(entity).State == EntityState.Modified) {
            return;
        }
        
        _dbSet.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
    }

    public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter) {
        return _dbSet.Where(filter).AsNoTracking().ToListAsync();
    }

    public Task<TEntity> FirstOrDefaultWithDetailsAsync(Expression<Func<TEntity, bool>> filter) {
        return FindAllWithDetailsWithoutFilter().FirstOrDefaultAsync(filter);
    }

    public Task<List<TEntity>> FindAllWithDetailsAsync(Expressions<TEntity> expressions) {
        
        var query = FindAllWithDetailsWithoutFilter();

        if (expressions.FilterExpressions.Any()) {
            query = expressions.FilterExpressions.Aggregate(query, (current, expression) => current.Where(expression));
        }

        if (expressions.AscendingOrderExpressions.Any()) {
            query = query.OrderBy(expressions.AscendingOrderExpressions[0]);

            if (expressions.AscendingOrderExpressions.Count > 1) {

                for (var i = 1; i < expressions.AscendingOrderExpressions.Count; i++) {
                    query = (query as IOrderedQueryable<TEntity>).ThenBy(expressions.AscendingOrderExpressions[i]);
                }
            }
        }

        if (expressions.DescendingOrderExpressions.Any()) {
            query = query.OrderByDescending(expressions.DescendingOrderExpressions[0]);

            if (expressions.DescendingOrderExpressions.Count > 1) {

                for (var i = 1; i < expressions.DescendingOrderExpressions.Count; i++) {
                    query = (query as IOrderedQueryable<TEntity>).ThenByDescending(expressions.DescendingOrderExpressions[i]);
                }
            }
        }

        if (expressions.SkipCount > 0) {
            query = query.Skip(expressions.SkipCount);
        }

        if (expressions.TakeCount > 0) {
            query = query.Take(expressions.TakeCount);
        }

        return query.AsNoTracking().ToListAsync();
    }
    
    protected virtual IQueryable<TEntity> FindAllWithDetailsWithoutFilter() {
        return _dbSet.AsNoTracking();
    }
}