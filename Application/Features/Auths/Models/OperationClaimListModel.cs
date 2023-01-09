using Application.Features.Auths.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Auths.Models
{
    public class OperationClaimListModel : BasePageableModel
    {
        public IList<GetListOperationClaim> Items { get; set; }
    }
}
