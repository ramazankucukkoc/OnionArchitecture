using Application.Features.Categories.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Categories.Queries.GetListCategory
{
    public class GetListCategoryQuery : IRequest<CategoryListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
