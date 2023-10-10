using Core.Application.Responses;

namespace Application.Features.Personnels.Commands.Create;

public class CreatedPersonnelResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Image { get; set; }
}