using ProiectDeAnMRSTW.Application.Abstractions.Messaging;
using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Products.GetAllProducts
{
    internal sealed class GetAllProductQuerryHandler : IQuerryHandler<GetAllProductQuerry, List<Aliment>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQuerryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<List<Aliment>>> Handle(GetAllProductQuerry request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsByCategoryName(request.product_category, cancellationToken);
            if (products == null || !products.Any())
            {
                return Result.Failure<List<Aliment>>(ProductErrors.NotFound);
            }

            return Result.Success(products);    
        }
    }
}
