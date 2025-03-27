using MediatR;
using ProiectDeAnMRSTW.Application.Abstractions.Email;
using ProiectDeAnMRSTW.Domain.Products;
using ProiectDeAnMRSTW.Domain.Reviews;
using ProiectDeAnMRSTW.Domain.Reviews.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Reviews
{
    internal sealed class ReviewCreatedDomainEventHandler : INotificationHandler<ReviewCreatedDomainEvent>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IProductRepository _productRepository;
        private readonly IEmailService _emailService;


        public ReviewCreatedDomainEventHandler(
            IReviewRepository reviewRepository,
            IProductRepository productRepository,
            IEmailService emailService)
        {
            _reviewRepository = reviewRepository;
            _productRepository = productRepository;
            _emailService = emailService;
        }

        public async Task Handle(ReviewCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            //var review = await _reviewRepository.GetByIdAsync(notification.ReviewId, cancellationToken);
            //if (review is null)
            //{
            //    return;
            //}
            //var product = await _productRepository.GetByIdAsync(review.ProductId, cancellationToken);
            //if (product is null)
            //{
            //    return;
            //}
            await _emailService.SendAsync("product.Name", "Review Created!", "Ready to the next review");
        }
    }

}
