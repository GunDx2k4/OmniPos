using Microsoft.AspNetCore.Mvc;
using OmniPos.Application.Common;
using OmniPos.Application.DTOs;
using OmniPos.Application.Products.Queries;

namespace OmniPos.Server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController(Dispatcher dispatcher) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var products = await dispatcher.DispatchAsync(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await dispatcher.DispatchAsync(new GetProductQuery() { ProductId = id });
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
