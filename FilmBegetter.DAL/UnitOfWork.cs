using FilmBegetter.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace FilmBegetter.DAL;

public class UnitOfWork : IUnitOfWork {
    
    private readonly ApplicationDbContext _context;

    private readonly IServiceProvider _services;

    public UnitOfWork(ApplicationDbContext context, IServiceProvider services) {
        _context = context;
        _services = services;
    }
    
    public TRepository GetRepository<TRepository, TEntity>() where TRepository : IRepository<TEntity> where TEntity : class {
        return _services.GetRequiredService<TRepository>();
    }

    public Task<int> SaveChangesAsync() {
        return _context.SaveChangesAsync();
    }

    public IDbContextTransaction BeginTransaction() {
        return _context.Database.BeginTransaction();
    }
}