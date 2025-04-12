using ProiectDeAnMRSTW.Domain.Reviews;

namespace ProiectDeAnTW.Controllers.Reviews
{
public sealed record CreateReviewRequest(
    string ProductName,
    Rating rating, 
    Comment comment);
}
