
using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using AutoMapper;
using Core.Application.Response;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
            CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
            CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdateBrandResponse>().ReverseMap();
            CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
            CreateMap<Brand, DeleteBrandResponse>().ReverseMap();
            CreateMap<GetListResponse<GetListBrandListItemDto>, Paginate<Brand>>().ReverseMap();

        }
    }
}