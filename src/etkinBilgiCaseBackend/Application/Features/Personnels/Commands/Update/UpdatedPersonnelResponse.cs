using Core.Application.Responses;

namespace Application.Features.Personnels.Commands.Update;

public class UpdatedPersonnelResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Image { get; set; }
}