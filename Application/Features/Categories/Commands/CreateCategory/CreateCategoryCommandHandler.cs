using Application.Features.Categories.Dtos;
using Application.Features.Categories.Profiles;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _businessRules;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, CategoryBusinessRules businessRules)
        {
            _categoryRepository = categoryRepository;
            _businessRules = businessRules;
        }

        public async Task<CreateCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);

            Category mappedCategory = LazyObjectMapper.Mapper.Map<Category>(request);
            Category createdCategory = await _categoryRepository.AddAsync(mappedCategory);
            CreateCategoryDto createCategoryDto = LazyObjectMapper.Mapper.Map<CreateCategoryDto>(createdCategory);

            return createCategoryDto;
        }

    }
}
