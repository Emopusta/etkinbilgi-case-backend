using Application.Features.Personnels.Constants;
using Application.Features.Personnels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Personnels.Constants.PersonnelsOperationClaims;
using Microsoft.AspNetCore.Http;
using Application.Features.Users.Rules;
using Application.Services.ImageService;

namespace Application.Features.Personnels.Commands.Create;

public class CreatePersonnelCommand : IRequest<CreatedPersonnelResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Email { get; set; }
    public IFormFile Image { get; set; }

    public string[] Roles => new[] { Admin, Write, PersonnelsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPersonnels";

    public class CreatePersonnelCommandHandler : IRequestHandler<CreatePersonnelCommand, CreatedPersonnelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelRepository _personnelRepository;
        private readonly PersonnelBusinessRules _personnelBusinessRules;
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public CreatePersonnelCommandHandler(IMapper mapper, IPersonnelRepository personnelRepository, PersonnelBusinessRules personnelBusinessRules, IUserRepository userRepository, UserBusinessRules userBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _personnelRepository = personnelRepository;
            _personnelBusinessRules = personnelBusinessRules;
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<CreatedPersonnelResponse> Handle(CreatePersonnelCommand request, CancellationToken cancellationToken)
        {
            Personnel personnel = _mapper.Map<Personnel>(request);

            var requestedUser = await _userRepository.GetAsync(predicate => predicate.Email == request.Email, cancellationToken: cancellationToken);
            await _userBusinessRules.UserShouldBeExistsWhenSelected(requestedUser);

            personnel.UserId = requestedUser.Id;
            personnel.Image = await _imageServiceBase.UploadAsync(request.Image);

            await _personnelRepository.AddAsync(personnel);

            CreatedPersonnelResponse response = _mapper.Map<CreatedPersonnelResponse>(personnel);
            return response;
        }
    }
}