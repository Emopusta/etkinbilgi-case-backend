using Application.Features.PersonnelShifts.Constants;
using Application.Features.PersonnelShifts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.PersonnelShifts.Constants.PersonnelShiftsOperationClaims;

namespace Application.Features.PersonnelShifts.Commands.Create;

public class CreatePersonnelShiftCommand : IRequest<CreatedPersonnelShiftResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid PersonnelId { get; set; }
    public DateTime StartShift { get; set; }
    public DateTime EndShift { get; set; }

    public string[] Roles => new[] { Admin, Write, PersonnelShiftsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPersonnelShifts";

    public class CreatePersonnelShiftCommandHandler : IRequestHandler<CreatePersonnelShiftCommand, CreatedPersonnelShiftResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelShiftRepository _personnelShiftRepository;
        private readonly PersonnelShiftBusinessRules _personnelShiftBusinessRules;

        public CreatePersonnelShiftCommandHandler(IMapper mapper, IPersonnelShiftRepository personnelShiftRepository,
                                         PersonnelShiftBusinessRules personnelShiftBusinessRules)
        {
            _mapper = mapper;
            _personnelShiftRepository = personnelShiftRepository;
            _personnelShiftBusinessRules = personnelShiftBusinessRules;
        }

        public async Task<CreatedPersonnelShiftResponse> Handle(CreatePersonnelShiftCommand request, CancellationToken cancellationToken)
        {
            PersonnelShift personnelShift = _mapper.Map<PersonnelShift>(request);

            await _personnelShiftRepository.AddAsync(personnelShift);

            CreatedPersonnelShiftResponse response = _mapper.Map<CreatedPersonnelShiftResponse>(personnelShift);
            return response;
        }
    }
}