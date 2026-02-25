using MediatR;
using visitorclean.Application.Feature.visitor.Interface;
using System.Threading.Tasks;
using visitorclean.Domain.Entities;
using System.Net;
using visitorclean.Application.Feature.visitor.Commands;
using visitorclean.Application.Feature.visitor.Dto;
using AutoMapper;

namespace visitorclean.Application.Feature.visitor.Commands.updatevisitor;
public class UpdateVisitorCommandHandler:IRequestHandler<UpdateVisitorCommand, VisitorDto>
{
    private readonly IVisitorRepository _repo;
    private readonly IMapper _mapper;
    private readonly IPermissionService _permissionService;

    public UpdateVisitorCommandHandler(IVisitorRepository repo,IMapper mapper,IPermissionService permissionService)
    {
        _repo=repo;
        _mapper=mapper;
        _permissionService=permissionService;
    }

    public async Task<VisitorDto> Handle(UpdateVisitorCommand request ,CancellationToken cancellationToken)
    {
        var hasPermission = await _permissionService
            .HasPermission(request.UserId, Permissions.UpdateVisitor);

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    
  
        var visitor = await _repo.GetByIdAsync(request.Id);

        if (visitor is null)
        throw new Exception($"Visitor avec l'id {request.Id} introuvable");

       
        

        // Mettre à jour le visiteur
        visitor.Update(request.Nom, request.Email, request.Password);

        await _repo.Update(visitor);
        var VisitorDto=_mapper.Map<VisitorDto>(visitor);
        

        return VisitorDto;
    }

    
}
