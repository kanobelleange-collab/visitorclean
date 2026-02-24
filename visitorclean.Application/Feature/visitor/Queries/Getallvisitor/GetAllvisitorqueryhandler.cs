using visitorclean.Domain.Entities;
using MediatR;
using System;
using visitorclean.Application.Interface;
using System.Threading; // INDISPENSABLE pour CancellationToken
using System.Threading.Tasks;
namespace visitorclean.Application.Feature.visitor.Queries;
public class GetAllvisitorqueryHandler:IRequestHandler<GetAllvisitorquery, IEnumerable<Visitor>>
{

    private readonly IVisitorRepository _repo;
    public GetAllvisitorqueryHandler(IVisitorRepository repository){
        _repo=repository;
    }
    public async Task<IEnumerable<Visitor>>Handle(GetAllvisitorquery request ,CancellationToken cancellationToken){
        return await _repo.GetAllAsync();
    }

}
