using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnTW.Models;

namespace ProiectDeAnTW.Interfaces
{
    public interface IReviewService
    {
        Task<Result<ReviewModel?>> CreateReview(ReviewModel model);
    }
}
