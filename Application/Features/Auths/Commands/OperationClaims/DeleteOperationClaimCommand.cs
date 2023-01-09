using Application.Features.Auths.Dtos;
using Application.Features.Auths.Profiles;
using Application.Services.Repositories;
using Core.Security.Entitites;
using MediatR;

namespace Application.Features.Auths.Commands.OperationClaims
{
    public class DeleteOperationClaimCommand : IRequest<DeleteOperationClaimDto>
    {
        public int Id { get; set; }
        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeleteOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<DeleteOperationClaimDto> Handle(DeleteOperationClaimCommand request,
                CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);
                operationClaim.Status = true;

                OperationClaim operationDeleted = await _operationClaimRepository.UpdateAsync(operationClaim);
                await _operationClaimRepository.SaveChangesAsync();
                DeleteOperationClaimDto deleteOperationClaimDto = LazyObjectMapper.Mapper.Map<DeleteOperationClaimDto>(operationDeleted);
                return deleteOperationClaimDto;
            }
        }
    }
}
