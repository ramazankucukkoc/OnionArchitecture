using Application.Features.Products.Dtos;
using MediatR;

namespace Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductQuery : IRequest<ProductGetByIdDto>
    {
        public int Id { get; set; }
    }
}
