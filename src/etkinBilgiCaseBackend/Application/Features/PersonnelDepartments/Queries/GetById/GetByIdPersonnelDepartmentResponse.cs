using Core.Application.Responses;

namespace Application.Features.PersonnelDepartments.Queries.GetById;

public class GetByIdPersonnelDepartmentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid PersonnelId { get; set; }
    public Guid DepartmentId { get; set; }
}