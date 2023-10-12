using Core.Application.Dtos;

namespace Application.Features.PersonnelShifts.Queries.GetList;

public class GetListPersonnelShiftListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid PersonnelId { get; set; }
    public string StartShift { get; set; }
    public string EndShift { get; set; }
}