using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;

        public ProductBusinessRules(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task ProductNameCanNotDuplicatedWhenInserted(string name)
        {
            IPaginate<Product> result = await _productRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Brand Name Exists");
        }
        public async Task ProductShouldExistWhenRequested(int id)
        {
            Product? product = await _productRepository.GetAsync(p => p.Id == id);
            if (product == null) throw new BusinessException("Hataaaaaaaaaaaaaa!!!");
        }

    }
}
