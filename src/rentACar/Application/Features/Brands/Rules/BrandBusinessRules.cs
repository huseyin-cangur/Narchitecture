

using Application.Features.Brands.Constants;
using Core.Application.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules:BaseBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCannotBeDuplicatetedWhenInserted(string name)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Name.ToLower() == name.ToLower());

            if (brand != null)
            {
                throw new BusinessException(BrandMessages.BrandNameExists);
            }
        }
    }
}