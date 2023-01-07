using Application.Features.Categories.Dtos;
using MediatR;

namespace Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryQuery : IRequest<CategoryGetByIdDto>
    {
        public int Id { get; set; }
    }
}
