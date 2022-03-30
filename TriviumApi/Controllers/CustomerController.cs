using Microsoft.AspNetCore.Mvc;
using TriviumApi.Models.Contracts;
using TriviumApi.Models.DTOS;

namespace TriviumApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CustomerDTO customerDTO, [FromServices] ICustomerService service)
        {
            var customer = await service.Register(customerDTO.Map());

            if (customer == null) return BadRequest();
            return Ok(customer);

        }

        [HttpGet]
        public async Task<IActionResult> List([FromServices] ICustomerService service)
        {
            var (customers, count) = await service.List();
            return Ok(new { customers, count });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Find([FromRoute] int id, [FromServices] ICustomerService service)
        {
            var customer = await service.Find(id);

            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CustomerDTO customerDTO, [FromServices] ICustomerService service)
        {
            var cust = await service.Find(id);
            if ( cust == null) return NotFound();

            var custumer = customerDTO.Map();
            custumer.Id = id;
            return Ok(await service.Update(custumer));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id, [FromServices] ICustomerService service)
        {
            var customer = await service.Find(id);
            if (customer == null) return NotFound();

            await service.Delete(customer);
            return NoContent();
        }
    }
}