using Core.Application.Responses;

namespace Application.Features.PersonnelShifts.Commands.Delete;

public class DeletedPersonnelShiftResponse : IResponse
{
    public Guid Id { get; set; }
}