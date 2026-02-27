using MediatR;
using System;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using visitorclean.Application.Feature.visit.Dto;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visit.Interface;
using  visitorclean.Application.Feature.visit.Commands.createvisit;
using visitorclean.Application.Common;
using visitorclean.Application.Service.Interface;
namespace visitorclean.Application.Feauture.visit.Commands.createvisit;

    public class CreateVisitHandler : IRequestHandler<CreateVisitCommand, VisitDto>
    {
         private readonly IVisitRepository  _repository;
         private readonly IMapper _mapper;
         private readonly IPermissionService _permissionService;

        public CreateVisitHandler(IVisitRepository repository, IMapper mapper,IPermissionService permissionService)
        {
            _repository = repository;
            _mapper = mapper;

            _permissionService=permissionService;
        }

        public async Task<VisitDto> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
        {
             var hasPermission = await _permissionService
            .HasPermission(request.UserId, AppPermission.CreateVisit);

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    

            var visit= _mapper.Map<Visit>(request);
             await _repository.AddAsync(visit);
             return _mapper.Map<VisitDto>(visit);
            
        }
    }