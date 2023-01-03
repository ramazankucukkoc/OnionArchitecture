using Application.Features.Categories.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class UpdateCategoryCommand:IRequest<UpdateCategoryDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
