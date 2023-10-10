using Core.Application.Responses;

namespace Application.Features.PersonnelShifts.Commands.Create;

public class CreatedPersonnelShiftResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid PersonnelId { get; set; }
    public DateTime StartShift { get; set; }
    public DateTime EndShift { get; set; }
}