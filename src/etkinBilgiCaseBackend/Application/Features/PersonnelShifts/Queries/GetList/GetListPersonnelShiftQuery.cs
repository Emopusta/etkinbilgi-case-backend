using Application.Features.PersonnelShifts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.PersonnelShifts.Constants.PersonnelShiftsOperationClaims;

namespace Application.Features.PersonnelShifts.Queries.GetList;

public class GetListPersonnelShiftQuery : IRequest<GetListResponse<GetListPersonnelShiftListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListPersonnelShifts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetPersonnelShifts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPersonnelShiftQueryHandler : IRequestHandler<GetListPersonnelShiftQuery, GetListResponse<GetListPersonnelShiftListItemDto>>
    {
        private readonly IPersonnelShiftRepository _personnelShiftRepository;
        private readonly IMapper _mapper;

        public GetListPersonnelShiftQueryHandler(IPersonnelShiftRepository personnelShiftRepository, IMapper mapper)
        {
            _personnelShiftRepository = personnelShiftRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPersonnelShiftListItemDto>> Handle(GetListPersonnelShiftQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PersonnelShift> personnelShifts = await _personnelShiftRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPersonnelShiftListItemDto> response = _mapper.Map<GetListResponse<GetListPersonnelShiftListItemDto>>(personnelShifts);
            return response;
        }
    }
}