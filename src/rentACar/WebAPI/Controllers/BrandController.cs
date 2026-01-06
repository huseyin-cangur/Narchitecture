
using Application.Features.Brands.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BrandController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            if (mediator == null)
                return BadRequest();

           CreatedBrandResponse response =  await mediator.Send(createBrandCommand);

            return Ok(response);
        }

    }
}