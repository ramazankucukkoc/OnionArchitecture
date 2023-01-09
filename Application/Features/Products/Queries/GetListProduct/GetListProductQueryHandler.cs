using Application.Features.Products.Models;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetListProduct
{
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, ProductListModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public GetListProductQueryHandler(IProductRepository productRepository,
            IMapper mapper, ProductBusinessRules productBusinessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<ProductListModel> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Product> products = await _productRepository.GetListAsync(predicate: c => c.Status != true,
                include:x=>x.Include(p=>p.Category),
                index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            ProductListModel mappedProductListModel = _mapper.Map<ProductListModel>(products);
            return mappedProductListModel;
        }


    }
}
