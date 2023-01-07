using Core.Security.Entitites;
using Core.Security.JWT;

namespace Application.Services.AuthService
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);

        public Task<RefreshToken> CreateRefreshToken(User user, string IpAdress);
        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);



    }
}
