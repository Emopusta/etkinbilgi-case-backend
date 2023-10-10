using Application.Features.PersonnelShifts.Constants;
using Application.Features.PersonnelShifts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.PersonnelShifts.Constants.PersonnelShiftsOperationClaims;

namespace Application.Features.PersonnelShifts.Queries.GetById;

public class GetByIdPersonnelShiftQuery : IRequest<GetByIdPersonnelShiftResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdPersonnelShiftQueryHandler : IRequestHandler<GetByIdPersonnelShiftQuery, GetByIdPersonnelShiftResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelShiftRepository _personnelShiftRepository;
        private readonly PersonnelShiftBusinessRules _personnelShiftBusinessRules;

        public GetByIdPersonnelShiftQueryHandler(IMapper mapper, IPersonnelShiftRepository personnelShiftRepository, PersonnelShiftBusinessRules personnelShiftBusinessRules)
        {
            _mapper = mapper;
            _personnelShiftRepository = personnelShiftRepository;
            _personnelShiftBusinessRules = personnelShiftBusinessRules;
        }

        public async Task<GetByIdPersonnelShiftResponse> Handle(GetByIdPersonnelShiftQuery request, CancellationToken cancellationToken)
        {
            PersonnelShift? personnelShift = await _personnelShiftRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _personnelShiftBusinessRules.PersonnelShiftShouldExistWhenSelected(personnelShift);

            GetByIdPersonnelShiftResponse response = _mapper.Map<GetByIdPersonnelShiftResponse>(personnelShift);
            return response;
        }
    }
}