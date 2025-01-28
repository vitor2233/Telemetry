using Telemetry.Communication.Requests;
using Telemetry.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using Telemetry.Application.UseCases.Machines.Delete;
using Telemetry.Application.UseCases.Machines.Update;
using Telemetry.Application.UseCases.Machines.Register;
using Telemetry.Application.UseCases.Machines.GetById;

namespace Telemetry.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MachinesController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(GetMachineByIdResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetMachineByIdUseCase useCase,
        [FromRoute] Guid id)
    {
        var response = await useCase.Execute(id);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(MachineResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterMachineUseCase useCase,
        [FromBody] MachineRequestJson request)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(MachineResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateMachineUseCase useCase,
        [FromRoute] Guid id,
        [FromBody] MachineRequestJson request)
    {
        var response = await useCase.Execute(id, request);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteMachineUseCase useCase,
        [FromRoute] Guid id)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}