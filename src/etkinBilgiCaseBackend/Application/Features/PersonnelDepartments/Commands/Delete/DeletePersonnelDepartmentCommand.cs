using Application.Features.PersonnelDepartments.Constants;
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

namespace Application.Features.PersonnelDepartments.Commands.Delete;

public class DeletePersonnelDepartmentCommand : IRequest<DeletedPersonnelDepartmentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, PersonnelDepartmentsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPersonnelDepartments";

    public class DeletePersonnelDepartmentCommandHandler : IRequestHandler<DeletePersonnelDepartmentCommand, DeletedPersonnelDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelDepartmentRepository _personnelDepartmentRepository;
        private readonly PersonnelDepartmentBusinessRules _personnelDepartmentBusinessRules;

        public DeletePersonnelDepartmentCommandHandler(IMapper mapper, IPersonnelDepartmentRepository personnelDepartmentRepository,
                                         PersonnelDepartmentBusinessRules personnelDepartmentBusinessRules)
        {
            _mapper = mapper;
            _personnelDepartmentRepository = personnelDepartmentRepository;
            _personnelDepartmentBusinessRules = personnelDepartmentBusinessRules;
        }

        public async Task<DeletedPersonnelDepartmentResponse> Handle(DeletePersonnelDepartmentCommand request, CancellationToken cancellationToken)
        {
            PersonnelDepartment? personnelDepartment = await _personnelDepartmentRepository.GetAsync(predicate: pd => pd.Id == request.Id, cancellationToken: cancellationToken);
            await _personnelDepartmentBusinessRules.PersonnelDepartmentShouldExistWhenSelected(personnelDepartment);

            await _personnelDepartmentRepository.DeleteAsync(personnelDepartment!);

            DeletedPersonnelDepartmentResponse response = _mapper.Map<DeletedPersonnelDepartmentResponse>(personnelDepartment);
            return response;
        }
    }
}