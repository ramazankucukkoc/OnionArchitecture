using Application.Features.Categories.Dtos;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryDto>
    {
        public int Id { get; set; }
    }
}
