using Application.Features.PersonnelDepartments.Constants;
using Application.Features.PersonnelDepartments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.PersonnelDepartments.Constants.PersonnelDepartmentsOperationClaims;

namespace Application.Features.PersonnelDepartments.Commands.Create;

public class CreatePersonnelDepartmentCommand : IRequest<CreatedPersonnelDepartmentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid PersonnelId { get; set; }
    public Guid DepartmentId { get; set; }

    public string[] Roles => new[] { Admin, Write, PersonnelDepartmentsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPersonnelDepartments";

    public class CreatePersonnelDepartmentCommandHandler : IRequestHandler<CreatePersonnelDepartmentCommand, CreatedPersonnelDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelDepartmentRepository _personnelDepartmentRepository;
        private readonly PersonnelDepartmentBusinessRules _personnelDepartmentBusinessRules;

        public CreatePersonnelDepartmentCommandHandler(IMapper mapper, IPersonnelDepartmentRepository personnelDepartmentRepository,
                                         PersonnelDepartmentBusinessRules personnelDepartmentBusinessRules)
        {
            _mapper = mapper;
            _personnelDepartmentRepository = personnelDepartmentRepository;
            _personnelDepartmentBusinessRules = personnelDepartmentBusinessRules;
        }

        public async Task<CreatedPersonnelDepartmentResponse> Handle(CreatePersonnelDepartmentCommand request, CancellationToken cancellationToken)
        {
            PersonnelDepartment personnelDepartment = _mapper.Map<PersonnelDepartment>(request);

            await _personnelDepartmentRepository.AddAsync(personnelDepartment);

            CreatedPersonnelDepartmentResponse response = _mapper.Map<CreatedPersonnelDepartmentResponse>(personnelDepartment);
            return response;
        }
    }
}