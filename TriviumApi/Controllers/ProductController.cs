using Microsoft.AspNetCore.Mvc;
using TriviumApi.Models.Contracts;

namespace TriviumApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List([FromServices] IProductService service)
        {
            var (products, count) = await service.List();
            return Ok(new { products, count });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Find([FromRoute] int id, [FromServices] ICustomerService service)
        {
            var product = await service.Find(id);

            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}
