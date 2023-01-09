using Application.Features.Auths.Dtos;
using Application.Features.Auths.Profiles;
using Application.Services.Repositories;
using Core.Security.Entitites;
using MediatR;

namespace Application.Features.Auths.Queries.OperationClaims.GetByIdQuery
{
    public class OperationClaimGetByIdQuery : IRequest<OperationClaimGetByIdDto>
    {
        public int Id { get; set; }

        public class OperationClaimGetByIdQueryHandler : IRequestHandler<OperationClaimGetByIdQuery, OperationClaimGetByIdDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;

            public OperationClaimGetByIdQueryHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<OperationClaimGetByIdDto> Handle(OperationClaimGetByIdQuery request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);
                OperationClaimGetByIdDto operationClaimGetByIdDto = LazyObjectMapper.Mapper.Map<OperationClaimGetByIdDto>(operationClaim);
                return operationClaimGetByIdDto;

            }
        }
    }
}
