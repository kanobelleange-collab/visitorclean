using visitorclean.Application.Feature.visit.Dto;
using visitorclean.Domain.Entities;
using MediatR;
namespace visitorclean.Application.Feature.visit.Queries.GetVisitById;
public class GetVisitByIdQuery : IRequest<VisitDto?>
{
    public int Id{get;set;}
   
    public GetVisitByIdQuery(int id)
    {
        Id=id;
    }
}
