using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProiectDeAnMRSTW.Application.Products.GetAllProducts;
using ProiectDeAnMRSTW.Domain.Products;

namespace ProiectDeAnTW.Controllers.Products
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IProductRepository repo;
        public ProductsController(ISender sender, IProductRepository repo)
        {
            _sender = sender;
            this.repo = repo;
        }

        [HttpGet("by-category")]//[HttpGet("{product_category}")]
        public async Task<IActionResult> GetAllProductsByCategory(
            [FromQuery] string product_category,
            CancellationToken cancellationToken = default)
        {
            var query = new GetAllProductQuerry(product_category);
            var result = await _sender.Send(query, cancellationToken);
            if (result.Value == null)
            {
                return NotFound();
            }
            return Ok(result.Value);
        }

        [HttpGet("by-id")]//[HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(
            [FromQuery] Guid id,
            CancellationToken cancellationToken = default)
        {
            var obj = await repo.GetByIdAsync(id);
            return Ok(obj);
        }
    }
}