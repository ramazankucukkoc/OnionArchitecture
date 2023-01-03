using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CategoryNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Category> result = await _categoryRepository.GetListAsync(category => category.Name == name);
            if (result.Items.Any()) throw new BusinessException("Category Name Exists");
        }
        public async Task CategoryShouldExistsWhenRequested(int id)
        {
            Category? category = await _categoryRepository.GetAsync(c => c.Id == id);
            if (category == null) throw new BusinessException("Requested category does not exists");

        }

    }
}
