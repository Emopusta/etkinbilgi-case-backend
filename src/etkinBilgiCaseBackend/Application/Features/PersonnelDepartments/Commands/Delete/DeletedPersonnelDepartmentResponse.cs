using Core.Application.Responses;

namespace Application.Features.PersonnelDepartments.Commands.Delete;

public class DeletedPersonnelDepartmentResponse : IResponse
{
    public Guid Id { get; set; }
}