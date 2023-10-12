using Core.Application.Responses;

namespace Application.Features.PersonnelShifts.Queries.GetById;

public class GetByIdPersonnelShiftResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid PersonnelId { get; set; }
    public string StartShift { get; set; }
    public string EndShift { get; set; }
}