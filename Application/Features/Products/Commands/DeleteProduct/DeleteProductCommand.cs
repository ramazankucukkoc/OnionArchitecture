﻿using Application.Features.Products.Dtos;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
