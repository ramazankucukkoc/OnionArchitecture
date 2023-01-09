using Application.Features.Auths.Constants;
using Application.Features.Auths.Dtos;
using Application.Features.Auths.Profiles;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entitites;
using MediatR;

namespace Application.Features.Auths.Commands.OperationClaims
{
    public class CreateOperationClaimCommand : IRequest<CreateOperationClaimDto>
    {
        public string CliamName { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreateOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }
            public async Task<CreateOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                if (IsClaimExists(request.CliamName))
                {
                    throw new BusinessException(Messages.OperationCliamsExists);
                }
                OperationClaim operationClaim = new OperationClaim
                {
                    Name = request.CliamName
                };
                OperationClaim operationClaimAdd = await _operationClaimRepository.AddAsync(operationClaim);
                await _operationClaimRepository.SaveChangesAsync();
                CreateOperationClaimDto createdMapped = LazyObjectMapper.Mapper.Map<CreateOperationClaimDto>(operationClaimAdd);
                return createdMapped;
            }
            private bool IsClaimExists(string claimName)
            {
                return _operationClaimRepository.Query().Any(x => x.Name == claimName);
            }
        }
    }
}
