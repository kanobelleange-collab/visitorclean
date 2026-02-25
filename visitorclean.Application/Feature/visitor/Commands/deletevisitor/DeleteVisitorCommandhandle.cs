using visitorclean.Domain.Entities;
using MediatR;
using System;
using System.Threading.Tasks;
using visitorclean.Application.Feature.visitor.Interface;

namespace visitorclean.Application.Feature.visitor.Commands.deletevisitor;

public class DeleteVisitorCommandHandler:IRequestHandler<DeleteVisitorCommand , bool>
{
    private readonly IVisitorRepository _repo;
    private readonly IPermissionService _permissionService;

    public DeleteVisitorCommandHandler(IVisitorRepository repo,IPermissionService permissionService){

        _repo=repo;
        _permissionService=permissionService;
        
    }

    public async Task<bool> Handle(DeleteVisitorCommand request ,CancellationToken cancellationToken)
    {
        var hasPermission = await _permissionService
            .HasPermission(request.UserId, Permissions.DeleteVisitor);

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    
    
        await _repo.DeleteAsync(request.Id);
        return true;
    }
}