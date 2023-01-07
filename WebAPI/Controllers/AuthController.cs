using Application.Features.Auths.Commands.OperationClaims;
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
        [HttpPost("OperationClaimAdd")]
        public async Task<IActionResult> OperationClaimAdd([FromBody] CreateOperationClaimCommand createOperationClaimCommand )
        {
            CreateOperationClaimDto createOperationClaimDto = await Mediator.Send(createOperationClaimCommand);
            return Created("",createOperationClaimDto);
        }


    }
}
