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

        public ReviewsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost("create-review")]
        public async Task<IActionResult> CreateReview(
            [FromBody] CreateReviewDto request,
            CancellationToken cancellationToken)
        {

            var command = new AddReviewCommand(
                ProductName: request.ProductName,
                Rating: request.Rating,
                Comment: request.Comment
                );
            var result = await _sender.Send(command, cancellationToken);
            
            return result.IsSuccess ?
                Ok(result) :
                BadRequest(result);
            /*
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            */
        }
    }
}