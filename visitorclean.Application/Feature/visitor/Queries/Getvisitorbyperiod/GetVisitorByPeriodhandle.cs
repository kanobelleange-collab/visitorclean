using System;
using System.Threading.Tasks;
using MediatR;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visitor.Queries.Getvisitorbyperiod;
using visitorclean.Application.Interface;
using visitorclean.Application.Feature.visitor.Queries.Getvisitorwithvisitdto;

namespace visitorclean.Application.Feature.visitor.Queries.Getvisitorbyperiod;

public class GetVisitorByPeriodhandler:IRequestHandler<GetVisitorByPeriodQuery, List<VisitorWithVisitDto>>
{
    private readonly IVisitorReadRepository _repo;

    public GetVisitorByPeriodhandler(IVisitorReadRepository repo)
    {
        _repo=repo;
    }
    public async Task <List<VisitorWithVisitDto>>Handle(GetVisitorByPeriodQuery request,CancellationToken cancellationToken)
    {
        return await _repo.GetVisitorByPeriodAsync(
            request.StartDate,
            request.EndDate,
            cancellationToken
        );
    }
}

