using Application.Features.Auths.Models;
using Application.Features.Auths.Profiles;
using Application.Services.Repositories;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entitites;
using MediatR;

namespace Application.Features.Auths.Queries.OperationClaims.GetByIdQuery
{
    public class OperationClaimGetListQuery : IRequest<OperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class OperationClaimGetListQueryHandler : IRequestHandler<OperationClaimGetListQuery, OperationClaimListModel>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;

            public OperationClaimGetListQueryHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<OperationClaimListModel> Handle(OperationClaimGetListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> operationCliams = await _operationClaimRepository.GetListAsync(predicate: o => o.Status == false,
                    orderBy: x => x.OrderBy(o => o.Name), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                OperationClaimListModel operationClaimListModel = LazyObjectMapper.Mapper.Map<OperationClaimListModel>(operationCliams);
                return operationClaimListModel;
            }
        }
    }
}
