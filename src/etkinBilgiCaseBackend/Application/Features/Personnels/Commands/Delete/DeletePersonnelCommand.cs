using Application.Features.Personnels.Constants;
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

namespace Application.Features.Personnels.Commands.Delete;

public class DeletePersonnelCommand : IRequest<DeletedPersonnelResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, PersonnelsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPersonnels";

    public class DeletePersonnelCommandHandler : IRequestHandler<DeletePersonnelCommand, DeletedPersonnelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelRepository _personnelRepository;
        private readonly PersonnelBusinessRules _personnelBusinessRules;

        public DeletePersonnelCommandHandler(IMapper mapper, IPersonnelRepository personnelRepository,
                                         PersonnelBusinessRules personnelBusinessRules)
        {
            _mapper = mapper;
            _personnelRepository = personnelRepository;
            _personnelBusinessRules = personnelBusinessRules;
        }

        public async Task<DeletedPersonnelResponse> Handle(DeletePersonnelCommand request, CancellationToken cancellationToken)
        {
            Personnel? personnel = await _personnelRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _personnelBusinessRules.PersonnelShouldExistWhenSelected(personnel);

            await _personnelRepository.DeleteAsync(personnel!);

            DeletedPersonnelResponse response = _mapper.Map<DeletedPersonnelResponse>(personnel);
            return response;
        }
    }
}