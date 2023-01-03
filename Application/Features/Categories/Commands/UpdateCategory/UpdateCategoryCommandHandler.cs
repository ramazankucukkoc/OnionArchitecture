using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Profiles;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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

            Category? mappedCategory = LazyObjectMapper.Mapper.Map<Category>(request);
            
          //  mappedCategory.Id = 0;
            Category updateCategory = await _categoryRepository.UpdateAsync(mappedCategory);
            UpdateCategoryDto updateCategoryDto = LazyObjectMapper.Mapper.Map<UpdateCategoryDto>(updateCategory);

            return updateCategoryDto;

        }
    }
}
