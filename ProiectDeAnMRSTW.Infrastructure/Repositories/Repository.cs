using Microsoft.EntityFrameworkCore;
using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Infrastructure.Data;

namespace ProiectDeAnMRSTW.Infrastructure.Repositories;

internal abstract class Repository<T>
    where T : Aliment
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Ma aflu in RepositorY din Infrastructure");
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }
    public async Task<List<T>?> GetAllProductsByCategoryName(string name, CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
            .Where(product => product.Category == name)
            .ToListAsync(cancellationToken);
    }
    public async Task<Guid> GetProductIdByName(string Name,CancellationToken cancellationToken = default)
    {
        var Product = await DbContext.Set<T>().FirstOrDefaultAsync(product => product.Name == Name);
        if (Product == null)
        {
            return Guid.Empty;
        }
        return Product.Id;
    }
    public async Task<List<Aliment>> GetAllProductsFromDB(CancellationToken cancellationToken = default)
    {
        var AllProducts = await DbContext.Aliment.ToListAsync();
        if (AllProducts == null)
        {
            return [];
        }
        return AllProducts;
    }

    public virtual void Add(T entity)
    {
        DbContext.Add(entity);
    }
}
