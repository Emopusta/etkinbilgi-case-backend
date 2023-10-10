using Application.Features.PersonnelShifts.Constants;
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

namespace Application.Features.PersonnelShifts.Commands.Delete;

public class DeletePersonnelShiftCommand : IRequest<DeletedPersonnelShiftResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, PersonnelShiftsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPersonnelShifts";

    public class DeletePersonnelShiftCommandHandler : IRequestHandler<DeletePersonnelShiftCommand, DeletedPersonnelShiftResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelShiftRepository _personnelShiftRepository;
        private readonly PersonnelShiftBusinessRules _personnelShiftBusinessRules;

        public DeletePersonnelShiftCommandHandler(IMapper mapper, IPersonnelShiftRepository personnelShiftRepository,
                                         PersonnelShiftBusinessRules personnelShiftBusinessRules)
        {
            _mapper = mapper;
            _personnelShiftRepository = personnelShiftRepository;
            _personnelShiftBusinessRules = personnelShiftBusinessRules;
        }

        public async Task<DeletedPersonnelShiftResponse> Handle(DeletePersonnelShiftCommand request, CancellationToken cancellationToken)
        {
            PersonnelShift? personnelShift = await _personnelShiftRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _personnelShiftBusinessRules.PersonnelShiftShouldExistWhenSelected(personnelShift);

            await _personnelShiftRepository.DeleteAsync(personnelShift!);

            DeletedPersonnelShiftResponse response = _mapper.Map<DeletedPersonnelShiftResponse>(personnelShift);
            return response;
        }
    }
}