using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            //Command Mappings Creates
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            //Command Mappings Deletes
            CreateMap<Category, DeleteCategoryDto>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
            //Command Mappings Updates
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            //Queries Mappings


        }

    }
}
