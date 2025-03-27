using ProiectDeAnMRSTW.Application.Abstractions.Messaging;
using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Products
{
    internal class GetCategoriesQueryHandler : IQuerryHandler<GetCategoriesQuery,List<CategorieAliment>>
    {
        private readonly ICategory _categories;

        public GetCategoriesQueryHandler(ICategory categories)
        {
            _categories = categories;
        }

        public async Task<Result<List<CategorieAliment>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var Categories = await _categories.GetAllCategories();
            if (Categories == null)
            {
                return Result.Failure<List<CategorieAliment>>(ProductErrors.NotFound);
            }
            return Result.Success(Categories);
        }
    }
}
