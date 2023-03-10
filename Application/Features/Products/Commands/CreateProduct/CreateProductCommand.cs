using Application.Features.Products.Constants;
using Application.Features.Products.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductDto>, ISecuredRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public string[] Roles { get; } = new[]
            { ProductRoles.ProductAdmin, ProductRoles.ProductCreate, ProductRoles.Admin };

    }
}
