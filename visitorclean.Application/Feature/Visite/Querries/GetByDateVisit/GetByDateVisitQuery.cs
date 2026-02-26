using visitorclean.Domain.Entities;
using MediatR;
using visitorclean.Application.Feature.Visite.Dtos;
namespace visitorclean.Application.Feature.Visite.Querries.GetByDateVisit;
public record GetByDateVisitQuery : IRequest<VisitDto>
{
    public DateTime Date{get;set;}
    public GetByDateVisitQuery(DateTime date)
    {
        Date = date;
    }
}