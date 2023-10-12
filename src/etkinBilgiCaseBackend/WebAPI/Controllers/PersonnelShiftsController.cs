using Application.Features.PersonnelShifts.Commands.Create;
using Application.Features.PersonnelShifts.Commands.Delete;
using Application.Features.PersonnelShifts.Commands.Update;
using Application.Features.PersonnelShifts.Queries.GetById;
using Application.Features.PersonnelShifts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonnelShiftsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] CreatePersonnelShiftCommand createPersonnelShiftCommand)
    {
        CreatedPersonnelShiftResponse response = await Mediator.Send(createPersonnelShiftCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePersonnelShiftCommand updatePersonnelShiftCommand)
    {
        UpdatedPersonnelShiftResponse response = await Mediator.Send(updatePersonnelShiftCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedPersonnelShiftResponse response = await Mediator.Send(new DeletePersonnelShiftCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdPersonnelShiftResponse response = await Mediator.Send(new GetByIdPersonnelShiftQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPersonnelShiftQuery getListPersonnelShiftQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListPersonnelShiftListItemDto> response = await Mediator.Send(getListPersonnelShiftQuery);
        return Ok(response);
    }
}