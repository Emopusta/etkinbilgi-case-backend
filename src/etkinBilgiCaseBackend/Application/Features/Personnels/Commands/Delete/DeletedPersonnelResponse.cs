using Core.Application.Responses;

namespace Application.Features.Personnels.Commands.Delete;

public class DeletedPersonnelResponse : IResponse
{
    public Guid Id { get; set; }
}