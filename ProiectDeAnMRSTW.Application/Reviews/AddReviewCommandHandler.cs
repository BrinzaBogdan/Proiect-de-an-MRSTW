using MediatR;
using Microsoft.Extensions.Logging;
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
    internal sealed class AddReviewCommandHandler : ICommandHandler<AddReviewCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReviewRepository _reviewRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILogger<AddReviewCommandHandler> _logger;
        public AddReviewCommandHandler(
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            IReviewRepository reviewRepository,
            IDateTimeProvider dateTimeProvider,
            ILogger<AddReviewCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
            _dateTimeProvider = dateTimeProvider;
            _logger = logger;
        }

        public Guid ProductId { get; private set; }

        public async Task<Result> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            Result<Rating> rating = Rating.Create(request.Rating.Value);

            if (rating.IsFailure)
            {
                return Result.Failure(rating.Error);
            }

            ProductId = await _productRepository.GetProductIdByName(request.ProductName);

            if (ProductId == Guid.Empty)
            {
                _logger.LogWarning($"Product does not exist in database {this.GetType().Name}");
                return Result.Failure(ProductErrors.NullValue);
            }

            Result<Review> review = Review.Create(
                ProductId,
                rating.Value,
                request.Comment,
                _dateTimeProvider.UtcNow);

            if (review.IsFailure)
            {
                _logger.LogWarning($"Create Review is null in {this.GetType().Name} handler");
                return Result.Failure(review.Error);
            }

            _reviewRepository.Add(review.Value);
            _logger.LogWarning($"Review created succesfuly in {review.GetType()}");
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
