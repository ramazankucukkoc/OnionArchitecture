using Application.Features.Categories.Profiles;
using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductBusinessRules _businessRules;

        public UpdateProductCommandHandler(IProductRepository productRepository, ProductBusinessRules businessRules)
        {
            _productRepository = productRepository;
            _businessRules = businessRules;
        }
        public async Task<UpdateProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.ProductShouldExistWhenRequested(request.Id);

            Product? product = await _productRepository.GetAsync(p => p.Id == request.Id);
            product.Name = request.Name;

            product.Description = request.Description;
            product.CategoryId = request.CategoryId;

            Product updatedProduct = await _productRepository.UpdateAsync(product);
            UpdateProductDto updateProductDto = LazyObjectMapper.Mapper.Map<UpdateProductDto>(updatedProduct);
            return updateProductDto;

        }
    }
}
