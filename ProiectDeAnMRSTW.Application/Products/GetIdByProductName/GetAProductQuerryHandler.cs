using ProiectDeAnMRSTW.Application.Abstractions.Messaging;
using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Products.GetIdByProductName
{
    internal sealed class GetAProductQuerryHandler : IQuerryHandler<GetAProductQuerry, Guid>
    {
        private readonly IProductRepository _productRepository;

        public GetAProductQuerryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<Guid>> Handle(GetAProductQuerry request, CancellationToken cancellationToken)
        {
            var ProductId = await _productRepository.GetProductIdByName(request.ProductName, cancellationToken);
            if (ProductId == null)
            {
                return Result.Failure<Guid>(ProductErrors.NotFound);
            }
            return Result.Success(ProductId);
        }
    }
}