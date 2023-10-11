using Application.Features.Personnels.Commands.Create;
using Application.Features.Personnels.Commands.Delete;
using Application.Features.Personnels.Commands.Update;
using Application.Features.Personnels.Queries.GetById;
using Application.Features.Personnels.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Personnels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Personnel, CreatePersonnelCommand>().ReverseMap();
        CreateMap<Personnel, CreatedPersonnelResponse>().ReverseMap();
        CreateMap<Personnel, UpdatePersonnelCommand>().ReverseMap();
        CreateMap<Personnel, UpdatedPersonnelResponse>().ReverseMap();
        CreateMap<Personnel, DeletePersonnelCommand>().ReverseMap();
        CreateMap<Personnel, DeletedPersonnelResponse>().ReverseMap();
        CreateMap<Personnel, GetByIdPersonnelResponse>().ReverseMap();
        CreateMap<Personnel, GetListPersonnelListItemDto>()
            .ForMember(p => p.FirstName, opt => opt.MapFrom(u => u.User.FirstName))
            .ForMember(p => p.LastName, opt => opt.MapFrom(u => u.User.LastName))
            .ForMember(p => p.Email, opt => opt.MapFrom(u => u.User.Email))
            .ReverseMap();


        CreateMap<IPaginate<Personnel>, GetListResponse<GetListPersonnelListItemDto>>().ReverseMap();
    }
}