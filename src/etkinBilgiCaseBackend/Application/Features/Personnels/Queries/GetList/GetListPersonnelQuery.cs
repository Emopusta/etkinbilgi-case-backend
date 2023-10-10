using Application.Features.Personnels.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Personnels.Constants.PersonnelsOperationClaims;

namespace Application.Features.Personnels.Queries.GetList;

public class GetListPersonnelQuery : IRequest<GetListResponse<GetListPersonnelListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListPersonnels({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetPersonnels";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPersonnelQueryHandler : IRequestHandler<GetListPersonnelQuery, GetListResponse<GetListPersonnelListItemDto>>
    {
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IMapper _mapper;

        public GetListPersonnelQueryHandler(IPersonnelRepository personnelRepository, IMapper mapper)
        {
            _personnelRepository = personnelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPersonnelListItemDto>> Handle(GetListPersonnelQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Personnel> personnels = await _personnelRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPersonnelListItemDto> response = _mapper.Map<GetListResponse<GetListPersonnelListItemDto>>(personnels);
            return response;
        }
    }
}