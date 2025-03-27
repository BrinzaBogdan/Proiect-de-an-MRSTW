using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using ProiectDeAnMRSTW.Application.Abstractions.Reviews;
using ProiectDeAnMRSTW.Application.Products;
using ProiectDeAnMRSTW.Domain.Abstractions;

namespace ProiectDeAnTW.Controllers.Reviews
{

    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly ISender _sender;

        //[HttpGet]
        //public async Task<IActionResult> SearchReview(
        //    Guid id,
        //    CancellationToken cancellationToken = default)
        //{
        //    //var query = new AddReviewCommand(id);

        //    var result = await _sender.Send(query, cancellationToken);

        //    return Ok(result.Value);

        //}
        //[HttpPost]
        //public async Task<IActionResult> ReserveBooking(
        //    CreateReviewRequest request,
        //    CancellationToken cancellationToken)
        //{
        //    var command = new CreateReviewRequest(
        //        request.id,
        //        request.productId,
        //        request.rating,
        //        request.comment,
        //        request.createdOnUtc);

        //    var result = await _sender.Send(command, cancellationToken);

        //    //if (result.IsFailure)
        //    //{
        //    //    return BadRequest(result.Error);
        //    //}

        //    //return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, result.Value);
        //    return CreatedAtAction(nameof( new {id = result.Value}
        //}

    }
}
