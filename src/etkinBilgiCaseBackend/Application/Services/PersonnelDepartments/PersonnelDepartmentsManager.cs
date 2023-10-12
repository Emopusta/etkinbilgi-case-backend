using Application.Features.PersonnelDepartments.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PersonnelDepartments;

public class PersonnelDepartmentsManager : IPersonnelDepartmentsService
{
    private readonly IPersonnelDepartmentRepository _personnelDepartmentRepository;
    private readonly PersonnelDepartmentBusinessRules _personnelDepartmentBusinessRules;

    public PersonnelDepartmentsManager(IPersonnelDepartmentRepository personnelDepartmentRepository, PersonnelDepartmentBusinessRules personnelDepartmentBusinessRules)
    {
        _personnelDepartmentRepository = personnelDepartmentRepository;
        _personnelDepartmentBusinessRules = personnelDepartmentBusinessRules;
    }

    public async Task<PersonnelDepartment?> GetAsync(
        Expression<Func<PersonnelDepartment, bool>> predicate,
        Func<IQueryable<PersonnelDepartment>, IIncludableQueryable<PersonnelDepartment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PersonnelDepartment? personnelDepartment = await _personnelDepartmentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return personnelDepartment;
    }

    public async Task<IPaginate<PersonnelDepartment>?> GetListAsync(
        Expression<Func<PersonnelDepartment, bool>>? predicate = null,
        Func<IQueryable<PersonnelDepartment>, IOrderedQueryable<PersonnelDepartment>>? orderBy = null,
        Func<IQueryable<PersonnelDepartment>, IIncludableQueryable<PersonnelDepartment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PersonnelDepartment> personnelDepartmentList = await _personnelDepartmentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return personnelDepartmentList;
    }

    public async Task<PersonnelDepartment> AddAsync(PersonnelDepartment personnelDepartment)
    {
        PersonnelDepartment addedPersonnelDepartment = await _personnelDepartmentRepository.AddAsync(personnelDepartment);

        return addedPersonnelDepartment;
    }

    public async Task<PersonnelDepartment> UpdateAsync(PersonnelDepartment personnelDepartment)
    {
        PersonnelDepartment updatedPersonnelDepartment = await _personnelDepartmentRepository.UpdateAsync(personnelDepartment);

        return updatedPersonnelDepartment;
    }

    public async Task<PersonnelDepartment> DeleteAsync(PersonnelDepartment personnelDepartment, bool permanent = false)
    {
        PersonnelDepartment deletedPersonnelDepartment = await _personnelDepartmentRepository.DeleteAsync(personnelDepartment);

        return deletedPersonnelDepartment;
    }
}
