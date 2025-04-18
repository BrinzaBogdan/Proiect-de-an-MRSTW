﻿using ProiectDeAnMRSTW.Application.Abstractions.Clock;
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

        public async Task<Result> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            Result<Rating> rating = Rating.Create(request.Rating.Value);

            if (rating.IsFailure)
            {
                return Result.Failure(rating.Error);
            }

            Result<Review> review = Review.Create(
                request.ProductId,
                rating.Value,
                request.Comment,
                _dateTimeProvider.UtcNow);

            if (review.IsFailure)
            {
                return Result.Failure(review.Error);
            }

            _reviewRepository.Add(review.Value);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
