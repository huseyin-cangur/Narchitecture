

using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Application.Response;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetListByDynamic
{
    public class GetListByDynamicCarQuery : IRequest<GetListResponse<GetListByDynamicCarItemDto>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery DynamicQuery { get; set; }


        public class GetListByDynamicCarQueryHandler : IRequestHandler<GetListByDynamicCarQuery, GetListResponse<GetListByDynamicCarItemDto>>
        {
            private readonly IMapper _mapper;
            private readonly ICarRepository _carRepository;

            public GetListByDynamicCarQueryHandler(IMapper mapper, ICarRepository carRepository)
            {
                _mapper = mapper;
                _carRepository = carRepository;
            }


            public async Task<GetListResponse<GetListByDynamicCarItemDto>> Handle(GetListByDynamicCarQuery request, CancellationToken cancellationToken)
            {
                var models = await _carRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                include: m => m.Include(m => m.Fuel).Include(m => m.Transmission).Include(m => m.Model).ThenInclude(m => m.Brand),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
             );

                var response = _mapper.Map<GetListResponse<GetListByDynamicCarItemDto>>(models);

                return response;
            }
        }
    }
}