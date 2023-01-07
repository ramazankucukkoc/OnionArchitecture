using Application.Features.Categories.Dtos;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
