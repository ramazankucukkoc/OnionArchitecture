using Application.Features.Auths.Dtos;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entitites;
using Domain.Entities;

namespace Application.Features.Categories.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            //Command Mappings Creates
            CreateMap<OperationClaim,CreateOperationClaimDto>().
                ForMember(co=>co.ClaimName,opt=>opt.MapFrom(o=>o.Name)).
                ReverseMap();

            //Queries Mappings


        }

    }
}
