using ProiectDeAnMRSTW.Application.DTOs;
using ProiectDeAnMRSTW.Domain.Abstractions;

namespace ProiectDeAnTW.Interfaces
{
    public interface IReviewService
    {
        Task<CreateReviewDto> CreateReview(CreateReviewDto model);
    }
}
