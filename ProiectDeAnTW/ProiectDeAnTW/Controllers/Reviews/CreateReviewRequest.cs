using ProiectDeAnMRSTW.Domain.Reviews;

namespace ProiectDeAnTW.Controllers.Reviews
{
public sealed record CreateReviewRequest(
    Guid id,
    Guid productId,
    Rating rating, 
    Comment comment, 
    DateTime createdOnUtc);
}
