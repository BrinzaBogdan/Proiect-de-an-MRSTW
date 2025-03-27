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
    internal sealed class GetAProductQuerryHandler : IQuerryHandler<GetAProductQuerry, Aliment> 
    {
        private readonly IProductRepository _productRepository;

        public GetAProductQuerryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<Aliment>> Handle(GetAProductQuerry request, CancellationToken cancellationToken)
        {
            var product =  await _productRepository.GetByIdAsync(request.ProducID,cancellationToken);
            if (product == null)
            {
                return Result.Failure<Aliment>(ProductErrors.NotFound);
            }
            return Result.Success(product);
        }
    }
}