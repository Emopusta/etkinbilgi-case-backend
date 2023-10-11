using Application.Features.Personnels.Commands.Create;
using Application.Features.Personnels.Commands.Delete;
using Application.Features.Personnels.Commands.Update;
using Application.Features.Personnels.Queries.GetById;
using Application.Features.Personnels.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonnelsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] CreatePersonnelCommand createPersonnelCommand)
    {
        CreatedPersonnelResponse response = await Mediator.Send(createPersonnelCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePersonnelCommand updatePersonnelCommand)
    {
        UpdatedPersonnelResponse response = await Mediator.Send(updatePersonnelCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedPersonnelResponse response = await Mediator.Send(new DeletePersonnelCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdPersonnelResponse response = await Mediator.Send(new GetByIdPersonnelQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPersonnelQuery getListPersonnelQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListPersonnelListItemDto> response = await Mediator.Send(getListPersonnelQuery);
        return Ok(response);
    }
}