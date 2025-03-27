using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDeAnMRSTW.Application.Products;

namespace ProiectDeAnTW.Controllers.Products.ProductCategories
{
    [Route("api/categories")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ISender _sender;
        public ProductCategoryController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken = default)
        {
            var query = new GetCategoriesQuery();
            var result = await _sender.Send(query, cancellationToken);
            if (result.Value == null)
            {
                Console.WriteLine("Eroare in Controller Produse: result.Value este null");
                return NotFound();
            }
            return Ok(result.Value);
        }

    }
}
