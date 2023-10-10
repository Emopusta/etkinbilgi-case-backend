using Core.Application.Dtos;

namespace Application.Features.Personnels.Queries.GetList;

public class GetListPersonnelListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Image { get; set; }
}