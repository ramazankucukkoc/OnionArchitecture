using Application.Features.Categories.Dtos;
using Application.Features.Categories.Profiles;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryGetByIdDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, 
            CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CategoryGetByIdDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.CategoryShouldExistsWhenRequested(request.Id);
            Category? category = await _categoryRepository.GetAsync(c => c.Id == request.Id);
            CategoryGetByIdDto categoryGetByIdDto=LazyObjectMapper.Mapper.Map<CategoryGetByIdDto>(category);
            return categoryGetByIdDto;

        }
    }
}
