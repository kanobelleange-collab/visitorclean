using MediatR;
using visitorclean.Domain.Entities;
using System;
using System.Threading.Tasks;
using visitorclean.Application.Feature.visitor.Queries.Getvisitorwithvisitdto;
using visitorclean.Application.Interface;

namespace visitorclean.Application.Feature.visitor.Queries.Getvisitorwithvisitdto;

public sealed class GetVisitorWithVisitDtohandler:IRequestHandler<GetVisitorWithVisitDtoquery, List<VisitorWithVisitDto>>
{
    private readonly IVisitorReadRepository _repo;

    public GetVisitorWithVisitDtohandler(IVisitorReadRepository repo)
    {
        _repo=repo;
    }
    public async Task <List<VisitorWithVisitDto>>Handle(GetVisitorWithVisitDtoquery request,CancellationToken cancellationToken)
    {
        return await _repo.GetVisitorWithVisitAsync(cancellationToken);
    }

}