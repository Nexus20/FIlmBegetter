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

    public void Create(TEntity entity) {
        _dbSet.Add(entity);
    }

    public void Delete(TEntity entity) {
        _dbSet.Remove(entity);
    }
    
    public async Task DeleteAsync(Expression<Func<TEntity, bool>> filter) {
        
        var entitiesToDelete = await FindAsync(filter);

        foreach (var entityToDelete in entitiesToDelete) {
            try {
                if (Context.Entry(entityToDelete).State == EntityState.Detached) {
                    _dbSet.Attach(entityToDelete);
                }
            }
            catch (InvalidOperationException ex) {
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

    public virtual Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter) {
        return FindAllWithDetailsWithoutFilter().Where(filter).AsNoTracking().ToListAsync();
    }

    public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter) {
        return _dbSet.FirstOrDefaultAsync(filter);
    }
    
    public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter) {
        return _dbSet.FirstOrDefault(filter);
    }

    public virtual Task<TEntity> FirstOrDefaultWithDetailsAsync(Expression<Func<TEntity, bool>> filter) {
        return FindAllWithDetailsWithoutFilter().FirstOrDefaultAsync(filter);
    }

    protected IQueryable<TEntity> ApplyFilters(IQueryable<TEntity> query, Expressions<TEntity> expressions) {
        
        if (expressions.FilterExpressions.Any()) {
            
            foreach (var expression in expressions.FilterExpressions) {
                query = query.Where(expression);
            }
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

        return query;
    }
    
    public virtual Task<List<TEntity>> FindAllWithDetailsAsync(Expressions<TEntity> expressions) {
        var query = FindAllWithDetailsWithoutFilter();
        ApplyFilters(query, expressions);
        return query.AsSplitQuery().AsNoTracking().ToListAsync();
    }
    
    protected virtual IQueryable<TEntity> FindAllWithDetailsWithoutFilter() {
        return _dbSet.AsNoTracking();
    }
}