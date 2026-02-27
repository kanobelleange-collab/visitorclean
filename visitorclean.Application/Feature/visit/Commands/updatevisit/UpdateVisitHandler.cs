using MediatR;
using System;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visit.Dto;
using visitorclean.Application.Feature.visit.Interface;
using  visitorclean.Application.Feature.visit.Commands.updatevisit;
using visitorclean.Application.Service.Interface;
using visitorclean.Application.Common;
using visitorclean.Application.Feature.Permission.Interface;
namespace visitorclean.Application.Feature.visit.Commands.updatevisit;
    public class UpdateVisitHandler : IRequestHandler<UpdateVisitCommand, VisitDto?>
    {
         private readonly IVisitRepository  _repository;
         private readonly IMapper _mapper;
         private readonly IPermissionService _permissionService;

        public UpdateVisitHandler(IVisitRepository repository, IMapper mapper,IPermissionService permissionService)
        {
            _repository = repository;
            _mapper = mapper;
            _permissionService=permissionService;
        }

        public async Task<VisitDto?> Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
        {

                var hasPermission = await _permissionService
            .HasPermission(request.UserId, AppPermission.UpdateVisit);

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    

       var visit=_mapper.Map<Visit>(request);
       return await _repository.UpdateAsync(visit);
            
        }
    }