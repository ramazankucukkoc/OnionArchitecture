using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entitites;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoginDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
        {
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;

            public LoginCommandHandler(IAuthService authService, AuthBusinessRules authBusinessRules, IUserRepository userRepository)
            {
                _authService = authService;
                _authBusinessRules = authBusinessRules;
                _userRepository = userRepository;
            }

            public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.EmailIsExists(request.UserForLoginDto.Email);
                User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

                if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                    throw new BusinessException("Password is true hashing");

                AccessToken accessToken = await _authService.CreateAccessToken(user);
                RefreshToken refreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                LoginDto loginDto = new() { AccessToken = accessToken, RefreshToken = refreshToken };
                return loginDto;
            }
        }
    }
}
