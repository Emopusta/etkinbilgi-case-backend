using Application.Features.PersonnelDepartments.Commands.Create;
using Application.Features.PersonnelDepartments.Commands.Delete;
using Application.Features.PersonnelDepartments.Commands.Update;
using Application.Features.PersonnelDepartments.Queries.GetById;
using Application.Features.PersonnelDepartments.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.PersonnelDepartments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PersonnelDepartment, CreatePersonnelDepartmentCommand>().ReverseMap();
        CreateMap<PersonnelDepartment, CreatedPersonnelDepartmentResponse>().ReverseMap();
        CreateMap<PersonnelDepartment, UpdatePersonnelDepartmentCommand>().ReverseMap();
        CreateMap<PersonnelDepartment, UpdatedPersonnelDepartmentResponse>().ReverseMap();
        CreateMap<PersonnelDepartment, DeletePersonnelDepartmentCommand>().ReverseMap();
        CreateMap<PersonnelDepartment, DeletedPersonnelDepartmentResponse>().ReverseMap();
        CreateMap<PersonnelDepartment, GetByIdPersonnelDepartmentResponse>().ReverseMap();
        CreateMap<PersonnelDepartment, GetListPersonnelDepartmentListItemDto>().ReverseMap();
        CreateMap<IPaginate<PersonnelDepartment>, GetListResponse<GetListPersonnelDepartmentListItemDto>>().ReverseMap();
    }
}