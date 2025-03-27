using ProiectDeAnMRSTW.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Domain.Products
{
    public interface ICategory
    {
        Task<List<CategorieAliment>?> GetAllCategories(CancellationToken cancellationToken = default);
    }
}
