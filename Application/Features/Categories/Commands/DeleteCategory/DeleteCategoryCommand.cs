﻿using Application.Features.Categories.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class DeleteCategoryCommand:IRequest<DeleteCategoryDto>
    {
        public int Id { get; set; }
    }
}
