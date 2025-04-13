using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using ProiectDeAnMRSTW.Application.Abstractions.Reviews;
using ProiectDeAnMRSTW.Application.Products;
using ProiectDeAnMRSTW.Application.Reviews;
using ProiectDeAnMRSTW.Domain.Abstractions;
using ProiectDeAnMRSTW.Domain.Products;

namespace ProiectDeAnTW.Controllers.Reviews
{

    //[ApiController]
    //[Route("api/reviews")]
    //public class ReviewsController : ControllerBase
    //{
    //    private readonly ISender _sender;
    //    private readonly IProductRepository _productRepository;

    //    public ReviewsController(IProductRepository productRepository)
    //    {
    //        _productRepository = productRepository;
    //    }
    //    [HttpPost]
    //    public async Task<IActionResult> CreateReview(
    //        CreateReviewRequest request,
    //        CancellationToken cancellationToken)
    //    {
    //        var productID = await _productRepository.GetProductIdByName(request.ProductName,cancellationToken);

    //        var command = new AddReviewCommand(
    //            productID,
    //            request.rating,
    //            request.comment
    //            );

    //        Result result = await _sender.Send(command, cancellationToken);

    //        if (result.IsFailure)
    //        {
    //            return BadRequest(result.Error);
    //        }

    //        //return CreatedAtAction(nameof(CreateReview), (new { id = result }));
    //        return Ok();
    //    }

    //}
    
        [ApiController]
        [Route("api/user")]
        public class UserController : ControllerBase
        {
            [HttpPost("update")]
            public IActionResult Update([FromBody] UserDto user)
            {
                if (string.IsNullOrWhiteSpace(user.Nume) || string.IsNullOrWhiteSpace(user.Email))
                {
                    return BadRequest("Datele sunt invalide.");
                }

                //Console.WriteLine($"{user.Nume},   {user.Email}");
                // Logica ta de salvare (ex. în baza de date)
                return Ok($"Name: {user.Nume},\n" +
                    $"Email: {user.Email}");
            }
        }
    /*
            [HttpPost("update")]
            public IActionResult Update([FromQuery] string Nume, [FromQuery] string Email)
            {
                if (string.IsNullOrWhiteSpace(Nume) || string.IsNullOrWhiteSpace(Email))
                {
                    return BadRequest("Datele sunt invalide.");
                }

                //Console.WriteLine($"{Nume},   {Email}");
                // Logica ta de salvare (ex. în baza de date)
                return Ok($"{Nume},   {Email}");
            }
    */

        public class UserDto
        {
            public string Nume { get; set; }
            public string Email { get; set; }
        }
    
}