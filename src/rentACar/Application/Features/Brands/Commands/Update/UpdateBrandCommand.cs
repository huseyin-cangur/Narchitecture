

using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommand : IRequest<UpdateBrandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandResponse>
        {
            private readonly IBrandRepository _brandRepository;

            public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            private readonly IMapper _mapper;
            public async Task<UpdateBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.Id);


                brand = _mapper.Map(request, brand);

                brand = await _brandRepository.UpdateAsync(brand);

                UpdateBrandResponse response = _mapper.Map<UpdateBrandResponse>(brand);

                return response;

              
            }
        }
    }
}