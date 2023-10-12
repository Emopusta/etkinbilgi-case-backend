using Application.Features.PersonnelDepartments.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.PersonnelDepartments.Constants.PersonnelDepartmentsOperationClaims;

namespace Application.Features.PersonnelDepartments.Queries.GetList;

public class GetListPersonnelDepartmentQuery : IRequest<GetListResponse<GetListPersonnelDepartmentListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListPersonnelDepartments({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetPersonnelDepartments";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPersonnelDepartmentQueryHandler : IRequestHandler<GetListPersonnelDepartmentQuery, GetListResponse<GetListPersonnelDepartmentListItemDto>>
    {
        private readonly IPersonnelDepartmentRepository _personnelDepartmentRepository;
        private readonly IMapper _mapper;

        public GetListPersonnelDepartmentQueryHandler(IPersonnelDepartmentRepository personnelDepartmentRepository, IMapper mapper)
        {
            _personnelDepartmentRepository = personnelDepartmentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPersonnelDepartmentListItemDto>> Handle(GetListPersonnelDepartmentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PersonnelDepartment> personnelDepartments = await _personnelDepartmentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPersonnelDepartmentListItemDto> response = _mapper.Map<GetListResponse<GetListPersonnelDepartmentListItemDto>>(personnelDepartments);
            return response;
        }
    }
}