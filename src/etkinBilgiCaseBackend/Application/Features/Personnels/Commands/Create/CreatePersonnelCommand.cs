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

namespace Application.Features.Personnels.Commands.Create;

public class CreatePersonnelCommand : IRequest<CreatedPersonnelResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public string Image { get; set; }

    public string[] Roles => new[] { Admin, Write, PersonnelsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPersonnels";

    public class CreatePersonnelCommandHandler : IRequestHandler<CreatePersonnelCommand, CreatedPersonnelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelRepository _personnelRepository;
        private readonly PersonnelBusinessRules _personnelBusinessRules;

        public CreatePersonnelCommandHandler(IMapper mapper, IPersonnelRepository personnelRepository,
                                         PersonnelBusinessRules personnelBusinessRules)
        {
            _mapper = mapper;
            _personnelRepository = personnelRepository;
            _personnelBusinessRules = personnelBusinessRules;
        }

        public async Task<CreatedPersonnelResponse> Handle(CreatePersonnelCommand request, CancellationToken cancellationToken)
        {
            Personnel personnel = _mapper.Map<Personnel>(request);

            await _personnelRepository.AddAsync(personnel);

            CreatedPersonnelResponse response = _mapper.Map<CreatedPersonnelResponse>(personnel);
            return response;
        }
    }
}