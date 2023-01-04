using Application.Features.Categories.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetListCategory
{
    public class GetListCategoryQuery:IRequest<CategoryListModel>
    {
        public PageRequest  PageRequest { get; set; }
    }
}
