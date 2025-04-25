using Azure;
using ProiectDeAnTW.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using ProiectDeAnTW.Models;
using Microsoft.AspNetCore.Components;
using ProiectDeAnMRSTW.Domain.Abstractions;
namespace ProiectDeAnTW.Services
{
    public class ReviewService : IReviewService
    {
        private HttpClient _httpClient { get; set; }
        private readonly ILogger<ReviewService> logger;
        public ReviewService(HttpClient HttpClient)
        {
            _httpClient = HttpClient;
        }

        public async Task<Result<ReviewModel?>> CreateReview(ReviewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7000/api/reviews/create-review", model);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Result<ReviewModel>>();
                return result!;
            }
            else
            {
                // Poți extrage un mesaj de eroare din body dacă există
                var errorContent = await response.Content.ReadAsStringAsync();
                return Result.Failure<ReviewModel?>(Error.NullValue);
            }

        }
    }
}
