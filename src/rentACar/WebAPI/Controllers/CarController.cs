
using Application.Features.Cars.Queries.GetList;
using Application.Features.Cars.Queries.GetListByDynamic;
using Core.Application.Request;
using Core.Application.Response;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CarController : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListCarQuery getListCarQuery = new() { PageRequest = pageRequest };

            GetListResponse<GetListCarItemDto> getListResponse = await mediator.Send(getListCarQuery);

            return Ok(getListResponse);
        }
        [HttpPost]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,[FromBody] DynamicQuery dynamicQuery)
        {
            GetListByDynamicCarQuery getListByDynamicCarQuery = new() { PageRequest = pageRequest,DynamicQuery= dynamicQuery};

            GetListResponse<GetListByDynamicCarItemDto> getListResponse = await mediator.Send(getListByDynamicCarQuery);

            return Ok(getListResponse);
        }

    }
}