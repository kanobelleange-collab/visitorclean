using MediatR;
using visitorclean.Application.Feature.visitor.Commands;
using System.Threading.Tasks;
using visitorclean.Application.Interface;
using visitorclean.Application.Feature.visitor.Queries.GetByidvisitor;
using visitorclean.Domain.Entities;

namespace visitorclean.Application.Feature.visitor.Queries.GetByidvisitor;
public class GetByIdVisitorqueryHandler:IRequestHandler<GetByIdVisitorquery, Visitor>
{
    private readonly IVisitorRepository _repo;

    public GetByIdVisitorqueryHandler(IVisitorRepository repo)
    {
        _repo=repo;
    }
    public async Task<Visitor>Handle(GetByIdVisitorquery request ,CancellationToken cancellationToken)
    {
      var visitor= await _repo.GetByIdAsync( request.Id);
      if (visitor ==null)
         throw new Exception($"visitor avec l'id {request.Id} est introuvable");
        return visitor;
    }
    
        
    
}