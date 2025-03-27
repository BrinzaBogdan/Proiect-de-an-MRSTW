using ProiectDeAnMRSTW.Application.Abstractions.Clock;
using ProiectDeAnMRSTW.Application.Abstractions.Messaging;
using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products;
using ProiectDeAnMRSTW.Domain.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Reviews
{
    internal sealed class AddReviewCommandHandler : ICommandHandler<AddReviewCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReviewRepository _reviewRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AddReviewCommandHandler(
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            IReviewRepository reviewRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<int>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {

            var aliment = await _productRepository.GetByIdAsync(request.productId, cancellationToken);

            if (aliment == null)
            {
                return Result.Failure<int>(ProductErrors.NotFound);
            }

            var review = Review.Create(
                aliment,
                request.Rating,
                request.Comment,
                _dateTimeProvider.UtcNow);

            if (review.IsSuccess)
            {
                _reviewRepository.Add(review.Value);
            }
            else
            {
                Console.WriteLine($"Erorr: {review.Error}");
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return review.Value.Id;
        }
    }
}
