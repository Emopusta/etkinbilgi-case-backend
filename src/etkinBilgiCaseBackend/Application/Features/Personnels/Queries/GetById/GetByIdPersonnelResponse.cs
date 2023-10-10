using Core.Application.Responses;

namespace Application.Features.Personnels.Queries.GetById;

public class GetByIdPersonnelResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}