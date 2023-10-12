using Core.Application.Responses;

namespace Application.Features.PersonnelDepartments.Commands.Create;

public class CreatedPersonnelDepartmentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid PersonnelId { get; set; }
    public Guid DepartmentId { get; set; }
}