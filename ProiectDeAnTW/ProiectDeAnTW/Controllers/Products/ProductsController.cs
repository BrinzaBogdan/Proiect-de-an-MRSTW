using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDeAnMRSTW.Application.Products.GetAllProducts;
using ProiectDeAnMRSTW.Application.Products.GetIdByProductName;

namespace ProiectDeAnTW.Controllers.Products
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        public ProductsController(ISender sender)
        {
            _sender = sender;
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
    }
}


/*

 [HttpGet("by-id")]//[HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(
            [FromQuery] Guid id,
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Controller Produse 1 cu id: {id}");
            if (_sender == null)
            {
                Console.WriteLine("Eroare: _sender este null");
                return BadRequest("Internal server error");
            }
            Console.WriteLine("Inceput de Controller Produse");
            var query = new GetAProductQuerry(id);
            if (query == null)
            {
                Console.WriteLine("Eroare: query este null");
                return BadRequest("Internal server error");
            }
            var result = await _sender.Send(query, cancellationToken);
            if (result == null)
            {
                Console.WriteLine("Eroare in Controller Produse: result este null");
                return NotFound();
            }
            if (result.Value == null)
            {
                Console.WriteLine("Eroare in Controller Produse: result.Value este null");
                return NotFound();
            }
            return Ok(result.Value);

        }


 */