
using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Request;
using Core.Application.Response;
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

            CreatedBrandResponse response = await mediator.Send(createBrandCommand);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromBody] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };

            GetListResponse<GetListBrandListItemDto> getListResponse = await mediator.Send(getListBrandQuery);

            return Ok(getListResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            GetByIdBrandQuery getByIdBrandQuery = new() { Id = id };
            GetByIdBrandResponse response = await mediator.Send(getByIdBrandQuery);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            UpdateBrandResponse response = await mediator.Send(updateBrandCommand);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)

        {
            DeleteBrandCommand deleteBrand = new() { Id = Id };
            DeleteBrandResponse response = await mediator.Send(deleteBrand);

            return Ok(response);
        }

    }
}