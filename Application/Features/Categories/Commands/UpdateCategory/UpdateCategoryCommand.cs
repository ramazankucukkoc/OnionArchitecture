using Application.Features.Categories.Dtos;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
