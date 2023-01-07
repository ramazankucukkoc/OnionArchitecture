using Core.Security.Entitites;
using Core.Security.JWT;

namespace Application.Features.Auths.Dtos
{
    public class RefreshTokenDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }

    }
}
