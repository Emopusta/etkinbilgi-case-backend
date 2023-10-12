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

namespace Application.Features.PersonnelShifts.Commands.Update;

public class UpdatePersonnelShiftCommand : IRequest<UpdatedPersonnelShiftResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid PersonnelId { get; set; }
    public string StartShift { get; set; }
    public string EndShift { get; set; }

    public string[] Roles => new[] { Admin, Write, PersonnelShiftsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPersonnelShifts";

    public class UpdatePersonnelShiftCommandHandler : IRequestHandler<UpdatePersonnelShiftCommand, UpdatedPersonnelShiftResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelShiftRepository _personnelShiftRepository;
        private readonly PersonnelShiftBusinessRules _personnelShiftBusinessRules;

        public UpdatePersonnelShiftCommandHandler(IMapper mapper, IPersonnelShiftRepository personnelShiftRepository,
                                         PersonnelShiftBusinessRules personnelShiftBusinessRules)
        {
            _mapper = mapper;
            _personnelShiftRepository = personnelShiftRepository;
            _personnelShiftBusinessRules = personnelShiftBusinessRules;
        }

        public async Task<UpdatedPersonnelShiftResponse> Handle(UpdatePersonnelShiftCommand request, CancellationToken cancellationToken)
        {
            PersonnelShift? personnelShift = await _personnelShiftRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _personnelShiftBusinessRules.PersonnelShiftShouldExistWhenSelected(personnelShift);
            personnelShift = _mapper.Map(request, personnelShift);

            await _personnelShiftRepository.UpdateAsync(personnelShift!);

            UpdatedPersonnelShiftResponse response = _mapper.Map<UpdatedPersonnelShiftResponse>(personnelShift);
            return response;
        }
    }
}