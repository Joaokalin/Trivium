using Microsoft.AspNetCore.Mvc;
using TriviumApi.Models.Contracts;

namespace TriviumApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchasesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List([FromServices] IPurchaseService service)
        {
            var (purchases, count) = await service.List();
            return Ok(new { purchases, count });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Find([FromRoute] int id, [FromServices] IPurchaseService service)
        {
            var purchase = await service.Find(id);

            if (purchase == null) return NotFound();
            return Ok(purchase);
        }

        [HttpGet("customer/{customerId:long}")]
        public async Task<IActionResult> CustomerHistory([FromRoute] long customerId, [FromServices] IPurchaseService service)
        {
            var history = await service.CustomerHistory(customerId);
            return Ok(history);
        }

        [HttpGet("product/{productId:long}")]
        public async Task<IActionResult> ProductHistory([FromRoute] long productId, [FromServices] IPurchaseService service)
        {
            var history = await service.ProductHistory(productId);
            return Ok(history);
        }
    }
}
