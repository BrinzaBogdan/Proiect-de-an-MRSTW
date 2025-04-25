using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDeAnMRSTW.Application.DTOs;

//using ProiectDeAnMRSTW.Application.Abstractions.Reviews;
using ProiectDeAnMRSTW.Application.Products;
using ProiectDeAnMRSTW.Application.Reviews;
using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products;

namespace ProiectDeAnTW.Controllers.Reviews
{

    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly ISender _sender;
        //private readonly IProductRepository _productRepository;

        public ReviewsController(ISender sender)
        {
            _sender = sender;
            //_productRepository = productRepository;
        }
        [HttpPost("create-review")]
        public async Task<IActionResult> CreateReview(
            [FromBody] CreateReviewDto request,
            CancellationToken cancellationToken)
        {
            //var productID = await _productRepository.GetProductIdByName(request.ProductName, cancellationToken);

            var command = new AddReviewCommand(
                ProductName :request.ProductName,
                Rating : request.Rating,
                Comment : request.Comment
                );

            var result = await _sender.Send(command, cancellationToken);

            return 
                result.IsSuccess ? 
                Ok(result) : 
                BadRequest(result);
        }

    }

    //[ApiController]
    //[Route("api/user")]
    //public class UserController : ControllerBase
    //{
    //    [HttpPost("update")]
    //    public IActionResult Update([FromBody] UserDto user)
    //    {
    //        if (string.IsNullOrWhiteSpace(user.Nume) || string.IsNullOrWhiteSpace(user.Email))
    //        {
    //            return BadRequest("Datele sunt invalide.");
    //        }

    //        //Console.WriteLine($"{user.Nume},   {user.Email}");
    //        // Logica ta de salvare (ex. în baza de date)
    //        return Ok($"Name: {user.Nume},\n" +
    //            $"Email: {user.Email}");
    //    }
    //}

}