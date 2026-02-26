using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visit.Dto;
using MediatR;
using AutoMapper;
using visitorclean.Application.Feature.visit.Commands.updatevisit;
using System.Net;
using visitorclean.Application.Feature.visit.Interface;
using visitorclean.Application.Service.Interface;
using visitorclean.Application.Common;

namespace visitorclean.Application.Feature.visit.Commands.updatevisit;

public class UpdateVisitCommandHandler:IRequestHandler<UpdateVisitCommand, VisitDto>
{
    private readonly IVisitRepository _repo;
    private readonly IMapper _mapper;
    private readonly IPermissionService _permissionService;

    public UpdateVisitCommandHandler(IVisitRepository  repo,IMapper mapper,IPermissionService permissionService)
    {
        _repo=repo;
        _mapper=mapper;
        _permissionService=permissionService;
    }
    public async Task<VisitDto> Handle(UpdateVisitCommand request ,CancellationToken cancellationToken)
    {
        var hasPermission = await _permissionService
            .HasPermission(request.UserId, AppPermission.UpdateVisit);

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    
    
        var visit= await _repo.GetByIdAsync(request.Id);
         if (visit == null)
        return null; // signal qu’on ne trouve pas

    // Mise à jour automatique
        visit.Update(request.motif,request.datevisit,request.Service_A_Visiter);
        visit.idVisitor = request.idVisitor;

         await _repo.Update(visit);
//mapper dto pou retourner api
        var VisitDto=_mapper.Map<VisitDto>(visit);
        return VisitDto;

        
    }
}