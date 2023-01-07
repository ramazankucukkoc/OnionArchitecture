using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Profiles;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _businessRules;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository,
            CategoryBusinessRules businessRules)
        {
            _categoryRepository = categoryRepository;

            _businessRules = businessRules;
        }
        public async Task<UpdateCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CategoryShouldExistsWhenRequested(request.Id);

            Category? category = await _categoryRepository.GetAsync(c => c.Id == request.Id);

            category.Description = request.Description;
            category.Name = request.Name;
            Category updateCategory = await _categoryRepository.UpdateAsync(category);
            UpdateCategoryDto updateCategoryDto = LazyObjectMapper.Mapper.Map<UpdateCategoryDto>(updateCategory);

            return updateCategoryDto;

        }
    }
}
