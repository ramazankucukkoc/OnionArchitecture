using Application.Features.Categories.Models;
using Application.Features.Categories.Profiles;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries.GetListCategory
{
    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, CategoryListModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryListModel> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Category> categories = await _categoryRepository
                .GetListAsync(predicate: c => c.Status == false, index: request.PageRequest.PageSize, size: request.PageRequest.Page);
            CategoryListModel mappedCategoryListModel = LazyObjectMapper.Mapper.Map<CategoryListModel>(categories);

            return mappedCategoryListModel;

        }
    }
}
