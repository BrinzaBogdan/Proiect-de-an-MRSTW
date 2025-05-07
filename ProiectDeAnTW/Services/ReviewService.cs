using Azure;
using ProiectDeAnTW.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ProiectDeAnMRSTW.Domain.Abstractions;
using System.Linq.Expressions;
using ProiectDeAnMRSTW.Application.DTOs;
namespace ProiectDeAnTW.Services
{
    public class ReviewService : IReviewService
    {
        private HttpClient _httpClient { get; set; }
        private readonly ILogger<ReviewService> _logger;
        public ReviewService(HttpClient HttpClient, ILogger<ReviewService> logger)
        {
            _httpClient = HttpClient;
            _logger = logger;
        }

        public async Task<CreateReviewDto> CreateReview(CreateReviewDto model)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7000/api/reviews/create-review", model);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<CreateReviewDto>();
                _logger.LogInformation("Post request succeded on Review");
                return new();
            }
            else
            {
                _logger.LogError("Review Post request is null");
                // Poți extrage un mesaj de eroare din body dacă există
                var errorContent = await response.Content.ReadAsStringAsync();
                return new();
            }

        }
    }
}
