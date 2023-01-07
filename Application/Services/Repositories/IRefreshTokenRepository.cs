using Core.Persistence.Repositories;
using Core.Security.Entitites;

namespace Application.Services.Repositories
{
    public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken>
    {

    }
}
