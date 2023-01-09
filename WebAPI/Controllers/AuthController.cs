using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, IpAddress = GetByIpAddress() };
            RegisteredDto registered = await Mediator.Send(registerCommand);
            return Created("", registered.AccessToken);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new()
            { UserForLoginDto = userForLoginDto, IpAddress = GetByIpAddress() };

            LoginDto loginDto = await Mediator.Send(loginCommand);
            return Ok(loginDto);
        }


    }
}
