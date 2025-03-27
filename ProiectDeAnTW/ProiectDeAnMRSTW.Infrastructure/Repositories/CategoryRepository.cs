using Microsoft.EntityFrameworkCore;
using ProiectDeAnMRSTW.Domain.Products;
using ProiectDeAnMRSTW.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Infrastructure.Repositories
{
    internal sealed class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategorieAliment>?> GetAllCategories(CancellationToken cancellationToken = default)
        {
            return await _dbContext.CategorieAliment.ToListAsync();
        }
    }
}
