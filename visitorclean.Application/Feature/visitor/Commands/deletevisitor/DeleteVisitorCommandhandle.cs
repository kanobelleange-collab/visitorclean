using visitorclean.Domain.Entities;
using MediatR;
using System;
using System.Threading.Tasks;
using visitorclean.Application.Interface;

namespace visitorclean.Application.Feature.visitor.Commands.deletevisitor;

public class DeleteVisitorCommandHandler:IRequestHandler<DeleteVisitorCommand , bool>
{
    private readonly IVisitorRepository _repo;

    public DeleteVisitorCommandHandler(IVisitorRepository repo){

        _repo=repo;
        
    }
    public async Task<bool>Handle(DeleteVisitorCommand request ,CancellationToken cancellationToken)
    {
        await _repo.DeleteAsync(request.Id);
        return true;
    }
}