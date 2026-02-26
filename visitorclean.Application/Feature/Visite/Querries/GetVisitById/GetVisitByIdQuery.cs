using visitorclean.Application.Feature.Visite.Dtos;
using visitorclean.Domain.Entities;
using MediatR;
namespace visitorclean.Application.Feature.Visite.Querries.GetVisitById;
public class GetVisitByIdQuery : IRequest<VisitDto?>
{
    public int Id{get;set;}
   
    public GetVisitByIdQuery(int id)
    {
        Id=id;
    }
}
