using Application.Features.Products.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Products.Queries.GetListProduct
{
    public class GetListProductQuery : IRequest<ProductListModel>
    {
        public PageRequest PageRequest { get; set; }

    }
}
