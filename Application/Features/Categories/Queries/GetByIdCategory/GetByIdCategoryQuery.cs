using Application.Features.Categories.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryQuery:IRequest<CategoryGetByIdDto>
    {
        public int Id { get; set; }
    }
}
