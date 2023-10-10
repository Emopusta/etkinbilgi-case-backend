using Application.Features.Personnels.Constants;
using Application.Features.Personnels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Personnels.Constants.PersonnelsOperationClaims;

namespace Application.Features.Personnels.Queries.GetById;

public class GetByIdPersonnelQuery : IRequest<GetByIdPersonnelResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdPersonnelQueryHandler : IRequestHandler<GetByIdPersonnelQuery, GetByIdPersonnelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelRepository _personnelRepository;
        private readonly PersonnelBusinessRules _personnelBusinessRules;

        public GetByIdPersonnelQueryHandler(IMapper mapper, IPersonnelRepository personnelRepository, PersonnelBusinessRules personnelBusinessRules)
        {
            _mapper = mapper;
            _personnelRepository = personnelRepository;
            _personnelBusinessRules = personnelBusinessRules;
        }

        public async Task<GetByIdPersonnelResponse> Handle(GetByIdPersonnelQuery request, CancellationToken cancellationToken)
        {
            Personnel? personnel = await _personnelRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _personnelBusinessRules.PersonnelShouldExistWhenSelected(personnel);

            GetByIdPersonnelResponse response = _mapper.Map<GetByIdPersonnelResponse>(personnel);
            return response;
        }
    }
}