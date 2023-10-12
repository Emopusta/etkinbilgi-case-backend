using Application.Features.PersonnelDepartments.Constants;
using Application.Features.PersonnelDepartments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.PersonnelDepartments.Constants.PersonnelDepartmentsOperationClaims;

namespace Application.Features.PersonnelDepartments.Queries.GetById;

public class GetByIdPersonnelDepartmentQuery : IRequest<GetByIdPersonnelDepartmentResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdPersonnelDepartmentQueryHandler : IRequestHandler<GetByIdPersonnelDepartmentQuery, GetByIdPersonnelDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelDepartmentRepository _personnelDepartmentRepository;
        private readonly PersonnelDepartmentBusinessRules _personnelDepartmentBusinessRules;

        public GetByIdPersonnelDepartmentQueryHandler(IMapper mapper, IPersonnelDepartmentRepository personnelDepartmentRepository, PersonnelDepartmentBusinessRules personnelDepartmentBusinessRules)
        {
            _mapper = mapper;
            _personnelDepartmentRepository = personnelDepartmentRepository;
            _personnelDepartmentBusinessRules = personnelDepartmentBusinessRules;
        }

        public async Task<GetByIdPersonnelDepartmentResponse> Handle(GetByIdPersonnelDepartmentQuery request, CancellationToken cancellationToken)
        {
            PersonnelDepartment? personnelDepartment = await _personnelDepartmentRepository.GetAsync(predicate: pd => pd.Id == request.Id, cancellationToken: cancellationToken);
            await _personnelDepartmentBusinessRules.PersonnelDepartmentShouldExistWhenSelected(personnelDepartment);

            GetByIdPersonnelDepartmentResponse response = _mapper.Map<GetByIdPersonnelDepartmentResponse>(personnelDepartment);
            return response;
        }
    }
}