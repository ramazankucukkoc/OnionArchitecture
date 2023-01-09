using Application.Features.Auths.Dtos;
using Application.Features.Auths.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entitites;

namespace Application.Features.Categories.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            //Command Mappings Creates
            CreateMap<OperationClaim, CreateOperationClaimDto>().
                ForMember(co => co.ClaimName, opt => opt.MapFrom(o => o.Name)).
                ReverseMap();
            CreateMap<DeleteOperationClaimDto, OperationClaim>().ReverseMap();

            //Queries Mappings

            CreateMap<OperationClaim, GetListOperationClaim>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<GetListOperationClaim, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimGetByIdDto>().ReverseMap();


        }

    }
}
