using ProiectDeAnMRSTW.Application.Abstractions.Messaging;
using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products;
using ProiectDeAnTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Products
{
    internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var aliment = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if(aliment == null)
            {
                return Result.Failure<Guid>(ProductErrors.NotFound); 
            }

            var product = Aliment.Create(Guid.NewGuid());

            _productRepository.Add(aliment);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return aliment.Id;
        }
    }
}
