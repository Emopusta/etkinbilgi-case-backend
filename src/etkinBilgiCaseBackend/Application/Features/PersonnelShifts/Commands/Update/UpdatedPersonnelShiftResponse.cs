using Core.Application.Responses;

namespace Application.Features.PersonnelShifts.Commands.Update;

public class UpdatedPersonnelShiftResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid PersonnelId { get; set; }
    public DateTime StartShift { get; set; }
    public DateTime EndShift { get; set; }
}