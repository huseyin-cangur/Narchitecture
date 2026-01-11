

using Application.Features.Cars.Queries.GetList;
using Application.Features.Cars.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Response;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Cars.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, GetListCarItemDto>()
            .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
            .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Model.Brand.Name))
            .ForMember(destinationMember: c => c.ModelName, memberOptions: opt => opt.MapFrom(c => c.Model.Name))
            .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
            .ReverseMap();

            CreateMap<Car, GetListByDynamicCarItemDto>()
            .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
             .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Model.Brand.Name))
            .ForMember(destinationMember: c => c.ModelName, memberOptions: opt => opt.MapFrom(c => c.Model.Name))
            .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
            .ReverseMap();

            CreateMap<Paginate<Car>, GetListResponse<GetListCarItemDto>>().ReverseMap();
            CreateMap<Paginate<Car>, GetListResponse<GetListByDynamicCarItemDto>>().ReverseMap();
        }

    }
}