using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDeAnMRSTW.Application.Products;

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
        [HttpGet("by-id")]//[HttpGet("{id}")]
        public async Task<IActionResult> GetProducts(
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
        [HttpGet("by-category")]//[HttpGet("{product_category}")]
        public async Task<IActionResult> GetCarne(
            [FromQuery] string product_category,
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Controller Produse cu product_category: {product_category}");

            var query = new GetAllProductQuerry(product_category);
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
            /*
         [HttpGet]
public async Task<IActionResult> GetProducts(
    [FromQuery] Guid? id,
    [FromQuery] string? product_category,
    CancellationToken cancellationToken = default)
{
    if (id != null)
    {
        Console.WriteLine($"Căutare produs după ID: {id}");
        var query = new GetAProductQuerry(id.Value);
        var result = await _sender.Send(query, cancellationToken);
        return result?.Value == null ? NotFound() : Ok(result.Value);
    }
    else if (!string.IsNullOrEmpty(product_category))
    {
        Console.WriteLine($"Căutare produse după categorie: {product_category}");
        var query = new GetAllProductQuerry(product_category);
        var result = await _sender.Send(query, cancellationToken);
        return result?.Value == null ? NotFound() : Ok(result.Value);
    }
    else
    {
        return BadRequest("Trebuie să specifici un id sau o categorie!");
    }
}    
             */
        }
    }
}
