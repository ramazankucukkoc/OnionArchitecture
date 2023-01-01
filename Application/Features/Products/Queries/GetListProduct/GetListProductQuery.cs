using Application.Features.Products.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetListProduct
{
    public class GetListProductQuery:IRequest<ProductListModel>
    {
        public PageRequest PageRequest { get; set; }

    }
}
