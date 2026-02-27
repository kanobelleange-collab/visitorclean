using visitorclean.Domain.Entities;
using MediatR;
using visitorclean.Application.Feature.visit.Dto;
namespace visitorclean.Application.Feature.visit.Queries.GetByDateVisit;
public record GetByDateVisitQuery : IRequest<VisitDto>
{
    public DateTime Date{get;set;}
    public GetByDateVisitQuery(DateTime date)
    {
        Date = date;
    }
}