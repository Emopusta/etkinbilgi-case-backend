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

namespace Application.Features.PersonnelDepartments.Commands.Update;

public class UpdatePersonnelDepartmentCommand : IRequest<UpdatedPersonnelDepartmentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid PersonnelId { get; set; }
    public Guid DepartmentId { get; set; }

    public string[] Roles => new[] { Admin, Write, PersonnelDepartmentsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPersonnelDepartments";

    public class UpdatePersonnelDepartmentCommandHandler : IRequestHandler<UpdatePersonnelDepartmentCommand, UpdatedPersonnelDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelDepartmentRepository _personnelDepartmentRepository;
        private readonly PersonnelDepartmentBusinessRules _personnelDepartmentBusinessRules;

        public UpdatePersonnelDepartmentCommandHandler(IMapper mapper, IPersonnelDepartmentRepository personnelDepartmentRepository,
                                         PersonnelDepartmentBusinessRules personnelDepartmentBusinessRules)
        {
            _mapper = mapper;
            _personnelDepartmentRepository = personnelDepartmentRepository;
            _personnelDepartmentBusinessRules = personnelDepartmentBusinessRules;
        }

        public async Task<UpdatedPersonnelDepartmentResponse> Handle(UpdatePersonnelDepartmentCommand request, CancellationToken cancellationToken)
        {
            PersonnelDepartment? personnelDepartment = await _personnelDepartmentRepository.GetAsync(predicate: pd => pd.Id == request.Id, cancellationToken: cancellationToken);
            await _personnelDepartmentBusinessRules.PersonnelDepartmentShouldExistWhenSelected(personnelDepartment);
            personnelDepartment = _mapper.Map(request, personnelDepartment);

            await _personnelDepartmentRepository.UpdateAsync(personnelDepartment!);

            UpdatedPersonnelDepartmentResponse response = _mapper.Map<UpdatedPersonnelDepartmentResponse>(personnelDepartment);
            return response;
        }
    }
}