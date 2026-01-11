

using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetList
{
    public class GetListCarQuery : IRequest<GetListResponse<GetListCarItemDto>>
    {
        public PageRequest PageRequest { get; set; }



        public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery, GetListResponse<GetListCarItemDto>>
        {

            private readonly IMapper _mapper;
            private readonly ICarRepository _carRepository;

            public GetListCarQueryHandler(IMapper mapper, ICarRepository carRepository)
            {
                _mapper = mapper;
                _carRepository = carRepository;
            }

            public async Task<GetListResponse<GetListCarItemDto>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
            {
                var models = await _carRepository.GetListAsync(
                   include: m => m.Include(m => m.Fuel).Include(m => m.Transmission).Include(m => m.Model).ThenInclude(m => m.Brand),
                   index: request.PageRequest.PageIndex,
                   size: request.PageRequest.PageSize
                );

                var response = _mapper.Map<GetListResponse<GetListCarItemDto>>(models);

                return response;
            }
        }

    }
}