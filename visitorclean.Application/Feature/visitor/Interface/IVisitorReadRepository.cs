using System;
using visitorclean.Domain.Entities;
using System.Threading.Tasks;
using visitorclean.Application.Feature.visitor.Queries.Getvisitorwithvisitdto;


namespace visitorclean.Application.Feature.visitor.Interface;
public interface IVisitorReadRepository
{
    Task<List<VisitorWithVisitDto>>GetVisitorWithVisitAsync(CancellationToken cancellationToken);
    Task<List<VisitorWithVisitDto>>GetVisitorByPeriodAsync( DateTime startDate,
            DateTime endDate,
            CancellationToken cancellationToken
        );

}