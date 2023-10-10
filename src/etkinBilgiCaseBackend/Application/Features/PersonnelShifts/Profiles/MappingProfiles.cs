using Application.Features.PersonnelShifts.Commands.Create;
using Application.Features.PersonnelShifts.Commands.Delete;
using Application.Features.PersonnelShifts.Commands.Update;
using Application.Features.PersonnelShifts.Queries.GetById;
using Application.Features.PersonnelShifts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.PersonnelShifts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PersonnelShift, CreatePersonnelShiftCommand>().ReverseMap();
        CreateMap<PersonnelShift, CreatedPersonnelShiftResponse>().ReverseMap();
        CreateMap<PersonnelShift, UpdatePersonnelShiftCommand>().ReverseMap();
        CreateMap<PersonnelShift, UpdatedPersonnelShiftResponse>().ReverseMap();
        CreateMap<PersonnelShift, DeletePersonnelShiftCommand>().ReverseMap();
        CreateMap<PersonnelShift, DeletedPersonnelShiftResponse>().ReverseMap();
        CreateMap<PersonnelShift, GetByIdPersonnelShiftResponse>().ReverseMap();
        CreateMap<PersonnelShift, GetListPersonnelShiftListItemDto>().ReverseMap();
        CreateMap<IPaginate<PersonnelShift>, GetListResponse<GetListPersonnelShiftListItemDto>>().ReverseMap();
    }
}