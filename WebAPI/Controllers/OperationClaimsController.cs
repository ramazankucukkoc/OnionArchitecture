using Application.Features.Auths.Commands.OperationClaims;
using Application.Features.Auths.Dtos;
using Application.Features.Auths.Models;
using Application.Features.Auths.Queries.OperationClaims.GetByIdQuery;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreateOperationClaimDto createOperationClaimDto = await Mediator.Send(createOperationClaimCommand);
            return Created("", createOperationClaimDto);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeleteOperationClaimDto deleteOperationClaimDto = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(deleteOperationClaimDto);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            OperationClaimGetListQuery operationClaimGetListQuery = new() { PageRequest = pageRequest };
            OperationClaimListModel claimListModel = await Mediator.Send(operationClaimGetListQuery);
            return Ok(claimListModel);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            OperationClaimGetByIdQuery operationClaim = new() { Id = id };
            OperationClaimGetByIdDto claimGetByIdDto = await Mediator.Send(operationClaim);
            return Ok(claimGetByIdDto);
        }

    }
}
