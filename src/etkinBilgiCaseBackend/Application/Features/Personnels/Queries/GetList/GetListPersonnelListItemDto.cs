using Core.Application.Dtos;

namespace Application.Features.Personnels.Queries.GetList;

public class GetListPersonnelListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; }
}