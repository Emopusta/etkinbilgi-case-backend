using Application.Features.PersonnelDepartments.Commands.Create;
using Application.Features.PersonnelDepartments.Commands.Delete;
using Application.Features.PersonnelDepartments.Commands.Update;
using Application.Features.PersonnelDepartments.Queries.GetById;
using Application.Features.PersonnelDepartments.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonnelDepartmentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePersonnelDepartmentCommand createPersonnelDepartmentCommand)
    {
        CreatedPersonnelDepartmentResponse response = await Mediator.Send(createPersonnelDepartmentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePersonnelDepartmentCommand updatePersonnelDepartmentCommand)
    {
        UpdatedPersonnelDepartmentResponse response = await Mediator.Send(updatePersonnelDepartmentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedPersonnelDepartmentResponse response = await Mediator.Send(new DeletePersonnelDepartmentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdPersonnelDepartmentResponse response = await Mediator.Send(new GetByIdPersonnelDepartmentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPersonnelDepartmentQuery getListPersonnelDepartmentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListPersonnelDepartmentListItemDto> response = await Mediator.Send(getListPersonnelDepartmentQuery);
        return Ok(response);
    }
}