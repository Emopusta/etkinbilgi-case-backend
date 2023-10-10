using Application.Features.Personnels.Constants;
using Application.Features.Personnels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Personnels.Constants.PersonnelsOperationClaims;

namespace Application.Features.Personnels.Commands.Update;

public class UpdatePersonnelCommand : IRequest<UpdatedPersonnelResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string[] Roles => new[] { Admin, Write, PersonnelsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPersonnels";

    public class UpdatePersonnelCommandHandler : IRequestHandler<UpdatePersonnelCommand, UpdatedPersonnelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelRepository _personnelRepository;
        private readonly PersonnelBusinessRules _personnelBusinessRules;

        public UpdatePersonnelCommandHandler(IMapper mapper, IPersonnelRepository personnelRepository,
                                         PersonnelBusinessRules personnelBusinessRules)
        {
            _mapper = mapper;
            _personnelRepository = personnelRepository;
            _personnelBusinessRules = personnelBusinessRules;
        }

        public async Task<UpdatedPersonnelResponse> Handle(UpdatePersonnelCommand request, CancellationToken cancellationToken)
        {
            Personnel? personnel = await _personnelRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _personnelBusinessRules.PersonnelShouldExistWhenSelected(personnel);
            personnel = _mapper.Map(request, personnel);

            await _personnelRepository.UpdateAsync(personnel!);

            UpdatedPersonnelResponse response = _mapper.Map<UpdatedPersonnelResponse>(personnel);
            return response;
        }
    }
}