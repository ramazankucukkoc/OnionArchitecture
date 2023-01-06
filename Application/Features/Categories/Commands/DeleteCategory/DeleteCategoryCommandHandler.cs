using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, 
            IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<DeleteCategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {            
            await _categoryBusinessRules.CategoryShouldExistsWhenRequested(request.Id);

            Category? category = await _categoryRepository.GetAsync(c => c.Id == request.Id);
            
            Category deletedCategory = await _categoryRepository.DeleteAsync(category);

            DeleteCategoryDto createdCategoryDto =_mapper.Map<DeleteCategoryDto>(deletedCategory);

            return createdCategoryDto;
        }
    }
}
