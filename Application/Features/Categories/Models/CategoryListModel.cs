using Application.Features.Categories.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Categories.Models
{
    public class CategoryListModel : BasePageableModel
    {
        public List<CategoryListDto> Items { get; set; }

    }
}
