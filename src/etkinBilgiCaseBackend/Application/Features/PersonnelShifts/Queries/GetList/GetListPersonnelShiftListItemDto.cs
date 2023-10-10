using Core.Application.Dtos;

namespace Application.Features.PersonnelShifts.Queries.GetList;

public class GetListPersonnelShiftListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid PersonnelId { get; set; }
    public DateTime StartShift { get; set; }
    public DateTime EndShift { get; set; }
}