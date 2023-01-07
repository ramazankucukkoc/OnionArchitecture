using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Categories.Profiles
{
    public class CategoryProfile : Profile
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


            CreateMap<IPaginate<Category>, CategoryListModel>().ReverseMap();
            CreateMap<CategoryListDto, CategoryListModel>().ReverseMap();
            CreateMap<CategoryListDto, Category>().ReverseMap();

            CreateMap<Category, CategoryGetByIdDto>().ReverseMap();

            //Queries Mappings


        }

    }
}
