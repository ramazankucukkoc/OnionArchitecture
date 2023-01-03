 using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper,
            ProductBusinessRules productBusinessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
            
        }

        public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //_logger.Debug("İşelmeler");
            //iş kuralı bu satırı geçemezse hata fırlatılacak.
            await _productBusinessRules.ProductNameCanNotDuplicatedWhenInserted(request.Name);

            Product mappedProduct=_mapper.Map<Product>(request);
            Product createdProduct = await _productRepository.AddAsync(mappedProduct);
            CreateProductDto createProductDto =_mapper.Map<CreateProductDto>(createdProduct);
             
            return createProductDto;

        }
    }
}
