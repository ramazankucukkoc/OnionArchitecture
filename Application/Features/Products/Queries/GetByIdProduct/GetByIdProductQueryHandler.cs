using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductGetByIdDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _businessRules;

        public GetByIdProductQueryHandler(IProductRepository productRepository, 
            IMapper mapper, ProductBusinessRules businessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<ProductGetByIdDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {        
            Product? product = await _productRepository.GetAsync(p => p.Id == request.Id);
            _businessRules.ProductShouldExistWhenRequested(product.Id);

            ProductGetByIdDto productGetById=_mapper.Map<ProductGetByIdDto>(product);
            return productGetById;
        }
    }
}
